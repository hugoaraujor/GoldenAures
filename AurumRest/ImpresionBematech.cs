using AurumData;
using FiscalPrinterBematech;
using System;
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
		public  int estaConectada()
		{
			int retorno = 0;
			retorno = BemaFI32.Bematech_FI_VerificaImpresoraPrendida();
			return retorno;
		}
		public void ImprimeReporteGerencial(List<string> Lista)
		{
			foreach (string st in Lista)
			{
				FiscalPrinterBematech.BemaFI32.Bematech_FI_InformeGerencial(st);
			}
			FiscalPrinterBematech.BemaFI32.Bematech_FI_CierraInformeGerencial();
		}
		public string  NumerodeCierresZ()
		{	string numero = "      ";
			FiscalPrinterBematech.BemaFI32.Bematech_FI_NumeroReducciones(ref numero);
			return numero;
		}
		public void AbrirCaja(string monto)
		{
			FiscalPrinterBematech.BemaFI32.Bematech_FI_AberturaDoDia(string.Format("{0:0##.00}",monto), "Efectivo");
		}
		public void LecturaX()
		{
			FiscalPrinterBematech.BemaFI32.Bematech_FI_LecturaX();
		}
		public void LecturaZ()
		{
			FiscalPrinterBematech.BemaFI32.Bematech_FI_FechamentoDoDia();
		}
		public string Facturar( ProcTicket ticket)
		{
			Factura FB = new FacturaBematech();
			string  numerofact=FB.Facturar( ticket);
			return numerofact;
		}
		public void EmiteNotadeCredito(string facturaNo)
		{
			Factura FB = new FacturaBematech();
			FB.EmiteNotadeCredito(facturaNo);
		}
	

	}

}

