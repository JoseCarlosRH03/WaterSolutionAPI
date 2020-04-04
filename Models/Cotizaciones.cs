using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Cotizaciones
    {
        public Cotizaciones()
        {
            DetalleCotizacion = new HashSet<DetalleCotizacion>();
        }

        public int CotizacionId { get; set; }
        public double TotalCotizado { get; set; }
        public DateTime FechaCotizacion { get; set; }
        public string EstadoCotizacion { get; set; }
        public int SolicitudId { get; set; }

        public virtual Solicitud Solicitud { get; set; }
        public virtual ICollection<DetalleCotizacion> DetalleCotizacion { get; set; }
    }
}
