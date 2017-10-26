using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class MesoneroBAL
	{
		private MesoneroBAL umanager;
		private MesoneroBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new MesoneroBAL());
			}
		}

		public bool Existe(string strmesonero)
		{
			return UManager.Existe(strmesonero);
		}


		public void Insert(MesoneroDTO area)
		{
			UManager.Insert(area);
		}

		public void Edit(MesoneroDTO area)
		{
			UManager.Edit(area);
		}
		public void Delete(int Idarea)
		{
			UManager.Delete(Idarea);
		}
	}
}
