using AurumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{
	public class ProcTicket
	{
		public ProcTicket()
		{
			lista = new List<TicketDetalle>();
			totales = new TotalapagarView();
		}
		public int ticketNro { get; set; }
		public	List<TicketDetalle> lista { get; set; }
		public TotalapagarView totales { get; set; }
	}
}
