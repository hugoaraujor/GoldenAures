using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurumRest
{
	public partial class ErrorBar : UserControl
	{

		[Category("Mensaje"), DefaultValue(typeof(string), "None")]
		[Description("The Error Bar Message")]
		string mensaje;
		errorType status;
		public string Mensaje {
			get { return mensaje; }
			set
			{
				mensaje = value;
				label1.Text = mensaje;
				this.Visible = true;
				this.timer1.Enabled = true;
				this.Invalidate();
			}
			
		}
		[Category("status"), DefaultValue(errorType.Info)]
		[Description("The Error Bar Message")]
		public errorType Status
		{
			get { return status; }
			set
			{
				status = value;
				switch (status)
				{
					case errorType.Normal:
						
						this.label1.BackColor = Color.WhiteSmoke;
						break;
					case errorType.Info:
						this.label1.BackColor = Color.Honeydew;
						break;
					case errorType.Alert:
						this.label1.BackColor = Color.MistyRose;
						break;
					default:
						this.label1.BackColor = Color.LightGoldenrodYellow;
						break;
				}

				this.Invalidate();
			}

		}
		
		public ErrorBar()
		{

			InitializeComponent();

			this.Visible = false;
			


		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			this.Visible = false;
			this.timer1.Enabled = false;

		}
	}
}

