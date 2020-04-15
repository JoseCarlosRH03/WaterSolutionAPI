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
	public class MaterialServices : IMaterial
	{
		private readonly WaterSolutionDBContext _context;

		public MaterialServices(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<Material> save(Material model)
		{
			await _context.Material.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<Material> Edit(Material model)
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

		public bool Exists(int id) => _context.Material.Any(x => x.MaterialId == id);
	}
}
