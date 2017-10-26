using AurumData.Models;
using AurumData;
using System;
using System.Data.Entity;
using System.Linq;
namespace AurumData
{
	
	public class Data : DbContext
	{
		// El contexto se ha configurado para usar una cadena de conexión 'Data' del archivo 
		// de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
		// esta cadena de conexión tiene como destino la base de datos 'Aurum.Data' de la instancia LocalDb. 
		// 
		// Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
		// modifique la cadena de conexión 'Data'  en el archivo de configuración de la aplicación.
		public Data()
			: base("name=Data")
		{
		}

		// Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
		// sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

		public virtual DbSet<Area> Areas { get; set; }
		public virtual DbSet<Deposito> Depositos { get; set; }
		public virtual DbSet<Banco> Bancos { get; set; }
		public virtual DbSet<Categoria> Categorias { get; set; }
		public virtual DbSet<Cierre> Cierres { get; set; }
		public virtual DbSet<Cliente> Clientes { get; set; }
		public virtual DbSet<CuentasxCobrar> cuentasxcobrar { get; set; }
		public virtual DbSet<Parametro> Parametros { get; set; }
		public virtual DbSet<itemsOrder> itemsOrders { get; set; }
		public virtual DbSet<Mesa> Mesas { get; set; }
		public virtual DbSet<Mesonero> Mesoneros { get; set; }
		public virtual DbSet<Orden> Ordenes { get; set; }
		public virtual DbSet<Producto> Productos { get; set; }
		public virtual DbSet<Tarjeta> Tarjetas { get; set; }
		public virtual DbSet<Usuario> Usuarios { get; set; }
		public virtual DbSet<Factura> Facturas { get; set; }
		public virtual DbSet<Pago> Pagos { get; set; }
		public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
		public virtual DbSet<Apertura> Aperturas{ get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<Turno> Turnos { get; set; }
		public virtual DbSet<remotas> Remotas { get; set; }
		public virtual DbSet<TicketDetalle> TicketDetalle { get; set; }
		public virtual DbSet<Ticket> Tickets { get; set; }
		public virtual DbSet<Promociones> Promociones { get; set; }


	}

	
}