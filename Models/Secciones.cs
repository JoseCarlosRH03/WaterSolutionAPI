using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Secciones
    {
        public Secciones()
        {
            Empleados = new HashSet<Empleados>();
            Solicitud = new HashSet<Solicitud>();
        }

        public int IdSeccion { get; set; }
        public string NombreSeccion { get; set; }
        public int? DepartamentoIdDepartamento { get; set; }

        public virtual Departamentos Departamento { get; set; }
        public virtual ICollection<Empleados> Empleados { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
    }
}
