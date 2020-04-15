using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Departamentos
    {
        public Departamentos()
        {
            secciones = new HashSet<Secciones>();
        }

        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; }

        public virtual ICollection<Secciones> secciones { get; set; }
    }
}
