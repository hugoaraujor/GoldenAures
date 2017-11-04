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
		[StringLength(7)]
		private string facturanro;
		[StringLength(7)]
		private string nota;
		[DataType(DataType.Currency)]
		private Decimal montoneto;
		[DataType(DataType.Currency)]
		private Decimal montoiva;
		[DataType(DataType.Currency)]
		private Decimal exento;
		[DataType(DataType.Currency)]
		private Decimal total;
		[StringLength(15)]
		private string caja;
		[StringLength(10)]
		private string mesa;
		private int sirve;
		private int clienteID;
		private int  userid;
		[DataType(DataType.Currency)]
		private Decimal descuento;
		[DataType(DataType.Currency)]
		private Decimal tasa;
		[StringLength(20)]
		private string equipo;
		[StringLength(15)]
		private string serial;
		[StringLength(5)]
		private string moneda;
		private bool anulada;
		[StringLength(7)]
		private string cierrex;
		[StringLength(7)]
		private string cierrez;
		[DataType(DataType.DateTime)]
		private DateTime fecha;

		public Factura()
		{
			
		}
		public int Id { get => id; set => id = value; }
		public string Facturanro { get => facturanro; set => facturanro = value; }
		public string Nota { get => nota; set => nota = value; }
		public decimal Montoneto { get => montoneto; set => montoneto = value; }
		public decimal Montoiva { get => montoiva; set => montoiva = value; }
		public decimal Exento { get => exento; set => exento = value; }
		public decimal Total { get => total; set => total = value; }
		public string Caja { get => caja; set => caja = value; }
		public string Mesa { get => mesa; set => mesa = value; }
		public int Sirve { get => sirve; set => sirve = value; }
		public int ClienteID { get => clienteID; set => clienteID = value; }
		public int Userid { get => userid; set => userid = value; }
		public decimal Descuento { get => descuento; set => descuento = value; }
		public decimal Tasa { get => tasa; set => tasa = value; }
		public string Equipo { get => equipo; set => equipo = value; }
		public string Serial { get => serial; set => serial = value; }
		public string Moneda { get => moneda; set => moneda = value; }
		public bool Anulada { get => anulada; set => anulada = value; }
		public string Cierrex { get => cierrex; set => cierrex = value; }
		public string Cierrez { get => cierrez; set => cierrez = value; }
		public DateTime Fecha { get => fecha; set => fecha = value; }
	}
}
