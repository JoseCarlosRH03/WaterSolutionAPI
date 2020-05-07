using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterSolutionAPI.ModelDTO
{
    public class DetalleCotizacionDTO
    {
        public int DetalleCotizacionId { get; set; }
        public double Cantidad { get; set; }
        public double TotalDetalle { get; set; }
        public double Presio { get; set; }
        public int MaterialId { get; set; }
        public int CotizacionId { get; set; }
        public  MaterialDTO Material { get; set; }
    }
}
