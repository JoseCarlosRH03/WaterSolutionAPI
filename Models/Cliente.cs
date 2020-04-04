using System;
using System.Collections.Generic;

namespace WaterSolutionAPI.Models
{
    public partial class Cliente
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
    }
}
