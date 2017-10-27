using AurumBusiness.Controllers;
using AurumData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



//string NumeroSerial = new string(' ', 15);
//int iRetorno = BemaFI32.Bematech_FI_NumeroSerie(ref NumeroSerial);
namespace AurumRest
{
	public partial class Punto : Form
	{
		IPrinterFIOperaciones printer;
		CategoriasManager catMan = new CategoriasManager();
		ProductoManager prodMan = new ProductoManager();
		public DetalleFactura DetaFac = new DetalleFactura();
		
		int selection = 0;
		bool selectionaux = false;


		public Punto()
		{
			InitializeComponent();
			
		}

		public void Seleccion(int value, bool aux=false)
		{
			this.selection = value;
			this.selectionaux = aux;
		}

		public void  ChoiceClick(object sender, EventArgs e)
		{
			MessageBox.Show("hugo araujo");
		}
		private void Punto_Load(object sender, EventArgs e)
		{

			Control botonera = new Botonera(catMan.GetActives(), prodMan.GetProductos(0, true),0,0);
			Control diagrama = new DiagramaMesas();
			
		//	Size size = new Size(900,650);
		//  Size size2 = new Size(350, 650);
		//	botonera.Size = size;
			
			var nro = 0;
			var mesastr = "0";
			((Botonera)botonera).Carga(mesastr,nro);
			//Control c = botonera;
			((Botonera)botonera).UserControlButtonClicked += new EventHandler(ChoiceClick);
			
			flowLayoutPanel1.Controls.Add(botonera);
			flowLayoutPanel1.Controls.Add(diagrama);



		}
		public void GuardarFactura()
		{
			FacturasManager fM = new FacturasManager();

		}
		private void salirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		
	}
}
