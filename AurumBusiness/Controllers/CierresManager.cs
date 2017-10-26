using AurumData;
using AurumDataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.Controllers
{
	public class CierresManager
	{
		#region Insert

		public void Insert(CierreDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Cierres.Add(new Cierre()
				{
				
				Monto = x.Monto,
				Inicio = x.Inicio,
				Fin = x.Fin,
				Cambio = x.Cambio,
				Cheque = x.Cheque,
				Efectivo = x.Efectivo,
				Debito = x.Debito,
				Otros = x.Otros,
				Fecha = x.Fecha,
				Usuarioid = x.Usuarioid


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
				Apertura query = (from x in db.Aperturas
								  where x.Idapertura == IdClase
								  select x).FirstOrDefault<Apertura>();
				if (query != null)
				{
					db.Aperturas.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existe()
		{
			bool resp = false;
			using (var db = new Data())
			{
				Apertura Edo = (from x in db.Aperturas where x.Fecha == DateTime.Now select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public void Edit(CierreDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Cierres where p.Idcierre == Editedclass.Idcierre select p).FirstOrDefault();
					if (pac != null)
					{

						pac.Monto = x.Monto;
						pac.Inicio = x.Inicio;
						pac.Fin = x.Fin;
						pac.Cambio = x.Cambio;
						pac.Cheque = x.Cheque;
						pac.Efectivo = x.Efectivo;
						pac.Debito = x.Debito;
						pac.Otros = x.Otros;
						pac.Fecha = x.Fecha;
						pac.Usuarioid = x.Usuarioid;
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

