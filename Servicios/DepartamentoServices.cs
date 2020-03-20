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
	public class DepartamentoServices : IDepartamento
	{
		private readonly WaterSolutionDBContext _context;

		public DepartamentoServices(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<Departamentos> save(Departamentos model)
		{
			await _context.Departamentos.AddAsync(model);
			await _context.SaveChangesAsync();
			return model;
		}

		public async Task<Departamentos> Edit(Departamentos model)
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
			return _context.Departamentos.Any(x => x.IdDepartamento == id);
		}
	}
}
