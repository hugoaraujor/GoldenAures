using AurumBusiness.Controllers;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class itemsOrderBAL
	{
		private itemsOrderManager umanager;
		private itemsOrderManager  UManager
		{
			get
			{
				return umanager ?? (umanager = new itemsOrderManager());
			}
		}

	

		public void Insert(itemsOrderDTO iOrder)
		{
			UManager.Insert(iOrder);
		}

		public void Edit(itemsOrderDTO iOrder)
		{
			UManager.Edit(iOrder);
		}
		public void Delete(int Idorder)
		{
			UManager.Delete(Idorder);
		}
	}
}
