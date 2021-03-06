﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AurumData
{
	public class PagoView
	{
		public PagoView()
		{
		
		}

		public PagoView(string detalle, decimal cambio)
		{
			this.detalle = detalle;
			this.cambio = cambio;
			this.nota = "";
		}

		public  int idpago { get; set; }
		public string clase { get; set; }
		public  Decimal montopago { get; set; }
		public string detalle { get; set; }
		public string nota { get; set; }
		public decimal cambio { get; set; }
		public int tipopago { get; set; }
	}
	[Table("Pagos")]
	public class Pago
	{
	
		private int idpago;
		private int tipopago;
		private Decimal montopago;
		private Decimal cambio;
		[StringLength(10)]
		private string factura;
		[StringLength(10)]
		private string nota;
	

		public Pago()
		{
			
		}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idpago { get => idpago; set => idpago = value; }
		public int Tipopago { get => tipopago; set => tipopago = value; }
		public decimal Montopago { get => montopago; set => montopago = value; }
		public decimal Cambio { get => cambio; set => cambio = value; }
		public string Factura { get => factura; set => factura = value; }
		public string Nota { get => nota; set => nota = value; }



	}
}
