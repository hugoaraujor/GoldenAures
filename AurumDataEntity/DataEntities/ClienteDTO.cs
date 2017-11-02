
namespace AurumDataEntities
{
	public class ClienteDTO
	{
		
		public int Idcliente { get; set; }
		public string Nombre { get; set; }
		public string Identificacion { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public bool Credito { get; set; }
		public bool Debito { get; set; }
	}
}