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
	public class TurnoManager
	{
		#region Insert

		public void Insert(TurnoDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Turnos.Add(new Turno()
				{
				 Turnodesc=x.Turnodesc,
				 Desde=x.Desde,
				 Hasta=x.Hasta



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
				Turno query = (from x in db.Turnos
								 where x.Idturno == IdClase
								 select x).FirstOrDefault<Turno>();
				if (query != null)
				{
					db.Turnos.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existe(string turnostr)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Turno Edo = (from x in db.Turnos where x.Turnodesc == turnostr select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public void Edit(TurnoDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Turnos where p.Idturno == x.Idturno select p).FirstOrDefault();
					if (pac != null)
					{
						pac.Turnodesc = x.Turnodesc;
				 pac.Desde = x.Desde;
				 pac.Hasta = x.Hasta;
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
