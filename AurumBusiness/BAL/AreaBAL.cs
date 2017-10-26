using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.Controllers
{
	public class AreaBAL
	{
		private AreaBAL umanager;
		private AreaBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new AreaBAL());
			}
		}

		public bool ExisteArea(int Areaid )
		{
			return UManager.ExisteArea(Areaid);
		}


		public void InsertArea(AreaDTO area)
		{
			UManager.InsertArea(area);
		}

		public void EditArea(AreaDTO area)
		{
			UManager.EditArea(area);
		}
		public void DeleteArea(int Idarea)
		{
			UManager.DeleteArea(Idarea);
		}
	}
}
