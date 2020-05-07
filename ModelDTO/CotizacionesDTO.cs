using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterSolutionAPI.ModelDTO
{
    public class CotizacionesDTO
    {
        public int CotizacionId { get; set; }
        public double TotalCotizado { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public string EstadoCotizacion { get; set; }
        public int SolicitudId { get; set; }

        public  ICollection<DetalleCotizacionDTO> DetalleCotizacion { get; set; }
    }
}
