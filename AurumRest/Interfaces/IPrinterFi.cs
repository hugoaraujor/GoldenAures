using AurumData;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System;

namespace AurumRest
{
	public interface IPrinterFIOperaciones
	{
		void EmiteNotadeCredito(String facturaNo);
		void Facturar( List<TicketDetalle> lista, TotalapagarView totales);
		void ImprimeReporteGerencial( List<string> Lista);
		bool isAnulada(string invoiceNo="");
	}

	

}

