using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class PermisoRole
    {
        public PermisoRole()
        {
            RolesPermisos = new HashSet<RolesPermisos>();
        }

        public int IdPermiso { get; set; }
        public string NombrePermiso { get; set; }

        public virtual ICollection<RolesPermisos> RolesPermisos { get; set; }
    }
}
