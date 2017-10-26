using AurumData;
using System;
using System.Collections.Generic;

namespace AurumRest
{
	public class TotalapagarView
	{   public Cliente cliente { get; set; }
		public Decimal totalNeto { get; set; }
		public Decimal totalIva { get; set; }
		public Decimal descuento { get; set; }
		public Decimal total { get; set; }
		
		public Decimal pagado { get; set; }
		public Decimal resta { get; set; }

		public Decimal IvaPercent { get; set; }
		public Ivatipo currentIva { get; set; }

		public List<PagoView> ListaPagos = new List<PagoView>();
	}

	
}
