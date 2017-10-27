using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurumData
{
	[Table("DetalleFactura")]
	public class DetalleFactura
	{
	

		private int id;
		[StringLength(10)]
		private string codigoproducto;
		private Decimal monto;
		private Decimal iva;
		private Decimal cant;
		private string factura;
		[StringLength(100)]
		private string  nota;
		private string mesa;
		public DetalleFactura()
		{
	
		}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get => id; set => id = value; }
		public string Codigoproducto { get => codigoproducto; set => codigoproducto = value; }
		public decimal Monto { get => monto; set => monto = value; }
		public decimal Iva { get => iva; set => iva = value; }
		public decimal Cant { get => cant; set => cant = value; }
		public string Factura { get => factura; set => factura = value; }
		public string Nota { get => nota; set => nota = value; }
		public string Mesa { get => mesa; set => mesa = value; }
	}
}