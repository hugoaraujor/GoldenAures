using AurumBusiness.Controllers;
using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AurumRest.comandBar;

namespace AurumRest
{
	public partial class PartsForm : Form
	{
		ProductoDTO currentPart = new ProductoDTO();
		ProductoManager productManager = new ProductoManager();
		CategoriasManager catManager = new CategoriasManager();
		MenuManager menuManager = new MenuManager();
		int currentindex = -1;
		Data Context = new Data();
		
	
		public PartsForm()
		{
			InitializeComponent();
			this.comandBar1.OnUserControlButtonClicked += new ButtonClickedEventHandler(OnUCButtonClickHandler);
		}
		private void OnUCButtonClickHandler(object sender, EventArgs e)
		{
			// Handle event here

			if (this.comandBar1.Status != RecordAction.Undo)
			{
				panel1.Focus();
				this.textoBoxp1.Focus();
				SeleccionoBarra();
			}
			else
			{ panel1.Enabled = false; }
		}
		private void Carga_Busqueda()
		{
			Search_Params Sp = new Search_Params();

			Sp.data = productManager.GetAll();
			Sp.palabra = "";
			Sp.parametros = new List<string>();
			Sp.parametros.Add("Nombre");

			BusquedaFrm BF = new BusquedaFrm(Sp);
			BF.ShowDialog();
			var seleccion = BF.GetValue();
			if (seleccion > -1)
			{
				
				currentPart.IdProducto = seleccion;
				currentindex = seleccion;
				currentPart = productManager.GetProductoDTO(currentindex);

				DespliegaCampos();

			}
		}

		private void DespliegaCampos()
		{
			comboUpdates();
			label8.Text = currentPart.Imagenurl;
			checkBox1.Checked = currentPart.Activo;
			checkBox2.Checked = currentPart.Exento;
			comboBox1.SelectedValue = currentPart.Categoria;
			comboBox2.SelectedValue = currentPart.Impresora;
			comboBox3.SelectedValue = currentPart.Menu;
			textoBoxp1.Text = currentPart.Codigo;
			textoBoxp2.Text = currentPart.Nombre;
			textoBoxp3.Text = Convert.ToDecimal(currentPart.Costo).ToString("0.00");
			textoBoxp4.Text = Convert.ToDecimal(currentPart.PrecioNeto).ToString("0.00");
			labelindex.Text = currentPart.IdProducto.ToString();
			if (label8.Text != "")
				pictureBox1.Image = Image.FromFile(label8.Text);
			else
			{
				Image im = null;
				this.pictureBox1.Image = im;
			}
		}

		public void SeleccionoBarra()
		{

			
			this.textoBoxp1.Focus();
			if (comandBar1.Status == RecordAction.Search)
			{
			 Carga_Busqueda();
			}

			if (comandBar1.Status == RecordAction.None)
			{
				this.panel1.Enabled = false;
			}
			if (comandBar1.Status == RecordAction.Insert)
			{
				this.labelindex.Text = "-1";
			
			}
			if (comandBar1.Status == RecordAction.Insert || (comandBar1.Status == RecordAction.Update))
			{
				this.panel1.Enabled = true;
				this.panel1.Select();
				textoBoxp1.Focus();
			}

			if (comandBar1.Status == RecordAction.Delete && comandBar1.confirma)
			{
				productManager.Delete(currentPart.IdProducto);
				this.comandBar1.confirma = false;
				Utilities.Controles(this, "Reset");
				panel1.Enabled = false;
			}
			if (comandBar1.Status == RecordAction.Save)
			{
				var aux=validaforma();
				if (aux != "")
				{	errorBar1.Mensaje = aux;
					errorBar1.Status = errorType.Error;
					this.comandBar1.Novalido();
					return;
				}
				if (comandBar1.Status == RecordAction.Save)
					{
					currentPart = new ProductoDTO
					{
						IdProducto = Convert.ToInt16(labelindex.Text),
						Activo = this.checkBox1.Checked,
						Categoria = (int)comboBox1.SelectedValue,
						Codigo = textoBoxp1.Text,
						Exento = checkBox2.Checked,
						Impresora = (int)comboBox2.SelectedValue,
						Costo = Convert.ToDecimal(textoBoxp3.Text),
						Menu = (int)comboBox3.SelectedValue,
						Nombre = textoBoxp2.Text,
						PrecioNeto = Convert.ToDecimal(textoBoxp4.Text),
						Imagenurl = this.label8.Text
					};
				}
				if (comandBar1.Status == RecordAction.Save && comandBar1.previo == RecordAction.Insert && aux=="")
				{
				
					var aux1 = validarRegistro(currentPart);
					if (aux1.Length > 0)
					{
						Varios.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					productManager.Insert(currentPart);
					this.comandBar1.previo = RecordAction.None;
					Utilities.Controles(this, "Reset");
					panel1.Enabled = false;
				}

				if (comandBar1.Status == RecordAction.Save && comandBar1.previo == RecordAction.Update && aux == "")
				{

					var aux1 = validarRegistro(currentPart);
					if (aux1.Length > 0)
					{
						Varios.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					productManager.Edit(currentPart);
					this.comandBar1.previo = RecordAction.None;
					Utilities.Controles(this, "Reset");
					panel1.Enabled = false;
				}

				
			}
		}

		
		private void button1_Click(object sender, EventArgs e)
		{
			this.FileSearch.FileName = "";
			this.FileSearch.Filter = "Image File *.jpg|*.jpeg|*.png|*.gif";
			DialogResult auxDr = this.FileSearch.ShowDialog();
			if (auxDr == DialogResult.OK)
			{
				this.pictureBox1.Image = Image.FromFile(this.FileSearch.FileName);
				this.label8.Text = this.FileSearch.FileName;
			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Image im = null;
			this.pictureBox1.Image = im;
			label8.Text="";
		}

		private void PartsForm_Load(object sender, EventArgs e)
		{

			comboUpdates();
		}
		private string validarRegistro(ProductoDTO newpart)
		{
			var aux = productManager.Existe(newpart.Nombre);
			string msgValidate = "";
			if (newpart.Codigo == "")
				msgValidate = "Ingrese Código\n";
			if (aux && (newpart.Codigo!= currentPart.Codigo))
				msgValidate = msgValidate + "Producto ya Existente.\n";
			if (newpart.Nombre == "")
				msgValidate = msgValidate + "Nombre del Producto o Plato no puede ser dejado en Blanco\n";
			if (newpart.Categoria.ToString() == "")
				msgValidate = msgValidate + "Debe seleccionar una categoria\n";
			
			return msgValidate;
		}
		private string validaforma()
		{
			string msgValidate = "";
			if (this.comboBox1.SelectedValue == null)
				msgValidate = msgValidate + "Debe seleccionar una categoria\n";
			if (this.comboBox2.SelectedValue == null)
				msgValidate = msgValidate + "Debe seleccionar una Impresora\n";
			if (this.comboBox3.SelectedValue == null)
				msgValidate = msgValidate + "Debe seleccionar un Menú\n";
			return msgValidate;
		}
		private void comboUpdates()
		{
			comboBox1.DataSource = null;
			comboBox2.DataSource = null;
			comboBox3.DataSource = null;
			var categorias = Context.Categorias.Where(p => p.Activo).ToArray();
			comboBox1.DataSource = categorias;
			comboBox1.ValueMember = "Idcategoria";
			comboBox1.DisplayMember = "CategoriaDesc";
			comboBox1.SelectedValue = 0;

			var remotas = Context.Remotas.ToArray();
			comboBox2.DataSource = remotas;
			comboBox2.ValueMember = "remotaid";
			comboBox2.DisplayMember = "nombre";
			comboBox2.SelectedValue = 0;

			var menu = Context.Menus.ToArray();
			comboBox3.DataSource = menu;
			comboBox3.ValueMember = "IdMenu";
			comboBox3.DisplayMember = "menuDesc";
			comboBox3.SelectedValue = 0;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			var existe=catManager.Existe(comboBox1.Text);
			var resp=MessageBox.Show("Esta seguro de Agregar esta Categoría?", "Agregar Categoria", MessageBoxButtons.YesNo);
			if (resp == DialogResult.Yes && comboBox1.Text!="" && existe==false)
			{
				catManager.InsertCategorias(new Categoria { Activo = true, CategoriaDesc = comboBox1.Text.ToUpper(), Pesa = false, Idcategoria = 0 });
			}
			comboUpdates();
		}

		private void PartsForm_KeyUp(object sender, KeyEventArgs e)
		{

		}
		private static Control GetFocusedControl()
		{
			Control focused = null;
			var handle = GetFocusedControlHandle();

			if (handle != IntPtr.Zero)
			{
				focused = Control.FromHandle(handle);
			}

			return focused;
		}
		// ...
		[DllImport("user32.dll")]
		private static extern IntPtr GetFocusedControlHandle();

		private void textoBoxp1_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
