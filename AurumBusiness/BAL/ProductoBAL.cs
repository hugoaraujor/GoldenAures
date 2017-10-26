using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class ProductoBAL
	{
		private ProductoBAL umanager;
		private ProductoBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new ProductoBAL());
			}
		}

		public bool ExisteProducto(int Productoid)
		{
			return UManager.ExisteProducto(Productoid);
		}


		public void Inserta(ProductoDTO producto)
		{
			UManager.Inserta(producto);
		}

		public void Edit(ProductoDTO area)
		{
			UManager.Edit(area);
		}
		public void DeleteProducto(int Idarea)
		{
			UManager.DeleteProducto(Idarea);
		}
	}
}
