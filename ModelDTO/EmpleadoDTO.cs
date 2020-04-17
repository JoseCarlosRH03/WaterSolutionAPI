using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.ModelDTO
{
	public class EmpleadoDTO
	{
		public int idUsuario { get; set; }
		public string passwordUsuario { get; set; }
		public bool estadoUsuario { get; set; }
		public string nombreUsuario { get; set; }
		public int idEmpleado { get; set; }
		public string nombreEmpleado { get; set; }
		public string ApellidosEmpleado { get; set; }
		public string cedulaEmpleado { get; set; }
		public DateTime fechaEmpleado { get; set; }
		public string TelefornoEmpleado { get; set; }
		public string direccionEmpleado { get; set; }
		public string nombreSeccion { get; set; }
		public int idSeccion { get; set; }
		public string nombreDepartamento { get; set; }
		public int idDepartamento { get; set; }
		public string nombreCargo { get; set; }
		public int idCargo { get; set; }
		public string nombreRole { get; set; }
		public List<PermisoRole> Permiso { get; set; }
	}
}
