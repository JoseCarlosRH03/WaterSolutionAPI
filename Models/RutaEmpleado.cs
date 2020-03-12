using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class RutaEmpleado
    {
        public int RutaEmpleadoId { get; set; }
        public int EmpleadoId { get; set; }
        public int RutaId { get; set; }

        public virtual Empleados Empleado { get; set; }
        public virtual Ruta Ruta { get; set; }
    }
}
