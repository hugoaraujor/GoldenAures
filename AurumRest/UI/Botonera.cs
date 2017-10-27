using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AurumData;
using AurumBusiness.Controllers;
using AurumDataEntity;

namespace AurumRest
{
	public partial class Botonera : UserControl
	{
		ProductoManager prodMan = new ProductoManager();
		public event EventHandler UserControlButtonClicked;
		public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
		public List<ListaDTO> Opciones = new List<ListaDTO>();
		public List<ListaDTO> SubOpciones = new List<ListaDTO>();
		public Categoria category = new Categoria();
		public Producto Producto = new Producto();
		public List<TicketDetalle> ListaDetalle = new List<TicketDetalle>();
		List<int> Borrados = new List<int>();
		public TicketDetalleManager TicketManager = new TicketDetalleManager();
		public int CurrentTicket = 0;
		public string CurrentMesa = "0";
		public int level = 0;
		public int selection = 0;
		private int CurrentTicketNro=0;
		Global g = new Global();
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
		public Botonera(List<ListaDTO> lista, List<ListaDTO> subopcion, int valor, int level = 0)
		{
			InitializeComponent();
			
			CurrentMesa ="0";
			CurrentTicketNro = g.secuencia.getTicket();
			label4.Text = CurrentMesa;
			labelticket.Text = CurrentTicketNro.ToString();
			var s = new Mesa();
			s.Siglas = "0";
			g.SetMesa(s);
			Opciones = lista;
			SubOpciones = subopcion;
			displayOpciones(lista, false);
			CurrentMesa = g.currMesa.Siglas;
			CurrentTicketNro = g.secuencia.getTicket();
			label4.Text = CurrentMesa;

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
					Nota = 0,
					Neto = Producto.PrecioNeto,
					Monto = Producto.PrecioNeto * 1,
					Mesa = CurrentMesa,
					Ticket = CurrentTicketNro,
					Notas = "",
					Adicionales = "",
					Iva = Convert.ToDecimal(Ivastr) / 100,
					Montoiva = Producto.PrecioNeto * Convert.ToDecimal(Ivastr) / 100
				};
				ListaDetalle.Add(item);
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
			this.dataGridView1.DataSource = ListaDetalle;
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
			if (ListaDetalle.Count > 0)
			{
				foreach (TicketDetalle d in ListaDetalle)
				{suma = suma + (d.Cant * d.Monto);
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
			ListaDetalle = TicketManager.GetList(mesa);
			if (ListaDetalle.Count > 0)
			{
				this.dataGridView1.DataSource = ListaDetalle;
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
			int n = 0;
			foreach (TicketDetalle t in ListaDetalle)
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
			ListaDetalle.Clear();
			GetSuma();
			
			g.secuencia.SaveTicket(g.secuencia.newTicket());
			CurrentTicketNro = g.secuencia.getTicket();
			labelticket.Text = CurrentTicketNro.ToString();
			dataGridView1.DataSource = null;
			dataGridView1.Refresh();
			this.SendToBack();
		}
		private void eliminarBorrados()
		{
			foreach (int n in Borrados)
			{
				TicketManager.Delete(n);
			}
			Borrados.Clear();
		}
		private void button3_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0 && ListaDetalle[dataGridView1.SelectedRows[0].Index].Cant <= 999)
			{
				ListaDetalle[dataGridView1.SelectedRows[0].Index].Cant++;
				ListaDetalle[dataGridView1.SelectedRows[0].Index].Monto = ListaDetalle[dataGridView1.SelectedRows[0].Index].Cant * ListaDetalle[dataGridView1.SelectedRows[0].Index].Neto;
			}
			refreshView();
		}
		private void button4_Click(object sender, EventArgs e)
		{
			var cant = ListaDetalle[dataGridView1.SelectedRows[0].Index].Cant;
			if (dataGridView1.SelectedRows.Count > 0 && cant > 1)
			{
				this.ListaDetalle[dataGridView1.SelectedRows[0].Index].Cant--;
				this.ListaDetalle[dataGridView1.SelectedRows[0].Index].Monto = this.ListaDetalle[dataGridView1.SelectedRows[0].Index].Cant * ListaDetalle[dataGridView1.SelectedRows[0].Index].Neto;
			}
			refreshView();
		}
		private void button5_Click(object sender, EventArgs e)
		{
			ListaDetalle.Clear();
			refreshView();

		}
		private void button6_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				if (ListaDetalle[dataGridView1.SelectedRows[0].Index].Id != 0)
					Borrados.Add(ListaDetalle[dataGridView1.SelectedRows[0].Index].Id);
				ListaDetalle.RemoveAt(dataGridView1.SelectedRows[0].Index);
				refreshView();
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			eliminarBorrados();
			Global g = new Global();
			g.SetTicket(ListaDetalle);
			TotalForm TF = new TotalForm(GetSuma(),Ivatipo.General);
			TF.ShowDialog();
			MesasManager mesasM = new MesasManager();
			var mesa=mesasM.GetMesa( CurrentMesa);
			if (TF.TotalesPago.pagado < TF.TotalesPago.resta)
			{
				ResetFormValues(TF);
			}
			else
			 {   // cambiar el printer antes de llamar operacion para trabajar con otro printer ppoe ejemplo
				 ///	IPrinterFIOperaciones IP = new ImpresionBixolon();
				//Doble Abstract Factory Printer y Documento
				IPrinterFIOperaciones IP = new ImpresionBematech();
				IP.Facturar(ListaDetalle, TF.TotalesPago);
				//MessageBox.Show(IP.isAnulada().ToString());

			}

		}

		private void ResetFormValues(TotalForm TF)
		{
			TF.TotalesPago.pagado = 0;
			TF.TotalesPago.resta = 0;
			TF.TotalesPago.descuento = 0;
			TF.TotalesPago.ListaPagos.Clear();
			TF.TotalesPago.cliente = null;
			TF.TotalesPago.currentIva = Ivatipo.General;
			TF.TotalesPago.IvaPercent = 0;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void button9_Click_1(object sender, EventArgs e)
		{
			this.SendToBack();
		}

	
		public void Cambia(DiagramaMesas dMesas)
		{
			CurrentMesa = dMesas.GetMesa();
			this.label4.Text = dMesas.GetMesa();
			labelticket.Text = CurrentTicketNro.ToString();
			if (dMesas.totaliza)
			{
				ListaDetalle = TicketManager.GetList(dMesas.GetMesa(), 0);
				refreshView();

			}
		}
		public void Close(Mesa lamesas)
		{
			Carga(lamesas.Siglas,0);

		}

		private void ImprimirNota(Form tform)
		{
		
		}

		private void button10_Click_1(object sender, EventArgs e)
		{
			Form p=(this.ParentForm as Form);
			Console.Write(p.Name);
			((Punto)p).ChoiceClick(sender,e);
			IPrinterFIOperaciones IP = new ImpresionBematech();
			IP.EmiteNotadeCredito("000001");

		}
		private void  ParentMethods(object p)
		{

		}
	}
}
