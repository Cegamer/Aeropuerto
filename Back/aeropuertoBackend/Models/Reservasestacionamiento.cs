using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Reservasestacionamiento
    {
        public int IdReservasEstacionamiento { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstacionamiento { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Estacionamiento IdEstacionamientoNavigation { get; set; } = null!;
        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
    }
}
