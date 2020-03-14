using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	
	public interface IEmpleados
	{
		Task<List<Empleados>> Get();
		Task<Empleados> GetByID(int id);
		Task<Empleados> Save(Empleados model);
		Task<Empleados> Edit(Empleados model);
		bool Exist(int id);

	}
}
