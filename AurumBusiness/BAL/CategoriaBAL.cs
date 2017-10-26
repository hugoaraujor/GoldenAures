using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class CategoriaBAL
	{
		private CategoriaBAL umanager;
		private CategoriaBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new CategoriaBAL());
			}
		}

		public bool ExisteCategoria(int Categoria)
		{
			return UManager.ExisteCategoria(Categoria);
		}


		public void Insert(CategoriaDTO bancos)
		{
			UManager.Insert(bancos);
		}

		public void Edit(CategoriaDTO bancos)
		{
			UManager.Edit(bancos);
		}
		public void DeleteCategorias(int IdCategorias)
		{
			UManager.DeleteCategorias(IdCategorias);
		}
	}
}

