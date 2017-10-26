using AurumBusiness.Controllers;
using AurumData;
using AurumDataEntity;
using AurumDataEntity.DataEntities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AurumRest
{
	public partial class Lista : Form
	{
		private string archivo;
		private string entidad;
		IListStrategy modulo = null;	
		
		public Lista(string Entidad)
		{
			entidad = Entidad;
			InitializeComponent();
		
		}

		private void Area_Load(object sender, EventArgs e)
		{
			switch (entidad.ToLower())
			{
				case "area":
					modulo=new AreasLista();
					break;
				case "banco":
					modulo = new BancoLista();
					break;
				case "menu":
					modulo = new MenuLista();
					break;
				case "tarjeta":
					modulo = new TarjetaLista();
					break;
				case "depósitos":
					modulo = new DepositosLista();
					break;
				case "tickets":
					modulo = new TicketsLista();
					break;
			}
		   this.Text = entidad;
			FillLista();
			Refresca(entidad);
		
		}

		private dynamic FillLista()
		{  //Leer Data
			this.LayoutBtn.Visible = true;
			dynamic aux = null;
			 aux = modulo.GetData();
			if (aux == null)
				MessageBox.Show("No hay Datos Definidos");

			return aux;
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = "Agregar Valor";
			OneValueFrm onevalue = new OneValueFrm();
			onevalue.previo = "";
			onevalue.strleido = "";
			onevalue.ShowDialog();
			modulo.InsertItem(onevalue.strleido);
			Refresca(entidad);
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = "Borrar";
			DialogResult resp;
			resp = MessageBox.Show("Esta Seguro de Borrar este Registro?", "", MessageBoxButtons.YesNo);
			if (resp == DialogResult.Yes)
			{ modulo.DeleteItem((int)listBox1.SelectedValue);
			}
				
			Refresca(entidad);

		}
		public void Refresca(string v)
		{//llenalista
			this.listBox1.DataSource = FillLista();
				this.listBox1.DisplayMember = "Descriptor";
				this.listBox1.ValueMember = "index";
			
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{//editar
			toolStripStatusLabel1.Text = "Editar Valor";
			bool aux = false;

			OneValueFrm ovf = new OneValueFrm();
			ovf.previo = this.listBox1.Text;
			ovf.strleido = "";
			MessageBox.Show(this.listBox1.SelectedValue.ToString());
			ovf.ShowDialog();
			if (ovf.strleido.Length > 0)
				modulo.EditaItem((int)this.listBox1.SelectedValue, ovf.strleido);
					
			Refresca(entidad);
			if (aux)
				toolStripStatusLabel1.Text = "Actualizacion Realizada";
			else
				toolStripStatusLabel1.Text = "Actualizacion No se ha realizado";
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = "Seleccione la Herramienta de actualizacion";
			if (entidad.ToLower() == "area" && listBox1.SelectedItems.Count > 0)
			{
				AreaManager am = new AreaManager();
				AreaDTO selarea;
				var aux = this.listBox1.SelectedValue;
				if (entidad == "area")
				{
					selarea = am.GetAreaDTO((int)this.listBox1.SelectedValue);
				
				if (selarea.File != null)
				{
					this.LupaBtn.Visible = true;
					archivo = selarea.File;
				}
				else
				{
					this.LupaBtn.Visible = false;
					archivo = "";
				}
				}
			}
		}

		private void LayoutBtn_Click(object sender, EventArgs e)
		{

			var ImagenFile = this.openFileDialog1.ShowDialog();
			AreaManager am = new AreaManager();
			MessageBox.Show(ImagenFile.ToString());
			if (this.listBox1.SelectedValue != null)
				am.AsignarLayout((int)this.listBox1.SelectedValue, openFileDialog1.FileName);

		}

		private void LupaBtn_Click(object sender, EventArgs e)
		{
			FormView fv = new FormView(archivo);
			fv.ShowDialog();
		}
	}
}

