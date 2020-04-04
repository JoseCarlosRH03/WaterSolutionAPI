using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Secciones
    {
        public Secciones()
        {
            Empleados = new HashSet<Empleados>();
        }

        public int IdSeccion { get; set; }
        public string NombreSeccion { get; set; }
        public int? DepartamentoIdDepartamento { get; set; }

        public virtual Departamentos DepartamentoIdDepartamentoNavigation { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
    }
}
