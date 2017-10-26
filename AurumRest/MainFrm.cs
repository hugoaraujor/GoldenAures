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
	public partial class MainFrm : Form
	{  public static Default defaultValues=new Default();
		public static string IMPRESORAXDEFECTO="BEMATECH";
		ProductoDTO currentPart = new ProductoDTO();
		public MainFrm()
		{
			InitializeComponent();
			defaultValues.Regresa = true;
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(Global.Instancia.Usuario().UserName);
		}

		private void areaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AreasForm fa = new AreasForm();
			Mostrar(fa);
		}

		private void Mostrar(object TheFrm)
		{

			Form formx = new Form();
			formx=(Form)TheFrm;
			formx.ShowDialog();
			formx.Dispose();
		}
		private void Abre(object TheFrm)
		{
			Form formx = new Form();
			formx=(Form)TheFrm;
			formx.Show();
			formx.Dispose();
		}

		private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Lista fa = new Lista("Banco");
			Mostrar(fa);
		}

		private void menusToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Lista fc = new Lista("Menu");
			Mostrar(fc);
		}

		private void tarjetasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Lista ec = new Lista("Tarjeta");
			Mostrar(ec);
		}

		private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			ClienteFrm cliente = new ClienteFrm();
			Mostrar(cliente);
		}

		private void depósitosToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Lista fa = new Lista("Depósitos");
			Mostrar(fa);
		}

		private void productosToolStripMenuItem_Click(object sender, EventArgs e)
		{
		PartsForm fa = new PartsForm();
			Mostrar(fa);
		}

		private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CategoriasForm fa = new CategoriasForm();
			Mostrar(fa);
		}

		private void remotasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemotasForm fa = new RemotasForm();
			Mostrar(fa);
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void irAlPuntoDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
			Punto ac = new Punto();
			ac.MdiParent = this;
			ac.WindowState = FormWindowState.Maximized;
			ac.Show();
		}

		private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Lista ec = new Lista("Tickets");
			Mostrar(ec);
		}

		private void nuevoLibroDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
		}

		private void MainFrm_Load(object sender, EventArgs e)
		{
			estableceFondo();
			
		}

		private void estableceFondo()
		{
			
			foreach (Control control in this.Controls)
			{
				// #2
				MdiClient client = control as MdiClient;
				if (!(client == null))
				{
					// #3
					client.BackColor = Color.FromArgb(68, 114, 196);


					
					// 4#
					break;
				}
			}
			
		}
	}
}
