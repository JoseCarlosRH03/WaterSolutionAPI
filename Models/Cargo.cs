using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Cargo
    {
        public Cargo()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int IdCargo { get; set; }
        public string NombreCargo { get; set; }
        public int RoleIdRole { get; set; }

        public virtual Role RoleIdRoleNavigation { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
