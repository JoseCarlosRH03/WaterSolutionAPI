using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;
using WaterSolutionAPI.Interfaces;
using WaterSolutionAPI.WaterSoluctionDBC;

namespace WaterSolutionAPI.Servicios
{
	public class DetalleCotizacionService : IDetalleCotizacion
	{
		private readonly WaterSolutionDBContext _context;

		public DetalleCotizacionService(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<DetalleCotizacion> save(DetalleCotizacion model)
		{
			await _context.DetalleCotizacion.AddAsync(model);
			await _context.SaveChangesAsync();
			return model;
		}

		public async Task<DetalleCotizacion> Edit(DetalleCotizacion model)
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
			return _context.DetalleCotizacion.Any(x => x.DetalleCotizacionId == id);
		}
	}
}
