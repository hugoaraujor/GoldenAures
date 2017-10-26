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
	public class UsuariosManager
	{
		
		public List<Usuario> GetUsuarios()
		{
			List<Usuario> query;
			using (var db = new Data())
			{
				 query = (from x in db.Usuarios
							 where x.Activo
							 select x).ToList();
				
			}
			return query;

		}
		#region Login
		public bool LoginUsuarios(string user,string clave)
		{
			bool logged = false;
			using (var db = new Data())
			{
				Usuario query = (from x in  db.Usuarios
								 where x.UserName == user && x.Clave== clave && x.Activo
								  select x).FirstOrDefault<Usuario>();
				if (query != null)
				{
					logged=true;
				}
				
					return logged;
			}
		}
		#endregion

		public Usuario GetUsuario(string username,string clave)
		{
			Usuario query = null;
			using (var db = new Data())
			{
				 query = (from x in db.Usuarios
								 where x.UserName== username && x.Clave==clave && x.Activo
								 select x).FirstOrDefault<Usuario>();
				
			return query;
			}
		}		
		#region Insert
		public void InsertUsuarios(UsuarioDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Usuarios.Add(new Usuario()
				{
					Iduser = x.Iduser,
					UserName = x.UserName,
					Clave = x.Clave,
					Iswaitress=x.Iswaitress,
					Email =x.Email,
					Phone=x.Phone,
					Rol =x.Rol,
					Online=x.Online,
					Activo=x.Activo 


	});

				db.SaveChanges();


			}
		}

		#endregion
		#region Delete

		public void DeleteUsuario(int IdUsuario)
		{
			using (var db = new Data())
			{
				Usuario query = (from x in db.Usuarios
							   where x.Iduser== IdUsuario
							   select x).FirstOrDefault<Usuario>();
				if (query != null)
				{
					db.Usuarios.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool ExisteUsuario(int userint)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Usuario Edo = (from x in db.Usuarios where x.Iduser == userint select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public void Edit(UsuarioDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Usuarios where p.Iduser == Editedclass.Iduser select p).FirstOrDefault();
					if (pac != null)
					{

					pac.Iduser = x.Iduser;
					pac.UserName = x.UserName;
					pac.Clave = x.Clave;
					pac.Iswaitress = x.Iswaitress;
					pac.Email = x.Email;
					pac.Phone = x.Phone;
					pac.Rol = x.Rol;
					pac.Online = x.Online;
					pac.Activo = x.Activo;
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
