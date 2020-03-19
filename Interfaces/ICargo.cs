using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface ICargo
	{
	    Task<Cargo> save(Cargo model);
		Task<Cargo> Edit(Cargo model);
		bool Exists(int id);
	}
}
