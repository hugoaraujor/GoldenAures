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
	public partial class FormView : Form
	{
		private string file;
		public FormView(string filename)
		{
			InitializeComponent();
			file = filename;
		}

		private void FormView_Load(object sender, EventArgs e)
		{
			this.picture.Image = Image.FromFile(file);
		}
	}
}
