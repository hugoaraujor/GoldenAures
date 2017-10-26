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
	public class CuentasxCobrarManager
	{
		#region Insert

		public void Insert(CuentasxCobrarDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.cuentasxcobrar.Add(new CuentasxCobrar()
				{
				Cuentaid = x.Cuentaid,
				Descripcion = x.Descripcion,
				Fecha = x.Fecha,
				Idcliente = x.Idcliente,
				Monto = x.Monto,
				Paga = x.Paga,
				Resta = x.Resta



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
				CuentasxCobrar query = (from x in db.cuentasxcobrar
								  where x.Cuentaid == IdClase
								  select x).FirstOrDefault<CuentasxCobrar>();
				if (query != null)
				{
					db.cuentasxcobrar.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		


		#region Edit

		public void Edit(CuentasxCobrarDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.cuentasxcobrar where p.Cuentaid == Editedclass.Cuentaid select p).FirstOrDefault();
					if (pac != null)
					{
						pac.Cuentaid = x.Cuentaid;
						pac.Descripcion =x.Descripcion;
						pac.Fecha = x.Fecha;
						pac.Idcliente = x.Idcliente;
						pac.Monto = x.Monto;
						pac.Paga = x.Paga;
						pac.Resta = x.Resta;
						
					
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
