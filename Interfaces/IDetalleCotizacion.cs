using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.ModelDTO;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IDetalleCotizacion
	{
		Task<List<DetalleCotizacion>> save(List<DetalleCotizacion> model);
		Task<List<DetalleCotizacion>> Edit(List<DetalleCotizacion> model);
		Task<List<DetalleCotizacion>> Delete(List<DetalleCotizacion> model);
		bool Exists(int id);
	}
}
