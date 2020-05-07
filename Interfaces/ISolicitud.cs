using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.ModelDTO;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.Interfaces
{
	public interface ISolicitud
	{
		Task<Solicitud> save(Solicitud model);
		Task<Solicitud> Edit(Solicitud model);
		Task<List<SeguimientosDTO>> saveSeguimiento(Seguimientos model);
		Task<List<SolicitudDTO>> MotrarTodo(int id);
		Task<List<SolicitudDTO>> MostrarSolicitudRuta(int id);
		bool Exists(int id);
	}
}
