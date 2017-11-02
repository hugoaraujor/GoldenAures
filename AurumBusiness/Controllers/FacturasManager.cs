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
	public class FacturasManager
	{
		#region Insert

		public void Insert(FacturaDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Facturas.Add(new Factura()
				{

					Caja = x.Caja,
					Descuento = x.Descuento,
					Equipo = x.Equipo,
					Facturanro = x.Facturanro,
					Montoiva=x.Montoiva,
                    Mesa = x.Mesa,
					Montoneto = x.Montoneto,
					Nota = x.Nota,
					Serial = x.Serial,
					Sirve = x.Sirve,
					Tasa = x.Tasa,
					Total = x.Total,
					Userid = x.Userid,
					ClienteID = x.ClienteID,
					Moneda = x.Moneda,
					Anulada = x.Anulada,
					Exento=0,
					Fecha=DateTime.Now,
					Cierrex=x.Cierrex,
					Cierrez = x.Cierrez

				});
				try
				{
					db.SaveChanges();
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}


			}
		}

		#endregion
		#region Delete

		public void Delete(string Factura)
		{
			using (var db = new Data())
			{
				Factura query = (from x in db.Facturas
										where x.Facturanro == Factura
										select x).FirstOrDefault<Factura>();
				if (query != null)
				{
					db.Facturas.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existe(string factura)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Factura query= (from x in db.Facturas where x.Facturanro == factura select x).FirstOrDefault();
				if (query != null)
				{
					resp = true;
				}

			}
			return resp;
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
		#endregion

	}

	
}
