using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class RolesPermisos
    {
        public int IdRole { get; set; }
        public int IdPermiso { get; set; }
        public int IdRolPermiso { get; set; }

        public virtual PermisoRole IdPermisoNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
