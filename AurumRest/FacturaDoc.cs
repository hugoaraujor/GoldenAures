using System;
using System.Collections.Generic;
using System.Linq;
using AurumRest;
using System.Threading.Tasks;
using AurumData;
using System;
using System.Collections.Generic;
namespace AurumData
{
	public class FacturaDoc
	{
		
		public List<TicketDetalle> DetalleaFacturar { get; set; }
		public List<TotalapagarView>  detalles { get; set; }
		public Mesa mesa { get; set; }
		public string notas;
	}
}
