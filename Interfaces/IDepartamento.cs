using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IDepartamento
	{
		Task<Departamentos> save(Departamentos model);
		Task<Departamentos> Edit(Departamentos model);
		bool Exists(int id);
	}
}
