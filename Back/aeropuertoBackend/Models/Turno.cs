using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Turno
    {
        public Turno()
        {
            Turnosempleados = new HashSet<Turnosempleado>();
        }

        public int Idturno { get; set; }
        public string NombreTurno { get; set; } = null!;
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }

        public virtual ICollection<Turnosempleado> Turnosempleados { get; set; }
    }
}
