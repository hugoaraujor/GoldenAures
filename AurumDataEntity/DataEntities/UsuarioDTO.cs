
using static AurumData.Usuario;

namespace AurumDataEntity
{
	public class UsuarioDTO
	{


		public int Iduser { get; set; }
		public bool Activo { get; set; }
		public string UserName { get; set; }
		public string Clave { get; set; }
		public string Secretquestion { get; set; }
		public string SecretAnswer { get; set; }
		public bool Iswaitress { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	    public rolenum Rol { get; set; }
		public bool Online { get; set; }
		public bool Activo1 { get; set; }

	}
}
