using AurumBusiness.Controllers;
using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class FacturasBAL
	{
		private FacturasManager umanager;
		private FacturasManager UManager
		{
			get
			{
				return umanager ?? (umanager = new FacturasManager());
			}
		}



		public void Insert(FacturaDTO factura)
		{
			UManager.Insert(factura);
		}

		public void Edit(FacturaDTO fac)
		{
			UManager.Edit(fac);
		}
		public void Delete(string fac)
		{
			UManager.Delete(fac);
		}
		public bool Existe(string fac)
		{
			bool resp = false;
			resp=UManager.ExisteFact(fac);
			return resp;
		}
		public Factura GetFactura(string fac)
		{
			Factura resp;
			resp = UManager.GetFactura(fac);
			return resp;
		}
	}
}


