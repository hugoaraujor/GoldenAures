using System;
using System.Linq;
using AurumData;
using AurumDataEntity;
using System.Data.Entity.Validation;

namespace AurumBusiness.Controllers
{
	public class AperturasManager
	{

			
			#region Insert

			public void InsertClase(AperturaDTO NewClase)
			{
				var x = NewClase;
				using (var db = new Data())
				{
					db.Aperturas.Add(new Apertura()  
					{
					  Fecha=DateTime.Now,
					   Monto=x.Monto
					  

					});

					db.SaveChanges();


				}
			}

			#endregion
			#region Delete

			public void Delete(int IdClase)
			{
				using (var db = new  Data())
				{
					Apertura query = (from x in db.Aperturas
												 where x.Idapertura== IdClase
												 select x).FirstOrDefault<Apertura>();
					if (query!= null)
					{
						db.Aperturas.Remove(query);
						db.SaveChanges();
					}
				}
			}

			#endregion
			#region Existe

			public bool ExisteApertura()
			{
				bool resp = false;
				using (var db = new Data())
				{
					Apertura Edo = (from x in db.Aperturas where x.Fecha ==DateTime.Now select x).FirstOrDefault();
					if (Edo != null)
					{
						resp = true;
					}

				}
				return resp;
			}
			#endregion


			#region Edit

			public void Edit(AperturaDTO Editedclass)
			{
				var x = Editedclass;

				try
				{
					using (var db = new Data())
					{
						var pac = (from p in db.Aperturas where p.Idapertura == Editedclass.Idapertura select p).FirstOrDefault();
						if (pac != null)
						{
							
							pac.Monto = x.Monto;
							pac.Fecha = x.Fecha;

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


