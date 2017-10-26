using AurumBusiness.Controllers;
using AurumDataEntity.DataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurumRest
{
	public partial class AbrirMesaFrm : Form
	{
		public AbrirMesaView abrirmesaResults = new AbrirMesaView();
		MesonerosManager MeseroManager = new MesonerosManager();
		public AbrirMesaFrm()
		{
			InitializeComponent();
		}

		private void AbrirMesaFrm_Load(object sender, EventArgs e)
		{
			this.label2.Text = string.Format("{0:MM/dd/yy H:mm}",DateTime.Now);
			CargaCombo(this.comboBox1);
		}

		private void CargaCombo(ComboBox comboBox1)
		{
			    comboBox1.DataSource = MeseroManager.GetAll(); 
				comboBox1.DisplayMember = "Mesero";
			    comboBox1.ValueMember = "Id";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (comboBox1.Text == "" || comboBox1.SelectedIndex == -1)
			{
				comboBox1.Focus();

			}
			else
			{
				abrirmesaResults.mesonero = MeseroManager.getMesero((int)comboBox1.SelectedValue);
				abrirmesaResults.Fecha = DateTime.Now;
				abrirmesaResults.personas = (int)numericUpDown1.Value;
				this.Close();
			}
			
		}
	}
}
