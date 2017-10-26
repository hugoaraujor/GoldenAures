using AurumData;
using AurumDataEntity;
using AurumDataEntity.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.Controllers
{
	public class MenuManager
	{
		public MenuDTO GetDataMenu(int Idmenu)
		{
			
			MenuDTO resp = new MenuDTO();
			using (var db = new Data())
			{
					var pac = (from p in db.Menus where p.Idmenu == Idmenu select p).First();
					if (pac != null)
					{
						resp = new MenuDTO { Idmenu = pac.Idmenu, MenuDesc = pac.MenuDesc };
					}
				}	return resp;

		}
		public List<ListaDTO> GetList()
		{
			var pac = GetData();
			List<ListaDTO> LstResp = new List<ListaDTO>();
			foreach(Menu a in pac)
			{
				ListaDTO Ret = new ListaDTO { index = a.Idmenu, descriptor = a.MenuDesc };
				LstResp.Add(Ret);
			}
			return LstResp;

		}
		public List<Menu> GetData()
		{
			List<Menu> pac =null;
			using (var db = new Data())
			{
				pac = db.Menus.ToList();

			}

			return pac;
			
		}
		#region Insert

		public void InsertClase(MenuDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Menus.Add(new Menu()
				{
					MenuDesc = x.MenuDesc


			});

				db.SaveChanges();


			}
		}

		#endregion
		#region Delete

		public void Delete(int IdClase)
		{
			using (var db = new Data())
			{
				Menu query = (from x in db.Menus
							  where x.Idmenu == IdClase
							  select x).FirstOrDefault<Menu>();
				if (query != null)
				{
					db.Menus.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existemenu(string menustr)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Menu Edo = (from x in db.Menus where x.MenuDesc == menustr select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public bool Edit(MenuDTO Editedclass)
		{
			bool resp = true;
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Menus where p.Idmenu == Editedclass.Idmenu select p).FirstOrDefault();
					if (pac != null)
					{

						pac.MenuDesc = x.MenuDesc;
						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{ resp = false; }
			return resp;
		}

		#endregion

	}
}
