using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class MesasBAL
	{
		private MesasBAL umanager;
		private MesasBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new MesasBAL());
			}
		}

		public bool Existe(int Areaid)
		{
			return UManager.Existe(Areaid);
		}


		public void Insert(MesaDTO area)
		{
			UManager.Insert(area);
		}

		public void Edit(MesaDTO area)
		{
			UManager.Edit(area);
		}
		public void Delete(int Idarea)
		{
			UManager.Delete(Idarea);
		}
	}
}
