using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumData
{
	[Table("Menus")]
	public class Menu
	{
		private int idmenu;
		private string menuDesc;

		public Menu()
		{

		}
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Idmenu { get => idmenu; set => idmenu = value; }
		public string MenuDesc { get => menuDesc; set => menuDesc = value; }
	}
}
