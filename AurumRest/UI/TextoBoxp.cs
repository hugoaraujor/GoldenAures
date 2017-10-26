using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace AurumRest
{
	public partial class TextoBoxp : TextBox
	{

		[Category("PlaceHolder"), DefaultValue(typeof(string), "Ingreso")]
		string entry;

		[Category("IsDecimal"), DefaultValue(typeof(bool),"False")]
		bool isDecimal;
		[Category("IsInteger"), DefaultValue(typeof(bool), "False")]
		bool isInteger;
		[Category("IsPercent"), DefaultValue(typeof(bool), "False")]
		bool isPercent;
		Color colorOrigen;
		public bool IsInteger
		{
			get { return isInteger; }
			set
			{
				isInteger = value;

			}

		}
		public bool IsPercent
		{
			get { return isPercent; }
			set
			{
				isPercent = value;

			}

		}
		public bool IsDecimal
		{
			get { return isDecimal; }
			set
			{
				isDecimal = value;
				
			}

		}
		[Category("IsCode"), DefaultValue(typeof(int), "000000")]
		bool isCode;
		
		public bool IsCode
		{
			get { return isCode; }
			set
			{
				isCode = value;

			}

		}
		public TextoBoxp()
		{
			InitializeComponent();
			this.KeyPress += TextoBoxp_KeyPress;
			this.KeyDown += TextoBoxp_KeyDown;
			this.LostFocus += TextoBoxp_LostFocus;
		
		}

		private void TextoBoxp_LostFocus(object sender, EventArgs e)
		{
			this.BackColor = Color.White;
			if (isInteger)
			{

				try
				{
					if (this.Text != "")
						this.Text = (String.Format("{0:0}", Convert.ToInt16(this.Text)));

				}
				catch
				{ }

				TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			}
			if (isDecimal)
			{
				
					try
					{
						if (this.Text != "")
							this.Text = (String.Format("{0:0.00}", Decimal.Parse(this.Text)));

					}
					catch
					{ }
				
				TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			}
			if (isCode)
			{

				try
				{
					if (this.Text != "")
						this.Text = (String.Format("{0:000000}", Decimal.Parse(this.Text)));

				}
				catch
				{ }

				TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			}
			if (isPercent)
			{

				try
				{
					if (this.Text != "")
					{
						this.ForeColor = (Color)colorOrigen;
						this.Text = string.Format("{0:00.00}",Decimal.Parse(this.Text))+"%";
					}

				}
				catch
				{ }

				TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			}
		}

		private void TextoBoxp_KeyDown(object sender, KeyEventArgs e)
		{
		if (this.Text == "0,00" || this.Text == "0" || this.Text == "" || this.Text==entry)
			{
				this.ForeColor = (Color) colorOrigen;
				this.Text = "";

			}
			if (this.Text.Length == 1 && e.KeyCode==Keys.Back)
			{
				this.ForeColor = Color.LightGray;
				this.Text = entry;

			}
			
		}

		private void TextoBoxp_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (Char)13)
			{

				Control ctrl = GetNextControl(this, true);
				//	Parent.SelectNextControl(this, true, true, false, false);
				//ctrl.Focus();
			}

			if (isDecimal)
			{
				NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
				string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
				string groupSeparator = numberFormatInfo.NumberGroupSeparator;
				string negativeSign = numberFormatInfo.NegativeSign;
				// Workaround for groupSeparator equal to non-breaking space 
				if (groupSeparator == ((char)160).ToString()&&(!(isCode)))
				{
					groupSeparator = " ";
				}
				string keyInput = e.KeyChar.ToString();
				if (Char.IsDigit(e.KeyChar))
				{
					// Digits are OK
				}
				else if ((keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
				 keyInput.Equals(negativeSign))&& (!(isCode)))
				{
					// Decimal separator is OK
				}
				else if (e.KeyChar == '\b')
				{
				//Backspace key is OK
				}
				//    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0) 
				//    { 
				//     // Let the edit control handle control and alt key combinations 
				//    } 
				else
				{
					// Consume this invalid key and beep
					e.Handled = true;
					//    MessageBeep();
				}
			}
		}

		public string Entry
		{
			get { return entry; }
			set
			{
				entry = value;
				colorOrigen = this.ForeColor;
				this.ForeColor = Color.LightGray;
				this.Text = entry;
				this.Invalidate();
			}

		}

		
	}
}
