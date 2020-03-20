using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface ICotizaciones
	{
		Task<Cotizaciones> save(Cotizaciones model);
		Task<Cotizaciones> Edit(Cotizaciones model);
		bool Exists(int id);
	}
}
