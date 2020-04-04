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
	public class PermisoRoleServices : IPermisoRole
	{
		private WaterSolutionDBContext _context;

		public PermisoRoleServices(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<PermisoRole> save(PermisoRole model)
		{
			await _context.PermisoRole.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<PermisoRole> Edit(PermisoRole model)
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

		public bool Exists(int id) => _context.RolesPermisos.Any(x => x.IdPermiso == id);
		
	}
}
