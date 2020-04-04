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
	public class RolesPermisoServices : IRolePermisos 
	{
		private readonly WaterSolutionDBContext _context;

		public RolesPermisoServices(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<RolesPermisos> save(RolesPermisos model)
		{
			await _context.RolesPermisos.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<RolesPermisos> Edit(RolesPermisos model)
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
