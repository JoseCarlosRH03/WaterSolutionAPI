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
					return response;
				}
			}

		}

		private ClienteDTO MapToValue(SqlDataReader reader)
		{
			return new ClienteDTO
			{
				Nombre = reader["Nombre"].ToString(),
				Apellidos = reader["Apellidos"].ToString(),
				Cedula = reader["Cedula"].ToString(),
				Direccion = reader["Direccion"].ToString(),
				Telefono = reader["Telefono"].ToString(),
				fecha = Convert.ToDateTime(reader["fecha"]),
				Descripcion = reader["Descripcion"].ToString(),
				DireccionSolicitud = reader["DireccionSolicitud"].ToString(),
				Sector = reader["Sector"].ToString(),
				fechaSolicitud = reader["fechaSolicitud"].ToString(),
				Estado = reader["Estado"].ToString(),
				TipoSolicitud = reader["TipoSolicitud"].ToString(),
				nombreSeccion = reader["nombreSeccion"].ToString(),
				TotalCotizado = Convert.ToDouble(reader["TotalCotizado"]),
				fechaCotizacion = Convert.ToDateTime(reader["fechaCotizacion"]),
				EstadoCotizacion = reader["EstadoCotizacion"].ToString(),
				Cantidad = Convert.ToInt32(reader["Cantidad"]),
				totalDetalle =	Convert.ToDouble(reader["totalDetalle"]),
				presio = Convert.ToDouble(reader["presio"]),
				NombreMaterial = reader["NombreMaterial"].ToString()
			};     
		}
		public bool Exists(int id)
		{
			return _context.Cliente.Any(x => x.PersonaId == id);
		}
	}
}
