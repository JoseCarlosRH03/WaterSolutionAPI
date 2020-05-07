using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Ruta
    {
        public Ruta()
        {
            RutaSolicitud = new HashSet<RutaSolicitud>();
        }

        public int RutaId { get; set; }
        public DateTime FechaRuta { get; set; }
        public int IdEmpleado { get; set; }

        public virtual Empleados empleadoRuta { get; set; }
        public virtual ICollection<RutaSolicitud> RutaSolicitud { get; set; }
    }
}
