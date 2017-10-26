using System;
namespace AurumDataEntity
{
	public class DetalleFacturaDTO
	{
		public int Id { get; set; }
		public string Codigoproducto { get; set; }
		public decimal Monto { get; set; }
		public decimal Iva { get; set; }
		public decimal Cant { get; set; }
		public string Factura { get; set; }
		public decimal Nota { get; set; }
	}
}