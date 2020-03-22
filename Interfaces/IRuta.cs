using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IRuta
	{
		Task<Ruta> save(Ruta model);
		Task<Ruta> Edit(Ruta model);
		bool Exists(int id);
	}
}
