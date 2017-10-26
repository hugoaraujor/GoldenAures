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
	public class DetalleFacturaManager
	{
			#region Insert

			public void Insert(DetalleFacturaDTO NewClase)
			{
				var x = NewClase;
				using (var db = new Data())
				{
					db.DetalleFactura.Add(new DetalleFactura()
					{
			
						Factura=x.Factura,
						Cant=x.Cant,
						Codigoproducto=x.Codigoproducto,
						Iva=x.Iva,
						Monto=x.Monto,
						Nota=x.Nota
						

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
				DetalleFactura query = (from x in db.DetalleFactura
								  where x.Id == IdClase
								  select x).FirstOrDefault<DetalleFactura>();
					if (query != null)
					{
						db.DetalleFactura.Remove(query);
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
				DetalleFactura Edo = (from x in db.DetalleFactura where x.Factura == factura select x).FirstOrDefault();
					if (Edo != null)
					{
						resp = true;
					}

				}
				return resp;
			}
			#endregion


			#region Edit

			public void Edit(DetalleFacturaDTO Editedclass)
			{
				var x = Editedclass;

				try
				{
					using (var db = new Data())
					{
						var pac = (from p in db.DetalleFactura where p.Factura == Editedclass.Factura select p).FirstOrDefault();
						if (pac != null)
						{
						pac.Factura = x.Factura;
						pac.Cant = x.Cant;
						pac.Codigoproducto = x.Codigoproducto;
						pac.Iva = x.Iva;
						pac.Monto = x.Monto;
						pac.Nota = x.Nota;


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


