using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AurumData;
using AurumBusiness.Controllers;
using AurumDataEntity;
using System.ComponentModel;
using System.Threading;
using FiscalPrinterBematech;
using System.Linq;
namespace AurumRest
{
	public partial class Botonera : UserControl
	{
		MesasManager mesasM = new MesasManager();
		public BackgroundWorker workerObj = new BackgroundWorker();
		private TicketDetalleManager TicketManager = new TicketDetalleManager();
		ProductoManager prodMan = new ProductoManager();
		public event EventHandler UserControlButtonClicked;
		public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
		private List<ListaDTO> Opciones = new List<ListaDTO>();
		private List<ListaDTO> SubOpciones = new List<ListaDTO>();
		private Categoria category = new Categoria();
		private Producto Producto = new Producto();
		List<int> Borrados = new List<int>();
		public ProcTicket TicketDoc = new ProcTicket();
		public int CurrentTicket = 0;
		public Mesa CurrentMesa=new Mesa();
		public int level = 0;
		public int selection = 0;
		private int CurrentTicketNro = 0;
		private Punto padre = new Punto();
		Global g=new Global();
		DiagramaMesas Diagrama = null;
		private void OnUserControlButtonClick()
		{
			if (UserControlButtonClicked != null)
			{
				UserControlButtonClicked(this, EventArgs.Empty);
			}
		}
		protected void TheButton_Click(object sender, EventArgs e)
		{
			OnUserControlButtonClick();
		}
		public Botonera()
		{
			//
		}
		public Botonera(DiagramaMesas diagrama,List<ListaDTO> lista, List<ListaDTO> subopcion, int valor, int level = 0)
		{
			InitializeComponent();
			Diagrama = diagrama;
			CurrentTicketNro = g.store.getTicket();
			label4.Text = CurrentMesa.Siglas;
			TicketDoc.ticketNro = CurrentTicketNro;
			labelticket.Text = CurrentTicketNro.ToString();
			var s = new Mesa();
			s.Siglas = "0";
			g.SetMesa(s);
			Opciones = lista;
			SubOpciones = subopcion;
			displayOpciones(lista, false);
			//CurrentMesa = g.currMesa.Siglas;
			TicketDoc.totales.mesa = s;
			CurrentTicketNro = g.store.getTicket();
			label4.Text = CurrentMesa.Siglas;
			workerObj.DoWork += new DoWorkEventHandler(WorkerObj_DoWork);
			workerObj.RunWorkerCompleted += WorkerObj_RunWorkerCompleted;

		}




		private void displayOpciones(List<ListaDTO> lista, bool subopcion = false)
		{
			this.FlowPanel.Controls.Clear();
			Control control = null;
			int i = 0;
			while (i <= lista.Count - 1)
			{
				control = new Button();
				var size = new Size();
				size.Height = 82;
				size.Width = 138;
				control.Size = size;
				control.Text = lista[i].descriptor;
				control.Tag = lista[i].index;
				control.Click += new EventHandler(OnClickButton);
				control.BackColor = Color.Aquamarine;
				control.BackgroundImageLayout = ImageLayout.Zoom;
				control.ForeColor = g.store.getFont().color;
				control.Font = new Font(g.store.getFont().Familia, g.store.getFont().Tamaño);

				if (lista[i].file != null)
				{
					if (lista[i].file != "")
						control.BackgroundImage = Image.FromFile(lista[i].file);
				}
				this.FlowPanel.Controls.Add(control);
				i++;
			}
		}
		void OnClickButton(object sender, EventArgs e)
		{
			selection = Convert.ToInt16(((Button)sender).Tag);
			SubOpciones = prodMan.GetProductos(selection, true);
			level++;
			var Ivastr = new Iva().getIvaString('G');
			if (level >= 2)
			{
				level = 1;
				Producto = prodMan.GetProducto(selection);
				TicketDetalle item = new TicketDetalle()
				{
					Id = 0,
					IdProducto = Producto.IdProducto,
					Nombre = Producto.Nombre,
					Codigoproducto = Producto.Codigo,
					Cant = 1,
					Cuenta=(int)this.cuenta.Value,
					Factura = "",
					Nota = "",
					Neto = Producto.PrecioNeto,
					Monto = Producto.PrecioNeto * 1,
					Mesa = CurrentMesa.Siglas,
					Ticket = CurrentTicketNro,
					Notas = "",
					Adicionales = "",
					Iva = Convert.ToDecimal(Ivastr) / 100,
					Montoiva = Producto.PrecioNeto * Convert.ToDecimal(Ivastr) / 100
				};
				TicketDoc.lista.Add(item);
				refreshView();
				iralUltimoRegistro();
				if (MainFrm.defaultValues.Regresa)
				{
					level--;
					this.displayOpciones(Opciones, false);
				}
			}
			else
			{
				this.displayOpciones(SubOpciones, false);
			}

		}
		//Refresh Datagrid
		private void refreshView()
		{
		
			this.dataGridView1.DataSource = null;
			this.dataGridView1.DataSource = TicketDoc.lista;
			if (TicketDoc.totales.mesa.Siglas != "0")
			{
				txtservicio.Text = String.Format("{0:0.00}", GetSuma() * .10m);
			}
			labelNeto.Text = String.Format("{0:0.00}", GetSuma());
			DataGridLayout();

		}
		//Datagrid Visual Format
		private void DataGridLayout()
		{
			Utilities.DataGridLayout(this.dataGridView1);
		}
		private Decimal GetSuma()
		{
			Decimal suma = 0;
			if (TicketDoc.lista.Count > 0)
			{
				foreach (TicketDetalle d in TicketDoc.lista)
				{
					suma = suma + (d.Cant * d.Monto);
				}
			}
			else
			{ suma = 0; }

			return suma;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			level--;
			if (level < 0)
				level = 0;
			displayOpciones(Opciones, false);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			level++;
			displayOpciones(SubOpciones, true);
		}
		public void Carga(string mesa, int ticket)
		{
			TicketDoc.lista = TicketManager.GetList(mesa);
			if (TicketDoc.lista.Count > 0)
			{
				this.dataGridView1.DataSource = TicketDoc.lista;
				iralUltimoRegistro();
			}
			refreshView();
		}

		private void iralUltimoRegistro()
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				dataGridView1.SelectedRows[0].Selected = false;
				dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
				dataGridView1.Rows[this.dataGridView1.RowCount - 1].Selected = true;
			}
		}
		private void button7_Click(object sender, EventArgs e)
		{
			var esta = ordenvacia();
			if (CurrentMesa.Siglas == "0" && !esta)
				return;

			Nohaypedido();
			grabaItemsCompra();
			eliminarBorrados();
			TicketDoc.lista.Clear();
			GetSuma();
			nuevoTicket();
			labelticket.Text = CurrentTicketNro.ToString();
			dataGridView1.DataSource = null;
			dataGridView1.Refresh();
			refreshView();
			this.SendToBack();
		}

		private void grabaItemsCompra()
		{
			int n = 0;
			foreach (TicketDetalle t in TicketDoc.lista)
			{
				if (t.Id > 0)
				{ TicketManager.Edit(t); }
				else
				{
					n = TicketManager.Add(t);
					t.Id = n;
				}
			}
		}

		private void nuevoTicket()
		{
			g.store.SaveTicket(g.store.newTicket());
			CurrentTicketNro = g.store.getTicket();

		}

		private void Nohaypedido()
		{
			if (CurrentMesa.Siglas == "0")
				return;

			if ((CurrentMesa.Siglas != "0") && !(TicketManager.tienePedidos(CurrentMesa.Siglas)) && ordenvacia())
			{
				DesocuparMesa(TicketDoc.totales.mesa);
			}

			
		}

		private void eliminarBorrados()
		{
			if (Borrados.Count>=0) return;
			foreach (int n in Borrados)
			{
				TicketManager.Delete(n);
			}
			Borrados.Clear();
		}
		private void button3_Click(object sender, EventArgs e)
		{
			ChangeQty(typeQty.plus);
		}
		public enum typeQty
		{
			plus,
			minus
		}
		public void ChangeQty(typeQty operation)
		{
			var cant = TicketDoc.lista[dataGridView1.SelectedRows[0].Index].Cant;
			if (dataGridView1.SelectedRows.Count > 0 && cant <= 999)
			{
				if (operation == typeQty.minus)
				{ if (cant > 1) TicketDoc.lista[dataGridView1.SelectedRows[0].Index].Cant--; }

				else
				{
					TicketDoc.lista[dataGridView1.SelectedRows[0].Index].Cant++;

				}
				TicketDoc.lista[dataGridView1.SelectedRows[0].Index].Monto = TicketDoc.lista[dataGridView1.SelectedRows[0].Index].Cant * TicketDoc.lista[dataGridView1.SelectedRows[0].Index].Neto;
			}
			refreshView();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			ChangeQty(typeQty.minus);
		}
		private void button5_Click(object sender, EventArgs e)
		{
			TicketDoc.lista.Clear();
			refreshView();

		}
		private void button6_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if (TicketDoc.lista[dataGridView1.SelectedRows[0].Index].Id != 0)
					Borrados.Add(TicketDoc.lista[dataGridView1.SelectedRows[0].Index].Id);
				TicketDoc.lista.RemoveAt(dataGridView1.SelectedRows[0].Index);
				refreshView();
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (TicketDoc.totales.mesa.Siglas != "0" )
			{
				grabaItemsCompra();
				TicketDoc.lista = TicketManager.GetList(TicketDoc.totales.mesa.Siglas);
				GetSuma();
				refreshView();
			}
			if (TicketDoc.totales.mesa.Siglas != "0" || TicketDoc.totales.mesa.Siglas.Contains("LL"))
				{ TicketDoc.totales.servicio = calcularservicio();
			 	}
		
			var paga=GetSuma();
			eliminarBorrados();

			IPrinterFIOperaciones IP = new ImpresionBematech();
			if (IP.estaConectada()==0)
			{
				MessageBox.Show("Impresora No Conectada");
				return;
			}
			TotalForm TF = new TotalForm(TicketDoc.totales.mesa ,paga, TicketDoc.totales.servicio, Ivatipo.General);
			TF.impresoraconectada = 0;
			TF.ShowDialog();
			TicketDoc.totales = TF.TotalesPago;
		
			if (TF.TotalesPago.resta <= 0.03M && TF.impresoraconectada==1)
			{// cambiar el printer antes de llamar operacion para trabajar con otro printer ppoe ejemplo
			 //	IPrinterFIOperaciones IP = new ImpresionBixolon();
			 //Doble Abstract Factory Printer y Documento
			 //workerObj.RunWorkerAsync();
				auxilio();
			
			}
			
			TF.Dispose();
			TF = null;
		}

		private decimal calcularservicio()
		{
			var suma = GetSuma()*.10M;
			return suma;
		}

		private void auxilio()
		{
			IPrinterFIOperaciones IP = new ImpresionBematech();
			var st = IP.Facturar(TicketDoc);
			TicketDoc.totales.factura = st;
			
			if (!(st == ""))
			{
				
				Console.WriteLine(st);
				DocumentManager DocM = new DocumentManager(TicketDoc);
				DocM.Guardar(st);
				if (st != "")
				{
					actualiza();
				}
			}
			else
			{
				 IP.isAnulada();
			}
			g.store.SaveFactura(st);
			nuevoTicket();
		}
		private void ResetFormValues()
		{
			//TicketDoc.totales = new TotalapagarView();
			TicketDoc.totales.pagado=0;
			TicketDoc.totales.resta = 0;
			TicketDoc.totales.descuento = 0;
			TicketDoc.lista.Clear();
			TicketDoc.totales.currentIva = Ivatipo.General;
			TicketDoc.totales.cliente = new Cliente();
			TicketDoc.totales.IvaPercent = 0;
			//TicketDoc = new ProcTicket();
			dataGridView1.DataSource = null;
			dataGridView1.Rows.Clear();
			label4.Text = "0";
			dataGridView1.Refresh();
			TicketDoc.totales.mesa = new Mesa();
			g.currMesa = TicketDoc.totales.mesa;
			
			if (g.store.regresaapunto() == 1)
			{
				Diagrama.MuestraMesas();
				Diagrama.Cambia();
				this.SendToBack();
			}

		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void button9_Click_1(object sender, EventArgs e)
		{
			if (CurrentMesa.Siglas == "0" && ordenvacia())
				return;
			Diagrama.Cambia();
			this.SendToBack();
		}

		private bool ordenvacia()
		{
			bool resp = true;
			if (this.dataGridView1.Rows.Count >0)
				resp = false;

			return resp;
		}

		public void Cambia(Mesa mesaSelected)
		{
			CurrentMesa = mesaSelected;
			var dMesas = Diagrama;
			this.label4.Text = dMesas.GetMesa().Siglas;
			TicketDoc.totales.mesa = CurrentMesa;
			TicketDoc.totales.mesa.Siglas=label4.Text;
			if (CurrentMesa.MultiplesCuentas)
			{
				cuenta.Visible = true;
			}
			else
			{
				cuenta.Visible = false;
			}
			labelticket.Text = CurrentTicketNro.ToString();
			if (dMesas.totaliza)
			{

				//TicketDoc.totales.mesa = TicketDoc.totales.mesa;
				TicketDoc.lista = TicketManager.GetList(dMesas.GetMesa().Siglas, 0);
				refreshView();

			}
		}
		public void Close(Mesa lamesas)
		{
			Carga(lamesas.Siglas, 0);

		}
		public void DesocuparMesa(Mesa lamesa)
		{
			var mesa2 = mesasM.GetMesa(TicketDoc.totales.mesa.Siglas);
			TicketDoc.totales.mesa.Idmesa = mesa2.Idmesa;
			TicketDoc.totales.mesa.Ocupada = false;
			TicketDoc.totales.mesa.Estado=EstadosMesa.Disponible;
			mesasM.Edit(TicketDoc.totales.mesa);
			Diagrama.MuestraMesas();
		}

		private void WorkerObj_DoWork(object sender, DoWorkEventArgs e)
		{
			IPrinterFIOperaciones IP = new ImpresionBematech();

			
			int ACK = 0;
			int ST1 = 0;
			int ST2 = 0;
						
			var st = IP.Facturar(TicketDoc);
				TicketDoc.totales.factura = st;
				e.Result = st;
			 
			
		}
		private void WorkerObj_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			DocumentManager DocM = new DocumentManager(TicketDoc);
			if (!(e.Result.ToString() == ""))
			{
				g.store.SaveFactura(e.Result.ToString());
				Console.WriteLine(e.Result.ToString());

				DocM.Guardar(e.Result.ToString());
				if (e.Result.ToString() != "")
				{
					actualiza();
				}
			}
		
		}
		private void actualiza()
		{
			Console.WriteLine("actualiza");
			if (TicketDoc.totales.mesa.Siglas != "0")
			{
				TicketDetalleManager TMngr = new TicketDetalleManager();
				TMngr.Delete(TicketDoc.totales.mesa.Siglas);
				DesocuparMesa(TicketDoc.totales.mesa);
			}
			
			ResetFormValues();
			refreshView();
		}

		private void button10_Click(object sender, EventArgs e)
		{
			var NumeroDoc = "       ";
			int iretorno = BemaFI32.Bematech_FI_NumeroComprobanteFiscal(ref NumeroDoc);
			var fm = new FacturasManager();
			BemaFI32.Bematech_FI_AnulaCupon();
			using (var db = new Data())
			{
				var pac = (from p in db.Facturas where p.Facturanro == "000001" select p).FirstOrDefault();
				
			}
			MesonerosManager MCtrller = new MesonerosManager();
			var aux= new Mesonero();
			aux.Idmesonero = 2;
			var atiende = MCtrller.getMesero((int)aux.Idmesonero).Nombre;
		}
	}


}
