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
	public class UsuarioServices : IUsuario
	{
		private readonly WaterSolutionDBContext _context;

		public UsuarioServices(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<Usuarios> save(Usuarios model)
		{
			await _context.Usuarios.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<Usuarios> Edit(Usuarios model)
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

		public bool Exists(int id) => _context.Usuarios.Any(x => x.IdUsuario == id);

	}
}
