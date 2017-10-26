using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Turnos")]
	public class Turno
	{

		private int idturno;
		private string  turnodesc;
		private string desde;
		private string hasta;

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idturno { get => idturno; set => idturno = value; }
		[StringLength(20)]
		public string Turnodesc { get => turnodesc; set => turnodesc = value; }
		[StringLength(5)]
		public string Desde { get => desde; set => desde = value; }
		[StringLength(5)]
		public string Hasta { get => hasta; set => hasta = value; }
	}
}
