using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("CuentasxCobrar")]
	public class CuentasxCobrar
	{
		private int cuentaid;
		private DateTime fecha;
		[DataType(DataType.Currency)]
		private decimal monto;
		private int idcliente;
		[StringLength(40)]
		private string descripcion;
		[DataType(DataType.Currency)]
		private decimal paga;
		[DataType(DataType.Currency)]
		private decimal resta;

		public CuentasxCobrar()
		{
			
		}

		public DateTime Fecha { get => fecha; set => fecha = value; }
		public decimal Monto { get => monto; set => monto = value; }
		public int Idcliente { get => idcliente; set => idcliente = value; }
		public string Descripcion { get => descripcion; set => descripcion = value; }
		public decimal Paga { get => paga; set => paga = value; }
		public decimal Resta { get => resta; set => resta = value; }

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Cuentaid { get => cuentaid; set => cuentaid = value; }
	}
}
