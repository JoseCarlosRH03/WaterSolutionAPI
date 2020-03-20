using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IDetalleCotizacion
	{
		Task<DetalleCotizacion> save(DetalleCotizacion model);
		Task<DetalleCotizacion> Edit(DetalleCotizacion model);
		bool Exists(int id);
	}
}
