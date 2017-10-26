using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AurumData
{
	[Table("Areas")]
	public class  Area
	{
		[Key]
		[Column(Order = 1)]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		private int areaid;
		[StringLength(20)]
		private string descriptor;
		private string file;
		private int mesas;
		private string prefijo;
		public Area()
		{

		}
		public int Areaid { get => areaid; set => areaid = value; }
		public string Descriptor { get => descriptor; set => descriptor = value; }
		public string File { get => file; set => file = value; }
		public int Mesas { get => mesas; set => mesas = value; }
		public string Prefijo { get => prefijo; set => prefijo = value; }
	}
}