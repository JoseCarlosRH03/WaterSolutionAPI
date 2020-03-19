using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Material
    {
        public Material()
        {
            DetalleCotizacion = new HashSet<DetalleCotizacion>();
        }

        public int MaterialId { get; set; }
        public string NombreMaterial { get; set; }

        public virtual ICollection<DetalleCotizacion> DetalleCotizacion { get; set; }
    }
}
