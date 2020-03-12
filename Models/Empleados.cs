using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Empleados
    {
        public Empleados()
        {
            RutaEmpleado = new HashSet<RutaEmpleado>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidosEmpleado { get; set; }
        public string CedulaEmpleado { get; set; }
        public DateTime FechaEmpleado { get; set; }
        public int IdTelefornoEmpleado { get; set; }
        public int IdDireccionEmpleado { get; set; }
        public int CargoidCargo { get; set; }
        public int SeccionIdSeccion { get; set; }

        public virtual Cargo CargoidCargoNavigation { get; set; }
        public virtual Secciones SeccionIdSeccionNavigation { get; set; }
        public virtual ICollection<RutaEmpleado> RutaEmpleado { get; set; }
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
