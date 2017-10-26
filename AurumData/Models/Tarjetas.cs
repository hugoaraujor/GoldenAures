using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurumData
{  [Table("Tarjetas")]
	public class Tarjeta
	{
	
		private int idtarjeta;
		[StringLength(22)]
		private string tarjetatipo;

		public Tarjeta()
		{

		}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idtarjeta { get => idtarjeta; set => idtarjeta = value; }
		public string Tarjetatipo { get => tarjetatipo; set => tarjetatipo = value; }
	}
}
