using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AurumDataEntity;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Data;
using AurumData;

namespace AurumBusiness.Controllers
{
	public class CategoriasManager
	{
		#region Insert

		public void InsertCategorias(Categoria NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Categorias.Add(new Categoria()
				{

				CategoriaDesc = x.CategoriaDesc,
				Pesa = x.Pesa,
				Activo = x.Activo
				

			});
				//db.Categorias.Add(x);
			//	db.Entry(x).State = EntityState.Added;
				db.SaveChanges();


			}
		}

		#endregion
		#region Delete

		public void Delete(int IdCategoria)
		{
			using (var db = new Data())
			{
				Categoria query = (from x in db.Categorias
							   where x.Idcategoria == IdCategoria
							   select x).FirstOrDefault<Categoria>();
				if (query != null)
				{
					db.Categorias.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public  bool Existe(string categoriasstr)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Categoria Edo = (from x in db.Categorias where x.CategoriaDesc == categoriasstr select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}

		public static List<Categoria> getRecordsAll()
		{
			List<Categoria> pac = new List<Categoria>();
			try
			{
				using (var db = new Data())
				{
					 pac = (from p in db.Categorias where p.Activo select p).ToList();
				}
			}
			catch {

			}
			return pac;
		}
		#endregion


		#region Edit

		public void Edit(CategoriaDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Categorias where p.Idcategoria == Editedclass.Idcategoria select p).FirstOrDefault();
					if (pac != null)
					{

						pac.CategoriaDesc = x.CategoriaDesc;
						pac.Pesa = x.pesa;
						pac.Activo = x.activo;
						//db.Categorias.Attach(pac);
						db.Entry(pac).State = EntityState.Modified;
						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{ }
		}

		public DataTable GetAll()
		{

			DataTable dt = new DataTable();
			

			dt.Columns.Add("Id", typeof(int));
			dt.Columns.Add("Categorias", typeof(string));

			List<AurumData.Categoria> cli = new List<Categoria>();

			using (var db = new Data())
			{
				 cli  = (from x in db.Categorias select x).ToList();
			}


			foreach (Categoria entity in cli)
			{
				var row = dt.NewRow();
				row["Id"] = entity.Idcategoria;
				row["Categorias"] = entity.CategoriaDesc;
				dt.Rows.Add(row);
			}


			return dt;
		}
		public List<ListaDTO> GetActives()
		{

			
			List<ListaDTO> activeCategorias= new List<ListaDTO>();
			List<Categoria> query;
			using (var db = new Data())
			{
		          query = (from x in db.Categorias where x.Activo select x).ToList();
			}


			foreach (Categoria entity in query)
			{
				var archivo="";
				activeCategorias.Add(new ListaDTO { descriptor = entity.CategoriaDesc, file = archivo, index = entity.Idcategoria });

			}

			return activeCategorias;
		}
		public CategoriaDTO GetCatDTO(int currentindex)
		{
			var x = currentindex;
			CategoriaDTO catDto = new CategoriaDTO();
			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Categorias where p.Idcategoria == x select p).FirstOrDefault();
					if (pac != null)
					{
						catDto.activo = pac.Activo;
						catDto.CategoriaDesc = pac.CategoriaDesc;
						catDto.Idcategoria = pac.Idcategoria;
						catDto.pesa = pac.Pesa;
						
					}

				}
			}
			catch (DbEntityValidationException e)
			{ }
			return catDto;
		}
		
		#endregion

	}
}
