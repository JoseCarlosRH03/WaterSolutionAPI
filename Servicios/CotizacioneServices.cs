using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Interfaces;
using WaterSolutionAPI.Models;
using WaterSolutionAPI.WaterSolutionDBC;

namespace WaterSolutionAPI.Servicios
{
	public class CotizacioneServices : ICotizaciones
	{
		private readonly WaterSolutionDBContext _context;

		public CotizacioneServices(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<Cotizaciones> save(Cotizaciones model)
		{
			await _context.Cotizaciones.AddAsync(model);
			_ = _context.SaveChangesAsync();

			return model;
		}
		public async Task<Cotizaciones> Edit(Cotizaciones model)
		{
			try
			{
				_context.Entry(model).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return model;
		}

		public bool Exists(int id)
		{
			return _context.Cotizaciones.Any(x => x.SolicitudId == id);
		}
	}
}
