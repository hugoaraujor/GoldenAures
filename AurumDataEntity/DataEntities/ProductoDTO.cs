
namespace AurumDataEntity
{
	public class ProductoDTO
	{
		public int IdProducto {get;set;}
		public string Codigo { get; set; }
		public string Nombre { get; set; }
		public decimal PrecioNeto { get; set; }
		public decimal Costo { get; set; }
		public int receta { get; set; }
		public decimal PrecioTotal { get; set; }
		public int Categoria { get; set; }
		public bool Exento { get; set; }
		public int Impresora { get; set; }
		public bool Activo { get; set; }
		public int Menu { get; set; }
		public bool Pesa { get; set; }
		public string Imagenurl { get; set; }
	}
}
