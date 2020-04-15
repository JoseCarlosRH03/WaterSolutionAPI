using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Empleados
    {
        public Empleados()
        {
            Ruta = new HashSet<Ruta>();
        }

        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public string CedulaEmpleado { get; set; }
        public DateTime FechaEmpleado { get; set; }
        public string TelefonoEmpleado { get; set; }
        public string DireccionEmpleado { get; set; }
        public int CargoidCargo { get; set; }
        public int SeccionIdSeccion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Cargo CargoidCargoNavigation { get; set; }
        public virtual Usuarios usuario { get; set; }
        public virtual Secciones SeccionIdSeccionNavigation { get; set; }
        public virtual ICollection<Ruta> Ruta { get; set; }
    }
}
