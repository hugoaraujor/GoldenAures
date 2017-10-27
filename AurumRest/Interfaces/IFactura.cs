using AurumData;
using System;
using System.Collections.Generic;

namespace AurumRest
{
	public interface IFactura
	{
		void Facturar(  List<TicketDetalle> lista, TotalapagarView totales);
	}
}
