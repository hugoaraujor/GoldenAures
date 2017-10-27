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
		[DataType(DataType.Currency)]
		private Decimal exento;
		[StringLength(15)]
		private string caja;
		[StringLength(10)]
		private string mesa;
		private int sirve;
		private int clienteID;
		private int  userid;
		[DataType(DataType.Currency)]
		private Decimal descuento;
		private Decimal tasa;
		[StringLength(20)]
		private string equipo;
		[StringLength(15)]
		private string serial;
		[StringLength(5)]
		private string moneda;
		private bool anulada;
		[DataType(DataType.DateTime)]
		private DateTime fecha;
		public Factura()
		{
			
		}
		[StringLength(10)]
		public string Facturanro { get => facturanro; set => facturanro = value; }
		public int Id { get => id; set => id = value; }
		[StringLength(160)]
		public string Nota { get => nota; set => nota = value; }
		public decimal Montoneto { get => montoneto; set => montoneto = value; }
		public decimal Iva { get => iva; set => iva = value; }
		public decimal Total { get => total; set => total = value; }
		[StringLength(12)]
		public string Caja { get => caja; set => caja = value; }
		[StringLength(10)]
		public string Mesa { get => mesa; set => mesa = value; }
		public int Sirve { get => sirve; set => sirve = value; }
		public int ClienteID { get => clienteID; set => clienteID = value; }
		public int Userid { get => userid; set => userid = value; }
		public decimal Descuento { get => descuento; set => descuento = value; }
		public decimal Tasa { get => tasa; set => tasa = value; }
		[StringLength(15)]
		public string Equipo { get => equipo; set => equipo = value; }
		[StringLength(15)]
		public string Serial { get => serial; set => serial = value; }
		[StringLength(5)]
		public string Moneda { get => moneda; set => moneda = value; }
		public bool Anulada { get => anulada; set => anulada = value; }
		public decimal Exento { get => exento; set => exento = value; }
		public DateTime Fecha { get => fecha; set => fecha = value; }
	}
}
