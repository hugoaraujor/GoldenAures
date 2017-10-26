
using System.Runtime.InteropServices;

namespace AurumRest
{
	/// <summary>   
	/// Classe con la declaración de las funciones del Bemafi32.dll   
	/// </summary>   
	public class BemaFI32
		{
			public BemaFI32()
			{
			}

			#region DECLARACIÓN DE LAS FUNCIONES del BemaFI32.DLL   

			#region Funciones de Inicialización   
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ProgramaAlicuota(string Alicuota, int ICMS_ISS);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ProgramaRedondeo();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ProgramaTruncamiento();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ActivaDesactivaReporteZAutomatico(int flag);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ActivaDesactivaCuponAdicional(int flag);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ActivaDesactivaVinculadoComprobanteNoFiscal(int flag);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ActivaDesactivaImpresionBitmapMA(int flag);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_HoraLimiteReporteZ(string Hora);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ProgramaCliche(string Cliche);

			#endregion

			#region Funciones del Cupon Fiscal    
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_AbreComprobanteDeVenta(string RIF, string Nombre);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_AbreComprobanteDeVentaEx(string RIF, string Nombre, string Direccion);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_VendeArticulo(string Codigo, string Descripcion, string Alicuota, string TipoCantidad, string Cantidad, int CasasDecimales, string ValorUnitario, string TipoDescuento, string Descuento);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_AnulaArticuloAnterior();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_AnulaCupon();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_CierraCupon(string FormaPago, string IncrementoDescuento, string TipoIncrementoDescuento, string ValorIncrementoDescuento, string ValorPago, string Mensaje);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_IniciaCierreCupon(string IncrementoDescuento, string TipoIncrementoDescuento, string ValorIncrementoDescuento);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_EfectuaFormaPago(string FormaPago, string ValorFormaPago);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_FinalizaCierreCupon(string Mensaje);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_DevolucionArticulo(string Codigo, string Descripcion, string Alicuota, string TipoCantidad, string Cantidad, int CasasDecimales, string ValorUnit, string TipoDescuento, string ValorDesc);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_AbreNotaDeCredito(string Nombre, string NumeroSerie, string RIF, string Dia, string Mes, string Ano, string Hora, string Minuto, string Segundo, string COO, string MsjPromocional);
			#endregion

			#region Funciones de los Informes Fiscales    
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_LecturaX();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_LecturaXSerial();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ReduccionZ(string Fecha, string Hora);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_InformeGerencial(string Texto);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_CierraInformeGerencial();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_FlagFiscalesIII(int Flag);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_InformeTransacciones(string tipo, string Fechaini, string Fechafim, string Opcion);
			#endregion

			#region Funciones de las Operaciones No Fiscales    
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_RecebimientoNoFiscal(string IndiceTotalizador, string Valor, string FormaPago);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_AbreComprobanteNoFiscalVinculado(string FormaPago, string Valor, string NumeroCupon);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ImprimeComprobanteNoFiscalVinculado(string Texto);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_CierraComprobanteNoFiscalVinculado();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_Sangria(string Valor);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_Provision(string Valor, string FormaPago);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_AbreInformeGerencial(string NumInforme);

		#endregion

		#region Funciones de Informaciones de la Impresora    
		    [DllImport("BemaFi32.dll")]	public static extern int Bematech_FI_NumeroSerie([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroSerie);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_Agregado([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorIncrementos);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_Cancelamientos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorCancelamientos);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_DatosUltimaReduccion([MarshalAs(UnmanagedType.VBByRefStr)] ref string DatosReduccion);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_Descuentos([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorDescuentos);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_NumeroCuponesAnulados([MarshalAs(UnmanagedType.VBByRefStr)] ref string NumeroCancelamientos);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_RetornoAlicuotas([MarshalAs(UnmanagedType.VBByRefStr)] ref string Alicuotas);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ClavePublica(string Clave);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ContadorSecuencial(string Retorno);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_VentaBrutaDiaria(string Valor);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_BaudrateProgramado(string Baudrate);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_FlagActivacionAlineamientoIzquierda(string Flag);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_FlagSensores(int Flag);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ImprimeClavePublica();

			#endregion

			#region Funciones de Autenticación y Gaveta de Efectivo    
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_AccionaGaveta();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_Autenticacion();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_ProgramaCaracterAutenticacion(string Parametros);
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_VerificaEstadoGaveta(out int EstadoGaveta);
			#endregion

			#region Otras Funciones     
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_AbrePuertaSerial();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_CierraPuertaSerial();
			[DllImport("BemaFi32.dll")] public static extern int Bematech_FI_RetornoImpresora(ref int ACK, ref int ST1, ref int ST2);

			[DllImport("BemaFi32.dll")]	public static extern int Bematech_FI_FinalizarCierreCupon(string Mensaje);
			[DllImport("BemaFi32.dll")]	public static extern int Bematech_FI_AbreNotaDeCredito(string Nombre, string NumeroSerie, string RIF, string Dia, string Mes, string Ano, string Hora, string Minuto, string Segundo, string COO);
		    [DllImport("BemaFi32.dll")] public static extern int Bematech_FI_VersaoFirmware([MarshalAs(UnmanagedType.VBByRefStr)] ref string VersaoFirmware);
			[DllImport("BemaFi32.dll")]	public static extern int Bematech_FI_TotalIcmsCupom([MarshalAs(UnmanagedType.VBByRefStr)] ref string ValorIcms);

		#endregion
	}

	#endregion
}

