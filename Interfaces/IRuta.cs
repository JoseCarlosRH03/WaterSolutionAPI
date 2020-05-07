using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.ModelDTO;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface IRuta
	{
		Task<Ruta> save(Ruta model);
		Task<Ruta> Edit(Ruta model);
		Task<RutaSolicitud> saveRutaSolicitud(RutaSolicitud model);
		Task<RutaSolicitud> Getruta(int id);
		Task<List<SeguimientosDTO>> Seguimientos(int id);
		bool Exists(int id);
	}
}
