using AurumDataEntity;
using AurumDataEntity.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{ 

	public interface IListStrategy
	{
		
		 List<ListaDTO> GetData();
		 void InsertItem(string v);
		 void DeleteItem(int Id);
		 void EditaItem(int intId, string valor);
		
	}
	

}
