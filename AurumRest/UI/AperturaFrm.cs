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

namespace AurumRest
{
	public partial class AperturaFrm : Form
	{
		public AperturaFrm()
		{
			InitializeComponent();
		}
		private void loadCombo()
		{
			TurnoManager tm = new TurnoManager();
			comboBox1.DataSource = null;
			comboBox1.DisplayMember = "Turnodesc";
			comboBox1.ValueMember = "Idturno";
			comboBox1.DataSource = tm.GetList();

		}
		private void AperturaFrm_Load(object sender, EventArgs e)
		{
			this.label2.Text = string.Format("{0:MM/dd/yy H:mm}", DateTime.Now);
			loadCombo();

			textoBoxp1.Focus();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			AperturasManager ap = new AperturasManager();
			Global g = new Global();
			ap.InsertClase(new AperturaDTO { Fecha = DateTime.Now, Monto = Convert.ToDecimal(textoBoxp1.Text), Turno = Convert.ToInt16(comboBox1.SelectedValue), userId =g.Usuario().Iduser, cerrada=false, Idapertura=0 });
			IPrinterFIOperaciones IP = new ImpresionBematech();
			IP.AbrirCaja(textoBoxp1.Text);
			this.Close();
		}
	}
}
