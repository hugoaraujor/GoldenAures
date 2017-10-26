using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AurumData;
using AurumDataEntity;
using System.Data.Entity.Validation;
using AurumDataEntity.DataEntities;

namespace AurumBusiness.Controllers
{
	public class BancosManager
	{
		public BancoDTO GetBancoDTO(int id)
		{
			AurumData.Banco query = null;
			using (var db = new Data())
			{
				query = (from x in db.Bancos where x.Idbanco == id select x).First();

			}
			BancoDTO B = new BancoDTO { Idbanco = query.Idbanco, Nombre = query.Nombre };
			return B;
		}
		public  List<ListaDTO> GetList()
		{
			List<ListaDTO> LstResp = new List<ListaDTO>();
			List<Banco> query = null;
			using (var db = new Data())
			{
				query = (from x in db.Bancos select x).ToList();

			}
			foreach (Banco a in query)
			{
				ListaDTO Ret = new ListaDTO { index =a.Idbanco, descriptor = a.Nombre };
				LstResp.Add(Ret);
			}
			return LstResp;
		}
		#region Insert

		public void InsertBancos(BancoDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Bancos.Add(new Banco()
				{
					Nombre = x.Nombre


			});

				db.SaveChanges();


			}
		}

		#endregion
		#region Delete

		public void DeleteBanco(int IdBanco)
		{
			using (var db = new Data())
			{
				Banco query = (from x in db.Bancos
							  where x.Idbanco == IdBanco
							  select x).FirstOrDefault<Banco>();
				if (query != null)
				{
					db.Bancos.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool ExisteBanco(string banco)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Banco Edo = (from x in db.Bancos where x.Nombre == banco select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public bool Edit(BancoDTO Editedclass)
		{
			bool resp = true;
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Bancos where p.Idbanco == Editedclass.Idbanco select p).FirstOrDefault();
					if (pac != null)
					{

						pac.Nombre = x.Nombre;
						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{

				 resp = false;
			}
			return resp;
		}

		#endregion
		//Getbancos
		public List<Banco> GetBancos()
		{
			List<Banco> pac = null;

				using (var db = new Data())
				{
					pac = db.Bancos.ToList();

			}
			
			return pac;
		}
	}
}
