using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IRolePermisos
	{
		Task<RolesPermisos> save(RolesPermisos model);
		Task<RolesPermisos> Edit(RolesPermisos model);
		bool Exists(int id);
	}
}
