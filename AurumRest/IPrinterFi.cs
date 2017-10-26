using AurumBusiness.Controllers;
using AurumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;


namespace AurumRest
{
 	public interface IPrinterFi
	{
		IFactura ImprimeFactura();
		void  ImprimeReporteGerencial();
	}

	public interface IFactura
	{   
		void Header();
		void DatosCliente(Cliente cliente);
		void Descuento();
		void Notas();
		void VendeProductos();
		void Pagos();
		void CierraFactura(Decimal descuento);
		bool Anulada();

		
	}
	public class ImprimeFacturaBematech : IFactura
	{
		private Cliente cliente;
		private List<TicketDetalle> lista;
		private TotalapagarView totales;
		private Mesa mesa;
		public ImprimeFacturaBematech(Mesa Mesa,List<TicketDetalle> Lista,TotalapagarView Totales )
		{
			mesa = Mesa;
			cliente = Totales.cliente;
			lista = Lista;
			totales = Totales;
		}
		public bool Anulada()
		{
			throw new NotImplementedException();
		}

		public void CierraFactura(decimal descuento)
		{
		
			if ((mesa.Siglas != "0") && (mesa.Siglas.IndexOf("LL") > -1))
				BemaFI32.Bematech_FI_FinalizarCierreCupon(mesa.Siglas+ " PARA LLEVAR." + " Gracias por su compra." );

			if ((mesa.Siglas != "0") && (mesa.Siglas.IndexOf("LL") == -1))
			{
				MesonerosManager MCtrller = new MesonerosManager();
				var atiende = MCtrller.getMesero((int)mesa.Idmesonero);
				var resp = BemaFI32.Bematech_FI_FinalizarCierreCupon("Mesa:" + mesa.Siglas + ".Atiende:" + atiende.Nombre);
			}

		}

		public void DatosCliente(Cliente cliente)
		{
			var n = BemaFI32.Bematech_FI_AbreComprobanteDeVentaEx(cliente.Identificacion, cliente.Nombre, cliente.Direccion);
			foreach (PagoView pv in totales.ListaPagos)
			{
				BemaFI32.Bematech_FI_EfectuaFormaPago(pv.clase, pv.montopago.ToString("{0:0.00}"));
			}
			if ((mesa.Siglas != "0") && (mesa.Siglas.IndexOf("LL") > -1))
				BemaFI32.Bematech_FI_FinalizarCierreCupon(mesa.Siglas + " PARA LLEVAR." + " Gracias por su compra.");

			if ((mesa.Siglas != "0") && (mesa.Siglas.IndexOf("LL") == -1))
			{
				MesonerosManager MCtrller = new MesonerosManager();
				var atiende = MCtrller.getMesero((int)mesa.Idmesonero);
				var resp = BemaFI32.Bematech_FI_FinalizarCierreCupon("Mesa:" + mesa.Siglas + ".Atiende:" + atiende.Nombre);
			}
		}

		public void Descuento()
		{
			if (totales.descuento > 0)
			{
				var n = BemaFI32.Bematech_FI_IniciaCierreCupon("D", "$", String.Format("{0:0.00}", Convert.ToDouble(totales.descuento)));			
			}
		}

		public void Header()
		{
			string NumeroSerial = new string(' ', 15);
			int iRetorno = BemaFI32.Bematech_FI_NumeroSerie(ref NumeroSerial);
			BemaFI32.Bematech_FI_AnulaCupon();
			
		}

		public void Notas()
		{
			throw new NotImplementedException();
		}

		public void Pagos()
		{
			foreach (PagoView pv in totales.ListaPagos)
			{
				var n = BemaFI32.Bematech_FI_EfectuaFormaPago(pv.clase, pv.montopago.ToString("{0:0.00}"));
			}
		}

		public void VendeProductos()
		{
			var prodVendido = lista;
			Global g = new Global();
			var imp = g.secuencia.getIva(totales.currentIva);
			foreach (TicketDetalle t in prodVendido)
			{
				var precio = String.Format("{0:0.00}", t.Neto);
				var cant = String.Format("{0:00.00}",t.Cant);
				imp = String.Format("{0:00.00}", imp).Replace(".","");
				var h = BemaFI32.Bematech_FI_VendeArticulo(t.Codigoproducto, t.Nombre,imp, "I",cant, 2, precio, "$", "0000");
			}
		}

		public void Facturar()
		{
			Header();
			DatosCliente(cliente);
			VendeProductos();
			Pagos();
			CierraFactura(totales.descuento);
			
		}

		
	}
}
