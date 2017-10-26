using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class TarjetaBAL
	{
		private TarjetaBAL umanager;
		private TarjetaBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new TarjetaBAL());
			}
		}

		public bool ExisteTarjeta(int Tarjetaid)
		{
			return UManager.ExisteTarjeta(Tarjetaid);
		}


		public void InsertTarjeta(TarjetaDTO area)
		{
			UManager.InsertTarjeta(area);
		}

		public void EditTarjeta(TarjetaDTO area)
		{
			UManager.EditTarjeta(area);
		}
		public void DeleteTarjeta(int Idarea)
		{
			UManager.DeleteTarjeta(Idarea);
		}
	}
}
