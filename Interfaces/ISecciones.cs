using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface ISecciones
	{
		Task<Secciones> save(Secciones model);
		Task<Secciones> Edit(Secciones model);
		bool Exists(int id);
	}
}
