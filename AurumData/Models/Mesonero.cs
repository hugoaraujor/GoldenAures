using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurumData
{

	[Table("Mesoneros")]
	public class Mesonero
	{
		
		private int idmesonero;
		[StringLength(10)]
		private string identificacion;
		[StringLength(60)]
		private string nombre;
		[StringLength(60)]
		private string direccionemail;
		[StringLength(30)]
		private string telefono;
		[StringLength(15)]
		private string clave;
		private int puntos;
		private decimal acumulado;
		private long servicios;
		private bool  activo;
		private bool sistema;
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idmesonero { get => idmesonero; set => idmesonero = value; }
		public string Identificacion { get => identificacion; set => identificacion = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public string Direccionemail { get => direccionemail; set => direccionemail = value; }
		public string Telefono { get => telefono; set => telefono = value; }
		public string Clave { get => clave; set => clave = value; }
		public int Puntos { get => puntos; set => puntos = value; }
		public decimal Acumulado { get => acumulado; set => acumulado = value; }
		public long Servicios { get => servicios; set => servicios = value; }
		public bool Activo { get => activo; set => activo = value; }
		public bool Sistema { get => sistema; set => sistema = value; }

		public Mesonero()
		{

		}

	}
}