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
	public partial class DescuentoDialog : Form
	{
		internal string valor="0,00";
		internal string percent = "0,00";
		internal TotalapagarView totales;
		public DescuentoDialog(TotalapagarView Totales)
		{
			totales = Totales;
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			valor= this.textoBoxp4.Text;
			this.Close();
		}

		private void textoBoxp2_Leave(object sender, EventArgs e)
		{
			if (textoBoxp2.Text=="")
			{
				return;
			}
			if (Convert.ToDecimal(textoBoxp2.Text) > 99)
			{
				return;
			}
			try
			{
				var tDesc = (totales.totalNeto * Convert.ToDecimal(this.textoBoxp2.Text)) / 100;
				percent = this.textoBoxp2.Text;
				this.textoBoxp4.Text = String.Format("{0:0.00}", tDesc);
			}
			catch
			{

			}
		}

		private void DescuentoDialog_Load(object sender, EventArgs e)
		{

		}
	}
}
