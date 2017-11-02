using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurumRest
{
	public enum Cierreenum
	{
		X,
		Z
	}
	public class Search_Params
	{
		public List<String> parametros { get; set; }
		public DataTable data { get; set; }
		public String palabra { get; set; }
	}
	public enum Ivatipo
	{
		General,
		Ampliado,
		Reducido
	}
	public enum errorType
	{   Normal,
		Info,
		Error,
		Alert
	}
	public enum BoxType
	{
		Numeric,
		Date,
		Text,
		Age,
		Name,
		Integer,
		Decimal,
		Porcentaje

	}
	public enum RecordAction
	{   Save,
		None,
		Insert,
		Delete,
		Update,
		Undo,
		Search
		
	}
	public class Iva
	{
		string reducido { get; set; }
		string Ampliado { get; set; }
		string General { get; set; }

	

		public void getDefaultValues()
		{
			 reducido = "0700";
			 Ampliado = "0900";
			 General = "1200";
		}
		public  string getIvaString(char letter)
		{
			string resp = General;

			if (letter.ToString().ToUpper() == "R")
			{ resp = reducido;
			}

			if (letter.ToString().ToUpper() == "A")
			{ resp = Ampliado;
			}

			return resp;
		}
	}
	public class Utilities
	{
		public enum busqueda
		{
			Clientes

		}

		public static DataTable ConvertToDataTable<T>(IList<T> data)
		{
			PropertyDescriptorCollection properties =
			   TypeDescriptor.GetProperties(typeof(T));
			DataTable table = new DataTable();
			foreach (PropertyDescriptor prop in properties)
				table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
			foreach (T item in data)
			{
				DataRow row = table.NewRow();
				foreach (PropertyDescriptor prop in properties)
					row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
				table.Rows.Add(row);
			}
			return table;

		}

		public static string GetTipo(Control tipo)
		{
			string tipod = tipo.GetType().ToString().ToLower();
			string lastword = tipod.Substring(tipo.GetType().ToString().LastIndexOf(".") + 1, (tipo.GetType().ToString().Length - (tipo.GetType().ToString().LastIndexOf(".") + 1)));
			Console.Write(lastword);
			return lastword;
		}
		public static void DataGridLayout(DataGridView xdataGridView1)
		{
			xdataGridView1.Columns[0].Visible = false;
			xdataGridView1.Columns[1].Visible = false;
			xdataGridView1.Columns[2].Visible = false;
			xdataGridView1.Columns[3].Width = 145;
			xdataGridView1.Columns[4].Width = 50;
			xdataGridView1.Columns[5].Width = 75;
			xdataGridView1.Columns[6].Width = 100;
			DataGridViewCellStyle style = new DataGridViewCellStyle();
		style.Format = "N2";
			xdataGridView1.Columns[5].DefaultCellStyle = style;
			xdataGridView1.Columns[4].DefaultCellStyle = style;
			xdataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			xdataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			xdataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

			xdataGridView1.Columns[7].Visible = false;
			xdataGridView1.Columns[8].Visible = false;
			xdataGridView1.Columns[9].Visible = false;
			xdataGridView1.Columns[10].Visible = false;
			xdataGridView1.Columns[11].Visible = false;
			xdataGridView1.Columns[12].Visible = false;
			xdataGridView1.Columns[13].Visible = false;
			xdataGridView1.Columns[14].Visible = false;
			xdataGridView1.Columns[15].Visible = false;
			xdataGridView1.Columns[16].Visible = false;
			xdataGridView1.Columns[17].Visible = false;
			xdataGridView1.Columns[18].Visible = false;

		}
		public static void Mensaje(AurumRest.ErrorBar msgBar, string v, errorType alert)
		{
			msgBar.Mensaje = v;
			msgBar.Status = alert;
		}
		public static void Controles(Control forma,string action)
		{
			foreach(Control c in forma.Controls)
			{
				if (action == "Unlock")
				{
					var aux = "textbox,combobox,listbox,checkbox,datecontrol,tabcontrol,textoboxp".IndexOf(Utilities.GetTipo(c));
					if ("textbox,combobox,listbox,datecontrol,checkbox,tabcontrol,textoboxp".IndexOf(Utilities.GetTipo(c)) > -1 && (c.Enabled == false))
					{
						c.Enabled = true;
					}
					if ("tabcontrol,panel,groupbox".IndexOf(Utilities.GetTipo(c)) > -1 && (c.Enabled == false))
					{
						c.Enabled = true;
					Controles(c, "Unlock");
					}
				}
				if (action == "Reset")
				{
					if ("textbox,combobox,listbox,datecontrol,checkbox,tabcontrol,textoboxp".IndexOf(Utilities.GetTipo(c)) > -1 && (c.Enabled == false))
					{
						if (Utilities.GetTipo(c) != "checkbox")
							c.Text = "";
						else
							((CheckBox)c).Checked = false;
					}
					
				}
				if (action == "Lock")
				{
					if ("textbox,combobox,listbox,checkbox,datecontrol,tabcontrol,textoboxp".IndexOf(Utilities.GetTipo(c)) > -1 && (c.Enabled == true))
					{
						c.Enabled = false;
					}
					if ("tabcontrol,panel,groupbox".IndexOf(Utilities.GetTipo(c)) > -1 && (c.Enabled == true))
					{
						c.Enabled = false;
					Controles(c, "Unlock");
					}

				}
			}
          }

	
	}
}
