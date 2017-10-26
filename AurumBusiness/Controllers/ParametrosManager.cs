using AurumData;
using AurumDataEntity;
using System.Data.Entity.Validation;
using System.Linq;
namespace AurumBusiness.Controllers
{
	public class ParametrosManager
	{
		#region Insert

		public void Insert(ParametroDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Parametros.Add(new Parametro()
				{
					Id=0,
				Caja = x.Caja,
				Empresa = x.Empresa,
				Phone=x.Phone,
				PorcentajeIva=x.PorcentajeIva,
				Rif=x.Rif,
				Serial=x.Serial,
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
				Parametro query = (from x in db.Parametros where x.Id == IdClase  select x).FirstOrDefault<Parametro>();
				if (query != null)
				{
					db.Parametros.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		

		

		#region Edit

		public void Edit(ParametroDTO Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					Parametro pac = (from p in db.Parametros where p.Id == Editedclass.Id select p).FirstOrDefault();
					if (pac != null)
					{

					
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