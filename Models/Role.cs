using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            Cargo = new HashSet<Cargo>();
            RolesPermisos = new HashSet<RolesPermisos>();
        }

        public int IdRole { get; set; }
        public string NombreRole { get; set; }
        public bool EstadoRole { get; set; }

        public virtual ICollection<Cargo> Cargo { get; set; }
        public virtual ICollection<RolesPermisos> RolesPermisos { get; set; }
    }
}
