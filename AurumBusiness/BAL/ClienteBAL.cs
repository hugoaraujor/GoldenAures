using AurumBusiness.Controllers;
using AurumDataEntities;


namespace AurumBusiness.BAL
{
	public class ClienteBAL
	{
		private ClienteManager umanager;
		private ClienteManager UManager
		{
			get
			{
				return umanager ?? (umanager = new ClienteManager());
			}
		}

		public bool ExisteCierreHoy(ClienteDTO cliente)
		{
			return UManager.Existe(cliente);
		}


		public void Insert(ClienteDTO cliente)
		{
			UManager.Insert(cliente);
		}

		public void Edit(ClienteDTO cliente)
		{
			UManager.Edit(cliente);
		}
		public void Delete(int IdCliente)
		{
			UManager.Delete(IdCliente);
		}
	}
}

