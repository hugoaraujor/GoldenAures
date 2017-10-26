using System;

namespace AurumDataEntities
{
	public class CuentasxCobrarDTO
	{
	
		public DateTime Fecha { get; set; }
		public decimal Monto { get; set; }
		public int Idcliente { get; set; }
		public string Descripcion { get; set; }
		public decimal Paga { get; set; }
		public decimal Resta { get; set; }
		public int Cuentaid { get; set; }
	}
}
