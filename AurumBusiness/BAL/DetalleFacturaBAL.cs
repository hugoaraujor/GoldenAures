using AurumBusiness.Controllers;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
		public class DetallefacturaBAL
		{
				private DetalleFacturaManager umanager;
				private DetalleFacturaManager UManager
				{
					get
					{
						return umanager ?? (umanager = new DetalleFacturaManager());
					}
				}



				public void Insert(DetalleFacturaDTO apertura)
				{
					UManager.Insert(apertura);
				}

				public void Edit(DetalleFacturaDTO cargo)
				{
					UManager.Edit(cargo);
				}
				public void Delete(int Id)
				{
					UManager.Delete(Id);
				}
		}
}

