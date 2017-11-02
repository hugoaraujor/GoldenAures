using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{ [Table("Aperturas")]
	public class Apertura
	{

		private int idapertura;
			private DateTime fecha;
			private decimal monto;
		private int turno;
		private int userid;
		private bool cerrada { get; set; }
		public Apertura()
			{

			}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idapertura { get => idapertura; set => idapertura = value; }
		public DateTime Fecha { get => fecha; set => fecha = value; }
		public decimal Monto { get => monto; set => monto = value; }
		public bool Cerrada { get => cerrada; set => cerrada = value; }
	}
}
