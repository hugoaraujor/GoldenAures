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
	public partial class LoginFrm : Form
	{
		UsuariosManager um = null;
		int intentos = 0;
		public LoginFrm()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			um = new UsuariosManager();
			this.comboBox1.DataSource =  um.GetUsuarios();
			this.comboBox1.DisplayMember="UserName";

		}

		private void button2_Click(object sender, EventArgs e)
		{
			Global g = new Global();

			var axlogged=um.LoginUsuarios(this.comboBox1.Text, textBox2.Text);
			if (!(axlogged))
			{
				intentos++;
				label5.Visible = true;
				if (intentos > 3)
				{
					
					this.Close();
					Application.Exit();
				}
			}
			else
			{
				g.GetUser(um.GetUsuario(this.comboBox1.Text, textBox2.Text));
				label5.Visible = false;
				this.Hide();
				MainFrm mf=new MainFrm();
				mf.ShowDialog();

				
			}
		}
	}
}
