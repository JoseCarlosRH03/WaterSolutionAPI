using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterSolutionAPI.ModelDTO
{
    public class SeguimientosDTO
    {
        public string seguimiento { get; set; }
        public DateTime fechaSeguimiento { get; set; }

        public  EmpleadoDTO2 EmpleadoSeguimiento { get; set; }
    }
}
