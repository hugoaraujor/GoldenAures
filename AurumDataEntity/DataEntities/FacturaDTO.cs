

namespace AurumDataEntity
{
	public class FacturaDTO
	{
		
		public string Facturanro { get;set; }
		public int Id { get; set; }
		public string Nota { get; set; }
		public decimal Montoneto { get; set; }
		public decimal Iva { get; set; }
		public decimal Total { get; set; }
		public string Caja { get; set; }
		public string Mesa { get; set; }
		public int Sirve { get; set; }
		public int Usuario { get; set; }
		public int Userid { get; set; }
		public decimal Descuento { get; set; }
		public decimal Tasa { get; set; }
		public int DescuentoTasa { get; set; }
		public string Equipo { get; set; }
		public string Serial { get; set; }
		public string Moneda { get; set; }
	}
}
