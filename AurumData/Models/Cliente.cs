using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurumData
{
	[Table("Clientes")]
	public class Cliente
	{
		//[Key]
		//[Column(Order = 1)]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		private int idcliente;
		[Required]
		[StringLength(13)]
		[Key]
		[Column(Order = 2)]
		private string identificacion;
		[Required]
		[StringLength(80)]
		private string nombre;
		
		[Required]
		[StringLength(100)]
		private string direccion;
		[StringLength(30)]
		private string telefono;
		private bool credito;
		private bool debito;
		public Cliente()
		{

		}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idcliente
		{
			get
			{
				return idcliente;
			}
			set
			{
				idcliente= value;
			}

		}
		public  string Nombre
		{
			get
			{
				return nombre;
			}
			set
			{
				 nombre=value;
			}

		}
		public string Identificacion
		{
			get
			{
				return identificacion;
			}
			set
			{
				identificacion = value;
			}

		}
		public string Direccion
		{
			get
			{
				return direccion;
			}
			set
			{
				direccion = value;
			}

		}
		public string Telefono
		{
			get
			{
				return telefono;
			}
			set
			{
				telefono = value;
			}

		}

		public bool Credito { get => credito; set => credito = value; }
		public bool Debito { get => debito; set => credito = debito; }
	}
}