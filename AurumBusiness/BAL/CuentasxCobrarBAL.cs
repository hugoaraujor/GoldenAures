using AurumBusiness.Controllers;
using AurumDataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class CuentasxcobrarBAL
	{
		public class CuentasxCobrarBAL
		{
			private CuentasxCobrarManager umanager;
			private CuentasxCobrarManager UManager
			{
				get
				{
					return umanager ?? (umanager = new CuentasxCobrarManager());
				}
			}

			

			public void Insert(CuentasxCobrarDTO apertura)
			{
				UManager.Insert(apertura);
			}

			public void Edit(CuentasxCobrarDTO cargo)
			{
				UManager.Edit(cargo);
			}
			public void Delete(int IdCargo)
			{
				UManager.Delete(IdCargo);
			}
		}
	}
}
