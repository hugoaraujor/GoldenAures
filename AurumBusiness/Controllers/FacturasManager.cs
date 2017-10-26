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
				DescuentoTasa = x.DescuentoTasa,
				Descuento = x.Descuento,
				Equipo = x.Equipo,
				Facturanro = x.Facturanro,
				Iva = x.Iva,
				Mesa = x.Mesa,
				Montoneto = x.Montoneto,
				Nota = x.Nota,
				Serial = x.Serial,
				Sirve = x.Sirve,
				Tasa = x.Tasa,
				Total = x.Total,
				Userid = x.Userid,
				Usuario = x.Usuario,
				Moneda=x.Moneda


			});

				db.SaveChanges();


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
						pac.DescuentoTasa=x.DescuentoTasa;
						pac.Descuento=x.Descuento;
						pac.Equipo = x.Equipo;
						pac.Facturanro = x.Facturanro;
						pac.Iva = x.Iva;
						pac.Mesa = x.Mesa;
						pac.Montoneto = x.Montoneto;
						pac.Nota = x.Nota;
						pac.Serial = x.Serial;
						pac.Sirve = x.Sirve;
						pac.Tasa = x.Tasa;
						pac.Total = x.Total;
						pac.Userid = x.Userid;
						pac.Usuario = x.Usuario;
						pac.Moneda = x.Moneda;

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
