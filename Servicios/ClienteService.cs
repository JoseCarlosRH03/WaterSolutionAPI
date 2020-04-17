using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
	public class ClienteService : ICliente
	{
		private readonly WaterSolutionDBContext _context;

		private readonly string _connectionString;
		private readonly IMapper _mapper;
		public ClienteService(WaterSolutionDBContext context, IConfiguration configuration,IMapper mapper )
		{
			_context = context;
			_connectionString = configuration.GetConnectionString("DefaultConnectionString");
			_mapper = mapper;
		}

		public async Task<Cliente> Save(Cliente model)
		{

			await _context.Cliente.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}
		public async Task<Cliente> Edit(Cliente model)
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
			return _context.Cliente.Any(x => x.PersonaId == id);
		}

		public async Task<List<Cliente>> ListaClientes()
		{
			return await _context.Cliente.ToListAsync();
		}


		public async Task<List<SolicitudDTO>> MotrarTodo(int id)
		{
			var solicitudes = await _context.Solicitud.Include(x => x.Cotizaciones)
				.ThenInclude(b => b.DetalleCotizacion).ThenInclude(a => a.Material)
				.Include(x => x.Seccion).ThenInclude(x => x.Departamento)
				.Include(x =>x.RutaSolicitud).ThenInclude(x =>x.Ruta).ThenInclude(x =>x.empleadoRuta)
				.Where(x =>x.PersonaId == id )
				.ToListAsync();

			var valor = _mapper.Map<List<SolicitudDTO>>(solicitudes);
			    
			return valor;
			
		}

	}
}
