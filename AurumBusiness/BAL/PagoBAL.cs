using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class PagoBAL
	{
		private PagoBAL umanager;
		private PagoBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new PagoBAL());
			}
		}

	

		public void InsertPago(PagoDTO area)
		{
			UManager.InsertPago(area);
		}

		public void EditPago(PagoDTO area)
		{
			UManager.EditPago(area);
		}
		public void DeletePago(int Idarea)
		{
			UManager.DeletePago(Idarea);
		}
	}
}
