using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AurumBusiness.Controllers;

namespace AurumRest
{
	public partial class DetalleMesaForm : Form
	{
		TicketDetalleManager tDetManager = new TicketDetalleManager();
		private string mesas="";
		public DetalleMesaForm(string mesastr)
		{
			InitializeComponent();
			mesas = mesastr;
		}

		private void DetalleMesaForm_Load(object sender, EventArgs e)
		{
			

			dataGridView1.DataSource = tDetManager.GetList(mesas);
			MesasManager MesaMngr = new MesasManager();


			MesonerosManager MeseroMngr = new MesonerosManager();
			var mesa = MesaMngr.GetMesa(mesas);
			labelMesa.Text = mesa.Siglas;
			label4.Text = mesa.Hora.ToString();
			var mesero = MeseroMngr.getMesero((int)mesa.Idmesonero);
			label3.Text = mesero.Nombre;
			Utilities.DataGridLayout(this.dataGridView1);
			this.dataGridView1.Columns["Nombre"].Width = 250;
			

		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
		{
			
		}

		private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
				this.Close();
		}
	}
}
