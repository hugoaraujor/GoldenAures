using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Categorias")]
	public class Categoria
	{

		private int idcategoria;
		private String categoriaDesc;
		private bool activo;
		private bool pesa;

		public Categoria()
		{
		}

		public Categoria(string descCategoria)
		{
			this.categoriaDesc = descCategoria;
		}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idcategoria { get => idcategoria; set => idcategoria = value; }
		public string CategoriaDesc { get => categoriaDesc; set => categoriaDesc = value; }
		public bool Activo { get => activo; set => activo = value; }
		public bool Pesa { get => pesa; set => pesa = value; }
	}
}
