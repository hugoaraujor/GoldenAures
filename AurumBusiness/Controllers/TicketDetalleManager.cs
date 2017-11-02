using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AurumData;
using AurumDataEntity;
using System.Data.Entity.Validation;
using AurumDataEntity.DataEntities;
using System.Data.Entity;

namespace AurumBusiness.Controllers
{
	public class TicketDetalleManager
	{
		public List<TicketDetalle> GetList(string mesa)
		{

	//		List<TicketDetalle> query = new List<TicketDetalle>();
			List<TicketDetalle> detallesF= new List<TicketDetalle>();
			ProductoManager productoMngr = new ProductoManager();
			using (var db = new Data())
				{
					detallesF = (from x in db.TicketDetalle where x.Mesa==mesa select x).ToList();

				}
			//foreach (DetalleFactura d in detallesF)
			//{
			//	var prod=productoMngr.GetProductoDTO(d.Codigoproducto);
			//	query.Add(new TicketDetalle { Codigoproducto = d.Codigoproducto, Cant = d.Cant, Nombre = prod.Nombre, Neto = d.Monto, Iva = d.Iva, Montoiva = d.Monto * d.Iva, Mesa = d.Mesa, Factura = d.Factura });
			//}

			return detallesF;
		}
		public List<TicketDetalle> GetList(string mesastr="0",int ticket=0,bool zero=false)
		{
			
			List<TicketDetalle> query= new List<TicketDetalle>();
			if (!zero)
			{
				using (var db = new Data())
				{
					query = (from x in db.TicketDetalle where x.Mesa == mesastr && x.Ticket == ticket select x).ToList();

				}
			}
			if (mesastr!="0" && (!zero))
			{
				using (var db = new Data())
				{
					query = (from x in db.TicketDetalle where x.Mesa == mesastr select x).ToList();

				}
			}

			return query;
		}
		#region Insert

		public int Add(TicketDetalle NewClase)
		{
			int n = 0;
			var x = NewClase;
			using (var db = new Data())
			{
				var item = new TicketDetalle()
				{
					Codigoproducto = x.Codigoproducto,
					Cant = x.Cant,
					Ticket = x.Ticket,
					Neto = x.Neto,
					Monto = x.Monto,
					Iva = x.Iva,
					Factura = x.Factura,
					Adicionales = x.Adicionales,
					Mesa = x.Mesa,
					Id = x.Id,
					Nota = x.Nota,
					Notas = x.Notas,
					Nombre = x.Nombre,
					Origen=x.Origen
					
				};
				
				db.TicketDetalle.Add(item);
				db.SaveChanges();
				//db.Entry(item).GetDatabaseValues();
				n = item.Id;
				
				

			}
			return n;
		}

		#endregion
		#region Delete

		public void Delete(int ticket)
		{
			using (var db = new Data())
			{
				var  query = (from x in db.TicketDetalle
							   where x.Id == ticket
							   select x).DefaultIfEmpty();
				if (query != null)
				{
					foreach (TicketDetalle t in query)
					{
						db.TicketDetalle.Remove(t);
					}

					
					db.SaveChanges();
				}
			}
		}
		public void Delete(string mesa)
		{
			using (var db = new Data())
			{

				var query = db.TicketDetalle.Where(x => x.Mesa.TrimEnd() == mesa.TrimEnd()).ToList();
				db.TicketDetalle.RemoveRange(query);
				db.SaveChanges();
			}
			
		}
		#endregion
		public bool tienePedidos(string currentMesa)
		{
			bool resp;
			using (var db = new Data())
			{
				var query = db.TicketDetalle.Where(x => x.Mesa == currentMesa).ToList();
				if (query.Count == 0)
				{
					resp = false;
				}
				else
				{
					resp = true;
				}
			}
			return resp;
		}
		#region Edit

		public void Edit(TicketDetalle ticketEdit)
		{
			bool resp = true;
			var x=ticketEdit;
			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.TicketDetalle where p.Id == ticketEdit.Id select p).FirstOrDefault();
					pac.Neto = x.Neto;
					pac.Monto = x.Monto;
					pac.Cant = x.Cant;
					pac.Adicionales = x.Adicionales;
					pac.Mesa = x.Mesa;
					pac.Nombre = x.Nombre;
					pac.Origen = x.Origen;
					db.Entry(pac).State = EntityState.Modified;
					db.SaveChanges();
					
				}
			}
			catch (DbEntityValidationException e)
			{

				
			}
			
		}

		#endregion
		}
}
