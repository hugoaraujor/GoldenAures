﻿namespace AurumRest
	public partial class BusquedaFrm : Form
			
			InitializeComponent();
			dt=busqueda.data;
			this.dataGridView1.DataSource = dt;
		public int GetValue()
		}
		public void SetCriteria(string Wbuscar)
		}
		private void button1_Click(object sender, EventArgs e)
		private void Buscar()
				Console.Write("" + comboBox1.Text + " LIKE '%" + this.textBox1.Text.ToLower() + "%'");

			}


		private void BusquedaFrm_Load(object sender, EventArgs e)

		}
		private void textBox1_TextChanged(object sender, EventArgs e)

		}
		private void textBox1_KeyUp(object sender, KeyEventArgs e)
			}
			}
		private void dataGridView1_DoubleClick(object sender, EventArgs e)
		private void selecciona()
		private void button2_Click(object sender, EventArgs e)