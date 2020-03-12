using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class DetalleCotizacion
    {
        public int DetalleCotizacionId { get; set; }
        public double Cantidad { get; set; }
        public double TotalDetalle { get; set; }
        public double Presio { get; set; }
        public int MaterialId { get; set; }
        public int CotizacionId { get; set; }

        public virtual Cotizaciones Cotizacion { get; set; }
        public virtual Material Material { get; set; }
    }
}
