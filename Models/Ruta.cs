using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Ruta
    {
        public Ruta()
        {
            RutaEmpleado = new HashSet<RutaEmpleado>();
            RutaSolicitud = new HashSet<RutaSolicitud>();
        }

        public int RutaId { get; set; }
        public DateTime Fecha { get; set; }

        public virtual ICollection<RutaEmpleado> RutaEmpleado { get; set; }
        public virtual ICollection<RutaSolicitud> RutaSolicitud { get; set; }
    }
}
