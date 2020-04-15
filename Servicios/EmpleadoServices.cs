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

		public async Task<List<EmpleadoDTO>> ListadoEmpleados()
		{
			using (SqlConnection sql = new SqlConnection(_connectionString))
			{
				using (SqlCommand cmd = new SqlCommand("ListaEmpleado", sql))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					List<EmpleadoDTO> response = new List<EmpleadoDTO>();
					await sql.OpenAsync();
					var permisos = _context.RolesPermisos.Include(x => x.IdPermisoNavigation).ToList();
					using (var reader = await cmd.ExecuteReaderAsync())
					{
						while(await reader.ReadAsync())
						{
							response.Add(MapToValue(reader, GetPermisos(reader, permisos)));
						}
					}
					return response;
				}
			}
		}

		public async Task<Empleados> Save(Empleados model)
		{
			await _context.Usuarios.AddAsync(model.usuario);
			await _context.SaveChangesAsync();
			model.IdUsuario = model.usuario.IdUsuario;
			model.usuario = null;
			await _context.Empleados.AddAsync(model);
			await _context.SaveChangesAsync();

			return model;
		}

		public async Task<Empleados> Edit(Empleados model)
		{

			try
			{	
				_context.Entry(model.usuario).State = EntityState.Modified;
				await _context.SaveChangesAsync();
				model.IdUsuario = model.usuario.IdUsuario;
				model.usuario = null;
				_context.Entry(model).State = EntityState.Modified;
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
					var permisos = _context.RolesPermisos.Include(x => x.IdPermisoNavigation).ToList();
					await sql.OpenAsync();

					using (var reader = await cmd.ExecuteReaderAsync())
					{
						if (await reader.ReadAsync())
						{
							response = MapToValue(reader, GetPermisos(reader, permisos));
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
				idUsuario = (int)reader["idUsuario"],
				passwordUsuario = reader["passwordUsuario"].ToString(),
				estadoUsuario = (bool)reader["estadoUsuario"],
				nombreUsuario = reader["nombreUsuario"].ToString(),
				idEmpleado = (int)reader["idEmpleado"],
				nombreEmpleado = reader["nombreEmpleado"].ToString(),
				ApellidosEmpleado = reader["ApellidosEmpleado"].ToString(),
				cedulaEmpleado = reader["cedulaEmpleado"].ToString(),
				fechaEmpleado = Convert.ToDateTime(reader["fechaEmpleado"]),
				TelefornoEmpleado = reader["TelefonoEmpleado"].ToString(),
				DireccionEmpleado = reader["DireccionEmpleado"].ToString(),
				nombreSeccion = reader["nombreSeccion"].ToString(),
				idSeccion = (int)reader["IdSeccion"],
				nombreDepartamento = reader["nombreDepartamento"].ToString(),
				idDepartamento = (int)reader["idDepartamento"],
				nombreCargo = reader["nombreCargo"].ToString(),
				idCargo = (int)reader["idCargo"],
				nombreRole = reader["nombreRole"].ToString(),
				Permiso = new List<PermisoRole>(lista),
			};
		}

		private List<PermisoRole> GetPermisos(SqlDataReader reader, List<RolesPermisos> permisos)
		{
			List<PermisoRole> lista = new List<PermisoRole>();

			var valores = permisos.Where(x => x.IdRole == (int)reader["idRole"]);

			foreach (var item in valores)
			{
				item.IdPermisoNavigation.RolesPermisos = null;
				lista.Add(item.IdPermisoNavigation);
			}

			return lista;
		}

		public async Task<FormEmpleadoDTO> FormEMpleado()
		{
			var cargos = await _context.Cargo.ToListAsync();
			var Departamentos = await _context.Departamentos.Include(x => x.secciones).ToListAsync();

			FormEmpleadoDTO FormEmpleado = new FormEmpleadoDTO {
				cargos = cargos,
				departamentos = Departamentos
			};

			return FormEmpleado;
		}
	}

}
