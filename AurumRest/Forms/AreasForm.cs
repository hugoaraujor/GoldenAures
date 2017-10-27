using AurumBusiness.Controllers;
using AurumData;
using AurumData.Models;
using AurumDataEntity;
using AurumDataEntity.DataEntities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static AurumRest.comandBar;

namespace AurumRest
{
	public partial class AreasForm : Form
	{
		AreaDTO currentArea = new AreaDTO();
		AreaManager areaManager = new AreaManager();
		int currentindex = -1;

		Data Context = new Data();


		public AreasForm()
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
				areaManager.Delete(currentArea.Areaid);
				this.comandBar1.confirma = false;
				initField();
				panel1.Enabled = false;
				Utilities.Mensaje(errorBar1, "El registro fue Borrado", errorType.Error);
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
					var area = new Area {  Descriptor=textoBoxp2.Text, Mesas=Convert.ToInt16(textoBoxp3.Text), Prefijo=textoBoxp1.Text, File="" };
					var areaDTO = new AreaDTO { Descriptor = textoBoxp2.Text, Mesas = Convert.ToInt16(textoBoxp3.Text), Prefijo = textoBoxp1.Text, File = "" };
					var aux1 = validarRegistro(area);
					if (aux1.Length > 0)
					{
						Utilities.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					areaManager.InsertClase(areaDTO);
					this.comandBar1.previo = RecordAction.None;
					Utilities.Controles(this, "Reset");
					panel1.Enabled = false;
				}

				if (comandBar1.Status == RecordAction.Save && comandBar1.previo == RecordAction.Update && aux == "")
				{
					var area = new Area { Descriptor = textoBoxp2.Text, Mesas = Convert.ToInt16(textoBoxp3.Text), Prefijo = textoBoxp1.Text, File = "",Areaid=Convert.ToInt16(labelindex.Text) };
					var areaDTO = new AreaDTO { Descriptor = textoBoxp2.Text, Mesas = Convert.ToInt16(textoBoxp3.Text), Prefijo = textoBoxp1.Text, File = "", Areaid = Convert.ToInt16(labelindex.Text) };

					var aux1 = validarRegistro(area);
					if (aux1.Length > 0)
					{
						Utilities.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					areaManager.Edit(areaDTO);
					this.comandBar1.previo = RecordAction.None;
					Utilities.Controles(this, "Reset");
					panel1.Enabled = false;
				}


			}
		}

		private void initField()
		{
			textoBoxp2.Text = "";
			textoBoxp3.Text = "";
		}


		private void Carga_Busqueda()
		{
			Search_Params Sp = new Search_Params();

			Sp.data = areaManager.GetAll();
			Sp.palabra = "";
			Sp.parametros = new List<string>();
			Sp.parametros.Add("Area");

			BusquedaFrm BF = new BusquedaFrm(Sp);
			BF.ShowDialog();
			var seleccion = BF.GetValue();
			if (seleccion > -1)
			{
				currentindex = seleccion;
				currentArea = areaManager.GetAreaDTO(currentindex);
				DespliegaCampos();

			}
		}
		private void DespliegaCampos()
		{
			this.textoBoxp2.Text = currentArea.Descriptor;
			this.textoBoxp3.Text = currentArea.Mesas.ToString();
			this.textoBoxp1.Text = currentArea.Prefijo;
			this.labelindex.Text = currentArea.Areaid.ToString();
		}

		private string validaforma()
		{
			string msgValidate = "";

			if (textoBoxp2.Text == "")
			{
				msgValidate = msgValidate + "Especifique un Nombre o Identificador\n";
				textoBoxp2.Focus();
			}
			if (textoBoxp1.Text == "")
			{
				msgValidate = msgValidate + "Especifique un Prefijo.\n";
				textoBoxp2.Focus();
			}
			
			return msgValidate;
		}

		private string validarRegistro(Area newpart)
		{
			bool aux = areaManager.ExisteArea(newpart.Descriptor);
			string msgValidate = "";

			if (aux && (newpart.Areaid != currentArea.Areaid))
				msgValidate = msgValidate + "Area ya Existente.\n";
			if (newpart.Descriptor == "")
				msgValidate = msgValidate + "Area Nombre no puede ser dejado en Blanco\n";
			if (newpart.Mesas == 0|| newpart.Mesas.ToString() == "")
				msgValidate = msgValidate + "Mesas no puede ser 0\n";


			return msgValidate;
		}

		private void comandBar1_Load(object sender, EventArgs e)
		{

		}
	}
}
