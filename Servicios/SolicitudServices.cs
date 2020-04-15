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
	public class SolicitudServices : ISolicitud
	{
		private readonly WaterSolutionDBContext _context;

		public SolicitudServices(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<Solicitud> save(Solicitud model)
		{
			await _context.Solicitud.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<Solicitud> Edit(Solicitud model)
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

		public bool Exists(int id) => _context.Solicitud.Any(x => x.SolicitudId == id);
	}
}
