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
		public string CurrentMesa = "0";
		public int level = 0;
		public int selection = 0;
		private int CurrentTicketNro = 0;
		private Punto padre = new Punto();
		private Global g = new Global();
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
			CurrentMesa = "0";
			CurrentTicketNro = g.secuencia.getTicket();
			label4.Text = CurrentMesa;
			TicketDoc.ticketNro = CurrentTicketNro;
			labelticket.Text = CurrentTicketNro.ToString();
			var s = new Mesa();
			s.Siglas = "0";
			g.SetMesa(s);
			Opciones = lista;
			SubOpciones = subopcion;
			displayOpciones(lista, false);
			CurrentMesa = g.currMesa.Siglas;
			TicketDoc.totales.mesa = s;
			CurrentTicketNro = g.secuencia.getTicket();
			label4.Text = CurrentMesa;
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
				control.ForeColor = g.secuencia.getFont().color;
				control.Font = new Font(g.secuencia.getFont().Familia, g.secuencia.getFont().Tamaño);

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
					Factura = "",
					Nota = "",
					Neto = Producto.PrecioNeto,
					Monto = Producto.PrecioNeto * 1,
					Mesa = CurrentMesa,
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
			label1.Text = String.Format("{0:0.00}", GetSuma());
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

			if (CurrentMesa == "0" && !ordenvacia())
				return;

			Nohaypedido();
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
			eliminarBorrados();
			TicketDoc.lista.Clear();
			GetSuma();

			g.secuencia.SaveTicket(g.secuencia.newTicket());
			CurrentTicketNro = g.secuencia.getTicket();
			labelticket.Text = CurrentTicketNro.ToString();
			dataGridView1.DataSource = null;
			dataGridView1.Refresh();
			this.SendToBack();
		}

		private void Nohaypedido()
		{
			if (CurrentMesa == "0")
				return;

			if ((CurrentMesa != "0") && !(TicketManager.tienePedidos(CurrentMesa)))
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
			

			eliminarBorrados();
			
			TotalForm TF = new TotalForm(TicketDoc.totales.mesa ,GetSuma(), Ivatipo.General);
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
			else
			{
				if(TF.impresoraconectada == 0)
				MessageBox.Show("La Impresora está apagada o Desconectada.");

			}
			TF.Dispose();
		}
		private void auxilio()
		{
			IPrinterFIOperaciones IP = new ImpresionBematech();
			var st = IP.Facturar(TicketDoc);
			TicketDoc.totales.factura = st;
			DocumentManager DocM = new DocumentManager(TicketDoc);
			if (!(st == ""))
			{
				g.secuencia.SaveFactura(st);
				Console.WriteLine(st);

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
		}
		private void ResetFormValues()
		{
			var temp = this.TicketDoc.totales;
			temp.pagado = 0;
			temp.resta = 0;
			temp.descuento = 0;
			TicketDoc.lista.Clear();
			temp.cliente = new Cliente();
			temp.currentIva = Ivatipo.General;
			temp.IvaPercent = 0;
			dataGridView1.DataSource = null;
			dataGridView1.Rows.Clear();
			label4.Text = "0";
			dataGridView1.Refresh();
			g.currMesa = new Mesa();
			if (g.secuencia.regresaapunto() == 1)
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
			if (CurrentMesa == "0" && ordenvacia())
				return;
			Diagrama.Cambia();
			this.SendToBack();
		}

		private bool ordenvacia()
		{
			bool resp = false;
			if (this.dataGridView1.Rows.Count <=0)
				resp = true;

			return resp;
		}

		public void Cambia()
		{
			var dMesas = Diagrama;
			CurrentMesa = dMesas.GetMesa();
			this.label4.Text = dMesas.GetMesa();
			TicketDoc.totales.mesa.Siglas=label4.Text;
			labelticket.Text = CurrentTicketNro.ToString();
			if (dMesas.totaliza)
			{

				TicketDoc.totales.mesa = mesasM.GetMesa(TicketDoc.totales.mesa.Siglas);
				TicketDoc.lista = TicketManager.GetList(dMesas.GetMesa(), 0);
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
            TicketDoc.totales.mesa = mesa2;
			TicketDoc.totales.mesa.Ocupada = false;
			TicketDoc.totales.mesa.Idocupante = 0;
			TicketDoc.totales.mesa.Estado = EstadosMesa.Cerrada;
			mesasM.Edit(TicketDoc.totales.mesa);
			TicketDoc.totales.mesa = new Mesa();
			TicketDoc.totales.mesa.Hora = default(DateTime);
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
				g.secuencia.SaveFactura(e.Result.ToString());
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
			//string nrosigultfactura = "995555";
			//FacturasManager fm = new FacturasManager();
			//fm.Insert(new AurumDataEntity.FacturaDTO { Anulada = true, ClienteID = 0, Montoneto = 0, Descuento = 0, Total = 0, Tasa = 0, Equipo = Global.Instancia.equipo, Caja = "", Facturanro = nrosigultfactura, Mesa = "0", Moneda = "", Serial = Global.Instancia.GetParametros().Serial, Sirve = 0, Userid = 0, Nota = "" });
			//fm.Insert(new AurumDataEntity.FacturaDTO { Anulada = true, ClienteID = 0, Montoneto = 0, Descuento = 0, Total = 0, Tasa = 0, Equipo = Global.Instancia.equipo, Caja = "", Facturanro = nrosigultfactura, Mesa = "0", Moneda = "", Serial = Global.Instancia.GetParametros().Serial, Sirve = 0, Userid = 0, Nota = "" });
			BemaFI32.Bematech_FI_InformeTransacciones("","31/10/2017","31/10/2017","");
			BemaFI32.Bematech_FI_AnulaCupon();
		//	IPrinterFIOperaciones IP = new ImpresionBematech();
			//IP.EmiteNotadeCredito("000002");
		}
	}


}
