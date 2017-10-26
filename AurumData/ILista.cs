using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.Controllers
{

	public interface IListStrategy
	{
		
		 IList<T> GetData<T>();
	}

}
