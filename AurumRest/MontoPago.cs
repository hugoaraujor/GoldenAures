using System;

namespace AurumRest
{
	public class MontoPago
	{
		private int index;
		private ClasePago clasePago;
		private string tipo;
		private Decimal monto;
		private string detalle;

		public ClasePago ClasePago { get => clasePago; set => clasePago = value; }
		public string Tipo { get => tipo; set => tipo = value; }
		public decimal Monto { get => monto; set => monto = value; }
		public string Detalle { get => detalle; set => detalle = value; }
		public int Index { get => index; set => index = value; }
	}	
}
