using System.Runtime.InteropServices;

namespace FiscalPrinterBematech
{
	/// <summary>   
	/// Classe con la declaración de las funciones del BemaFI32.dll   
	/// </summary>   
	public class BemaFI32
		{
			public BemaFI32()
			{
			}

			#region DECLARACIÓN DE LAS FUNCIONES del BemaFI32.dll   

			#region Funciones de Inicialización   
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ProgramaAlicuota(string Alicuota, int ICMS_ISS);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ProgramaRedondeo();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ProgramaTruncamiento();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ActivaDesactivaReporteZAutomatico(int flag);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ActivaDesactivaCuponAdicional(int flag);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ActivaDesactivaVinculadoComprobanteNoFiscal(int flag);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ActivaDesactivaImpresionBitmapMA(int flag);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_HoraLimiteReporteZ(string Hora);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ProgramaCliche(string Cliche);

			#endregion

			#region Funciones del Cupon Fiscal    
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_AbreComprobanteDeVenta(string RIF, string Nombre);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_AbreComprobanteDeVentaEx(string RIF, string Nombre, string Direccion);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_VendeArticulo(string Codigo, string Descripcion, string Alicuota, string TipoCantidad, string Cantidad, int CasasDecimales, string ValorUnitario, string TipoDescuento, string Descuento);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_AnulaArticuloAnterior();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_AnulaCupon();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_CierraCupon(string FormaPago, string IncrementoDescuento, string TipoIncrementoDescuento, string ValorIncrementoDescuento, string ValorPago, string Mensaje);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_IniciaCierreCupon(string IncrementoDescuento, string TipoIncrementoDescuento, string ValorIncrementoDescuento);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_EfectuaFormaPago(string FormaPago, string ValorFormaPago);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_FinalizaCierreCupon(string Mensaje);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_DevolucionArticulo(string Codigo, string Descripcion, string Alicuota, string TipoCantidad, string Cantidad, int CasasDecimales, string ValorUnit, string TipoDescuento, string ValorDesc);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_AbreNotaDeCredito(string Nombre, string NumeroSerie, string RIF, string Dia, string Mes, string Ano, string Hora, string Minuto, string Segundo, string COO, string MsjPromocional);
				[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_NumeroCupon([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCupom);
				[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_NumeroComprobanteFiscal([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroComprobanteFiscal);



		#endregion

		#region Funciones de los Informes Fiscales    
		    [DllImport("BemaFI32.dll")] public static extern int Bematech_FI_LecturaX();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_LecturaXSerial();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ReduccionZ(string Fecha, string Hora);
		    [DllImport("BemaFI32.dll")] public static extern int Bematech_FI_InformeGerencial(string Texto);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_CierraInformeGerencial();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_FlagFiscalesIII(int Flag);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_InformeTransacciones(string tipo, string Fechaini, string Fechafim, string Opcion);
		    [DllImport("BemaFI32.dll")] 	public static extern int Bematech_FI_FechamentoDoDia();
		#endregion

		#region Funciones de las Operaciones No Fiscales    
		[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_RecebimientoNoFiscal(string IndiceTotalizador, string Valor, string FormaPago);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_AbreComprobanteNoFiscalVinculado(string FormaPago, string Valor, string NumeroCupon);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ImprimeComprobanteNoFiscalVinculado(string Texto);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_CierraComprobanteNoFiscalVinculado();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_Sangria(string Valor);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_Provision(string Valor, string FormaPago);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_AbreInformeGerencial(string NumInforme);

		#endregion

		#region Funciones de Informaciones de la Impresora    
		    [DllImport("BemaFI32.dll")]	public static extern int Bematech_FI_NumeroSerie([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroSerie);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_Agregado([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorIncrementos);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_Cancelamientos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorCancelamientos);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_DatosUltimaReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string DatosReduccion);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_Descuentos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorDescuentos);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_NumeroCuponesAnulados([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCancelamientos);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_RetornoAlicuotas([MarshalAs(UnmanagedType.VBByRefStr)] ref string Alicuotas);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ClavePublica(string Clave);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ContadorSecuencial(string Retorno);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_VentaBrutaDiaria(string Valor);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_BaudrateProgramado(string Baudrate);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_FlagActivacionAlineamientoIzquierda(string Flag);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_FlagSensores(int Flag);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ImprimeClavePublica();

			#endregion

			#region Funciones de Autenticación y Gaveta de Efectivo    
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_AccionaGaveta();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_Autenticacion();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_ProgramaCaracterAutenticacion(string Parametros);
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_VerificaEstadoGaveta(out int EstadoGaveta);
			#endregion

			#region Otras Funciones     
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_AbrePuertaSerial();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_CierraPuertaSerial();
			[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_RetornoImpresora(ref int ACK, ref int ST1, ref int ST2);

			[DllImport("BemaFI32.dll")]	public static extern int Bematech_FI_FinalizarCierreCupon(string Mensaje);
			[DllImport("BemaFI32.dll")]	public static extern int Bematech_FI_AbreNotaDeCredito(string Nombre, string NumeroSerie, string RIF, string Dia, string Mes, string Ano, string Hora, string Minuto, string Segundo, string COO);
		    [DllImport("BemaFI32.dll")] public static extern int Bematech_FI_VersaoFirmware([MarshalAs(UnmanagedType.VBByRefStr)] ref string VersaoFirmware);
			[DllImport("BemaFI32.dll")]	public static extern int Bematech_FI_TotalIcmsCupom([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorIcms);

		[DllImport("BemaFI32.dll")] public static extern int VerificaEstadoImpresora(ref int ACK, ref int ST1, ref int ST2);
		[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_VerificaImpresoraPrendida();
		[DllImport("BemaFI32.dll")]	public static extern int Bematech_FI_AberturaDoDia(string Valor, string FormaPagto);
		[DllImport("BemaFI32.dll")] public static extern int Bematech_FI_NumeroReducciones([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumReducciones);



		#endregion
	}

	#endregion
}

