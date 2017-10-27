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
using AurumDataEntities;
using static AurumRest.Utilities;
namespace AurumRest
{
	public partial class ClienteFrm : Form
	{
		RecordAction status = new RecordAction();
		private int Currentindex = 0;
		ClienteManager cli = new ClienteManager();
		ClienteDTO currentcliente = new ClienteDTO( );
		
		public ClienteFrm()
		{
			
			InitializeComponent();
		}


		private void BorrarBtn_Click(object sender, EventArgs e)
		{
			status = RecordAction.Delete;
			if (currentcliente != null )
			{
				if (currentcliente.Idcliente != -1)
				{
					var resp = MessageBox.Show("Desea Borrar el registro?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
					if (resp == DialogResult.OK && Currentindex > 0)
					{
						cli.Delete(Currentindex);
					}
					currentcliente.Idcliente = -1;
					Utilities.Controles(this.panel1, "Reset");

					Utilities.Mensaje(errorBar1, "El Registro ha sido eliminado con exito", errorType.Alert);
				}
			}
			else
			{		Utilities.Mensaje(errorBar1, "Debe seleccionar un usuario", errorType.Info);	}


		}

		

		private void EditarBtn_Click(object sender, EventArgs e)
		{
			if (currentcliente != null)
			{
				if (currentcliente.Idcliente != -1)
				{
					status = RecordAction.Update;
					DesactivarBotonesEdicion();
					Auxiliares(true);
					Utilities.Controles(this, "Unlock");
				}
				else
				{ Utilities.Mensaje(errorBar1, "Debe seleccionar un usuario", errorType.Info); }
				
			}
		}

		private void LupaBtn_Click(object sender, EventArgs e)
		{
			Carga_Busqueda();


		}

		private void Carga_Busqueda()
		{
			Search_Params Sp = new Search_Params();
			ClienteManager cm = new ClienteManager();
			Sp.data = cm.GetClientes();
			Sp.palabra = "";
			Sp.parametros = new List<string>();
			Sp.parametros.Add("Nombre");
			Sp.parametros.Add("Identificación");
			Sp.parametros.Add("Teléfonos");

			BusquedaFrm BF = new BusquedaFrm(Sp);
			BF.ShowDialog();
			var seleccion = BF.GetValue();
			if (seleccion > -1)
			{
				Currentindex = seleccion;
				currentcliente = cli.GetClienteDTO(Currentindex);
				DespliegaCampos();
				Console.WriteLine(Currentindex);
			}
		}

		private void DespliegaCampos()
		{
			if (currentcliente != null)
			{
				this.checkBox1.Checked = currentcliente.Credito;
				this.checkBox2.Checked = currentcliente.Debito;
				textBox4.Text = currentcliente.Direccion;
				this.textBox2.Text = currentcliente.Nombre;
				textBox3.Text = currentcliente.Telefono;
				try
				{
					comboBox1.Text = currentcliente.Identificacion.Substring(0, 2);
				}
				catch
				{
					comboBox1.Text = "V-";
				}
				try
				{
					textBox1.Text = currentcliente.Identificacion.Substring(2, currentcliente.Identificacion.Length - 2);
				}
				catch
				{
					this.textBox1.Text = "";
				}
				indice.Text = currentcliente.Idcliente.ToString();
			}
		}

		private void Deshacer_Click(object sender, EventArgs e)
		{
			status = RecordAction.None;
			Auxiliares(false);
			ActivarBotonesEdicion();
			Utilities.Controles(this, "Lock");
		}

		private void Auxiliares(bool valor)
		{
			GuardarBtn.Visible = valor;
			Deshacer.Visible = valor;
		}

		private void GuardarBtn_Click(object sender, EventArgs e)
		{
			ClienteDTO recordActual=new ClienteDTO { Idcliente = currentcliente.Idcliente, Credito = this.checkBox1.Checked, Debito = this.checkBox2.Checked, Direccion = textBox4.Text, Nombre = this.textBox2.Text, Telefono = textBox3.Text, Identificacion = comboBox1.Text + textBox1.Text };
			if (validarRegistro(recordActual)== "")
			{
				status = RecordAction.Save;
				ActivarBotonesEdicion();
				Auxiliares(false);

				if (status == RecordAction.Insert)	 cli.Insert(recordActual);
				if (status == RecordAction.Update)	 cli.Edit(recordActual);

				status = RecordAction.None;
			}
			else
			{
				Utilities.Mensaje(errorBar1, validarRegistro(recordActual), errorType.Error);
			}
		}
				
		private string validarRegistro( ClienteDTO newCliente)
		{
		   var aux =cli.existeCedula(newCliente);
			string msgValidate = "";
			if (newCliente.Identificacion =="")
				msgValidate = "Ingrese Cédula\n";
			if (aux && (newCliente.Identificacion != currentcliente.Identificacion))
				msgValidate = msgValidate +"Cédula del cliente ya Existente.\n";
			if (newCliente.Nombre=="")
				msgValidate = msgValidate + "Nombre del Cliente no puede ser dejado en Blanco\n";
			if (newCliente.Direccion == "")
				msgValidate = msgValidate + "Direccion del Cliente no puede ser dejado en Blanco\n";

			return msgValidate;
		}
		private void ActivarBotonesEdicion()
		{
			AgregarBtn.Visible = true;
			BorrarBtn.Visible = true;
			EditarBtn.Visible = true;
			LupaBtn.Visible = true;
			Utilities.Controles(this, "Lock");
		}

		private void DesactivarBotonesEdicion()
		{
			AgregarBtn.Visible = false;
			BorrarBtn.Visible = false;
			EditarBtn.Visible = false;
			LupaBtn.Visible = false;
			Auxiliares(true);
			
		}
		private void AgregarBtn_Click(object sender, EventArgs e)
		{
			status = RecordAction.Insert;
			DesactivarBotonesEdicion();
			Auxiliares(true);
			Utilities.Controles(this, "Unlock");
			
			
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
			if (char.IsControl(e.KeyChar)  &&
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

		

		private void ClienteFrm_Load(object sender, EventArgs e)
		{
			currentcliente.Idcliente = -1;
			if (cli.GetClientesRecords() == 0)
			{
				errorBar1.Mensaje = "No hay Registros.";
				errorBar1.Status = errorType.Info;
				
			}
			else
			{
				EditarBtn.Enabled = true;
				BorrarBtn.Enabled = true;
				AgregarBtn.Enabled = true;
			}

		}

		private void textBox1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				textBox2.Focus();
			}

		}

		private void textBox2_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				textBox3.Focus();
			}
		}

		private void textBox3_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				textBox4.Focus();
			}
		}

		private void textBox4_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				checkBox1.Focus();
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void checkBox1_KeyUp(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Enter)
			{
				checkBox2.Focus();
			}
		}

		private void checkBox2_KeyUp(object sender, KeyEventArgs e)
		{

			if (e.KeyCode == Keys.Enter)
			{
				this.textBox1.Focus();
			}
		}
	}

}

	
	
