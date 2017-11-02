using AurumBusiness.Controllers;
using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurumRest
{
	public class Global
	{
		private static Global instancia = null;
		//GLobal Singleton
		public Global()
		{

		}
	
		public List<TicketDetalle> CurrentTicketDetalle = new List<TicketDetalle>();
		public Mesa currMesa = new Mesa();
		public Consecutivos secuencia = new Consecutivos();
		public string equipo = Environment.MachineName;
		public int userid=0;
		public static Global Instancia
		{

			get
			{
				if (instancia == null)
				{
					instancia = new Global();
					
	           }
				return instancia;
			}
		}
		public string GetMoneda()
		{
			var ri = new RegionInfo(System.Threading.Thread.CurrentThread.CurrentUICulture.LCID);
			string Moneda = ri.ISOCurrencySymbol;
			return Moneda;
	    }
		public UsuarioDTO GetUser(Usuario user)
		{
			userid = user.Iduser;
			return UsuarioOnLine = new UsuarioDTO { Activo = user.Activo, Iduser = user.Iduser, UserName = user.UserName, Rol = user.Rol };
		}
		public Parametro  GetParametros()
		{   ParametrosManager parametrosController = new ParametrosManager();
			 var p=parametrosController.getParams();
			return p;
		}
		public  void SetParametros(ParametroDTO parametros)
		{
			ParametrosManager parametrosController = new ParametrosManager();
			parametrosController.Insert(parametros);
			
			
		}
		public void SetMesa(Mesa mesa)
		{
			currMesa = mesa;
			

		}
		public void SetTicket(List<TicketDetalle> currentTicketDetalle)
		{
			CurrentTicketDetalle = currentTicketDetalle;
		}
		public UsuarioDTO Usuario()
		{    if (UsuarioOnLine == null)
			{ UsuarioOnLine = new UsuarioDTO { Iduser = 0, UserName = "", Activo = true };
			}
			return UsuarioOnLine;
		}
		private UsuarioDTO UsuarioOnLine = null;
	}
}


