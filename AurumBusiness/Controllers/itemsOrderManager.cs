using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.Controllers
{
	public class itemsOrderManager
	{
		#region Insert

		public void Insert(itemsOrderDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.itemsOrders.Add(new itemsOrder()
				{
					Comentario = x.Comentario,
					Cantidad = x.Cantidad,
					Monto = x.Monto,
					Productocode = x.Productocode,
					Mesa = x.Mesa
						


				});

				db.SaveChanges();


			}
		}

		#endregion
		#region Delete

		public void Delete(int IdBanco)
		{
			using (var db = new Data())
			{
				itemsOrder query = (from x in db.itemsOrders
									where x.Iditem == IdBanco
							   select x).FirstOrDefault<itemsOrder>();
				if (query != null)
				{
					db.itemsOrders.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existe(int itorderint)
		{
			bool resp = false;
			using (var db = new Data())
			{
				itemsOrder Edo = (from x in db.itemsOrders where x.Iditem == itorderint select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public void Edit(itemsOrderDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.itemsOrders where p.Iditem== Editedclass.Iditem select p).FirstOrDefault();
					if (pac != null)
					{
						pac.Comentario = x.Comentario;
						pac.Cantidad = x.Cantidad;
						pac.Monto = x.Monto;
						pac.Productocode = x.Productocode;
							pac.Mesa = x.Mesa;
						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{ }
		}

		#endregion
	}

}
