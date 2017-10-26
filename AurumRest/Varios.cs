using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{
	public static class Varios
	{
		public static void Mensaje(AurumRest.ErrorBar msgBar,string v, errorType alert)
		{			
			msgBar.Mensaje = v;
			msgBar.Status =alert;
		}

	}
}
