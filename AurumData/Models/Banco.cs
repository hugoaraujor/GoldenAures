using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Bancos")]
	public class Banco
	{
		
		private int idbanco;
		[StringLength(100)]
		private string nombre;

		public Banco()
		{

		}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idbanco { get => idbanco; set => idbanco = value; }
		public string Nombre { get => nombre; set => nombre = value; }
	}
}
