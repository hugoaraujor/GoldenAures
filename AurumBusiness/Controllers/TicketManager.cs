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
	public class TicketManager
	{
		public TicketDTO GetTicketDTO(int id)
		{
			AurumData.Ticket query = null;
			using (var db = new Data())
			{
				query = (from x in db.Tickets where x.Id== id select x).First();

			}
			TicketDTO B = new TicketDTO {   Id = query.Id, TicketTipo = query.TicketTipo };
			return B;
		}
		#region Insert

		public void Insert(TicketDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				db.Tickets.Add(new Ticket()
				{  
					  TicketTipo = x.TicketTipo



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
				Ticket query = (from x in db.Tickets
								 where x.Id == IdClase
								 select x).FirstOrDefault<Ticket>();
				if (query != null)
				{
					db.Tickets.Remove(query);
					db.SaveChanges();
				}
			}
		}

		public List<ListaDTO> GetList()
		{
			List<Ticket> pac = new List<Ticket>();
			using (var db = new Data())
			{
				pac = db.Tickets.ToList();

			}
			List<ListaDTO> LstResp = new List<ListaDTO>();
			foreach (Ticket a in pac)
			{
				ListaDTO Ret = new ListaDTO { index = a.Id, descriptor = a.TicketTipo };
				LstResp.Add(Ret);
			}
			return LstResp;

		}

		#endregion
		#region Existe

		public bool Existe(string ticketstr)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Ticket Edo = (from x in db.Tickets where x.TicketTipo == ticketstr select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public bool Edit(TicketDTO Editedclass)
		{
			bool resp = true;
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Tickets where p.Id == Editedclass.Id select p).FirstOrDefault();
					if (pac != null)
					{
						pac.TicketTipo = x.TicketTipo;
						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{ resp = false; }
			return resp;
		}

		#endregion
		public List<Ticket> GetTickets()
		{
			List<Ticket> pac = new List<Ticket>();
			using (var db = new Data())
			{
				pac = db.Tickets.ToList();

			}
			return pac;
		}

	}
}
