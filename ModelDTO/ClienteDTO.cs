using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterSolutionAPI.ModelDTO
{
	public class ClienteDTO
	{
	
		public int solicitudID { get; set; }
		public string descripcion { get; set; }
		public string direccionSolicitud { get; set; }
		public string sector { get; set; }
		public string fechaSolicitud { get; set; }
		public string estado { get; set; }
		public string tipoSolicitud { get; set; }
		public int seccionID { get; set; }
		public double totalCotizado { get; set; }
		public DateTime fechaCotizacion { get; set; }
		public string estadoCotizacion { get; set; }
		public int cotizacionID { get; set; }
	}
}
