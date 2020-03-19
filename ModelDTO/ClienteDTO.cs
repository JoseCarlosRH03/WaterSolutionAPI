using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterSolutionAPI.ModelDTO
{
	public class ClienteDTO
	{
		public string Nombre { get; set; }
		public string Apellidos { get; set; }
		public string Cedula { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public DateTime fecha { get; set; }
		public string Descripcion { get; set; }
		public string DireccionSolicitud { get; set; }
		public string Sector { get; set; }
		public string fechaSolicitud { get; set; }
		public string Estado { get; set; }
		public string TipoSolicitud { get; set; }
		public string nombreSeccion { get; set; }
		public double TotalCotizado { get; set; }
		public DateTime fechaCotizacion { get; set; }
		public string EstadoCotizacion { get; set; }
		public double Cantidad { get; set; }
		public double totalDetalle { get; set; }
		public double presio { get; set; }
		public string NombreMaterial { get; set; }
	}
}
