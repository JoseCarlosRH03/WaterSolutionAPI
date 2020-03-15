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

	public class EmpleadoServices : IEmpleados
	{
		private readonly WaterSolutionDBContext _context;

		private readonly string _connectionString;

		public EmpleadoServices(WaterSolutionDBContext context, IConfiguration configuration)
		{
			_context = context;
			_connectionString = configuration.GetConnectionString("DefaultConnectionString");

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

		public async Task<EmpleadoDTO> Longin(string usuario, string password)
		{

			using (SqlConnection sql = new SqlConnection(_connectionString))
			{
				using (SqlCommand cmd = new SqlCommand("MostrarTodo", sql))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.Parameters.Add( new SqlParameter("@Usuario", usuario));
					cmd.Parameters.Add(new SqlParameter("@password", password));
					EmpleadoDTO response = new EmpleadoDTO();
					List<PermisoRole> lista = new List<PermisoRole>();
					await sql.OpenAsync();

					using (var reader = await cmd.ExecuteReaderAsync())
					{
						var number = 1;

						while (await reader.ReadAsync())
						{
							if (number == 1)
							{
								var permisos = await _context.RolesPermisos.Include(x => x.IdPermisoNavigation).Where(x => x.IdRole == (int)reader["idRole"]).ToListAsync();
								number = 2;

								foreach (var item in permisos)
								{
									item.IdPermisoNavigation.RolesPermisos = null;
									lista.Add(item.IdPermisoNavigation); 
								}
							}
							response = MapToValue(reader,lista);
						}
					}
					return response;
				}
			}
		}

		private EmpleadoDTO MapToValue(SqlDataReader reader, List<PermisoRole> lista)
		{
			return new EmpleadoDTO
			{
				nombreUsuario = reader["nombreUsuario"].ToString(),
				nombreEmpleado = reader["nombreEmpleado"].ToString(),
				ApellidosEmpleado = reader["ApellidosEmpleado"].ToString(),
				cedulaEmpleado = reader["cedulaEmpleado"].ToString(),
				fechaEmpleado = Convert.ToDateTime(reader["fechaEmpleado"]),
				TelefornoEmpleado = reader["TelefornoEmpleado"].ToString(),
				DireccionEmpleado = reader["DireccionEmpleado"].ToString(),
				nombreSeccion = reader["nombreSeccion"].ToString(),
				nombreDepartamento = reader["nombreDepartamento"].ToString(),
				nombreCargo = reader["nombreCargo"].ToString(),
				nombreRole = reader["nombreRole"].ToString(),
				Permiso = lista,
			};
		}
	}

}
