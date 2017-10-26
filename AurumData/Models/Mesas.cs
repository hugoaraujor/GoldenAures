using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Mesas")]
	public class Mesa
	{
		private int idmesa;
		[StringLength(10)]
		private string siglas;
		private bool ocupada;
		
		private DateTime hora;
		private int? idmesonero;
		private int?  idocupante;
		private int area;
		private EstadosMesa estado;

		public Mesa()
		{

		}

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idmesa { get => idmesa; set => idmesa = value; }
		public string Siglas { get => siglas; set => siglas = value; }
		public bool Ocupada { get => ocupada; set => ocupada = value; }
		public DateTime Hora { get => hora; set => hora = value; }
		public int Area { get => area; set => area = value; }
		public  EstadosMesa Estado{ get => estado; set => estado= value; }
		public int? Idmesonero { get => idmesonero; set => idmesonero = value; }
		public int? Idocupante { get => idocupante; set => idocupante = value; }
	}
}
