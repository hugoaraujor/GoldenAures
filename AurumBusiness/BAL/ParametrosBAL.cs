using AurumBusiness.Controllers;
using AurumDataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.BAL
{
	
		public class ParametrosBAL
	{
			private ParametrosManager umanager;
			private ParametrosManager UManager
			{
				get
				{
					return umanager ?? (umanager = new ParametrosManager());
				}
			}

		

			public void Insert(ParametroDTO general)
			{
				UManager.Insert(general);
			}

			public void Edit(ParametroDTO cliente)
			{
				UManager.Edit(cliente);
			}
			public void Delete(int IdGen)
			{
				UManager.Delete(IdGen);
			}
		}
	}

