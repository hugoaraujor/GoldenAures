using AurumBusiness.Controllers;
using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AurumRest.comandBar;

namespace AurumRest
{
	public partial class partsDialog : Form
	{   ProductoDTO currentPart=new ProductoDTO();
		ProductoManager productManager=new ProductoManager();
		CategoriasManager catManager = new CategoriasManager();
		Data Context = new Data();
		MenuManager menuManager = new MenuManager();

		
   
		public partsDialog()
		{
			InitializeComponent();
			this.comandBar1.OnUserControlButtonClicked += new ButtonClickedEventHandler(OnUCButtonClickHandler);

		}
		private void OnUCButtonClickHandler(object sender, EventArgs e)
		{
			// Handle event here
			panel1.Enabled = true;
			panel1.Focus();
			this.textoBoxp1.Focus();
		}
	
		private void panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void partsDialog_Load(object sender, EventArgs e)
		{
			
			var categorias = Context.Categorias.Where(p => p.Activo).ToArray();
		    comboBox1.DataSource= categorias;
			comboBox1.ValueMember = " Idcategoria";
			comboBox1.DisplayMember = "CategoriaDesc";
		}

		private void textoBoxp2_TextChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.FileSearch.FileName = "";
			this.FileSearch.Filter = "Image File *.jpg|*.jpeg|*.png|*.gif";
			DialogResult auxDr=this.FileSearch.ShowDialog();
			if (auxDr == DialogResult.OK)
			{
				this.label8.Image = Image.FromFile(this.FileSearch.FileName);
				this.label9.Text = this.FileSearch.FileName;
			}
			
		}

	

		private void button2_Click(object sender, EventArgs e)
		{
			Image im = null;
			this.label8.Image = im;
		}

		public  void comandBar1_Click(object sender, EventArgs e)
		{
			currentPart = new ProductoDTO { Activo = checkBox2.Checked, Categoria = (int)comboBox1.SelectedValue, Codigo = textoBoxp1.Text, Exento = checkBox1.Checked, IdProducto = Convert.ToInt16(labelindex.Text), Impresora = (int)comboBox3.SelectedValue, Iva = 0, Menu = (int)comboBox2.SelectedValue, Nombre = textoBoxp2.Text, PrecioNeto = Convert.ToDecimal(textoBoxp2.Text) };
			
			this.textoBoxp1.Focus();
			if (comandBar1.Status == RecordAction.None)
			{
				this.panel1.Enabled = false;
			}
			if (comandBar1.Status==RecordAction.Insert|| (comandBar1.Status == RecordAction.Update))
			{
				this.panel1.Enabled = true;
				this.panel1.Select();
				textoBoxp1.Focus();
			}
					
			if (comandBar1.Status == RecordAction.Delete&&comandBar1.confirma)
			{
				productManager.Delete(currentPart.IdProducto);
				this.comandBar1.confirma = false;
			}
			if (comandBar1.Status == RecordAction.Save&& comandBar1.previo==RecordAction.Insert)
			{
				productManager.Insert(currentPart);
				this.comandBar1.previo = RecordAction.None;
			}
			if (comandBar1.Status == RecordAction.Save && comandBar1.previo == RecordAction.Insert)
			{
				productManager.Edit(currentPart);
				this.comandBar1.previo = RecordAction.None;
			}
		}


		private void comandBar1_Load(object sender, EventArgs e)
		{
			

		}

		private void label10_Click(object sender, EventArgs e)
		{

		}

		private void button3_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{

		}

		private void panel1_Paint_1(object sender, PaintEventArgs e)
		{

		}

		private void comandBar2_Load(object sender, EventArgs e)
		{

		}
	}
}
