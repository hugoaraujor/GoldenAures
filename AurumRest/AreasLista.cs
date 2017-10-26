using AurumBusiness.Controllers;
using AurumData;
using AurumDataEntity;
using AurumDataEntity.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{

	public class AreasLista :IListStrategy
	{
		AreaManager am = new AreaManager();
		public List<ListaDTO> GetData ()
		{
			
			var Ret=  am.GetList();
			return Ret;
		}
		public void InsertItem(string str)
		{
			if (str.Length > 0 && (!am.ExisteArea(str)))
				am.InsertClase(new AreaDTO {  Descriptor = str });
		}
		public void DeleteItem(int intId)
		{
			am.Delete(intId);
		}
		public void EditaItem(int intId,string valor)
		{
			
			AreaDTO areax = am.GetAreaDTO(intId);
			  if (valor.Length > 0 &&  (areax.Descriptor != valor))
				am.Edit(new AreaDTO { Areaid = intId, Descriptor = valor });
		}
	}

	public class BancoLista :IListStrategy
	{

		BancosManager am = new BancosManager();
		public List<ListaDTO> GetData()
		{
			var Ret = am.GetList();
			return Ret;
		}
		public void InsertItem(string str)
		{
			if (str.Length > 0 && (!am.ExisteBanco(str)))
				am.InsertBancos(new BancoDTO {  Nombre = str });
		}
		public void DeleteItem(int intId)
		{
			am.DeleteBanco(intId);
		}
		public void EditaItem(int intId, string valor)
		{
			BancoDTO banco = am.GetBancoDTO(intId);
			if (valor.Length > 0 && (banco.Nombre != valor))
				am.Edit(new BancoDTO {  Idbanco = intId, Nombre = valor });
		}

	}
	public class TarjetaLista : IListStrategy
	{
		TarjetaManager am = new TarjetaManager();
		public List<ListaDTO>  GetData()
		{
			
			var Ret = am.GetList();
			return Ret;
		}
		public void InsertItem(string str)
		{
			if (str.Length > 0 && (!am.Existe(str)))
				am.Insert(new TarjetaDTO { Tarjetatipo = str });
		}
		public void DeleteItem(int intId)
		{
			am.Delete(intId);
		}
		public void EditaItem(int intId, string valor)
		{
			TarjetaDTO tarj = am.GetTarjetaDTO(intId);
			if (valor.Length > 0 && (tarj.Tarjetatipo != valor))
				am.Edit(new TarjetaDTO { Idtarjeta = intId, Tarjetatipo = valor });
		}
	}
	public class DepositosLista : IListStrategy
	{
		DepositosManager am = new DepositosManager();
		public List<ListaDTO> GetData()
		{
			var Ret = am.GetList();
			return Ret;
		}
		public void InsertItem(string str)
		{
			if (str.Length > 0 && (!am.ExisteDeposito(str)))
				am.Insert(new DepositoDTO { Descriptor = str });
		}
		public void DeleteItem(int intId)
		{
			am.Delete(intId);
		}
		public void EditaItem(int intId, string valor)
		{
			DepositoDTO tarj = am.GetDepositoDTO(intId);
			if (valor.Length > 0 && (tarj.Descriptor != valor))
				am.Edit(new DepositoDTO { Depositoid = intId,  Descriptor = valor });
		}
	}
	public class TicketsLista : IListStrategy
	{
		TicketManager am = new TicketManager();
		public List<ListaDTO> GetData()
		{
			var Ret = am.GetList();
			return Ret;
		}
		public void InsertItem(string str)
		{
			if (str.Length > 0 && (!am.Existe(str)))
				am.Insert(new TicketDTO {  TicketTipo = str });
		}
		public void DeleteItem(int intId)
		{
			am.Delete(intId);
		}
		public void EditaItem(int intId, string valor)
		{
			TicketDTO ticket = am.GetTicketDTO(intId);
			if (valor.Length > 0 && (ticket.TicketTipo != valor))
				am.Edit(new TicketDTO { Id = intId, TicketTipo = valor });
		}
	}
	public class MenuLista : IListStrategy
	{
		MenuManager am = new MenuManager();
		public List<ListaDTO> GetData()
		{
			var Ret = am.GetList();
			return Ret;
		}
		public void InsertItem(string str)
		{
			if (str.Length > 0 && (!am.Existemenu(str)))
				am.InsertClase(new MenuDTO {  MenuDesc=str   });
		}
		public void DeleteItem(int intId)
		{
			am.Delete(intId);
		}
		public void EditaItem(int intId, string valor)
		{
			MenuDTO menux = am.GetDataMenu(intId);
			if (valor.Length > 0 && (menux.MenuDesc != valor))
				am.Edit(new MenuDTO { Idmenu = intId,  MenuDesc = valor });
		}
	}
}
