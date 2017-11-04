using AurumBusiness.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{
	public class anula
	{
		public void GuardaAnulada()
		{
		FacturasManager fm = new FacturasManager();
		Global g = new Global();
		Console.WriteLine("Guarda Anulada");

				string nroultfactura = g.store.getUltFactura();
		string nrosigultfactura = (Convert.ToInt16(nroultfactura) + 1).ToString("D6");
		bool siexiste = fm.ExisteFact(nrosigultfactura.ToString());
				if (siexiste == true)
				{

					//fm.Delete(nroultfactura);
					var Fact = fm.GetFactura(nrosigultfactura);
						fm.Edit(new AurumDataEntity.FacturaDTO { Exento = 0, Anulada = true, ClienteID = 0, Montoneto = 0, Descuento = 0, Total = 0, Tasa = 0, Equipo = g.equipo, Caja = "", Facturanro = nrosigultfactura, Mesa = "0", Moneda = "", Serial = g.GetParametros().Serial, Sirve = 0, Userid = 0, Nota = "", Cierrex = "0", Cierrez = "0", Montoiva = 0, Fecha = Convert.ToDateTime(DateTime.Now)
	});
				}
				else
				{
					fm.Insert(new AurumDataEntity.FacturaDTO { Anulada = true, ClienteID = 0, Montoneto = 0, Descuento = 0, Total = 0, Tasa = 0, Equipo = g.equipo, Caja = "", Facturanro = nrosigultfactura, Mesa = "0", Moneda = "", Serial = g.GetParametros().Serial, Sirve = 0, Userid = 0, Nota = "", Cierrex = "0", Cierrez = "0", Montoiva = 0, Id = 0, Fecha = Convert.ToDateTime(DateTime.Now) });
				}

	}
	}
}
