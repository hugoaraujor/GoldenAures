using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Tickets")]
	public class Ticket
	{
		
		
			private int id;
			[StringLength(25)]
			private string ticketTipo;

			public Ticket()
			{

			}
			[Key]
			[Column(Order = 1)]
			[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
			public int Id { get => id; set => id= value; }
			public string TicketTipo { get => ticketTipo; set => ticketTipo = value;
		}
	}
}
