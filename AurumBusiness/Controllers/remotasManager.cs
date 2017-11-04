using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AurumDataEntity;
using System.Data.Entity.Validation;
using System.Data.Entity;
using AurumDataEntity.DataEntities;
using AurumData;
using AurumData.Models;
using System.Data;

namespace AurumBusiness.Controllers
{
	public class remotasManager
	{
		public List<ListaDTO> GetList()
		{
			List<ListaDTO> LstResp = new List<ListaDTO>();
			List<remotas> query = null;
			using (var db = new Data())
			{
				query = (from x in db.Remotas select x).ToList();

			}
			foreach (remotas a in query)
			{
				ListaDTO Ret = new ListaDTO { index = a.remotaid, descriptor = a.nombre };
				LstResp.Add(Ret);
			}
			return LstResp;
		}
		public remotasDTO GetRemotaDTO(int id)
		{
			remotasDTO B = new remotasDTO();
			remotas query = null;
			using (var db = new Data())
			{
				query = (from x in db.Remotas where x.remotaid == id select x).FirstOrDefault();

			}
			if (query!=null)
			    B = new remotasDTO {  remotaid = query.remotaid, remota = query.remota, nombre=query.nombre };
			return B;
		}
		public remotas GetRemota(int id)
		{
			remotas query = null;
			using (var db = new Data())
			{
				query = (from x in db.Remotas where x.remotaid == id select x).First();

			}
			
			return query;
		}
		public List<remotas> GetRemotas()
		{
			List<remotas> query = null;
			using (var db = new Data())
			{
				query = (from x in db.Remotas select x).ToList();

			}
			return query;
		}
		#region Insert

		public void InsertClase(remotasDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Remotas.Add(new remotas()
				{
					remota = NewClase.remota,
					nombre = NewClase.nombre

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
				remotas query = (from x in db.Remotas
								 where x.remotaid == IdClase
								 select x).FirstOrDefault<remotas>();
				if (query != null)
				{
					db.Remotas.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existeremota(string remotastr)
		{
			bool resp = false;
			using (var db = new Data())
			{
				remotas Edo = (from x in db.Remotas where x.remota.ToLower() == remotastr.ToLower() select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion




		public bool Edit(remotasDTO Editedclass)
		{
			bool aux = false;
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Remotas where p.remotaid == Editedclass.remotaid select p).FirstOrDefault();
					if (pac != null)
					{
						pac.remotaid = Editedclass.remotaid;
						pac.remota = x.remota;
						pac.nombre = x.nombre;

					}
					db.Entry(pac).State = System.Data.Entity.EntityState.Modified;
					db.SaveChanges();
				}
			}
			catch (DbEntityValidationException e)
			{
				aux = false;
			}
			return aux;
		}

		public DataTable GetAll()
		{

			DataTable dt = new DataTable();


			dt.Columns.Add("Id", typeof(int));
			dt.Columns.Add("Remota", typeof(string));

			List<remotas> cli = new List<remotas>();

			using (var db = new Data())
			{
				cli = (from x in db.Remotas select x).ToList();
			}


			foreach (remotas entity in cli)
			{
				var row = dt.NewRow();
				row["Id"] = entity.remotaid;
				row["Remota"] = entity.nombre;
				dt.Rows.Add(row);
			}


			return dt;
		}
	}
}
