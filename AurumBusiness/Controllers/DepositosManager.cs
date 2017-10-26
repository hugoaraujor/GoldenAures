using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AurumData;
using AurumDataEntity;
using System.Data.Entity.Validation;
using System.Data.Entity;
using AurumDataEntity.DataEntities;
using AurumData.Models;
using System.Linq;
namespace AurumBusiness.Controllers
{
	public class DepositosManager
	{

		public DepositoDTO GetDepositoDTO(int Iddep)
		{
			DepositoDTO resp = new DepositoDTO();
			using (var db = new Data())
			{
				var pac = (from p in db.Depositos where p.Depositoid == Iddep select p).First();
				if (pac != null)
				{
					resp = new DepositoDTO { Depositoid = pac.Depositoid, Descriptor= pac.Descriptor };
				}
			}
			return resp;

		}
		public List<ListaDTO> GetList()
		{
			var pac = GetDepositos();
			List<ListaDTO> LstResp = new List<ListaDTO>();
			foreach (Deposito a in pac)
			{
				ListaDTO Ret = new ListaDTO { index = a.Depositoid, descriptor = a.Descriptor };
				LstResp.Add(Ret);
			}
			return LstResp;

		}
		public List<Deposito> GetDepositos()
		{
			List<Deposito> query = null;
			using (var db = new Data())
			{
				query = (from x in db.Depositos select x).ToList();

			}
			return query;
		}
		#region Insert

		public void Insert(DepositoDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Depositos.Add(new Deposito()
				{
					Descriptor = NewClase.Descriptor


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
				Deposito query = (from x in db.Depositos
							  where x.Depositoid == IdClase
							  select x).FirstOrDefault();
				if (query != null)
				{
					db.Depositos.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool ExisteDeposito(string depnombre)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Deposito Edo = (from x in db.Depositos where x.Descriptor.ToLower() == depnombre.ToLower() select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public bool Edit(DepositoDTO Editedclass)
		{
		bool aux = false;
		var x = Editedclass;
		try
		{
		using (var db = new Data())
		{
				var pac = (from p in db.Depositos where p.Depositoid == Editedclass.Depositoid select p).FirstOrDefault();
				if (pac != null)
				{
					pac.Depositoid = Editedclass.Depositoid;
					pac.Descriptor = x.Descriptor;
				}
				db.Entry(pac).State = EntityState.Modified;
				db.SaveChanges();
				}
		}
		catch (DbEntityValidationException e)
		{
		aux = false;
		}
		return aux;
		}
		#endregion

	}
}


