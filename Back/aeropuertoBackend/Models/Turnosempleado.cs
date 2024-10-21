using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Turnosempleado
    {
        public int IdTurnosEmpleados { get; set; }
        public int IdUsuario { get; set; }
        public int? IdTurno { get; set; }
        public string? TurnosEmpleadoscol { get; set; }

        public virtual Turno? IdTurnoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
