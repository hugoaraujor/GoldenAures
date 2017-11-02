using AurumBusiness.Controllers;
using AurumData;
using AurumDataEntities;
using System;
using System.Windows.Forms;
using AurumRest;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using FiscalPrinterBematech;
namespace AurumRest
{

	public partial class TotalForm : Form
	{
		public bool percentEdited = false;
		public bool totalEdited = false;
		public BackgroundWorker workerObject = new BackgroundWorker();
		private ClienteManager CMngr = new ClienteManager();
		private Global g = new Global();
		public TotalapagarView TotalesPago;
        public int ipago = 0;
		public int impresoraconectada = 0;
		public List<Cliente> inicialQuery = new List<Cliente>();

		public TotalForm(Mesa mesa,Decimal paymentAmount,Decimal exento, Ivatipo G)
		{
			InitializeComponent();
			//getPaymentParams(paymentAmount, G);

			TotalesPago = new TotalapagarView();
			TotalesPago.mesa=mesa;
			TotalesPago.totalNeto = paymentAmount;
			TotalesPago.servicio = exento;

			calculaValores(G);
			//calculaValores(Ivatipo.Reducido);
			displaytotales();
			workerObject.DoWork += new DoWorkEventHandler(WorkerObject_DoWork);
			workerObject.RunWorkerCompleted += WorkerObject_RunWorkerCompleted;
		}
		
		public void calculaValores(Ivatipo iva, Decimal descuento = 0)
		{
			var ivap = g.secuencia.getIva(iva);
			var ivag = g.secuencia.getIva(Ivatipo.General);

			TotalesPago.IvaPercent = Convert.ToDecimal(ivap);
			TotalesPago.totalNeto = (TotalesPago.totalNeto);
			TotalesPago.descuento = descuento;
			TotalesPago.totalIva = Math.Round((TotalesPago.totalNeto- TotalesPago.descuento) * (TotalesPago.IvaPercent / 100), 2);
			TotalesPago.total = Math.Round((((TotalesPago.totalNeto - TotalesPago.descuento)  * ((TotalesPago.IvaPercent / 100) + 1))+ TotalesPago.servicio), 2) ;
			TotalesPago.resta = TotalesPago.total - pagado();
			TotalesPago.currentIva = iva;
			TotalesPago.Cambio = 0;
		}

		public void AgregaMododePago(string tipo, Decimal d, String Detalle = "", int i = 0)
		{

			PagoCtrl detPago = new PagoCtrl(this);
			var aux = Enum.TryParse(tipo, out ClasePago myStatus);
			detPago.SetValues(new MontoPago { ClasePago = myStatus, Monto = d, Tipo = "", Detalle = Detalle, Index = i , Cambio=Math.Abs(pagado()-d)});
			labelResta.Text = string.Format("{0:0.00}", d);
			detPago.Name = detPago.Name + i.ToString();
			detPago.button2.Click += new EventHandler(Agrega);
			PanelPago.Controls.Add(detPago);
		}
		public void AgregaPago(MontoPago pago)
		{
			ipago = TotalesPago.ListaPagos.Count() + 1;
			TotalesPago.ListaPagos.Add(new PagoView { clase = pago.ClasePago.ToString(), detalle = pago.Detalle, montopago = pago.Monto,cambio=pago.Cambio });
			TotalesPago.pagado = pagado();
			TotalesPago.resta = TotalesPago.total - TotalesPago.pagado;

			if (TotalesPago.resta > 0)
			{
				labelResta.Text = string.Format("{0:0.00}", TotalesPago.resta);
				label16.Text = string.Format("{0:0.00}", pagado());
				AgregaMododePago(pago.ClasePago.ToString(), TotalesPago.resta, pago.Detalle, ipago);
			}
		}
		public void Agrega(object sender, EventArgs e)
		{

			if (TotalesPago.resta <= 0.03M)
			{
				
				pictureBox1.Visible = true;
				label15.ForeColor = Color.DodgerBlue;
				labelResta.ForeColor = Color.DodgerBlue;
				label15.Text = "CAMBIO:";
				timer1.Enabled = true;
				button3.Enabled = true;
				button3.Focus();
				//PanelPago.Enabled = false;
			}
			else
			{
				label15.ForeColor = Color.Black;
				label15.Text = "A Pagar:";
				labelResta.ForeColor = Color.Black;
			}
			labelResta.Text = string.Format("{0:0.00}", Math.Abs(TotalesPago.resta));
			label16.Text = string.Format("{0:0.00}", pagado());
			
		}

		private decimal pagado()
		{
			decimal sumaCtrls = 0;
			foreach (PagoView p in TotalesPago.ListaPagos)
			{
				sumaCtrls = sumaCtrls + p.montopago;
			}

			return sumaCtrls;

		}
		public bool hayEfectivo()
		{
			bool hay = false;
			foreach (PagoView p in TotalesPago.ListaPagos)
			{
				if (p.clase == ClasePago.Efectivo.ToString() && (!(hay)))
				{ hay = true; }
			}
			return hay;
		}
		private void TotalForm_Load(object sender, EventArgs e)
		{
			displaytotales();
		}
		public void displaytotales()
		{
			textoBoxp1.Text = string.Format("{0:0.00}", TotalesPago.totalNeto);
			textoBoxp4.Text = string.Format("{0:0}", TotalesPago.IvaPercent);
			textoBoxp2.Text = string.Format("{0:0.00}", TotalesPago.totalIva);
			textoBoxp3.Text = string.Format("{0:0.00}", TotalesPago.servicio);
			txtTotalPagar.Text = string.Format("{0:0.00}", TotalesPago.total);
		}
		#region Keys
		private void agregaNuevoCliente()
		{

			inicializa();
			TxtNombre.Focus();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			groupBox2.Enabled = true;
			TxtNombre.Focus();
		}
		private void TxtNombre_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Back)
			{
				txtCedula.Focus();
			}
		}
		#endregion
		private void inicializa()
		{
			TxtNombre.Text = "";
			TxtDireccion.Text = "";
			TxtTelefono.Text = "";
		}
		private void muestraCliente(Cliente query)
		{
			if (!(query == null))
			{
				TxtNombre.Text = query.Nombre;
				TxtDireccion.Text = query.Direccion;
				TxtTelefono.Text = query.Telefono;
				//groupBox2.Enabled = false;
			}
		}
		private void editCliente()
		{
			if (TotalesPago.cliente == null)
			{
				txtCedula.Focus();
				return;
			}
			var query = TotalesPago.cliente;
			var cedula = TotalesPago.cliente.Identificacion;
			if (TotalesPago.cliente != null)
			{ CMngr.Edit(new ClienteDTO { Idcliente = query.Idcliente, Identificacion = cedula, Nombre = TxtNombre.Text, Direccion = TxtDireccion.Text, Telefono = TxtTelefono.Text, Credito = false, Debito = false }); }
			else
			{ CMngr.Insert(new ClienteDTO { Identificacion = cedula, Nombre = TxtNombre.Text, Direccion = TxtDireccion.Text, Telefono = TxtTelefono.Text, Credito = false, Debito = false }); }
		}
		private void button2_Click(object sender, EventArgs e)
		{
			editCliente();
			panel1.SendToBack();
			if (ipago == 0)
			{
				AgregaMododePago(ClasePago.Efectivo.ToString(), TotalesPago.resta, "", ipago);
			}
			
		}
		
		private void timer1_Tick(object sender, EventArgs e)
		{
			label15.Visible = !label15.Visible;
			labelResta.Visible = !labelResta.Visible;
		}
		private void button3_Click(object sender, EventArgs e)
		{
			pictureBox1.Visible = false; timer1.Enabled = false;
		}
		private void button3_Click_1(object sender, EventArgs e)
		{
			 //impresoraconectada=BemaFI32.Bematech_FI_VerificaImpresoraPrendida();
			 this.Close();
			  


		}
		private void label9_Click(object sender, EventArgs e)
		{
			panel2.SendToBack();
		}
		private void txtCedula_TextChanged(object sender, EventArgs e)
		{
			if (txtCedula.Text.Length == 4)
			{
				inicialQuery = CMngr.getPrimeros(txtCedula.Text);
			}
		}
		private void txtCedula_Leave(object sender, EventArgs e)
		{
			if (comboBox2.Text == "")
			{
				comboBox2.Focus();
				return;
			}
			if (txtCedula.Text == "")
			{
				txtCedula.Focus();
				return;
			}

			TotalesPago.cliente = new Cliente();
			TotalesPago.cliente.Identificacion = comboBox2.Text + txtCedula.Text;
			workerObject.RunWorkerAsync();

		}
		private void WorkerObject_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (this.TotalesPago.cliente.Nombre == null)
			{
				inicializa();
				label8.Visible = true;
			}
			else
			{
				label8.Visible = false;
				muestraCliente(this.TotalesPago.cliente);
			}
		}
		private void WorkerObject_DoWork(object sender, DoWorkEventArgs e)
		{
			ClienteManager Cmngr = new ClienteManager();
			var cliente = Cmngr.existeCedula((string)this.TotalesPago.cliente.Identificacion);
			if (cliente != null)
			{
				this.TotalesPago.cliente = cliente;
				TotalesPago.cliente = cliente;
				e.Result = true;
			}
			else
				e.Result = false;
		
		}
		private void txtCedula_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				muestraCliente(TotalesPago.cliente);
			}
			if (e.KeyCode == Keys.F10)
			{
				txtDescuento.Enabled = true;
				txtDescuento.Focus();
			}
		}
		private void txtDescuento_Leave(object sender, EventArgs e)
		{
			var subtotal = Convert.ToDecimal(TotalesPago.totalNeto);
			var p = (Convert.ToDecimal(txtDescuento.Text) / subtotal) * 100;//txtDescuento.Text.Replace("%", "")/ subtotal,1);
			labelPercent.Text =  string.Format("{0:00.0}",Math.Round( p,1));
			calculaValores(TotalesPago.currentIva, Convert.ToDecimal(txtDescuento.Text));
					displaytotales();
		}
		private void TxtTelefono_Leave(object sender, EventArgs e)
		{
			editCliente();
		}
		
		private void textoBoxp5_TextChanged(object sender, EventArgs e)
		{
					totalEdited = true;

			if (this.txtDescuento.Text == "-")
			{
				DescuentoDialog dd = new DescuentoDialog(TotalesPago);
				dd.ShowDialog();
				if (dd.DialogResult != DialogResult.No)
				{
					txtDescuento.Text =dd.valor;
				}
			}
			
		}
		private void textoBoxp6_TextChanged(object sender, EventArgs e)
		{
			percentEdited = true;
		}

	
		
	}

}
