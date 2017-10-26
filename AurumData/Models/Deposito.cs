using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData.Models
{	[Table("Depositos")]
    public class Deposito
	{
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		private int depositoid;
		[StringLength(20)]
		private string descriptor;
		
		public Deposito()
		{

		}
		public int Depositoid { get => depositoid; set => depositoid = value; }
		public string Descriptor { get => descriptor; set => descriptor = value; }
	
	}
}
