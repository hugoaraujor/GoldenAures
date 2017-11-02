using AurumData;
using System;
using System.Collections.Generic;

namespace AurumRest
{
	public abstract class Factura
	{
		protected Cliente cliente;
		protected List<TicketDetalle> lista;
		protected TotalapagarView totales;
		protected bool anulada;
		
		//Factura
		public abstract void Header();
		public abstract void DatosCliente();
		public abstract void VendeProductos();
		public abstract void Descuento();
		public abstract void Pagos();
		public abstract void CierraFactura();
		public abstract bool isAnulada();
		public abstract int GetLast(ref string NumeroDoc);
		//Nota de credito
		public abstract void EmiteNotadeCredito(string facturaNo);

		// The "Template method"
		public string   Facturar(ProcTicket ticket)
		{
			cliente = ticket.totales.cliente;
			lista = ticket.lista;
			totales = ticket.totales;
		    
			Header();
			DatosCliente();
			VendeProductos();
			Descuento();
			Pagos();
			CierraFactura();
			isAnulada();
			string  NumeroDoc = "      ";
			int n=GetLast(ref  NumeroDoc);
			return NumeroDoc;
		}

		
		public string  EmitirNota(string Doc)
		{
			Header();
			EmiteNotadeCredito(Doc);
			VendeProductos();
			CierraFactura();
			string NumeroDoc = "      ";
			int n = GetLast(ref NumeroDoc);
			return NumeroDoc;
		}

	}
}
