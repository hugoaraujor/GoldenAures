using AurumBusiness.Controllers;
using AurumData;
using System;
using FiscalPrinterBematech;

namespace AurumRest
{
	class FacturaBematech : Factura
	{
		public   override void CierraFactura()
		{
			var mesaStr = totales.mesa;

			if (mesaStr != null)
			{
				if ((mesaStr.Siglas != "0") && (mesaStr.Siglas.IndexOf("LL") > -1))
				{ BemaFI32.Bematech_FI_FinalizarCierreCupon(mesaStr + " PARA LLEVAR." + " Gracias por su compra."); }

				if ((mesaStr.Siglas != "0") && (mesaStr.Siglas.IndexOf("LL") == -1))
				{   MesonerosManager MCtrller = new MesonerosManager();
					var atiende = MCtrller.getMesero((int)totales.mesa.Idmesonero).Nombre;
                     var resp = BemaFI32.Bematech_FI_FinalizarCierreCupon("Mesa:" + mesaStr + ".Atiende:" + atiende);
				}
			}
			else
			{
				var resp = BemaFI32.Bematech_FI_FinalizarCierreCupon("VENTA RAPIDA");
			}
		}
		public override bool isAnulada()
		{
			return anulada;
		}
		public override void  DatosCliente()
		{	Cliente cliente = totales.cliente;
			var n = BemaFI32.Bematech_FI_AbreComprobanteDeVentaEx(cliente.Identificacion, cliente.Nombre, cliente.Direccion);
		}
		public override void Descuento()
		{
			if (totales.descuento > 0)
			{	var n = BemaFI32.Bematech_FI_IniciaCierreCupon("D", "$", String.Format("{0:0.00}", Convert.ToDouble(totales.descuento)));	}
			else
			{  var n=BemaFI32.Bematech_FI_IniciaCierreCupon("D", "$", "0000");}
			
		}
		public override void  Header()
		{
			BemaFI32.Bematech_FI_AnulaCupon();
		
		}
		public override void Pagos()
		{
			foreach (PagoView pv in totales.ListaPagos)
			{
				var n = BemaFI32.Bematech_FI_EfectuaFormaPago(pv.clase, pv.montopago.ToString("{0:0.00}"));
			}
		}

		public override void VendeProductos()
		{
			var prodVendido = lista;
			Global g = new Global();
			var imp = g.secuencia.getIva(totales.currentIva);
			foreach (TicketDetalle t in prodVendido)
			{
				var precio = String.Format("{0:000000.00}", t.Neto).Replace(".", ""); ;
				var cant = string.Format("{0:0000}", t.Cant);
				var impFormatted = String.Format("{0:00.00}", Convert.ToDecimal(imp)).Replace(".","");
				var h = BemaFI32.Bematech_FI_VendeArticulo("", t.Nombre, impFormatted, "I",cant, 2, precio, "$", "0000");
			}
		}
		public override void EmiteNotadeCredito(string facturaNo)
		{
			ClienteManager Cm = new ClienteManager();
			totales = new TotalapagarView();
			totales.cliente= Cm.GetCliente(facturaNo);
			Cliente cliente = totales.cliente;
			TicketDetalleManager TDMNgr = new TicketDetalleManager();
			lista=TDMNgr.GetList(facturaNo);

			string NumeroSerial = new string(' ', 15);
			int iRetorno = BemaFI32.Bematech_FI_NumeroSerie(ref NumeroSerial);
			DateTime cDate = DateTime.Now;
			var cDia = cDate.Day.ToString("D2");
			var cMes = cDate.Month.ToString("D2");
			var cAno = cDate.Year.ToString().Substring(2, 2);
			var cHora = cDate.Hour.ToString("D2");
			var cMinuto = cDate.Minute.ToString("D2");
			var cSegundo = cDate.Second.ToString("D2");
			var cCOO = facturaNo;
			iRetorno = BemaFI32.Bematech_FI_AbreNotaDeCredito(cliente.Nombre, NumeroSerial, cliente.Identificacion, cDia, cMes, cAno, cHora, cMinuto, cSegundo, cCOO);
			VendeProductos();
			Descuento();
			iRetorno = BemaFI32.Bematech_FI_FinalizarCierreCupon("Gracias, vuelva siempre !!!");

		}

		//iRetorno = Bematech_FI_FinalizarCierreCupon("Gracias, vuelva siempre !!!")
	}
}
