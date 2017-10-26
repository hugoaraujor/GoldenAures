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
	public partial class MesaControl :Button
	{ 
		private string siglas;
		public string Siglas
		{
			get {
				return siglas;
			}
			set
			{
				siglas = value;
				this.Text = "Mesa "+siglas;

			}

		}
		public MesaControl()
		{
			InitializeComponent();
		
		}

		private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
		{
		  
		}
	}
}
