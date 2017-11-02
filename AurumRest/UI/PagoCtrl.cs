using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AurumData;
using AurumBusiness.Controllers;

namespace AurumRest
{
	public partial class PagoCtrl : UserControl
	{ public MontoPago Pago=new MontoPago();
		public string clase { get; set; }
		public bool confirmed { get; set; }
		public PagoCtrl()
		{
			InitializeComponent();
			confirmed = false;
		}
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
		{  switch (comboBox1.Text)
			{
				case "Efectivo":
                    comboBox3.Enabled = false;
					textoBoxp19.Focus();
					break;
				case "Débito":
					comboBox3.DataSource = null;
					BancoLista bM = new BancoLista();
					llenacombo(bM);
					break;
				case "Cheque":
					comboBox3.DataSource = null;
					BancoLista bMM = new BancoLista();
					llenacombo(bMM);
					break;
				case "Crédito":
					TarjetaLista Tm = new TarjetaLista();
					llenacombo(Tm);
					break;
				case "Alimentación":
					TicketsLista Tmt = new TicketsLista();
					llenacombo(Tmt);
					break;
			}
				comboBox3.Focus();
			
		}
		public void llenacombo(IListStrategy modulo)
		{
			comboBox3.DataSource = modulo.GetData();
			comboBox3.ValueMember = "index";
			comboBox3.DisplayMember = "Descriptor";
			comboBox3.Enabled = true;

		}
		public void SetValues(MontoPago m)
		{
			this.comboBox1.Text = m.ClasePago.ToString();
			this.comboBox3.Text = m.Tipo.ToString();
			this.textoBoxp19.Text =m.Monto.ToString();
		}
	
		private void textoBoxp19_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
				Pago.Monto = Math.Round(Convert.ToDecimal(this.textoBoxp19.Text),2);

		}

		private void textoBoxp19_Leave(object sender, EventArgs e)
		{
			Pago.Monto = Math.Round(Convert.ToDecimal(this.textoBoxp19.Text),2);
		}

		private void comboBox1_Leave(object sender, EventArgs e)
		{
			confirmapago();
		}

		private void confirmapago()
		{
			var Forma = (TotalForm)Parent.FindForm();
			confirmed = true;
			clase = comboBox1.Text;
			var pagado = Forma.TotalesPago.pagado;
			if ((this.textoBoxp19.Text != "") && aplicadescuento())
			{
				Forma.displaytotales();
				this.textoBoxp19.Text = string.Format("{0:0.00}", ((TotalForm)Forma).TotalesPago.resta);
				Forma.label13.Text = string.Format("{0:0.00}", Forma.TotalesPago.resta - pagado);

			}
		}

		private bool aplicadescuento()
		{ var Ret = false;
			var Forma=(TotalForm)Parent.FindForm();
			var totales = Forma.TotalesPago;
		    var hayefectivo = Forma.hayEfectivo();
			var mtotpagar = totales.totalNeto;
			Ivatipo iva;
			if (this.comboBox1.Text != ClasePago.Efectivo.ToString() && (!hayefectivo))
			{
				iva = Ivatipo.General;
				if (mtotpagar > 0 && mtotpagar <= 2000000)
				{
					iva = Ivatipo.Reducido;
				}
				if (mtotpagar >= 5000000 && mtotpagar < 100000000)
				{
					//iva = new Global().secuencia.getIva(Ivatipo.Ampliado);
					iva = Ivatipo.Ampliado;
				}
				Ret = true;
			}
			else
			{
				 iva = Ivatipo.General;
			}
			Forma.calculaValores(iva, Forma.TotalesPago.descuento);
			Forma.displaytotales();
			return Ret;
		}
		private void button2_Click(object sender, EventArgs e)
		{
			var Forma = Parent.FindForm();
			label1.BackColor = Color.White;
				Pago.Monto = Convert.ToDecimal(textoBoxp19.Text);
				Enum.TryParse(comboBox1.Text, out ClasePago myStatus);
				Pago.ClasePago = myStatus;
				Pago.Detalle = this.comboBox3.Text;
			Pago.Tipo = comboBox1.SelectedIndex.ToString();
			Pago.Cambio =Math.Abs( Convert.ToDecimal(((TotalForm)Forma).label13.Text) -Pago.Monto);
			Pago.ClasePago = myStatus;
			
				this.Tag = Pago;
			
				confirmed = true;
				((TotalForm)Forma).AgregaPago(Pago);
				button2.Visible = false;
				this.comboBox1.Enabled = false;
				this.comboBox3.Enabled = false;
				textoBoxp19.Enabled = false;
		}

		private void comboBox3_Leave(object sender, EventArgs e)
		{
			textoBoxp19.Focus();
		}
	}
}
