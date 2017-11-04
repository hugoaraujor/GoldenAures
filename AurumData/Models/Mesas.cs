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
		private string siglas;
		private bool ocupada;
		
		private DateTime hora;
		private int? idmesonero;
		private int?  idocupante;
		private int area;
		private EstadosMesa estado;
		private int personas;
		private bool multiplesCuentas;
		public Mesa()
		{
			siglas = "0";
			Idmesonero = 0;
			idocupante = 0;
			ocupada = false;
			estado = EstadosMesa.Disponible;
		}

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idmesa { get => idmesa; set => idmesa = value; }
		[Key]
		[Column(Order = 2)]
		[StringLength(6)]
		public string Siglas { get => siglas; set => siglas = value; }
		public bool Ocupada { get => ocupada; set => ocupada = value; }
		public DateTime Hora { get => hora; set => hora = value; }
		public int Area { get => area; set => area = value; }
		public  EstadosMesa Estado{ get => estado; set => estado= value; }
		public int? Idmesonero { get => idmesonero; set => idmesonero = value; }
		public int? Idocupante { get => idocupante; set => idocupante = value; }
		public bool MultiplesCuentas { get => multiplesCuentas; set => multiplesCuentas = value; }
		public int Personas { get => personas; set => personas = value; }
	}
}
