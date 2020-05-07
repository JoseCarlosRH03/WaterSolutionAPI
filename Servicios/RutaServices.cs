using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Interfaces;
using WaterSolutionAPI.ModelDTO;
using WaterSolutionAPI.Models;
using WaterSolutionAPI.WaterSolutionDBC;

namespace WaterSolutionAPI.Servicios
{
	public class RutaServices : IRuta
	{
		private readonly WaterSolutionDBContext _context;
		private readonly IMapper _mapper;

		public RutaServices(WaterSolutionDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<Ruta> save(Ruta model)
		{
			await _context.Ruta.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<RutaSolicitud> saveRutaSolicitud(RutaSolicitud model)
		{
			await _context.RutaSolicitud.AddAsync(model);
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


		public async Task<RutaSolicitud> Getruta(int id )
		{
			try
			{
				var resultado = await _context.RutaSolicitud.Include(x => x.Solicitud)
					.ThenInclude(x => x.Cotizaciones).ThenInclude(x => x.DetalleCotizacion).ThenInclude(X => X.Material)
					.Include(x =>x.Solicitud.Seguimientos)
					.Include(X => X.Ruta).ThenInclude(X => X.empleadoRuta)
					.Where(X => X.Solicitud.Estado == "En ruta" && X.Ruta.empleadoRuta.IdEmpleado == id).FirstOrDefaultAsync();
				
				
				return resultado;
			}
			catch (Exception ex)
			{
				throw ex;
			}
	
			
		}

		public async Task<List<SeguimientosDTO>> Seguimientos(int id)
		{
			var resultado = await _context.Seguimientos.Include(x =>x.EmpleadoSeguimiento)
					.Where(X => X.IdSolicitud == id).ToListAsync();

			var valor = _mapper.Map<List<SeguimientosDTO>>(resultado);


			return valor;
		}

		public bool Exists(int id) => _context.Ruta.Any(x => x.RutaId == id);
	}
}
