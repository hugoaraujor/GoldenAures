using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Security;
using System.Threading;
//using System.Data.SQLite;
//using FirebirdSql.Data.FirebirdClient;

namespace AurumSolution
{
	public partial class LOGIN : Form
	{
		public int n = 0;
		public static string usercode = "";
		public LOGIN()
		{
			InitializeComponent();
			this.textBox2.KeyDown += textBox2_KeyDown;
		}

		void textBox2_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
				validateuser();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			validateuser();
		}

		private void validateuser()
		{
			int n = 0;
			n = n + 1;
			this.toolStripStatusLabel1.Text = "Nombre de Usuario o Contraseña Equivocado";
			if (n >= 4)
			{
				this.toolStripStatusLabel1.Text = "Usted ha alcanzado el maximo numero de Intentos. La Aplicación se cerrará.";
				Application.Exit();
			}

		}




		private void Label4_Click(object sender, EventArgs e)
		{

			this.Close();
			Application.Exit();
		}

		private void label10_Click(object sender, EventArgs e)
		{

		}
	}
}

