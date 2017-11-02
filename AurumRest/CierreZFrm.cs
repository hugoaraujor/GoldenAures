using System;
using System.Collections.Generic;
using System.ComponentModel;
using AurumBusiness;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AurumData;
using AurumBusiness.Controllers;

namespace AurumRest
{
	public partial class CierreZFrm : Form
	{
		List<string> reporte = new List<string>();
		public Decimal[] total = new Decimal[7];
		public Cierreenum tipo = new Cierreenum();
		public CierreZFrm(Cierreenum cierra)
		{
			InitializeComponent();
			tipo = cierra;
		}

		private void buttonrealizar_Click(object sender, EventArgs e)
		{
			FacturasManager fm = new FacturasManager();
			var FacturasPendientesdeCierre = Cargadatos();
			if (FacturasPendientesdeCierre.Count == 0)
			{ errorBar1.Mensaje = "No Cierres pendientes";
				errorBar1.Status = errorType.Info;
				return;
			}
			IPrinterFIOperaciones IP = new ImpresionBematech();
			var proximoreporte = string.Format("{0:0000000}", Convert.ToInt16(this.label8.Text) + 1);
			if (tipo == Cierreenum.Z)
			{ fm.Cerrar(FacturasManager.Cierreenum.Z, proximoreporte);
			   IP.LecturaZ();
			}
			else
			{ fm.Cerrar(FacturasManager.Cierreenum.X, proximoreporte);
			  IP.LecturaX();
			}

			
			
			ProducirReporte();
		}

		private void ProducirReporte()
		{
			IPrinterFIOperaciones IP = new ImpresionBematech();
			reporte.Add(("REPORTE CIERRE" + "  " + tipo.ToString()).PadRight(47) + "\n\n");
			reporte.Add("APERTURA".PadRight(47) + "\n\n");
			reporte.Add("01 Efectivo".PadRight(26) + this.txtApertura.Text.PadLeft(21) + "\n\n");			reporte.Add("Formas de Pago".PadRight(47) + "\n\n");
			reporte.Add("01 Efectivo".PadRight(26) + this.textoBoxp1.Text.PadLeft(21) + "\n");
			reporte.Add("02 Debito".PadRight(26) + this.textoBoxp2.Text.PadLeft(21) + "\n");
			reporte.Add("03 Crédito".PadRight(26) + this.textoBoxp3.Text.PadLeft(21) + "\n");
			reporte.Add("04 Cesta Ticket".PadRight(26) + this.textoBoxp4.Text.PadLeft(21) + "\n");
			reporte.Add("05 Cheque".PadRight(26) + this.textoBoxp5.Text.PadLeft(21) + "\n");
			reporte.Add("06 Alimentación".PadRight(26) + this.textoBoxp6.Text.PadLeft(21) + "\n");
			reporte.Add("TOTAL PAGOS ".PadRight(26) + this.label19.Text.PadLeft(21) + "\n\n");
			reporte.Add("Facturación".PadRight(47) + "\n");
			reporte.Add("TOTAL NETO".PadRight(26) + this.txtNeto.Text.PadLeft(21) + "\n");
			reporte.Add("TRIBUTADO".PadRight(26) + this.txtxIva.Text.PadLeft(21) + "\n");
			reporte.Add("TOTALES FACTURACION".PadRight(26) + this.txttotal.Text.PadLeft(21) + "\n");
			reporte.Add("Facturas".PadRight(26) + this.txtxnrofacts.Text.PadLeft(21) + "\n");
			reporte.Add("Intervalo".PadRight(26) + (this.desdelabel.Text + "-" + this.hastalabel.Text).PadLeft(21) + "\n");
			IP.ImprimeReporteGerencial(reporte);
		}

		//Facturas del Dia

		private List<AurumData.Factura> Cargadatos()
		{
			using (var db = new Data())
			{
				var query = db.Facturas.Where(f => f.Cierrez==null).Select(f => f).ToList();
				return query;
			}

		}
		private Decimal CargaAperturas()
		{
			using (var db = new Data())
			{
				var amount = db.Aperturas.Where(f => f.Cerrada == false).Select(f => f).Sum(f=>f.Monto);
				return amount;
			}

		}
		private void  Totales( ref Decimal[] total)
		{
			var apertura = CargaAperturas();
			var facturasdeldia = Cargadatos();
			var sneto = facturasdeldia.Sum(f => f.Montoneto);
			var stotal = facturasdeldia.Sum(f => f.Total);
			var siva = facturasdeldia.Sum(f => f.Montoiva);
			var stotaFacturas = facturasdeldia.Count();

			var desde = facturasdeldia.Where(f=>f.Facturanro!="      ").Min(f => f.Facturanro);
			var hasta = facturasdeldia.Max(f => f.Facturanro);

			total[0] = stotaFacturas;
			total[1] = sneto;
			total[2] = siva;
			total[3] = stotal;
			total[4] = Convert.ToDecimal(desde);
			total[5] = Convert.ToDecimal(hasta);
			total[6] = Convert.ToDecimal(apertura);

		}

		private void CierreZFrm_Load(object sender, EventArgs e)
		{
			IPrinterFIOperaciones IP = new ImpresionBematech();
			var aux =   IP.NumerodeCierresZ().Replace("\0","");
			var numeroc = Convert.ToInt16(aux);
			label8.Text = string.Format("{0:0000000}",numeroc);
			string numero = "      ";

			
			fechalabel.Text = DateTime.Today.ToShortDateString();

			Totales(ref total);
			ParametrosManager p = new ParametrosManager();

			Seriallabel.Text = Global.Instancia.GetParametros().Serial;
			//if (this.txttotal.Text == "0")
				//return;
			DialogResult resp = MessageBox.Show("Esta seguro de efectuar el Cierre Z?", "Confirmación", MessageBoxButtons.YesNo);
			if (resp == DialogResult.No) return;
			txtNeto.Text = string.Format("{0:0.00}",total[1].ToString());
			txtxIva.Text = string.Format("{0:0.00}",total[2].ToString());
			txttotal.Text = string.Format("{0:0.00}",total[3].ToString());
			txtxnrofacts.Text = string.Format("{0:0.00}",total[0].ToString());
			txtApertura.Text= string.Format("{0:0.00}", total[6].ToString());

			desdelabel.Text = string.Format("{0:000000}", total[4]);
			hastalabel.Text = string.Format("{0:000000}", total[5]);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}

		private void textoBoxp5_Leave(object sender, EventArgs e)
		{
			if (((TextoBoxp)sender).Text == "")
			{
				((TextoBoxp)sender).Focus();
				return; }

			var suma = Convert.ToDecimal(textoBoxp1.Text)+ Convert.ToDecimal(textoBoxp2.Text) + Convert.ToDecimal(textoBoxp3.Text) + Convert.ToDecimal(textoBoxp4.Text) + Convert.ToDecimal(textoBoxp5.Text) + Convert.ToDecimal(textoBoxp6.Text);
			label19.Text = string.Format("{0:0.00}",suma);
		}

	}
}

