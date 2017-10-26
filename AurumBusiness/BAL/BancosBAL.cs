using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class BancosBAL
	{
		private BancosBAL umanager;
		private BancosBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new BancosBAL());
			}
		}

		public bool ExisteBanco(int Banco)
		{
			return UManager.ExisteBanco(Banco);
		}


		public void Insert(BancoDTO bancos)
		{
			UManager.Insert(bancos);
		}

		public void Edit(BancoDTO bancos)
		{
			UManager.Edit(bancos);
		}
		public void DeleteBancos(int IdBancos)
		{
			UManager.DeleteBancos(IdBancos);
		}
	}
}
