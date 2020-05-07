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
	public class SolicitudServices : ISolicitud
	{
		private readonly WaterSolutionDBContext _context;
		private readonly IMapper _mapper;

		public SolicitudServices(WaterSolutionDBContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;

		}

		public async Task<Solicitud> save(Solicitud model)
		{
			await _context.Solicitud.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}
		public async Task<List<SeguimientosDTO>> saveSeguimiento(Seguimientos model)
		{
			try
			{
				
				await _context.Seguimientos.AddAsync(model);
				await _context.SaveChangesAsync();

				var seguimientos = await _context.Seguimientos.Include(x => x.EmpleadoSeguimiento).Where(x => x.IdSolicitud == model.IdSolicitud).ToListAsync();

				var maper = _mapper.Map<List<SeguimientosDTO>>(seguimientos);
				return maper;
			}
			catch (Exception e)
			{

				throw;
			}
			
		}

		public async Task<Solicitud> Edit(Solicitud model)
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

		public async Task<List<SolicitudDTO>> MotrarTodo(int id)
		{
			var solicitudes = await _context.Solicitud.Include(x => x.Cotizaciones)
				.ThenInclude(b => b.DetalleCotizacion).ThenInclude(a => a.Material)
				.Include(x => x.Seccion).ThenInclude(x => x.Departamento)
				.Include( x => x.Seguimientos).ThenInclude( x =>x.EmpleadoSeguimiento)
				.Where(x => x.SeccionId == id && x.Estado == "Pendiente por Cotizacion" || x.Estado == "En cotizacion")
				.ToListAsync();

			var valor = _mapper.Map<List<SolicitudDTO>>(solicitudes);

			return valor;

		}


		public async Task<List<SolicitudDTO>> MostrarSolicitudRuta(int id)
		{
			var solicitudes = await _context.Solicitud.Include(x => x.Cotizaciones)
				.Include(x => x.Seguimientos).ThenInclude(x => x.EmpleadoSeguimiento)
				.Where(x => x.SeccionId == id && x.Estado == "Pendiente por Ruta")
				.ToListAsync();

			var valor = _mapper.Map<List<SolicitudDTO>>(solicitudes);

			return valor;
		}

		public bool Exists(int id) => _context.Solicitud.Any(x => x.SolicitudId == id);
	}
}
