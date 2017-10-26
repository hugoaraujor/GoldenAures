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

namespace AurumRest.UI
{
	public partial class MoveFrm : Form
	{
		private string mesa;
		private int done=0;
		public MoveFrm(string Mesa)
		{
			
			InitializeComponent();
			mesa = Mesa;
			label3.Text = mesa;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			
		}

		private void MoveFrm_Load(object sender, EventArgs e)
		{
			MesasManager TableMngr = new MesasManager();
			var query = TableMngr.GetMesas(true);//all areas all tables
			 query=	query.Where(x => !(x.Siglas==mesa)).ToList();
			this.comboBox1.DataSource=Utilities.ConvertToDataTable(query);
			this.comboBox1.DisplayMember = "Siglas";
			this.comboBox1.ValueMember = "Siglas";

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (comboBox1.Text == "")
			{ comboBox1.Focus();
				return;
			}
			if (done == 1)
			{
				this.Close();
				this.Dispose();
			}
			if (done == 0)
			{
				TicketDetalleManager TicketManager = new TicketDetalleManager();
				MesasManager mesaManager = new MesasManager();
				var queryto = TicketManager.GetList(comboBox1.Text);
				var mesato = mesaManager.GetMesa(comboBox1.Text);
				var queryfrom = TicketManager.GetList(mesa);
				var mesafrom = mesaManager.GetMesa(mesa);
			
				if (queryfrom.Count > 0 && mesafrom.Ocupada == true)
				{
					if (mesato.Ocupada == false)
					{
						mesato.Idmesonero = mesafrom.Idmesonero;
						mesato.Ocupada = true;
						mesato.Estado = EstadosMesa.Ocupada;
						mesato.Hora = mesafrom.Hora;
						mesaManager.Edit(mesato);
					}
					mesafrom.Ocupada = false;
					mesafrom.Idmesonero = null;
					mesafrom.Estado = EstadosMesa.Disponible;
					mesafrom.Idocupante = null;
					mesaManager.Edit(mesafrom);
				}
				else
				{
					return;
				}
				progressBar1.Maximum = queryfrom.Count()+1;
				int i = 1;
				foreach (TicketDetalle t in queryfrom)
				{
					t.Mesa = comboBox1.Text;
					t.Origen = t.Origen + mesafrom.Siglas + ">";
					TicketManager.Edit(t);
					i++;
					progressBar1.Value = i;
				}
				panel1.Visible = false;
				pictureBox1.Visible = true;
				
				done = 1;
			}
			

		}
	}
}
