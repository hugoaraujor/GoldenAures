using AurumDataEntity;
using AurumDataEntity.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.Controllers
{
	public class MenuBAL
	{
		private MenuBAL umanager;
		private MenuBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new MenuBAL());
			}
		}

		public bool Existe(string menustr)
		{
			return UManager.Existe(menustr);
		}


		public void InsertArea(MenuDTO menu)
		{
			UManager.InsertArea(menu);
		}

		public void EditArea(MenuDTO menu)
		{
			UManager.EditArea(menu);
		}
		public void DeleteArea(int Idmenu)
		{
			UManager.DeleteArea(Idmenu);
		}
	}
}