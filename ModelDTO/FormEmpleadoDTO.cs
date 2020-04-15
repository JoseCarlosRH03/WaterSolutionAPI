using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaterSolutionAPI.Models;

namespace WaterSolutionAPI.ModelDTO
{
    public class FormEmpleadoDTO
    {
        public List<Cargo> cargos { get; set; }
        public List<Departamentos> departamentos { get; set; }
    }
}
