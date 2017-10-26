using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData.Models
{
	public class Promociones
	{
		private int id;
        private Decimal minValue;
		private Decimal maxValue;
		private Decimal factorPrecio;
		private Decimal ivaPercent;
		private bool efectivo;
		private bool electronicos;
		private bool mixto;
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get => id; set => id = value; }
		public decimal MinValue { get => minValue; set => minValue = value; }
		public decimal MaxValue { get => maxValue; set => maxValue = value; }
		public decimal FactorPrecio { get => factorPrecio; set => factorPrecio = value; }
		public decimal IvaPercent { get => ivaPercent; set => ivaPercent = value; }
		public bool Efectivo { get => efectivo; set => efectivo = value; }
		public bool Electronicos { get => electronicos; set => electronicos = value; }
		public bool Mixto { get => mixto; set => mixto = value; }
	}
	
}
