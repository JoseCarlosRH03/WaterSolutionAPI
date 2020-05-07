using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;
using WaterSolutionAPI.Interfaces;
using WaterSolutionAPI.WaterSolutionDBC;
using WaterSolutionAPI.ModelDTO;

namespace WaterSolutionAPI.Servicios
{
	public class DetalleCotizacionService : IDetalleCotizacion
	{
		private readonly WaterSolutionDBContext _context;

		public DetalleCotizacionService(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<List<DetalleCotizacion>> save(List<DetalleCotizacion> model)
		{
			await _context.DetalleCotizacion.AddRangeAsync(model);
			await _context.SaveChangesAsync();
			return model;
		}

		public async Task<List<DetalleCotizacion>> Edit(List<DetalleCotizacion>  model)
		{
			try
			{
				_context.DetalleCotizacion.UpdateRange(model);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return model;
		}

		public async Task<List<DetalleCotizacion>> Delete(List<DetalleCotizacion> model)
		{
			 _context.DetalleCotizacion.RemoveRange(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public bool Exists(int id)
		{
			return _context.DetalleCotizacion.Any(x => x.DetalleCotizacionId == id);
		}
	}
}
