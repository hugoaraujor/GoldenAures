using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AurumData
{
	[Table("Ordenes")]
	public class Orden
	{
		
		private int idOrden;
		private System.DateTime fecha;
		private long numeroOrden;
		private int items;
		private string mesa;
		private int  meseroid;
		public  List<itemsOrder> itemsorden;
		private decimal monto;
		private decimal titems;
		public Orden(System.DateTime xfecha, long numeroOrden,  string mesa, int meseroid)
		{
			this.fecha = xfecha;
			this.numeroOrden = numeroOrden;
			this.mesa = mesa;
			this.meseroid = meseroid;
			this.monto=getTotalOrden();
			this.titems=getTotalItems();			


		}
		public Orden()
		{ }
		
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public  int IdOrden { get => idOrden; set => idOrden = value; }
		public long NumeroOrden { get => numeroOrden; set => numeroOrden = value; }
		public int Items { get => items; set => items = value; }
		public string Mesa { get => mesa; set => mesa = value; }
		public int Meseroid { get => meseroid; set => meseroid = value; }
		public System.DateTime Fecha { get => fecha; set => fecha = value; }
		public decimal Monto { get => monto; set => monto = value; }
		public decimal Titems { get => titems; set => titems = value; }

		public decimal getTotalOrden()
		{
			decimal t = 0;
			foreach (itemsOrder it in itemsorden)
			{
				t = t + it.Monto;
			}
			return t;
		}
		public decimal getTotalItems()
		{
			decimal c = 0;
			foreach (itemsOrder it in itemsorden)
			{
				c = c + it.Cantidad;
			}
			return c;
		}
	
	}
}
