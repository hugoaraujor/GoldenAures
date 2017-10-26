using AurumData;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AurumRest
{
	public class Global
	{
		private static Global instancia = null;

		public Global()
		{

		}
		public List<TicketDetalle> CurrentTicketDetalle = new List<TicketDetalle>();
		public Mesa currMesa = new Mesa();
		public Consecutivos secuencia = new Consecutivos();
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
		public void GetUser(Usuario user)
		{
			UsuarioOnLine = new UsuarioDTO { Activo = user.Activo, Iduser = user.Iduser, UserName = user.UserName, Rol = user.Rol };
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
		{
			return UsuarioOnLine;
		}
		private UsuarioDTO UsuarioOnLine = null;
	}
}


