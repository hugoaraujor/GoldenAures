using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumDataEntity
{
	public class AperturaDTO
	{
		public int Idapertura { get;set;}
		public DateTime Fecha { get;set;}
		public decimal Monto { get;set;}
		public int userId { get; set; }
		public int Turno { get; set; }
		public bool cerrada { get; set; }
	}
}
