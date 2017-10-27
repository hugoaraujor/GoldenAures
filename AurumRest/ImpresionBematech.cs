using AurumData;
using System.Collections.Generic;

namespace AurumRest
{
	public class ImpresionBematech: IPrinterFIOperaciones,IFactura
	{
		public bool statusAnulada;
		   public  bool isAnulada(string invoiceNo = "")
		{
			return false;
		}

		public void ImprimeReporteGerencial(List<string> Lista)
		{
		
		}

		public void Facturar( List<TicketDetalle> lista, TotalapagarView totales)
		{
			Factura FB = new FacturaBematech();
			FB.Facturar( lista,  totales);
		}
		public void EmiteNotadeCredito(string facturaNo)
		{
			Factura FB = new FacturaBematech();
			FB.EmiteNotadeCredito(facturaNo);
		}

		
	}

}

