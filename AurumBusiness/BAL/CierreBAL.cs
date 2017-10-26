using AurumBusiness.Controllers;
using AurumDataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class CierreBAL
	{
		private CierresManager umanager;
		private CierresManager UManager
		{
			get
			{
				return umanager ?? (umanager = new CierresManager());
			}
		}

		public bool ExisteCierreHoy()
		{
			return UManager.Existe();
		}


		public void Insert(CierreDTO cierre)
		{
			UManager.Insert(cierre);
		}

		public void Edit(CierreDTO cargo)
		{
			UManager.Edit(cargo);
		}
		public void Delete(int IdCargo)
		{
			UManager.Delete(IdCargo);
		}
	}

}
