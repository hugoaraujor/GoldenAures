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
		Cliente ClienteFact { get; set; }
		List<TicketDetalle> DetalleaFacturar { get; set; }
		List<TotalapagarView>  detalles { get; set; }
	}
}
