using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public int EmpleadoUsuarioidEmpleado { get; set; }
        public string NombreUsuario { get; set; }
        public byte PasswordUsuario { get; set; }
        public bool EstadoUsuario { get; set; }

        public virtual Empleados EmpleadoUsuarioidEmpleadoNavigation { get; set; }
    }
}
