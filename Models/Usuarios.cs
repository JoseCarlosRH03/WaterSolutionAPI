using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            PassworLost = new HashSet<PassworLost>();
        }

        public int IdUsuario { get; set; }
        public int EmpleadoUsuarioidEmpleado { get; set; }
        public string NombreUsuario { get; set; }
        public string PasswordUsuario { get; set; }
        public bool EstadoUsuario { get; set; }

        public virtual Empleados EmpleadoUsuarioidEmpleadoNavigation { get; set; }
        public virtual ICollection<PassworLost> PassworLost { get; set; }
    }
}
