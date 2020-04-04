using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.ModelDTO;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	
	public interface IEmpleados
	{
		Task<List<Empleados>> Get();
		Task<List<EmpleadoDTO>> ListadoEmpleados();
		Task<Empleados> Save(Empleados model);
		Task<Empleados> Edit(Empleados model);
		bool Exist(int id);
		Task<EmpleadoDTO> Longin(string usuario, string password);

	}
}
