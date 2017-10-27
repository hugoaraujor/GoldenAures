namespace AurumRest{	using System;	using System.Collections.Generic;	using System.Data;	using System.Windows.Forms;
	public partial class BusquedaFrm : Form	{		DataSet ds = new DataSet();		private string _criterio = "";		private string _campo = "";		private List<String> _ListaBuscar;		private int index { get; set; }		DataTable dt = new DataTable();		public BusquedaFrm(Search_Params busqueda)		{
			
			InitializeComponent();			index = 0;			_ListaBuscar = busqueda.parametros;			_campo = busqueda.palabra;			this.textBox1.Text = _campo;
			dt=busqueda.data;
			this.dataGridView1.DataSource = dt;			this.comboBox1.Text = _ListaBuscar[0];			if (_ListaBuscar.Count > 0)			{				foreach (string s in _ListaBuscar)					this.comboBox1.Items.Add(s);			}			else				this.comboBox1.Visible = false;			this.dataGridView1.Columns[0].Visible = false;		}
		public int GetValue()		{ 			return index;
		}
		public void SetCriteria(string Wbuscar)		{			_criterio = this.textBox1.Text;
		}
		private void button1_Click(object sender, EventArgs e)		{			Buscar();		}
		private void Buscar()		{			if (this.textBox1.Text.Length == 0)				(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = "";			else			{
				Console.Write("" + comboBox1.Text + " LIKE '%" + this.textBox1.Text.ToLower() + "%'");				(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = comboBox1.Text+" LIKE '%" + this.textBox1.Text.ToLower() + "%'";

			}		}


		private void BusquedaFrm_Load(object sender, EventArgs e)		{

		}
		private void textBox1_TextChanged(object sender, EventArgs e)		{

		}
		private void textBox1_KeyUp(object sender, KeyEventArgs e)		{			if (e.KeyCode == Keys.Enter)			{				Buscar();
			}			if (e.KeyCode == Keys.Escape)			{				this.Close();
			}		}
		private void dataGridView1_DoubleClick(object sender, EventArgs e)		{			selecciona();		}
		private void selecciona()		{			if (dataGridView1.SelectedRows.Count == 1)				index = (int)dataGridView1.SelectedRows[0].Cells[0].Value;			this.Close();		}
		private void button2_Click(object sender, EventArgs e)		{			selecciona();		}	}}
