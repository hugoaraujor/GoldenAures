using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Facturas")]
	public class Factura
	{
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		private int id;
		private string facturanro;
		[StringLength(15)]
		private string nota;
		[DataType(DataType.Currency)]
		private Decimal montoneto;
		[DataType(DataType.Currency)]
		private Decimal iva;
		[DataType(DataType.Currency)]
		private Decimal total;
		[StringLength(15)]
		private string caja;
		[StringLength(10)]
		private string mesa;
		private int sirve;
		private int usuario;
		private int  userid;
		[DataType(DataType.Currency)]
		private Decimal descuento;
		private Decimal tasa;
		private int descuentoTasa;
		[StringLength(20)]
		private string equipo;
		[StringLength(15)]
		private string serial;
		[StringLength(5)]
		private string moneda;

		public Factura()
		{
			
		}

		public string Facturanro { get => facturanro; set => facturanro = value; }
		public int Id { get => id; set => id = value; }
		public string Nota { get => nota; set => nota = value; }
		public decimal Montoneto { get => montoneto; set => montoneto = value; }
		public decimal Iva { get => iva; set => iva = value; }
		public decimal Total { get => total; set => total = value; }
		public string Caja { get => caja; set => caja = value; }
		public string Mesa { get => mesa; set => mesa = value; }
		public int Sirve { get => sirve; set => sirve = value; }
		public int Usuario { get => usuario; set => usuario = value; }
		public int Userid { get => userid; set => userid = value; }
		public decimal Descuento { get => descuento; set => descuento = value; }
		public decimal Tasa { get => tasa; set => tasa = value; }
		public int DescuentoTasa { get => descuentoTasa; set => descuentoTasa = value; }
		public string Equipo { get => equipo; set => equipo = value; }
		public string Serial { get => serial; set => serial = value; }
		public string Moneda { get => moneda; set => moneda = value; }
	}
}
