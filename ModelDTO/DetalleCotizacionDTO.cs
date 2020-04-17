using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterSolutionAPI.ModelDTO
{
    public class DetalleCotizacionDTO
    {
        public double Cantidad { get; set; }
        public double TotalDetalle { get; set; }
        public double Precio { get; set; }
        public  MaterialDTO Material { get; set; }
    }
}
