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
	{   string NumerodeCierresZ();
		void AbrirCaja(string Monto);
		void LecturaX();
		void LecturaZ();
		void EmiteNotadeCredito(String facturaNo);
		string  Facturar( ProcTicket ticket);
		void ImprimeReporteGerencial( List<string> Lista);
		bool isAnulada(string invoiceNo="");
	}

	

}

