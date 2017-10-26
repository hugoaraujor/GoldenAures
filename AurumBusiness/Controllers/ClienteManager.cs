using AurumData;
using AurumDataEntities;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Data;


namespace AurumBusiness.Controllers
{
	public class ClienteManager
	{
		
		#region Insert

		public void Insert(ClienteDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Clientes.Add(new Cliente()
				{
					Identificacion = x.Identificacion,
					Idcliente = x.Idcliente,
					Nombre = x.Nombre,
					Telefono = x.Telefono,
					Direccion = x.Direccion



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
				Cliente query = (from x in db.Clientes
								 where x.Idcliente == IdClase
								 select x).FirstOrDefault<Cliente>();
				if (query != null)
				{
					db.Clientes.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existe(ClienteDTO cliente)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Cliente cli = (from x in db.Clientes where x.Idcliente == cliente.Idcliente select x).FirstOrDefault();
				if (cli != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		public bool existeCedula(ClienteDTO cliente)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Cliente cli = (from x in db.Clientes where x.Identificacion == cliente.Identificacion select x).FirstOrDefault();
				if (cli != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		public Cliente existeCedula(string cedula)
		{

			Cliente cli = new Cliente();
			using (var db = new Data())
			{
				cli = (from x in db.Clientes where x.Identificacion == cedula select x).FirstOrDefault();
			}
			return cli;
		}
		#endregion
		public DataTable GetClientes()
		{

			DataTable dt = new DataTable();
			List<Cliente> cli = new List<Cliente>();

			dt.Columns.Add("Idcliente", typeof(int));
			dt.Columns.Add("Identificación", typeof(string));
			dt.Columns.Add("Nombre", typeof(string));
			dt.Columns.Add("Teléfonos", typeof(string));


			using (var db = new Data())
			{
				cli = (from x in db.Clientes select x).ToList();
			}


			foreach (Cliente entity in cli)
			{
				var row = dt.NewRow();
				row["Idcliente"] = entity.Idcliente;
				row["Identificación"] = entity.Identificacion;
				row["Nombre"] = entity.Nombre;
				row["Teléfonos"] = entity.Telefono;
				dt.Rows.Add(row);
			}


			return dt;
		}
		public long GetClientesRecords()
		{
			long cliRecords = 0;

			using (var db = new Data())
			{
				cliRecords = (from x in db.Clientes select x).LongCount<Cliente>();
			}


			return cliRecords;
		}
		public ClienteDTO GetClienteDTO(int currentindex)
		{
			ClienteDTO cliente = new ClienteDTO() { Credito = false, Debito = false, Direccion = "", Idcliente = -1, Identificacion = "V-            ", Nombre = "", Telefono = "" };


			using (var db = new Data())
			{
				if (currentindex > 0)
				{
					Cliente query = (from x in db.Clientes where x.Idcliente == currentindex select x).FirstOrDefault();
					cliente = new ClienteDTO
					{
						Credito = query.Credito,
						Debito = query.Debito,
						Idcliente = query.Idcliente,
						Direccion = query.Direccion,
						Nombre = query.Nombre,
						Identificacion = query.Identificacion,
						Telefono = query.Telefono
					};
				}
				else
					return null;
			};



			return cliente;

		}



		#region Edit

		public void Edit(ClienteDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Clientes where p.Idcliente == Editedclass.Idcliente select p).FirstOrDefault();
					if (pac != null)
					{

						pac.Identificacion = x.Identificacion;
						pac.Idcliente = x.Idcliente;
						pac.Nombre = x.Nombre;
						pac.Telefono = x.Telefono;
						pac.Direccion = x.Direccion;
						db.Clientes.Attach(pac);
						db.Entry(pac).State = System.Data.Entity.EntityState.Modified;
						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{ }
		}
		#endregion
		public List<Cliente> getPrimeros(string text)
		{
			List<Cliente> cliRecords = null;
			using (var db = new Data())
			{
				cliRecords = (from x in db.Clientes where x.Identificacion.IndexOf(text)>-1 select x).ToList();
				return cliRecords;
			}
		}
		public Cliente getCedula(List<Cliente> query,string cedula)
		{
			Cliente cliente=new Cliente();
			using(Data db = new Data())
			{
				if (query.Count() > 0)
				{
					 cliente = query.FirstOrDefault(u => u.Identificacion == cedula);
				}
				return cliente;
			}
			
		}
	}

	

}


