

using System;

namespace AurumDataEntity
{
	public class FacturaDTO
	{
		public int Id { get; set; }
		public string Facturanro { get;set; }
		public string Nota { get; set; }
		public decimal Montoneto { get; set; }
		public decimal Montoiva { get; set; }
		public decimal Exento { get; set; }
		public decimal Total { get; set; }
		public string Caja { get; set; }
		public string Mesa { get; set; }
		public int Sirve { get; set; }
		public int ClienteID { get; set; }
		public int Userid { get; set; }
		public decimal Descuento { get; set; }
		public decimal Tasa { get; set; }
		public string Equipo { get; set; }
		public string Serial { get; set; }
		public string Moneda { get; set; }
		public bool Anulada { get; set; }
		public string Cierrex { get; set; }
		public string Cierrez { get; set; }
		public DateTime Fecha { get; set; }
	}
}
