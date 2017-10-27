using AurumBusiness.Controllers;
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
	public partial class OneValueFrm : Form
	{
		public string previo;
		public string strleido;
		public bool notrepeated=false;
		public OneValueFrm()
		{
			InitializeComponent();
			
		}

		private void OneValueFrm_Load(object sender, EventArgs e)
		{
			textBox1.Text = previo;
			textBox1.Focus();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			
			strleido = this.textBox1.Text;
			this.Close();
		}

		
	}
}
