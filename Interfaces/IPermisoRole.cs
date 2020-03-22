using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IPermisoRole
	{
		Task<PermisoRole> save(PermisoRole model);
		Task<PermisoRole> Edit(PermisoRole model);
		bool Exists(int id);
	}
}
