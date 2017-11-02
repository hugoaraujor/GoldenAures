using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AurumBusiness.Controllers;
using AurumData;
using AurumRest.UI;

namespace AurumRest
{
	public partial class DiagramaMesas : UserControl
	{
		MesonerosManager m = new MesonerosManager();
		 public Global  g=Global.Instancia;
		int currentArea = 0;
		AreaManager areaControl = new AreaManager();
		MesasManager mesaManager = new MesasManager();
		List<Mesa> mesas = new List<Mesa>();
		Mesa currentMesa = new Mesa();
		int nmesas = 0;
		MesaControl control;
		Consecutivos secuencia=new Consecutivos();
		public bool totaliza=false;
		public delegate bool customHandler(object sender);
		public Botonera botonera;
		//	public event customHandler OnClickButton;
		public DiagramaMesas()
		{
			InitializeComponent();
			label3.Text = currentMesa.Siglas;
			this.GotFocus += DiagramaMesas_GotFocus;
		
		}

		private void DiagramaMesas_GotFocus(object sender, EventArgs e)
		{
			MessageBox.Show("esprimero);");
		}

		public string GetMesa()
		{
			return currentMesa.Siglas;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			this.currentMesa.Siglas = "0";
			g.SetMesa(this.currentMesa);
			botonera.Cambia();
			this.SendToBack();
		}
		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			MuestraMesas();

		}

		public void MuestraMesas()
		{
			if (listBox1.SelectedIndex > -1)
			{
				try
				{
					currentArea = (int)listBox1.SelectedValue;
				}
				catch
				{
		//			currentArea = -1;
				}
				nmesas = areaControl.GetTotalMesas(currentArea);
				ShowMesas(this.flowLayoutPanel2, currentArea,nmesas);
			}
		}

		private void ShowMesas(Panel panel1, int currArea,int nmesas)
		{
			panel1.Controls.Clear();
			var prefijo = areaControl.GetAreaDTO(currArea).Prefijo;
			for (int i = 0; i < nmesas; i++)
			{
				
				control = new MesaControl();
				var size = new Size();
				size.Height = 95;
				size.Width = 161;
				control.Size = size;
				var siglas = prefijo + "-" + (i+1).ToString();
				if (label3.Text == "")
				{
					label3.Text = siglas;
				}
				control.Text = siglas;

				control.Tag = i;
				control.KeyDown += new KeyEventHandler(ViewTable);
				control.Click += new EventHandler(OnClickButton);
				control.BackColor =Color.LightGray; 
				control.BackgroundImage = button9.BackgroundImage;
				control.BackgroundImageLayout = ImageLayout.Center;
				control.ForeColor = g.secuencia.getFont().color;
				control.ForeColor = Color.WhiteSmoke;
				var siExisteMesa = mesaManager.Existemesa(siglas);
				if (!(siExisteMesa))
				{
					mesaManager.InsertClase(new AurumDataEntity.MesaDTO { Area = currentArea, Estado = 0, Hora = DateTime.Now, Siglas = control.Text, idmesonero = 0, idocupante = 0, Ocupada = false });
				}
				else
				{

					currentMesa = mesaManager.GetMesa(siglas);
					if (currentMesa.Estado == EstadosMesa.Ocupada && currentMesa.Ocupada)
					{
						control.BackgroundImage = button8.BackgroundImage;
						control.BackColor = Color.FromArgb(143, 170, 220); 
						control.ForeColor = Color.White;
					}
					if (currentMesa.Estado == EstadosMesa.Cerrada &&currentMesa.Ocupada)
					{
						control.BackgroundImage = button9.BackgroundImage;
						control.BackColor = Color.DeepPink;
						control.ForeColor = Color.White;
					}
				}
				panel1.Controls.Add(control);


			}
		}
		private void ViewTable(object sender, KeyEventArgs e)
		{
			MesasManager tk = new MesasManager();
			var mesa=((Button)sender).Text;
			Mesa lamesaesta = tk.GetMesa(mesa);
			
			if (e.KeyCode == Keys.F2 && lamesaesta.Ocupada)
			{
				DetalleMesaForm dt = new DetalleMesaForm(((Button)sender).Text);
				dt.ShowDialog();
			}

		}
		void OnClickButton(object sender, EventArgs e)
		{
			label3.Text = (((Button)sender).Text);
			currentMesa = mesaManager.GetMesa(((Button)sender).Text);
			g.SetMesa(currentMesa);
			if (currentMesa.Estado == EstadosMesa.Ocupada&&currentMesa.Ocupada)
			{ button5.Text = "Ordenar";
				label4.Text = m.getMesero((int)currentMesa.Idmesonero).Nombre;
			}
			else
			{ button5.Text = "Abrir";
			  label4.Text = "DISPONIBLE";
			}
			
		

		}
		public void Cambia()
		{
		
			MuestraMesas();
			MessageBox.Show("cambia");
		}
		private void DiagramaMesas_Load(object sender, EventArgs e)
		{
			DataTable dt = new DataTable();
			dt = areaControl.GetAll();
			listBox1.DataSource = dt;
			listBox1.ValueMember = "Id";
			listBox1.DisplayMember = "Area";
			listBox1.SelectedValue = areaControl.GetAll().Rows[0].ItemArray[0];
		}

		private void button5_Click(object sender, EventArgs e)
		{


			g.SetMesa(this.currentMesa);
			botonera.Cambia();
			if (((Button)sender).Text == "Abrir")
			{
				DialogResult Dresult = AbrirMesa(this.currentMesa.Siglas);
				if (Dresult == DialogResult.OK)
				{
					mesaManager.Edit(currentMesa);

				}
			}
			if (((Button)sender).Text != "Abrir")
			{
				this.SendToBack();
			}
			secuencia.getTicket();
		}

		private DialogResult AbrirMesa(string mesa)
		{
			AbrirMesaFrm am = new AbrirMesaFrm();
			am.ShowDialog();
			if (am.DialogResult != DialogResult.OK)
				mesaManager.ChangeStatusMesa(currentMesa, am.abrirmesaResults);
			if (currentMesa.Estado == EstadosMesa.Ocupada)
			{ button5.Text = "Ordenar"; }
			else
			{ button5.Text = "Abrir"; }
			refrescar();
			return am.DialogResult;
		}

		private void refrescar()
		{
			ShowMesas(this.flowLayoutPanel2, currentArea,nmesas);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (currentMesa.Ocupada == false)
				return;
			totaliza = true;
			g.currMesa = currentMesa;
			g.SetMesa(this.currentMesa);
			botonera.Cambia();
			totaliza = false;
			//((Botonera)ctrl).Li
		
			//((Botonera)Parent.Parent.Controls.Find("botonera", true).carga
			//((Botonera)ctrl).Carga(currentMesa.Siglas,0);
			this.SendToBack();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			MoveFrm move = new MoveFrm(currentMesa.Siglas);
			move.TopMost=true;
			move.ShowDialog();
			refrescar();
		}

		private void button7_Click(object sender, EventArgs e)
		{
			if (currentMesa.Ocupada && currentMesa.Estado != 0)
			{ 
				DetalleMesaForm dt = new DetalleMesaForm(currentMesa.Siglas);
			dt.ShowDialog();
		}
			

		}

		private void DiagramaMesas_VisibleChanged(object sender, EventArgs e)
		{
			
		}

		private void flowLayoutPanel2_Enter(object sender, EventArgs e)
		{
			
		}
	}
}
