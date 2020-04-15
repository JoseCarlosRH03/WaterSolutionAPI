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

		public ClienteService(WaterSolutionDBContext context, IConfiguration configuration)
		{
			_context = context;
			_connectionString = configuration.GetConnectionString("DefaultConnectionString");

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

		public async Task<List<ClienteDTO>> MostrarCliente(int id)
		{
		//	var rutasEmpleados =  await _context.RutaEmpleado.Include(x => x.Empleado).ToListAsync();
			var rutaSolicitud = await _context.RutaSolicitud.Include(x => x.Ruta).ToListAsync();

			using (SqlConnection sql = new SqlConnection(_connectionString))
			{
				using (SqlCommand cmd = new SqlCommand("SolicitudCotizacion", sql))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@idCliente", id));
					var response = new List<ClienteDTO>();
					await sql.OpenAsync();

					using (var reader = await cmd.ExecuteReaderAsync())
					{
						while (await reader.ReadAsync())
						{
							response.Add(MapToValue(reader));
						}
					}

					foreach (var item in response)
					{
						rutaSolicitud.Where(x => x.SolicitudId == item.solicitudID).ToList();
					}
					return response;
				}
			}

		}

		private ClienteDTO MapToValue(SqlDataReader reader)
		{
			return new ClienteDTO
			{

				solicitudID = (int)(reader["SolicitudID"]),
				descripcion = reader["Descripcion"].ToString(),
				direccionSolicitud = reader["DireccionSolicitud"].ToString(),
				sector = reader["Sector"].ToString(),
				fechaSolicitud = reader["fecha"].ToString(),
				estado = reader["Estado"].ToString(),
				tipoSolicitud = reader["TipoSolicitud"].ToString(),
				seccionID = (int)(reader["SeccionID"]),
				totalCotizado = Convert.ToDouble(reader["TotalCotizado"]),
				fechaCotizacion = Convert.ToDateTime(reader["fechaCotizacion"]),
				estadoCotizacion = reader["EstadoCotizacion"].ToString(),
				cotizacionID = (int)(reader["CotizacionID"]),
			};     
		}
		public bool Exists(int id)
		{
			return _context.Cliente.Any(x => x.PersonaId == id);
		}
	}
}
