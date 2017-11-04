using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.Controllers
{
	public class FacturasManager
	{
		#region Existe

		public bool ExisteFact(string facturaserie)
		{
			bool resp = false;

			try
			{
				using (var db = new Data())
				{
					var query = (from x in db.Facturas where x.Facturanro == facturaserie select x).FirstOrDefault<Factura>();

					if (query != null)
						resp = true;
					//var query = (db.Facturas.Where(u => u.Facturanro.Trim() == facturaserie.Trim()).Any());

				}
			}
			catch (MyException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine("erro");
			}

			return resp;


		}
		#endregion
		#region Insert

		public void Insert(FacturaDTO NewClase)
		{
			var x=NewClase;
			var pac = new Factura();

			pac.Caja = x.Caja;
				pac.Descuento = x.Descuento;
			pac.Equipo = x.Equipo;
			pac.Facturanro = x.Facturanro;
			pac.Montoiva = x.Montoiva;
			pac.Mesa = x.Mesa;
			pac.Montoneto = x.Montoneto;
				pac.Nota = x.Nota;
				pac.Serial = x.Serial;
				pac.Sirve = x.Sirve;
			pac.Tasa = x.Tasa;
				pac.Total = x.Total;
				pac.Userid = x.Userid;
			pac.ClienteID = x.ClienteID;
			pac.Moneda = x.Moneda;
			pac.Anulada = x.Anulada;
			pac.Exento = 0;
				pac.Fecha = Convert.ToDateTime(DateTime.Now);
				pac.Cierrex = x.Cierrex;
				pac.Cierrez = x.Cierrez;
				pac.Id = 0;


		
			using (var db = new Data())
			{
				db.Facturas.Add(pac);
				db.Entry(pac).State = System.Data.Entity.EntityState.Added;
				db.SaveChanges();
			}

			
		}

		#endregion
		#region Delete

		public void Delete(string Factura)
		{
			using (var db = new Data())
			{
				var query = (from x in db.Facturas
										where x.Facturanro == Factura
										select x).FirstOrDefault<Factura>();
				if (query != null)
				{
					db.Facturas.Remove(query);
					db.Entry(query).State = EntityState.Deleted;
					db.SaveChanges();
				}
			}
		}

		#endregion
		


		#region Edit

		public void Edit(FacturaDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Facturas where p.Facturanro == Editedclass.Facturanro select p).FirstOrDefault();
					if (pac != null)
					{
						pac.Caja = x.Caja;
			
						pac.Descuento=x.Descuento;
						pac.Equipo = x.Equipo;
						pac.Facturanro = x.Facturanro;
						pac.Mesa = x.Mesa;
						pac.Montoneto = x.Montoneto;
						pac.Montoiva = x.Montoiva;
						pac.Nota = x.Nota;
						pac.Serial = x.Serial;
						pac.Sirve = x.Sirve;
						pac.Tasa = x.Tasa;
						pac.Total = x.Total;
						pac.Userid = x.Userid;
						pac.ClienteID = x.ClienteID;
						pac.Moneda = x.Moneda;
						pac.Cierrex = x.Cierrex;
						pac.Cierrez = x.Cierrez;
						pac.Fecha = x.Fecha;
						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{ }
		}
		public enum Cierreenum
		{
			X,
			Z
		}
		public void Cerrar(Cierreenum cierre,string nro)
		{
			

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Facturas where p.Cierrex==null select p);
					foreach (Factura f in pac)
					{
						if (pac != null && cierre == Cierreenum.X)
						{
							f.Cierrex = nro;
						}
						if (pac != null && cierre == Cierreenum.Z)
						{
							f.Cierrez = nro;
						}
					}
					db.SaveChanges();
				}
			}
			catch (DbEntityValidationException e)
			{ }
		}

		public Factura GetFactura(string Facturanro)
		{
			using (var db = new Data())
			{
				var pac = (from p in db.Facturas where p.Facturanro == Facturanro select p).FirstOrDefault();

				return pac;
			}

		}
		#endregion

	}

	
}
