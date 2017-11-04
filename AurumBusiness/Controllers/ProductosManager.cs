using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace AurumBusiness.Controllers
{
	public class ProductoManager
	{
		public ProductoDTO GetProductoDTO(string codigo)
		{
			ProductoDTO B = new ProductoDTO();
			Producto query = null;
			using (var db = new Data())
			{
				query = (from x in db.Productos where x.Codigo == codigo select x).FirstOrDefault();

			}
			if (query != null)
				B = new ProductoDTO { Activo = query.Activo, Pesa = query.Pesa, Categoria = query.Categoria, Codigo = query.Codigo, Exento = query.Exento, IdProducto = query.IdProducto, Imagenurl = query.Imagenurl, Impresora = query.Impresora, Menu = query.Menu, Nombre = query.Nombre, PrecioNeto = query.PrecioNeto, Costo = query.Costo };
			return B;
		}
		public ProductoDTO GetProductoDTO(int id)
		{
			ProductoDTO B = new ProductoDTO();
			Producto query = null;
			using (var db = new Data())
			{
				query = (from x in db.Productos where x.IdProducto== id select x).FirstOrDefault();

			}
			if (query != null)
				B = new ProductoDTO { Activo=query.Activo, Pesa = query.Pesa,Categoria = query.Categoria, Codigo=query.Codigo, Exento=query.Exento, IdProducto=query.IdProducto, Imagenurl=query.Imagenurl, Impresora=query.Impresora,  Menu=query.Menu, Nombre=query.Nombre, PrecioNeto=query.PrecioNeto,  Costo=query.Costo  };
			return B;
		}
		public Producto GetProducto(int id)
		{
			Producto query = null;
			using (var db = new Data())
			{
				query = (from x in db.Productos where  x.IdProducto == id select x).First();

			}

			return query;
		}
		public DataTable GetAll()
		{

			DataTable dt = new DataTable();


			dt.Columns.Add("Id", typeof(int));
			dt.Columns.Add("Producto", typeof(string));
			dt.Columns.Add("Precio", typeof(string));
			List<Producto> cli = new List<Producto>();

			using (var db = new Data())
			{
				cli = (from x in db.Productos  select x).ToList();
			}


			foreach (Producto entity in cli)
			{
				var row = dt.NewRow();
				row["Id"] = entity.IdProducto;
				row["Producto"] = entity.Nombre;
				row["Precio"] = entity.PrecioNeto;
				dt.Rows.Add(row);
			}


			return dt;
		}
		#region Insert

		public void Insert(ProductoDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Productos.Add(new Producto()
				{
				Codigo = x.Codigo,
				Nombre = x.Nombre,
				PrecioNeto = x.PrecioNeto,
				Costo = x.Costo,
				PrecioTotal = x.PrecioTotal,
				Exento = x.Exento,
				Impresora = x.Impresora,
				Activo = x.Activo,
				Menu = x.Menu,
				Categoria=x.Categoria,
				Imagenurl = x.Imagenurl

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
				Producto query = (from x in db.Productos
							  where x.IdProducto == IdClase
							  select x).FirstOrDefault<Producto>();
				if (query != null)
				{
					db.Productos.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existe(string  prodstr)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Producto Edo = (from x in db.Productos where x.Nombre == prodstr select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}

	
		#endregion


		#region Edit

		public void Edit(ProductoDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Productos where p.IdProducto == Editedclass.IdProducto select p).FirstOrDefault();
					if (pac != null)
					{
						pac.Codigo = x.Codigo;
						pac.Nombre = x.Nombre;
						pac.PrecioNeto = x.PrecioNeto;
						pac.Costo = x.Costo;
						pac.PrecioTotal = x.PrecioTotal;
						pac.Exento = x.Exento;
						pac.Impresora = x.Impresora;
						pac.Activo = x.Activo;
						pac.Menu = x.Menu;
						pac.Categoria = x.Categoria;
						pac.Imagenurl = x.Imagenurl;
						pac.IdProducto = x.IdProducto;
						db.Productos.Attach(pac);
						
						db.Entry(pac).State = System.Data.Entity.EntityState.Modified;
						//var entry = db.Entry(updatedUser);
						//entry.State = EntityState.Modified;

						//entry.Property(e => e.Password).IsModified = false;
						//entry.Property(e => e.SSN).IsModified = false;

						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{ }
		}

	

	
	public List<ListaDTO> GetActives()
	{


		List<ListaDTO> activeCategorias = new List<ListaDTO>();
		List<Categoria> query;
		using (var db = new Data())
		{
			query = (from x in db.Categorias where x.Activo select x).ToList();
		}


		foreach (Categoria entity in query)
		{
			var archivo = "";
			activeCategorias.Add(new ListaDTO { descriptor = entity.CategoriaDesc, file = archivo, index = entity.Idcategoria });

		}

		return activeCategorias;
	}
	public List<ListaDTO> GetProductos(int categoryNumber,bool activos=false)
	{
		var x = categoryNumber;
		List<ListaDTO> lista = new List<ListaDTO>();
			List<Producto> pac;
			try
			{
				using (var db = new Data())
				{
					pac = (from p in db.Productos where (p.Activo == activos) && (p.Categoria == categoryNumber) select p).ToList();

				}
				foreach (Producto p in pac)
				{
					lista.Add(new ListaDTO { descriptor = p.Nombre, index = p.IdProducto, file = p.Imagenurl, pesa = p.Pesa });
				}
			}
			catch {  Exception e=new Exception();
				Console.WriteLine(e.Message);
			}
			


			return lista;
	}
		#endregion

	}
}
