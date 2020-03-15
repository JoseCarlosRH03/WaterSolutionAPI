using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class PassworLost
    {
        public int IdPassworLost { get; set; }
        public string Extencion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
