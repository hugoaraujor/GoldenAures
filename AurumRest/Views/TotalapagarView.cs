using AurumData;
using System;
using System.Collections.Generic;

namespace AurumRest
{
	public class TotalapagarView
	{
		public TotalapagarView()
		{
			ListaPagos = new List<PagoView>();
			mesa = new Mesa();
			mesa.Siglas = "0";
			mesa.Idmesonero =0;
		}


		public Cliente cliente { get; set; }
		public Decimal totalNeto { get; set; }
		public Decimal totalIva { get; set; }
		public Decimal descuento { get; set; }
		public Decimal total { get; set; }
		public String factura { get; set; }

		public Decimal pagado { get; set; }
		public Decimal resta { get; set; }
		public Decimal Cambio { get; set; }

		public Decimal IvaPercent { get; set; }
		public Ivatipo currentIva { get; set; }
		public Mesa mesa { get; set; }
		public List<PagoView> ListaPagos ;
	}

	
}
