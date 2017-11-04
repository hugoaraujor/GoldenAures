using AurumBusiness.Controllers;
using AurumData;
using System;
using FiscalPrinterBematech;
using AurumBusiness.BAL;
using System.Linq;

namespace AurumRest
{
	public class FacturaBematech : Factura
	{
	
		public override void Header()
		{
			string NumeroDoc = "";
			var n = GetLast(ref NumeroDoc);
			int ACK = 0;
			int ST1 = 0;
			int ST2 = 0;

			int RetornoStatus = BemaFI32.Bematech_FI_RetornoImpresora(ref ACK, ref ST1, ref ST2);
			if (ACK != 6)
				{
			guardarAnulada(); 
					}
			BemaFI32.Bematech_FI_AnulaCupon();


		}
		

		public override void VendeProductos()
		{
			var prodVendido = lista;
			Global g = new Global();
			var imp = g.store.getIva(totales.currentIva);
			foreach (TicketDetalle t in prodVendido)
			{
				var precio = String.Format("{0:000000.00}", t.Neto).Replace(".", ""); ;
				var cant = string.Format("{0:0000}", t.Cant);
				var impFormatted = String.Format("{0:00.00}", Convert.ToDecimal(imp)).Replace(".", "");
				var h = BemaFI32.Bematech_FI_VendeArticulo("", t.Nombre, impFormatted, "I", cant, 2, precio, "$", "0000");
			}
			if (!esdeLlevar())
			{ 
			var serv = string.Format("{0:000000.00}", totales.servicio).Replace(".", ""); ;
			var h = BemaFI32.Bematech_FI_VendeArticulo("", "10% Servicio.", "II", "I", "0001", 2, serv, "%", "0000");
		     }
		}
		public override void Pagos()
		{
			foreach (PagoView pv in totales.ListaPagos)
			{
				var n = BemaFI32.Bematech_FI_EfectuaFormaPago(pv.clase, pv.montopago.ToString("{0:0.00}"));
			}
		}
		public   override void CierraFactura()
		{
			var mesaStr = totales.mesa.Siglas;
			int resp=0;
			if ((mesaStr != "0") && esdeLlevar())
			{
				resp = BemaFI32.Bematech_FI_FinalizarCierreCupon(mesaStr + " PARA LLEVAR." + " Gracias por su compra.");
			}
			if ((mesaStr != "0") && (!esdeLlevar()))
			{
				MesonerosManager MCtrller = new MesonerosManager();
				var aux = totales.mesa.Idmesonero;
				var atiende = MCtrller.getMesero((int)aux).Nombre;

				resp = BemaFI32.Bematech_FI_FinalizarCierreCupon("Mesa:" + mesaStr + ".Atiende:" + atiende);
			}
			if (mesaStr == "0")
			{
				resp = BemaFI32.Bematech_FI_FinalizarCierreCupon("VENTA RAPIDA");
			}
				

		

		}
	
		public override bool isAnulada()
		{
			int resp = 0;
			var retorno = VerificaRetornoImpresora("", "", resp, "Error en Impresión");
			if (retorno)
			{ guardarAnulada(); }
			return anulada;
		}
		public override void  DatosCliente()
		{	Cliente cliente = totales.cliente;
			var n = BemaFI32.Bematech_FI_AbreComprobanteDeVentaEx(cliente.Identificacion, cliente.Nombre, cliente.Direccion);
		}
		public override void Descuento()
		{
			if (totales.descuento > 0)
			{	var n = BemaFI32.Bematech_FI_IniciaCierreCupon("D", "$", String.Format("{0:0.00}", Convert.ToDouble(totales.descuento)));	}
			else
			{  var n=BemaFI32.Bematech_FI_IniciaCierreCupon("D", "$", "0000");}
			
		}

	
		
		private void guardarAnulada()
		{
			FacturasManager fm = new FacturasManager();
			Global g = new Global();
		    Console.WriteLine("Guarda Anulada");

			string  nroultfactura = g.store.getUltFactura();
			string  nrosigultfactura = (Convert.ToInt16(nroultfactura)+1).ToString("D6");
			bool siexiste = fm.ExisteFact(nrosigultfactura.ToString());
			if (siexiste==true)
			{
		
				//fm.Delete(nroultfactura);
				var Fact=fm.GetFactura(nrosigultfactura);

				fm.Edit(new AurumDataEntity.FacturaDTO { Exento = 0, Anulada = true, ClienteID = 0, Montoneto = 0, Descuento = 0, Total = 0, Tasa = 0, Equipo = g.equipo, Caja = "", Facturanro = nrosigultfactura, Mesa = "0", Moneda = "", Serial = g.GetParametros().Serial, Sirve = 0, Userid = 0, Nota="" , Cierrex="0", Cierrez="0", Montoiva=0, Fecha=Convert.ToDateTime(DateTime.Now)});
			}
			else
			{
				fm.Insert(new AurumDataEntity.FacturaDTO { Anulada = true, ClienteID = 0, Montoneto = 0, Descuento = 0, Total = 0, Tasa = 0, Equipo =g.equipo, Caja = "", Facturanro = nrosigultfactura, Mesa = "0", Moneda = "", Serial =g.GetParametros().Serial, Sirve = 0, Userid = 0, Nota = "",Cierrex="0",Cierrez="0", Montoiva=0,Id=0, Fecha = Convert.ToDateTime(DateTime.Now) });
			}
		}
		
		
		public override void EmiteNotadeCredito(string facturaNo)
		{
			
			ClienteManager Cm = new ClienteManager();
			totales = new TotalapagarView();
			totales.cliente= Cm.GetCliente(facturaNo);
			Cliente cliente = totales.cliente;
			
			TicketDetalleManager TDMNgr = new TicketDetalleManager();
			lista=TDMNgr.GetList(facturaNo);
			
			string NumeroSerial = new string(' ', 15);
			int iRetorno = BemaFI32.Bematech_FI_NumeroSerie(ref NumeroSerial);
			DateTime cDate = DateTime.Now;
			var cDia = cDate.Day.ToString("D2");
			var cMes = cDate.Month.ToString("D2");
			var cAno = cDate.Year.ToString().Substring(2, 2);
			var cHora = cDate.Hour.ToString("D2");
			var cMinuto = cDate.Minute.ToString("D2");
			var cSegundo = cDate.Second.ToString("D2");
			var cCOO = facturaNo;
			iRetorno = BemaFI32.Bematech_FI_AbreNotaDeCredito(cliente.Nombre, NumeroSerial, cliente.Identificacion, cDia, cMes, cAno, cHora, cMinuto, cSegundo, cCOO);
			VendeProductos();
			Descuento();
			iRetorno = BemaFI32.Bematech_FI_FinalizarCierreCupon("Gracias, vuelva siempre !!!");

		}
		public override int GetLast(ref string NumeroDoc)
		{
			var x = NumeroDoc;
			//	int iretorno = BemaFI32.Bematech_FI_NumeroComprobanteFiscal(ref x);
			//return iretorno;
			NumeroDoc = x;
			return 0;
		}

		public bool VerificaRetornoImpresora(string Label, string Contenido, int Retorno, string TituloVentana)
		{
			bool functionReturnValue = false;
			int ACK = 0;
			int ST1 = 0;
			int ST2 = 0;
			//Dim ST3 As Integer

			int RetornaMensaje = 0;
			string StringRetorno = null;
			string ValorRetorno = null;
			int RetornoStatus = 0;
			string Mensaje = null;

			functionReturnValue = false;

			if (Retorno == 0)
			{
				return functionReturnValue;
				//   MsgBox("Error de comunicación con la impresora.", vbOKOnly + vbCritical, TituloVentana)

			}
			else if (Retorno == 1 | Retorno == -27)
			{
				RetornoStatus = BemaFI32.Bematech_FI_RetornoImpresora(ref ACK, ref ST1, ref ST2);
				ValorRetorno = ACK.ToString() + "," + ST1.ToString() + "," + ST2.ToString();
			}


			if (!string.IsNullOrEmpty(Label) & Retorno != 0)
			{
				RetornaMensaje = 1;
			}

			if (ACK == 21)
			{
				return functionReturnValue;
				// MsgBox("Status de la Impresora: 21" & vbCr & vbLf & "Comando no ejecutado", vbOKOnly + vbInformation, TituloVentana)
			}

			if ((ST1 != 0 | ST2 != 0))
			{
				if ((ST1 >= 128))
				{
					StringRetorno = "Fin de Papel\n";
					ST1 = ST1 - 128;
				}

				if ((ST1 >= 64))
				{
					StringRetorno = StringRetorno + "Poco Papel";
					ST1 = ST1 - 64;
				}

				if ((ST1 >= 32))
				{
					StringRetorno = StringRetorno + "Error en el reloj";
					ST1 = ST1 - 32;
				}

				if ((ST1 >= 16))
				{
					StringRetorno = StringRetorno + "Impresora en error\\n";
					ST1 = ST1 - 16;
				}


				if ((ST1 >= 2))
				{
					StringRetorno = StringRetorno + "Cupón fiscal abierto\\n";
					ST1 = ST1 - 2;
				}


				if ((ST2 >= 64))
				{
					StringRetorno = StringRetorno + "Memória fiscal llena\\n";
					ST2 = ST2 - 64;
				}


				if ((ST2 >= 16))
				{
					StringRetorno = StringRetorno + "Alicuota no programada\\n";
					ST2 = ST2 - 16;
				}

				if ((ST2 >= 1))
				{
					StringRetorno = StringRetorno + "Comando no ejecutado\\n";
					ST2 = ST2 - 1;
				}

				if (RetornaMensaje == 1)
				{
					Mensaje = "Status de la Impresora: \\n" + ValorRetorno + " \\n" + StringRetorno + "\\n" + Label + StringRetorno;
				}
				else
				{
					Mensaje = "Status de la Impresora: \\n" + ValorRetorno + " \\n" + StringRetorno;
				}
				return functionReturnValue;
				
			}

			if (RetornaMensaje == 1)
			{
				Mensaje = Label + Contenido;
			}

				
			if (Retorno == -1)
			{
				return functionReturnValue;

			}

			functionReturnValue = true;
			return functionReturnValue;
		}

		public override bool esdeLlevar()
		{
			if (totales.mesa.Siglas.Contains("LL") )
				return true;
			else
				return false;
		}
	}
}
