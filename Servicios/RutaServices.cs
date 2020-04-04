using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Interfaces;
using WaterSolutionAPI.Models;
using WaterSolutionAPI.WaterSoluctionDBC;

namespace WaterSolutionAPI.Servicios
{
	public class RutaServices : IRuta
	{
		private readonly WaterSolutionDBContext _context;

		public RutaServices(WaterSolutionDBContext context)
		{
			_context = context;
		}
		public async Task<Ruta> save(Ruta model)
		{
			await _context.Ruta.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<Ruta> Edit(Ruta model)
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

		public bool Exists(int id) => _context.Ruta.Any(x => x.RutaId == id);
	}
}
