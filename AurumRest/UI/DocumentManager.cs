using AurumBusiness.Controllers;
using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{
	public class DocumentManager
	{
		
		ProcTicket ticketDoc;
		string numerodeDocumento = "";
		public DocumentManager(ProcTicket ticket)
		{
			ticketDoc = ticket;
			
		}
		public  void Guardar(string Numero)
		{
			ajustaiva(ticketDoc);

			InsertarHeader();
			Insertadetalles(ticketDoc, Numero);
			InsertarPagos(ticketDoc.totales);
		}

		private void InsertarPagos(TotalapagarView totales)
		{
			PagoManager pMng = new PagoManager();
			foreach (PagoView p in totales.ListaPagos)
			{
				pMng.Insert(new PagoDTO { Factura = totales.factura, Cambio = p.cambio, Montopago = p.montopago, Tipopago = p.tipopago, Nota = p.nota });

			}
		}

		private void ajustaiva(ProcTicket ticket)
		{
			DetalleFacturaManager fMng = new DetalleFacturaManager();
			foreach (TicketDetalle t in ticket.lista)
			{
				t.Factura = ticket.totales.factura;
				t.Montoiva = t.Monto * (ticket.totales.IvaPercent / 100);
			}
		}
		
		private void Insertadetalles(ProcTicket ticket, string Numero)
		{
			DetalleFacturaManager fMng = new DetalleFacturaManager();

			foreach (TicketDetalle t in ticket.lista)
			{

				fMng.Insert(
				new DetalleFacturaDTO
				{
					Cant = t.Cant,
					Codigoproducto = t.Codigoproducto,
					Factura = Numero,
					Iva = t.Montoiva,
					Monto = t.Monto,
					 Nota = t.Nota,
					Id = 0

				});
			}
		}

		private void InsertarHeader()
		{
			Global g=new Global();
			var parametros = g.GetParametros();
			FacturasManager fMng = new FacturasManager();
			int mesonero;
			try
			{
				mesonero = (int)ticketDoc.totales.mesa.Idmesonero;
			}
			catch
			{
				mesonero = 0;
			}
			var user = g.Usuario().Iduser;


			fMng.Insert(
				new FacturaDTO
				{
					Anulada = false,
					Caja = parametros.Caja,
					ClienteID = ticketDoc.totales.cliente.Idcliente,
					Descuento = ticketDoc.totales.descuento,
					Equipo = g.equipo,
					Facturanro = ticketDoc.totales.factura,
					Nota = "",
					Montoiva = ticketDoc.totales.totalIva,
					Mesa = ticketDoc.totales.mesa.Siglas,
					Moneda = g.GetMoneda(),
					Montoneto = ticketDoc.totales.totalNeto,
					Serial = parametros.Serial,
					Sirve = mesonero,
					Tasa = Convert.ToDecimal(g.secuencia.getIva(ticketDoc.totales.currentIva)),
					Total = ticketDoc.totales.total,
					Userid = user 
					 
					
				});
			//g.Usuario().Iduser
		}



	}
}
