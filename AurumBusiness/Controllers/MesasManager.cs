
using AurumData;
using AurumDataEntity;
using AurumDataEntity.DataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AurumBusiness.Controllers
{
	public class MesasManager
	{


		#region Insert
		public void InsertClase(MesaDTO NewClase)
		{
			var x = NewClase;
			using (var db = new Data())
			{
				AurumData.EstadosMesa estado = (AurumData.EstadosMesa)x.Estado;
				db.Mesas.Add(new Mesa()
				{
					Siglas = x.Siglas,
					Ocupada = x.Ocupada,
					Hora = x.Hora,
					Idmesonero = x.idmesonero,
					Idocupante = x.idocupante,
					Area = x.Area,
					Estado = estado
				});

				db.SaveChanges();


			}
		}

		#endregion
		#region Delete

		public void Delete(int IdClase)
		{
			using (var db = new Data())
			{
				Mesa query = (from x in db.Mesas
							  where x.Idmesa == IdClase
							  select x).FirstOrDefault<Mesa>();
				if (query != null)
				{
					db.Mesas.Remove(query);
					db.SaveChanges();
				}
			}
		}

		#endregion
		#region Existe

		public bool Existemesa(string mesastr)
		{
			bool resp = false;
			using (var db = new Data())
			{
				Mesa Edo = (from x in db.Mesas where x.Siglas == mesastr select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = true;
				}

			}
			return resp;
		}
		#endregion


		#region Edit

		public void Edit(Mesa Editedclass)
		{
			var x = Editedclass;

			try
			{
				using (var db = new Data())
				{
					var pac = (from p in db.Mesas where p.Idmesa == Editedclass.Idmesa select p).FirstOrDefault();
					if (pac != null)
					{
						AurumData.EstadosMesa estado = (AurumData.EstadosMesa)x.Estado;
						pac.Siglas = x.Siglas;
						pac.Ocupada = x.Ocupada;
						pac.Hora = x.Hora;
						pac.Idmesonero = x.Idmesonero;
						pac.Idocupante = x.Idocupante;
						pac.Area = x.Area;
						pac.Estado = estado;
						db.SaveChanges();
					}

				}
			}
			catch (DbEntityValidationException e)
			{ }
		}
		public  void ChangeStatusMesa(Mesa currentMesa,AbrirMesaView am)
		{
			currentMesa.Ocupada = true;
			currentMesa.Hora = am.Fecha;
			currentMesa.Idmesonero = am.mesonero.Idmesonero;
			currentMesa.Estado = EstadosMesa.Ocupada;
			Edit(currentMesa);
		}
		public Mesa GetMesa(string mesastr)
		{

			Mesa resp = new Mesa();
			using (var db = new Data())
			{
				Mesa Edo = (from x in db.Mesas where x.Siglas == mesastr select x).FirstOrDefault();
				if (Edo != null)
				{
					resp = Edo;
				}

			}
			return resp;
		}


		public List<Mesa> GetMesas(bool all=true)
		{
			List<Mesa> resp = new List<Mesa>();
			using (var db = new Data())
			{
				var query = db.Mesas;
				if (query != null)
				{
					resp = query.ToList();
				}
			}
			
			return resp;
		}

		
	}
}
		#endregion



