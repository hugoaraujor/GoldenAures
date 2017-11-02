using AurumBusiness.Controllers;
using AurumData;
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
	public partial class TurnosFrm : Form
	{
        RecordAction status = new RecordAction();
		private int Currentindex = 0;
	    TurnoManager	turnoManager  = new TurnoManager();
		TurnoDTO currentTurno = new TurnoDTO();
		Data Context = new Data();
		private void TurnosFrm_Load(object sender, EventArgs e)
		{
			currentTurno.Idturno = -1;
			if (turnoManager.GetList().Count > 0)
			{
				loadCombo();
				Console.WriteLine(listBox1.SelectedValue);
				errorBar1.Mensaje = "No hay Registros.";
				errorBar1.Status = errorType.Info;

			}
			
		}

		private void loadCombo()
		{
			listBox1.DataSource = null;
			listBox1.DisplayMember = "Turnodesc";
			listBox1.ValueMember = "Idturno";
			listBox1.DataSource = Context.Turnos.ToArray();

			listBox1.SelectedValue = 0;
		}

		public void SeleccionoBarra()
		{


			this.textoBoxp1.Focus();
			
			if (comandBar1.Status == RecordAction.None)
			{
			   Utilities.Controles(this,"Lock");
			}
			if (comandBar1.Status == RecordAction.Insert)
			{
				this.labelindex.Text = "-1";
				textoBoxp1.Text = "";
					textoBoxp2.Text = "";
				textoBoxp3.Text = "";

			}
			if (comandBar1.Status == RecordAction.Insert || (comandBar1.Status == RecordAction.Update))
			{
				
				textoBoxp1.Focus();
				textoBoxp1.Enabled = true;
				textoBoxp2.Enabled = true;
				textoBoxp3.Enabled = true;
				listBox1.Enabled = false;
				textoBoxp1.Focus();
			}

			if (comandBar1.Status == RecordAction.Delete && comandBar1.confirma)
			{
				turnoManager.Delete(currentTurno.Idturno);
				this.comandBar1.confirma = false;
				textoBoxp1.Enabled = false;
				textoBoxp2.Enabled = false;
				textoBoxp3.Enabled = false;
				this.labelindex.Text = "-1";
				textoBoxp1.Text = "";
				textoBoxp2.Text = "";
				textoBoxp3.Text = "";
			}
			if (comandBar1.Status == RecordAction.Save)
			{
				var aux = "";// validaforma();
				//if (aux != "")
				//{
				//	errorBar1.Mensaje = aux;
				//	errorBar1.Status = errorType.Error;
				//	this.comandBar1.Novalido();
				//	return;
				//}
				//if (comandBar1.Status == RecordAction.Save)
				{
					currentTurno = new TurnoDTO
					{ Idturno = Convert.ToInt16(labelindex.Text),
						Turnodesc = textoBoxp1.Text,
						 Desde= textoBoxp2.Text,
				          Hasta = textoBoxp3.Text
				};
				}
				if (comandBar1.Status == RecordAction.Save && comandBar1.previo == RecordAction.Insert && aux == "")
				{

					var aux1 = validarRegistro(currentTurno);
					if (aux1.Length > 0)
					{
						Utilities.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					turnoManager.Insert(currentTurno);
					this.comandBar1.previo = RecordAction.None;
					reset();
					
				}

				if (comandBar1.Status == RecordAction.Save && comandBar1.previo == RecordAction.Update && aux == "")
				{

					var aux1 = validarRegistro(currentTurno);
					if (aux1.Length > 0)
					{
						Utilities.Mensaje(errorBar1, aux1, errorType.Error);
						return;
					}
					turnoManager.Edit(currentTurno);
					this.comandBar1.previo = RecordAction.None;
					
					
				}


			}
			loadCombo();
			listBox1.Enabled = true;
			listBox1.Focus();
		}

		private void reset()
		{
			textoBoxp1.Enabled = false;
			textoBoxp2.Enabled = false;
			textoBoxp3.Enabled = false;
			this.labelindex.Text = "-1";
			textoBoxp1.Text = "";
			textoBoxp2.Text = "";
			textoBoxp3.Text = "";
		}

		private string validarRegistro(TurnoDTO currentTurno)
		{
			return "";
		}

		public TurnosFrm()
		{
			InitializeComponent();
			this.comandBar1.OnUserControlButtonClicked += new comandBar.ButtonClickedEventHandler(OnUCButtonClickHandler);
		}

		private void OnUCButtonClickHandler(object sender, EventArgs e)
		{
			// Handle event here

			if (this.comandBar1.Status != RecordAction.Undo)
			{
			 this.listBox1.Focus();
				SeleccionoBarra();
			}
			
		}






		private void DespliegaCampos()
		{
			int n = 0;
			if (currentTurno != null&& listBox1.SelectedValue!=null)
			{
					n=Convert.ToInt16(listBox1.SelectedValue.ToString());
				labelindex.Text =n.ToString();
				var ndx = Convert.ToInt16(labelindex.Text);
				
				Turno x = turnoManager.GetTurno(ndx);
				textoBoxp1.Text = x.Turnodesc;
				textoBoxp2.Text = x.Desde;
				textoBoxp3.Text = x.Hasta;
			}
		}

		


		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
				(e.KeyChar != '-'))
			{
				e.Handled = true;
			}

			// only allow one decimal point
			if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
			{
				e.Handled = true;
			}
		}
		public bool IsNumeric(string value)
		{
			return value.All(char.IsNumber);
		}



		private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
				(e.KeyChar != '-') &&
				(e.KeyChar != '(') &&
					(e.KeyChar != '+') &&
						(e.KeyChar != ' ') &&
				(e.KeyChar != ')'))
			{
				e.Handled = true;
			}

			// only allow one decimal point
			if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > 0))
			{
				e.Handled = true;
			}
			// only allow one decimal point
			if ((e.KeyChar == '(') && ((sender as TextBox).Text.IndexOf('(') > -1))
			{
				e.Handled = true;
			}
			if ((e.KeyChar == ')') && ((sender as TextBox).Text.IndexOf(')') > -1))
			{
				e.Handled = true;
			}
			if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1) && ((sender as TextBox).Text.IndexOf(' ') > -1))
			{
				e.Handled = true;
			}
			if ((e.KeyChar == ' ') && ((sender as TextBox).Text.IndexOf(' ') < -3))
			{
				e.Handled = true;
			}
		}

		private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (char.IsControl(e.KeyChar) &&
				(e.KeyChar != '&') &&
				(e.KeyChar != '+') &&
				(e.KeyChar != '-') &&
				(e.KeyChar != 'Ñ') &&
				(e.KeyChar != '(') &&
				(e.KeyChar != ')') &&
				(e.KeyChar != '.') &&
				(e.KeyChar != ','))
			{
				e.Handled = true;
			}
		}



	
		private void textBox1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				textoBoxp2.Focus();
			}

		}

		private void textBox2_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
			 this.textoBoxp3.Focus();
			}
		}

		private void textBox3_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				this.listBox1.Focus();
			}
		}

		private void ListBox1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				textoBoxp1.Focus();
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			currentTurno = new TurnoDTO() { Desde = textoBoxp2.Text, Hasta = textoBoxp3.Text, Turnodesc = textoBoxp1.Text, Idturno = Convert.ToInt16(labelindex.Text) };
			DespliegaCampos();
		}

		private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}
	}

}

