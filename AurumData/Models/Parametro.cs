using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Parametros")]
	public class Parametro
	{
		
		private int id;
		private Decimal porcentajeIva;
		private string caja;
		private string empresa;
		[StringLength(15)]
		private string rif;
		[StringLength(25)]
		private string phone;
		[StringLength(25)]
		private string serial;
		
		
		
		public Parametro()
		{

		}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get => id; set => id = value; }
		public decimal PorcentajeIva { get => porcentajeIva; set => porcentajeIva = value; }
		public string Caja { get => caja; set => caja = value; }
		public string Empresa { get => empresa; set => empresa = value; }
		public string Rif { get => rif; set => rif = value; }
		public string Phone { get => phone; set => phone = value; }
		public string Serial { get => serial; set => serial = value; }
	
		public void SetIva(int numero)
		{
			porcentajeIva = numero / 100;
		}
		public decimal GetIva()
		{
			return porcentajeIva;
		}
	}
}
