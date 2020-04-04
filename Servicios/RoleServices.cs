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
	public class RoleServices : IRole
	{
		private readonly WaterSolutionDBContext _context;

		public RoleServices(WaterSolutionDBContext contex)
		{
			_context = contex;
		}

		public async Task<Role> save(Role model)
		{
			await _context.Role.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<Role> Edit(Role model)
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

		public bool Exists(int id) => _context.Role.Any(x => x.IdRole == id);
		
	}
}
