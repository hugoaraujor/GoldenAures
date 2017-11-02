using System;

namespace AurumDataEntity
{
	public class PagoDTO
	{
		public int Idpago { get; set; }
		public int Tipopago { get; set; }
		public decimal Montopago { get; set; }
		public decimal Cambio { get; set; }
		public string Factura { get; set; }
		public string Nota { get; set; }
		
	}
}
