using System.Collections.Generic;
using System.Data;
using AurumDataEntity;
using AurumBusiness.Controllers;

namespace AurumBusiness
{
	public class AperturaBAL
	{
		private AperturasManager umanager;
		private AperturasManager UManager
		{
			get
			{
				return umanager ?? (umanager = new AperturasManager());
			}
		}
		
		public bool ExisteAperturaHoy()
		{
			return UManager.ExisteApertura();
		}

		
		public void InsertApertura(AperturaDTO apertura)
		{
			UManager.InsertClase(apertura);
		}

		public void EditCity(AperturaDTO cargo)
		{
			UManager.Edit(cargo);
		}
		public void DeleteApertura(int IdCargo)
		{
			UManager.Delete(IdCargo);
		}
	}
}
