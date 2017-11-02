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
	public class PagoManager
	{
		#region Insert

		public void Insert(PagoDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Pagos.Add(new Pago()
				{
				Factura = x.Factura,
				Cambio = x.Cambio,
				Montopago = x.Montopago,
				Nota = x.Nota,
				Tipopago = x.Tipopago
				  

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
				Pago query = (from x in db.Pagos
							  where x.Idpago == IdClase
							  select x).FirstOrDefault<Pago>();
				if (query != null)
				{
					db.Pagos.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion


		#region Edit

		public void Edit(PagoDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Pagos where p.Idpago == Editedclass.Idpago select p).FirstOrDefault();
					if (pac != null)
					{
						pac.Factura = x.Factura;
		  			pac.Cambio = x.Cambio;
						pac.Montopago = x.Montopago;
						pac.Nota = x.Nota;
						pac.Tipopago = x.Tipopago;
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
