using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IUsuario
	{
		Task<Usuarios> save(Usuarios model);
		Task<Usuarios> Edit(Usuarios model);
		bool Exists(int id);
	}
}
