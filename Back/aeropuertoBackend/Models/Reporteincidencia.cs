using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Reporteincidencia
    {
        public int IdreporteIncidencias { get; set; }
        public string Comentario { get; set; } = null!;
        public int IdUsuarioReporto { get; set; }

        public virtual Usuario IdUsuarioReportoNavigation { get; set; } = null!;
    }
}
