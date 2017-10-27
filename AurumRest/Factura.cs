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
		
		//Nota de credito
		public abstract void EmiteNotadeCredito(string facturaNo);

		// The "Template method"
		public void Facturar(List<TicketDetalle> ListaF, TotalapagarView TotalesF)
		{
			cliente = TotalesF.cliente;
			lista = ListaF;
			totales = TotalesF;

			Header();
			DatosCliente();
			VendeProductos();
			Descuento();
			Pagos();
			CierraFactura();
			isAnulada();
		}
		public void EmitirNota(string Doc)
		{
			Header();
			EmiteNotadeCredito(Doc);
			VendeProductos();
			CierraFactura();

		}

	}
}
