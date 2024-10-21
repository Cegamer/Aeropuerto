using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Reservasvuelo
    {
        public int IdReservasVuelo { get; set; }
        public int IdVuelo { get; set; }
        public int IdUsuario { get; set; }
        public int TipoAsiento { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
        public virtual Vuelo IdVueloNavigation { get; set; } = null!;
    }
}
