using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Cierres")]
	public class Cierre
	{

		private int     idcierre;
		[DataType(DataType.Currency)]
		private int tipo;
		private decimal efectivo;
		[DataType(DataType.Currency)]
		private decimal debito;
		[DataType(DataType.Currency)]
		private decimal credito;
		[DataType(DataType.Currency)]
		private decimal cheque;
		[DataType(DataType.Currency)]
		private decimal otros;
		[DataType(DataType.Currency)]
		private decimal cambio;
		[DataType(DataType.Currency)]
		private decimal monto;
		private int     usuarioid;
		[StringLength(10)]
		private string inicio;
		[StringLength(10)]
		private string fin;
		private DateTime fecha;

		public Cierre()
		{
		}

		
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idcierre { get => idcierre; set => idcierre = value; }
		public decimal Efectivo { get => efectivo; set => efectivo = value; }
		public decimal Debito { get => debito; set => debito = value; }
		public decimal Credito { get => credito; set => credito = value; }
		public decimal Cheque { get => cheque; set => cheque = value; }
		public decimal Otros { get => otros; set => otros = value; }
		public decimal Cambio { get => cambio; set => cambio = value; }
		public decimal Monto { get => monto; set => monto = value; }
		public int Usuarioid { get => usuarioid; set => usuarioid = value; }
		public string Inicio { get => inicio; set => inicio = value; }
		public string Fin { get => fin; set => fin = value; }
		public DateTime Fecha { get => fecha; set => fecha = value; }
	}
}
