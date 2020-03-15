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
	public class EmpleadoServices : IEmpleados
	{
		private readonly WaterSolutionDBContext _context;

		public EmpleadoServices(WaterSolutionDBContext context)
		{
			this._context = context;
		}

		public async Task<List<Empleados>> Get()
		{
			var result = _context.Empleados.ToListAsync();

			return await result;
		}

		public async Task<Empleados> GetByID(int id)
		{
			var result = await _context.Empleados.Include(x => x.CargoidCargoNavigation)
				.Include(x => x.SeccionIdSeccionNavigation).FirstOrDefaultAsync(x => x.IdEmpleado == id);

			var result2 = await _context.Cargo.Include(x => x.RoleIdRoleNavigation)
				.FirstOrDefaultAsync(x => x.IdCargo == result.CargoidCargoNavigation.IdCargo);

			result.CargoidCargoNavigation = result2;

			var result3 = await _context.RolesPermisos.Include(x => x.IdPermisoNavigation)
				.Where(x => x.IdRole == result2.RoleIdRoleNavigation.IdRole).ToListAsync();

			result.CargoidCargoNavigation.RoleIdRoleNavigation.RolesPermisos = result3;

			return result;
		}

		public async Task<Empleados> Save(Empleados model)
		{
			await _context.Empleados.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<Empleados> Edit(Empleados model)
		{

			try
			{
				_ = _context.Entry(model).State == EntityState.Modified;
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return model;
		}

		public bool Exist(int id)
		{
			return _context.Empleados.Any(x => x.IdEmpleado == id);
		}
	}

}
