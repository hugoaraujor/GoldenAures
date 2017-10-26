using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurumRest
{
	public partial class comandBar : UserControl 
	{
		RecordAction status;
		public RecordAction previo { get; set; }
		public bool confirma { get; set; }

		public delegate void ButtonClickedEventHandler(object sender, EventArgs e);
		public event ButtonClickedEventHandler OnUserControlButtonClicked;

		[Category("Action"), DefaultValue(RecordAction.None)]
		[Description("Action")]
		public RecordAction Status
		{
			get { return status; }
			set
			{
				status = value;
				
			}

		}
		public comandBar()
		{

			InitializeComponent();

		    this.AgregarBtn.Click += new EventHandler(OnButtonClicked);
			this.EditarBtn.Click += new EventHandler(OnButtonClicked);
			this.BorrarBtn.Click += new EventHandler(OnButtonClicked);
			this.GuardarBtn.Click += new EventHandler(OnButtonClicked);
			this.LupaBtn.Click += new EventHandler(OnButtonClicked);
			this.Deshacer.Click += new EventHandler(OnButtonClicked);


		}
		private void OnButtonClicked(object sender, EventArgs e)
		{
			// Delegate the event to the caller
			if (OnUserControlButtonClicked != null)
				OnUserControlButtonClicked(this, e);
		}


		private void EditarBtn_Click(object sender, EventArgs e)
		{
			previo = RecordAction.Update;
			status = RecordAction.Update;
			DesactivarBotonesEdicion();
			Auxiliares(true);
		


		}

		private void ActivarBotonesEdicion()
		{
			AgregarBtn.Visible = true;
			BorrarBtn.Visible = true;
			EditarBtn.Visible = true;
			LupaBtn.Visible = true;
			Utilities.Controles(this, "Lock");
		}
		public  void  Novalido()
		{    DesactivarBotonesEdicion();
						Auxiliares(true);

		}
		private void DesactivarBotonesEdicion()
		{
			AgregarBtn.Visible = false;
			BorrarBtn.Visible = false;
			EditarBtn.Visible = false;
			LupaBtn.Visible = false;
			Auxiliares(true);

		}
		private void Auxiliares(bool valor)
		{
			GuardarBtn.Visible = valor;
			Deshacer.Visible = valor;
		}  

		private void AgregarBtn_Click(object sender, EventArgs e)
		{  previo= RecordAction.Insert;
			DesactivarBotonesEdicion();
			status = RecordAction.Insert;

			Auxiliares(true);
			Form Parent = new Form();
			Parent.SelectNextControl(Parent.Parent,true,true,true,true);

		}

		private void BorrarBtn_Click(object sender, EventArgs e)
		{
			previo = RecordAction.None;
			var resp = MessageBox.Show("Confirma Borrado?","Confirmación",MessageBoxButtons.YesNo);
			if (resp==DialogResult.Yes)
			{ confirma = true; }
			else { confirma = false;}
			status = RecordAction.Delete;
		
		}

		private void GuardarBtn_Click(object sender, EventArgs e)
		{
			status = RecordAction.Save;
			Auxiliares(false);
			ActivarBotonesEdicion();
		

		}

		private void Deshacer_Click(object sender, EventArgs e)
		{
			previo = RecordAction.None;
			Auxiliares(false);
			ActivarBotonesEdicion();
			status = RecordAction.Undo;
		
			
		}

		private void LupaBtn_Click(object sender, EventArgs e)
		{
			previo= RecordAction.None;
			status = RecordAction.Search;
			
		}

		

	}
}
