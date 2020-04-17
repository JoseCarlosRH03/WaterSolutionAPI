using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.ModelDTO
{
	public class SolicitudDTO
	{
		public int solicitudId { get; set; }
		public string descripcion { get; set; }
		public string direccionSolicitud { get; set; }
		public string sector { get; set; }
		public DateTime fecha { get; set; }
		public string estado { get; set; }
		public string tipoSolicitud { get; set; }
		public int personaId { get; set; }
		public virtual CotizacionesDTO Cotizaciones { get; set; }
		public SeccionDTO seccion { get; set; }
		public List<RutaSolicitudDTO> rutaSolicitud { get; set; }


	}
}
