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
	public class CargoServices : ICargo
	{
		private readonly WaterSolutionDBContext _context;

		public CargoServices(WaterSolutionDBContext context)
		{
			_context = context;
		}

		public async Task<Cargo> save(Cargo model)
		{
			await _context.Cargo.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}
		public async Task<Cargo> Edit(Cargo model)
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
			return _context.Cargo.Any(x => x.IdCargo == id);
		}
	}
}
