using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurumData
{
	[Table("itemsOrder")]
	public class itemsOrder
	{
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		private int iditem;
		private decimal cantidad;
		[StringLength(10)]
		private string productocode;
		[StringLength(60)]
		private string comentario;
		private  Producto producto;
		private decimal monto;
		[StringLength(10)]
		private string mesa;
		public itemsOrder()
		{
		}

		public itemsOrder(decimal Cantidad, string Productocode)
		{
		 

		}

		

		public decimal Cantidad {
			get => cantidad;
			set {
				cantidad = value;
				monto = value * producto.PrecioNeto;
				}
		}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Iditem { get => Iditem; set => Iditem = value; }
		public string Productocode { get => productocode; set => productocode = value; }
		public string Comentario { get => comentario; set => comentario = value; }
		public decimal Monto { get => monto; set => monto = value; }
		public string Mesa { get => mesa; set => mesa = value; }
		public Producto Producto { get => producto; set => producto = value; }

		public void Comentar(string comenta) {
			comentario = comenta;
		}
	}
}