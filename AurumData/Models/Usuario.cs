using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Usuarios")]
	public class Usuario
	{
		
		private int iduser;
		[DataType(DataType.Text)]
		[StringLength(40)]
		private string userName;
		[StringLength(15)]
		private string clave;
		private bool iswaitress;
		[StringLength(100)]
		private string email;
		[StringLength(30)]
		private string phone;
		private rolenum rol;
		private bool online;
		private bool activo;

		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Iduser { get => iduser; set => iduser = value; }
		public string UserName { get => userName; set => userName = value; }
		public string Clave { get => clave; set => clave = value; }
		public bool Iswaitress { get => iswaitress; set => iswaitress = value; }
		public string Email { get => email; set => email = value; }
		public string Phone { get => phone; set => phone = value; }
		public rolenum Rol { get => rol; set => rol = value; }
		public bool Online { get => online; set => online = value; }
		public bool Activo { get => activo; set => activo = value; }

		public Usuario()
		{
			
		}
		public void SetRol(rolenum role)
		{
			rol = role;
		}
		
		public void GetEmail(string emailstr)
		{
		    this.email = emailstr;

		}
		public void GetPhone(string phonenum)
		{
			phone = phonenum;
		}
		public void IsWaitress(bool valor)
		{
			iswaitress = valor;
		}

		public static void LogUser(Usuario user)
		{
		 user.online = true;
		}
		public static void LogOutUser(Usuario user)
		{
		user.online = false;
		}
		public enum rolenum
		{
			Master = 0,
			Admin = 1,
			Supervisor = 2,
			Operator = 3,
			Waitress = 4
		}
	}
}
