using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IMaterial
	{
		Task<Material> save(Material model);
		Task<Material> Edit(Material model);
		Task<List<Material>> Get(int id);
		bool Exists(int id);
	}
}
