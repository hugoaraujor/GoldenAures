using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumDataEntities
{
	public class CierreDTO
	{

		public int Idcierre { get;set; }
		public decimal Efectivo { get; set; }
		public decimal Debito { get; set; }
		public decimal Credito { get; set; }
		public decimal Cheque { get; set; }
		public decimal Otros { get; set; }
		public decimal Cambio { get; set; }
		public decimal Monto { get; set; }
		public int Usuarioid { get; set; }
		public string Inicio { get; set; }
		public string Fin { get; set; }
		public DateTime Fecha { get; set; }
	}
}
