using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	public class TicketDetalle
	{
		
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		private int id;
		private string codigoproducto;
		private Decimal monto;
		private Decimal iva;
		private Decimal cant;
		private string factura;
		private Decimal nota;
		private string mesa;
		private string adicionales;
		private string notas;

		public int Id { get => id; set => id = value; }
		public string Codigoproducto { get => codigoproducto; set => codigoproducto = value; }
		public decimal Monto { get => monto; set => monto = value; }
		public decimal Iva { get => iva; set => iva = value; }
		public decimal Cant { get => cant; set => cant = value; }
		public string Factura { get => factura; set => factura = value; }
		public decimal Nota { get => nota; set => nota = value; }
		public string Mesa { get => mesa; set => mesa = value; }
		public string Adicionales { get => adicionales; set => adicionales = value; }
		public string Notas { get => notas; set => notas = value; }
	}
}
