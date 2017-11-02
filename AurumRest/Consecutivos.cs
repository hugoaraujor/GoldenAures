using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumRest
{
	public class Consecutivos
	{
		public static IniFile MyInis = new IniFile(@"c:\corinto\Aurum.ini");
		public int getTicket()
		{ int t;
			try
			{
				t = Convert.ToInt32(MyInis.Read("Consecutivos", "Ticket"));
			}
			catch{
				MyInis.Write("Consecutivos", "Ticket", "0");
				t = Convert.ToInt32(MyInis.Read("Consecutivos", "Ticket"));
			}
			//Global.Instancia.ticket=t;
			return t;
		}
		public string getUltFactura()
		{
			string  t;
			try
			{
				t = MyInis.Read("Consecutivos", "Factura");
			}
			catch
			{
				MyInis.Write("Consecutivos", "Factura", "0");
				t =MyInis.Read("Consecutivos", "Factura");
			}
			//Global.Instancia.ticket=t;
			return t;
		}


		public int regresaapunto()
		{
			int t;
			try
			{
				t = Convert.ToInt32(MyInis.Read("Comportamiento", "RegresaaPunto"));
			}
			catch
			{
				MyInis.Write("Comportamiento", "RegresaaPunto", "0");
				t = Convert.ToInt32(MyInis.Read("Comportamiento", "RegresaaPunto"));
			}
			//Global.Instancia.ticket=t;
			return t;
		}
		public FontType getFont()
		{
						FontType f = new FontType();
			int t;
			try
			{
				
				f.Familia =MyInis.Read("Botones", "FontType");
				f.Tamaño = Convert.ToInt16(MyInis.Read("Botones", "TamanoLetra"));
				f.color =System.Drawing.Color.FromName(MyInis.Read("Botones", "ColorTexto")); 
			}
			catch
			{
				MyInis.Write("Botones", "FontType", "Arial");
				MyInis.Write("Botones", "TamanoLetra", "11");
				MyInis.Write("Botones", "ColorTexto", "White");
				f.Familia = MyInis.Read("Botones", "FontType");
				f.Tamaño = Convert.ToInt16(MyInis.Read("Botones", "TamanoLetra"));
				f.color = System.Drawing.Color.FromName(MyInis.Read("Botones", "ColorTexto"));

			}
			//Global.Instancia.ticket=t;
			return f;
		}
		public string getIva(Ivatipo tipo)
		{
			string ivastr="";
		
			try
			{

			ivastr= MyInis.Read("Iva", tipo.ToString());
				
			}
			catch
			{
				MyInis.Write("Iva", "General", "12");
				MyInis.Write("Iva", "Reducido", "08");
				MyInis.Write("Iva", "Ampliado", "22");
				ivastr = MyInis.Read("Iva", Ivatipo.Ampliado.ToString()); 

			}
			//Global.Instancia.ticket=t;
			return ivastr;
		}
		public int newTicket()
		{
			int t;
			t=getTicket();
			t++;
			return t;
		}
		public void SaveTicket(int n)
		{
			int t = getTicket();
			MyInis.Write("Consecutivos", "Ticket",n.ToString());
			//Global.Instancia.ticket = t;

		}
		public void SaveFactura(string fact)
		{
			if (fact != "")
			{
				MyInis.Write("Consecutivos", "Factura", fact);
			}
			
		}
	}
}
