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
	public class SeccioneServices : ISecciones
	{
		private readonly WaterSolutionDBContext _context;

		public SeccioneServices(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<Secciones> save(Secciones model)
		{
			await _context.Secciones.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<Secciones> Edit(Secciones model)
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

		public bool Exists(int id) => _context.Secciones.Any(x => x.IdSeccion == id);

	}
}
