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
		public virtual byte Status { get; set; } = 0;
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		private int id;
		private int idproducto;
		[StringLength(10)]
		private string codigoproducto;
		[StringLength(29)]
		private string nombre;
		private Decimal cant;
		private Decimal neto;
		private Decimal monto;
		private Decimal iva;
		private Decimal montoiva;
		private string factura;
		private string nota;
		private string mesa;
		private string modificadores;
		private string adicionales;
		private string notas;
		private string origen;
		private int ticket;
		private int cuenta;

		public TicketDetalle()
	    {
 
        }

		

		public string Codigoproducto { get => codigoproducto; set => codigoproducto = value; }
		public string Nombre { get => nombre; set => nombre = value; }
		public decimal Cant { get => cant; set => cant = value; }
		public decimal Neto { get => neto; set => neto = value; }
		public decimal Monto { get => monto; set => monto = value; }
		public decimal Iva { get => iva; set => iva = value; }
		public string Factura { get => factura; set => factura = value; }
		public string  Nota { get => nota; set => nota = value; }
		public string Mesa { get => mesa; set => mesa = value; }
		public string Adicionales { get => adicionales; set => adicionales = value; }
		public string Notas { get => notas; set => notas = value; }
		public int Ticket { get => ticket; set => ticket = value; }

		public decimal Montoiva { get => montoiva; set => montoiva = value; }
		public int IdProducto { get => idproducto; set => idproducto = value; }
		public int Id { get => id; set => id = value; }
		public string Modificadores { get => modificadores; set => modificadores = value; }
		public string Origen { get => origen; set => origen = value; }
		public int Cuenta { get => cuenta; set => cuenta = value; }
	}
}
