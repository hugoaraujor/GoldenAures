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
	public class TarjetaManager
	{
		public TarjetaDTO GetTarjetaDTO(int id)
		{
			AurumData.Tarjeta query = null;
			using (var db = new Data())
			{
				query = (from x in db.Tarjetas where x.Idtarjeta == id select x).First();

			}
			TarjetaDTO B = new TarjetaDTO { Idtarjeta = query.Idtarjeta, Tarjetatipo = query.Tarjetatipo };
			return B;
		}
		#region Insert

		public void Insert(TarjetaDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Tarjetas.Add(new Tarjeta()
				{
					Tarjetatipo=x.Tarjetatipo
						


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
				Tarjeta query = (from x in db.Tarjetas
								  where x.Idtarjeta == IdClase
								  select x).FirstOrDefault<Tarjeta>();
				if (query != null)
				{
					db.Tarjetas.Remove(query);
					db.SaveChanges();
				}
			}
		}

		public List<ListaDTO> GetList()
		{
			List<Tarjeta> pac = new List<Tarjeta>();
			using (var db = new Data())
			{
				pac = db.Tarjetas.ToList();

			}
			List<ListaDTO> LstResp = new List<ListaDTO>();
			foreach (Tarjeta a in pac)
			{
				ListaDTO Ret = new ListaDTO { index = a.Idtarjeta, descriptor = a.Tarjetatipo };
				LstResp.Add(Ret);
			}
			return LstResp;

		}

		#endregion
		#region Existe

		public bool Existe(string tarjstr)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Tarjeta Edo = (from x in db.Tarjetas where x.Tarjetatipo == tarjstr select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public bool Edit(TarjetaDTO Editedclass)
		{
			bool resp = true;
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Tarjetas where p.Idtarjeta == Editedclass.Idtarjeta select p).FirstOrDefault();
					if (pac != null)
					{
						pac.Tarjetatipo = x.Tarjetatipo;
						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{ resp = false; }
			return resp;
		}

		#endregion
		public List<Tarjeta> GetTarjetas()
		{
			List<Tarjeta> pac = new List<Tarjeta>();
			using (var db = new Data())
			{
				pac = db.Tarjetas.ToList();

			}
			return pac;
		}

	}
}
