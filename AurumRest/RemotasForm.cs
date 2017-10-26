using AurumBusiness.Controllers;
using AurumData;
using AurumData.Models;
using AurumDataEntity.DataEntities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static AurumRest.comandBar;

namespace AurumRest
{
	public partial class RemotasForm : Form
	{
		remotasDTO currentRemota = new remotasDTO();
		remotasManager remotaManager = new remotasManager();
		int currentindex = -1;

		Data Context = new Data();


		public RemotasForm()
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
				remotaManager.Delete(currentRemota.remotaid);
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
					var remota = new remotas { remota = textoBoxp3.Text, remotaid = 0, nombre = textoBoxp2.Text };
					var remotaDTO = new remotasDTO { remota = textoBoxp3.Text, remotaid = 0, nombre = textoBoxp2.Text };
					var aux1 = validarRegistro(remota);
					if (aux1.Length > 0)
					{
						Varios.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					remotaManager.InsertClase(remotaDTO);
					this.comandBar1.previo = RecordAction.None;
					Utilities.Controles(this, "Reset");
					panel1.Enabled = false;
				}

				if (comandBar1.Status == RecordAction.Save && comandBar1.previo == RecordAction.Update && aux == "")
				{
					var remota = new remotas { remota = textoBoxp3.Text, remotaid = Convert.ToInt16(labelindex.Text), nombre = textoBoxp2.Text };
					var remotaDTO = new remotasDTO { remota = textoBoxp3.Text, remotaid = Convert.ToInt16(labelindex.Text), nombre = textoBoxp2.Text };
					var aux1 = validarRegistro(remota);
					if (aux1.Length > 0)
					{
						Varios.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					remotaManager.Edit(remotaDTO);
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

			Sp.data = remotaManager.GetAll();
			Sp.palabra = "";
			Sp.parametros = new List<string>();
			Sp.parametros.Add("Nombre");

			BusquedaFrm BF = new BusquedaFrm(Sp);
			BF.ShowDialog();
			var seleccion = BF.GetValue();
			if (seleccion > -1)
			{
				currentindex = seleccion;
				currentRemota = remotaManager.GetRemotaDTO(currentindex);
				DespliegaCampos();

			}
		}
		private void DespliegaCampos()
		{
			this.textoBoxp2.Text = currentRemota.nombre;
			this.textoBoxp3.Text = currentRemota.remota;
			this.labelindex.Text = currentRemota.remotaid.ToString();
		}

		private string validaforma()
		{
			string msgValidate = "";

			if (textoBoxp2.Text == "")
			{
				msgValidate = msgValidate + "Especifique una Impresora.\n";
				textoBoxp2.Focus();
			}
			if (textoBoxp3.Text == "")
			{
				msgValidate = msgValidate + "Especifique una Direccion de Impresión.\n";
				textoBoxp2.Focus();
			}
			return msgValidate;
		}

		private string validarRegistro(remotas newpart)
		{
			bool aux = remotaManager.Existeremota(newpart.remota);
			string msgValidate = "";

			if (aux && (newpart.remotaid != currentRemota.remotaid))
				msgValidate = msgValidate + "Impresora ya Existente.\n";
			if (newpart.remota == "")
				msgValidate = msgValidate + "Nombre no puede ser dejado en Blanco\n";


			return msgValidate;
		}

		private void comandBar1_Load(object sender, EventArgs e)
		{

		}
	}
}
