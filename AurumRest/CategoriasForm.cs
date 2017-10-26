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
	public partial class CategoriasForm : Form
	{
		CategoriaDTO currentCat = new CategoriaDTO();
	    CategoriasManager catManager = new CategoriasManager();
		int currentindex = -1;

		Data Context = new Data();


		public CategoriasForm()
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
				this.textoBoxp2.Focus();
				SeleccionoBarra();
			}
			else
			{ panel1.Enabled = false; }
		}

		public void SeleccionoBarra()
		{

		
			this.textoBoxp2.Focus();
			if (comandBar1.Status == RecordAction.Search)
			{
				Carga_Busqueda();
			}
			if (comandBar1.Status == RecordAction.None)
			{
				this.panel1.Enabled = false;
			}
			if (comandBar1.Status == RecordAction.Insert || (comandBar1.Status == RecordAction.Update))
			{
				this.panel1.Enabled = true;
				this.panel1.Select();
				if (comandBar1.Status == RecordAction.Insert)
				                   initField();
				textoBoxp2.Focus();
			}

			if (comandBar1.Status == RecordAction.Delete && comandBar1.confirma)
			{
			 catManager.Delete(currentCat.Idcategoria);
				this.comandBar1.confirma = false;
				initField();
				panel1.Enabled = false;
				Varios.Mensaje(errorBar1, "El registro fue Borrado", errorType.Error);
			}
			if (comandBar1.Status == RecordAction.Save)
			{
				var aux = validaforma();
				if (aux != "")
				{
					errorBar1.Mensaje = aux;
					errorBar1.Status = errorType.Error;
					this.comandBar1.Novalido();
					return;
				}
				if (comandBar1.Status == RecordAction.Save && comandBar1.previo == RecordAction.Insert && aux == "")
				{
				     var Cat = new Categoria {  Pesa = checkBox2.Checked, Activo = checkBox1.Checked,  CategoriaDesc = textoBoxp2.Text, Idcategoria=0 };
					var aux1 = validarRegistro(Cat);
					if (aux1.Length > 0)
					{
						Varios.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					catManager.InsertCategorias(Cat);
					this.comandBar1.previo = RecordAction.None;
					Utilities.Controles(this, "Reset");
					panel1.Enabled = false;
				}

				if (comandBar1.Status == RecordAction.Save && comandBar1.previo == RecordAction.Update && aux == "")
				{
					var Cat = new Categoria{ Pesa = checkBox2.Checked, Activo = checkBox1.Checked, CategoriaDesc = textoBoxp2.Text, Idcategoria = Convert.ToInt16(labelindex.Text) };
					var Catdto = new CategoriaDTO { pesa = checkBox2.Checked, activo = checkBox1.Checked, CategoriaDesc = textoBoxp2.Text, Idcategoria = Convert.ToInt16(labelindex.Text) };
					var aux1 = validarRegistro(Cat);
					if (aux1.Length > 0)
					{
						Varios.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					catManager.Edit(Catdto);
					this.comandBar1.previo = RecordAction.None;
					Utilities.Controles(this, "Reset");
					panel1.Enabled = false;
				}


			}
		}

		private void initField()
		{
			textoBoxp2.Text = "";
			checkBox1.Checked = false;
			checkBox2.Checked = true;
		}

		private void Carga_Busqueda()
		{
			Search_Params Sp = new Search_Params();
			
			Sp.data = catManager.GetAll();
			Sp.palabra = "";
			Sp.parametros = new List<string>();
			Sp.parametros.Add("Categorias");
			
			BusquedaFrm BF = new BusquedaFrm(Sp);
			BF.ShowDialog();
			var seleccion = BF.GetValue();
			if (seleccion > -1)
			{
			 currentindex = seleccion;
			 currentCat = catManager.GetCatDTO(currentindex);
			 DespliegaCampos();
				
			}
		}

		private void DespliegaCampos()
		{
			this.textoBoxp2.Text = currentCat.CategoriaDesc;
			this.labelindex.Text = currentCat.Idcategoria.ToString();
			this.checkBox1.Checked= currentCat.pesa;
			this.checkBox2.Checked = currentCat.activo;
		}

		private string  validaforma()
		{
			string msgValidate = "";

			if (textoBoxp2.Text == "")
			{
				msgValidate = msgValidate + "Especifique una Categoria.\n";
				textoBoxp2.Focus();
			}
			return msgValidate;
		}

		private string validarRegistro(Categoria newpart)
		{
			bool aux = catManager.Existe(newpart.CategoriaDesc);
			string msgValidate = "";
			
			if (aux && (newpart.Idcategoria != currentCat.Idcategoria))
				msgValidate = msgValidate + "Categoria ya Existente.\n";
			if (newpart.CategoriaDesc == "")
				msgValidate = msgValidate + "Nombre no puede ser dejado en Blanco\n";
			

			return msgValidate;
		}

		private void comandBar1_Load(object sender, EventArgs e)
		{

		}
	}
}
