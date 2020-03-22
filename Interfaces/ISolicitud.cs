using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface ISolicitud
	{
		Task<Solicitud> save(Solicitud model);
		Task<Solicitud> Edit(Solicitud model);
		bool Exists(int id);
	}
}
