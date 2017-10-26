using AurumBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{
	public class AreaLista : IListStrategy
	{
		public List<ListaDTO> GetData()
		{
			List<Area> Ret;
			   AreaManager am = new AreaManager();
			Ret = am.GetAreas();
			var Ret2=ConvertListaaDTO(Ret, RetRTO);
			return Ret;
		}
	}
	public class BancoLista : IListStrategy
	{
		
		public List<Banco> GetData()
		{
			BancosManager bm = new BancosManager();
			var Ret = bm.GetBancos();
			return Ret;
		}

		
	}
	public class TarjetaLista : IListStrategy
	{
		
		
		public List<Tarjeta> GetData()
		{
			TarjetaManager bm = new TarjetaManager();
			var Ret = bm.GetTarjetas();
			return Ret;
		}
	}
	public class MenuLista : IListStrategy
	{
		
		public List<AurumData.Menu> GetData()
		{
			MenuManager bm = new MenuManager();
			var Ret = bm.GetData();
			return Ret;
		}

	
	}
}
