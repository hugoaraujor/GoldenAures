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
using System.Data;

namespace AurumBusiness.Controllers
{
	public class AreaManager
	{
		public DataTable GetAll()
		{

			DataTable dt = new DataTable();


			dt.Columns.Add("Id", typeof(int));
			dt.Columns.Add("Area", typeof(string));

			List<Area> cli = new List<Area>();

			using (var db = new Data())
			{
				cli = (from x in db.Areas select x).ToList();
			}


			foreach (Area entity in cli)
			{
				var row = dt.NewRow();
				row["Id"] = entity.Areaid;
				row["Area"] = entity.Descriptor;
				dt.Rows.Add(row);
			}


			return dt;
		}
		public List<ListaDTO> GetList()
		{    List<ListaDTO> LstResp = new List<ListaDTO>();
			List<Area> query = null;
			using (var db = new Data())
			{
				query = (from x in db.Areas select x).ToList();

			}
			foreach (Area a in query)
			{
				ListaDTO Ret = new ListaDTO { index = a.Areaid,  descriptor = a.Descriptor };
				LstResp.Add(Ret);
			}
			return LstResp;
		}
		public AreaDTO GetAreaDTO(int  id)
		{
			AurumData.Area query = new AurumData.Area();
			AreaDTO B = new AreaDTO();

			using (var db = new Data())
			{
				query = (from x in db.Areas  where x.Areaid==id select x).FirstOrDefault();

			}
			if (query != null)
			{
				B = new AreaDTO { Areaid = query.Areaid, Descriptor = query.Descriptor, File = query.File, Prefijo = query.Prefijo };
			}
			return B;
		}
	
		public List<Area> GetAreas()
		{
			List<Area> query = null;
			using (var db = new Data())
			{
				query = (from x in db.Areas select x).ToList();

			}
			return query;
		}
		#region Insert

		public void InsertClase(AreaDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Areas.Add(new Area()
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
				Area query = (from x in db.Areas
							  where x.Areaid == IdClase
							  select x).FirstOrDefault<Area>();
				if (query != null)
				{
					db.Areas.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool ExisteArea(string area)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Area Edo = (from x in db.Areas where x.Descriptor.ToLower() == area.ToLower() select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion




		public bool Edit(AreaDTO Editedclass)
		{
			bool aux = false;
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Areas where p.Areaid == Editedclass.Areaid select p).FirstOrDefault();
					if (pac != null)
					{
						pac.Areaid = Editedclass.Areaid;
						pac.Descriptor = x.Descriptor;
						pac.Mesas = x.Mesas;
					}
					//db.Areas.Attach(pac);
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

		public bool AsignarLayout(int id, string filename)
		{
			bool aux = false;


			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Areas where p.Areaid == id select p).FirstOrDefault();
					if (pac != null)
					{

						pac.File = filename;
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
		public List<Mesa> GetMesas(int area)
		{
			using (var db = new Data())
			{

				var query = (from x in db.Mesas where x.Area == area select x);
				if (query != null)
				{
					return query.ToList();
				}
				else
					return null;


			}
		}
		public int GetTotalMesas(int area)
		{
			int query = 0;
			using (var db = new Data())
			{
				try
				{
					query = (from x in db.Areas where x.Areaid == area select x).SingleOrDefault().Mesas;
				}
				catch { query = 0; }
				if (query != 0)
				{
					return query;
				}
				else
					return 0;


			}
		}
	}
}
