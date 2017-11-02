using AurumData;
using System;
using System.Collections.Generic;

namespace AurumRest
{
	public interface IFactura
	{
		string  Facturar(ProcTicket ticket);
	}
}
