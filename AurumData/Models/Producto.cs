using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Productos")]
	public class Producto
	{
		
		private int idProducto;
		private string codigo;
		[DataType(DataType.Text)]
		[StringLength(29)]
		private string nombre;
		[DataType(DataType.Currency)]
		private Decimal precioNeto;
		[DataType(DataType.Currency)]
		private Decimal iva;
		[DataType(DataType.Currency)]
		private Decimal precioTotal;
		private int categoria;
		private bool exento;
		private int impresora;
		private bool activo;
		private int menu ;
		private decimal costo;
		private int receta;

		private string imagenurl;
		public Producto(string codigot, string nombrep, decimal preciot)
		{
			Codigo = codigot;
			Nombre = nombrep;
			PrecioTotal = preciot;
			var aux = new Parametro();
			PrecioNeto = (PrecioTotal / aux.GetIva() + 1);
			Iva = (PrecioTotal * aux.GetIva());
		}
		public Producto()
		{ }
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int IdProducto { get => idProducto; set => idProducto = value; }
		public string Codigo { get => codigo; set => codigo = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public decimal PrecioNeto { get => precioNeto; set => precioNeto = value; }
		public decimal Iva { get => iva; set => iva = value; }
		public decimal PrecioTotal { get => precioTotal; set => precioTotal = value; }
		public int Categoria { get => categoria; set => categoria = value; }
		public bool Exento { get => exento; set => exento = value; }
		public int Impresora { get => impresora; set => impresora = value; }
		public bool Activo { get => activo; set => activo = value; }
		public bool Pesa { get => activo; set => activo = value; }
		public int Menu { get => menu; set => menu = value; }
		public string Imagenurl { get => imagenurl; set => imagenurl = value; }
		public decimal Costo { get => costo; set => costo = value; }
		public int Receta { get => receta; set => receta = value; }
	}
}
