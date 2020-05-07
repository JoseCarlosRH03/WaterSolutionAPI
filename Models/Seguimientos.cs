using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Seguimientos
    {
        public int IdSeguimientos { get; set; }
        public int IdSolicitud { get; set; }
        public string Seguimiento { get; set; }
        public DateTime FechaSeguimiento { get; set; }
        public int? IdEmpleado { get; set; }

        public virtual Empleados EmpleadoSeguimiento { get; set; }
        public virtual Solicitud IdSolicitudNavigation { get; set; }
    }
}
