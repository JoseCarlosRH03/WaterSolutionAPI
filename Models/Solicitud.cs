using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Solicitud
    {
        public Solicitud()
        {
            RutaSolicitud = new HashSet<RutaSolicitud>();
            Seguimientos = new HashSet<Seguimientos>();
        }

        public int SolicitudId { get; set; }
        public string Descripcion { get; set; }
        public string DireccionSolicitud { get; set; }
        public string Sector { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string TipoSolicitud { get; set; }
        public int SeccionId { get; set; }
        public int PersonaId { get; set; }

        public virtual Cliente Persona { get; set; }
        public virtual Secciones Seccion { get; set; }
        public virtual Cotizaciones Cotizaciones { get; set; }
        public virtual ICollection<RutaSolicitud> RutaSolicitud { get; set; }
        public virtual ICollection<Seguimientos> Seguimientos { get; set; }
    }
}
