using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class RutaSolicitud
    {
        public int RutaSolicitudId { get; set; }
        public int SolicitudId { get; set; }
        public int RutaId { get; set; }

        public virtual Ruta Ruta { get; set; }
        public virtual Solicitud Solicitud { get; set; }
    }
}
