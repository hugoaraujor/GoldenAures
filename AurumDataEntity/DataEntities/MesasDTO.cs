using System;


using AurumData;
namespace AurumDataEntity
{
	

	public class MesaDTO
	{

		public int Idmesa { get; set;} 
		public string Siglas { get; set; }
		public bool Ocupada { get; set; }
		public DateTime Hora { get; set; }
		public int? idmesonero { get; set; }
		public int? idocupante { get; set; }
		public int Area { get; set; }
		public EstadosMesa Estado { get; set; }
	}
}
