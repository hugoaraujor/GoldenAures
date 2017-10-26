using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	public class UsuarioBAL
	{
		private UsuarioBAL umanager;
		private UsuarioBAL UManager
		{
			get
			{
				return umanager ?? (umanager = new UsuarioBAL());
			}
		}

		public bool ExisteUsuario(int Usuarioid)
		{
			return UManager.ExisteUsuario(Usuarioid);
		}


		public void InsertUsuario(UsuarioDTO area)
		{
			UManager.InsertUsuario(area);
		}

		public void EditUsuario(UsuarioDTO area)
		{
			UManager.EditUsuario(area);
		}
		public void DeleteUsuario(int Idarea)
		{
			UManager.DeleteUsuario(Idarea);
		}
	}
}
