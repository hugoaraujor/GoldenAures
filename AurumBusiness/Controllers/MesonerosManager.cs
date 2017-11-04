using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.Controllers
{
	public class MesonerosManager
	{
		public DataTable GetAll()
		{

			DataTable dt = new DataTable();


			dt.Columns.Add("Id", typeof(int));
			dt.Columns.Add("Mesero", typeof(string));

			List<AurumData.Mesonero> cli = new List<Mesonero>();

			using (var db = new Data())
			{
				cli = (from x in db.Mesoneros where x.Activo==true select x).ToList();
			}


			foreach(Mesonero entity in cli)
			{
				var row = dt.NewRow();
				row["Id"] = entity.Idmesonero;
				row["Mesero"] = entity.Nombre;
				dt.Rows.Add(row);
			}


			return dt;
		}
		#region Insert

		public void InsertClase(MesoneroDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Mesoneros.Add(new Mesonero()
				{
					 Activo=x.Activo,
					 Acumulado=x.Acumulado,
					 Direccionemail=x.Direccionemail,
					 Telefono=x.Telefono,
					  Clave=x.Clave,
					   Identificacion=x.Identificacion,
					   Nombre=x.Nombre,
					    Puntos=x.Puntos,
						 Servicios=x.Servicios,
						  Sistema=x.Sistema


				});

				db.SaveChanges();


			}
		}

		public Mesonero getMesero(int meseroid)
		{
			DataTable dt = new DataTable();

			Mesonero cli = new Mesonero();

			using (var db = new Data())
			{
				cli = (from x in db.Mesoneros where x.Idmesonero== meseroid select x).SingleOrDefault();
			}

			if (cli == null)
			{
				cli = new Mesonero();
				cli.Idmesonero =0;
				cli.Nombre = "NO ESPECIFICADO";
				cli.Puntos = 0;
				cli.Sistema = false;
			 }
			return cli;
		}

		#endregion
		#region Delete

		public void Delete(int IdClase)
		{
			using (var db = new Data())
			{
				Mesonero query = (from x in db.Mesoneros
							  where x.Idmesonero == IdClase
							  select x).FirstOrDefault();
				if (query != null)
				{
					db.Mesoneros.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existe(string mesonerostr)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Mesonero Edo = (from x in db.Mesoneros where x.Nombre == mesonerostr select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public void Edit(MesoneroDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Mesoneros where p.Idmesonero == Editedclass.Idmesonero select p).FirstOrDefault();
					if (pac != null)
					{

						pac.Activo = x.Activo;
						pac.Acumulado = x.Acumulado;
						pac.Direccionemail = x.Direccionemail;
						pac.Telefono = x.Telefono;
						pac.Clave = x.Clave;
						pac.Identificacion = x.Identificacion;
						pac.Nombre = x.Nombre;
						pac.Puntos = x.Puntos;
						pac.Servicios = x.Servicios;
						pac.Sistema = x.Sistema;
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
