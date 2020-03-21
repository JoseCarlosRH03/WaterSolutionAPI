using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IRole
	{
		Task<Role> save(Role model);
		Task<Role> Edit(Role model);
		bool Exists(int id);
	}
}
