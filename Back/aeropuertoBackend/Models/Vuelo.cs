using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Vuelo
    {
        public Vuelo()
        {
            Reservasvuelos = new HashSet<Reservasvuelo>();
        }

        public int IdVuelos { get; set; }
        public int Origen { get; set; }
        public int Destino { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public TimeSpan? HoraLlegada { get; set; }
        public int? IdTipoAvion { get; set; }
        public DateTime? FechaSalida { get; set; }

        public virtual Ciudade DestinoNavigation { get; set; } = null!;
        public virtual Tiposavion? IdTipoAvionNavigation { get; set; }
        public virtual Ciudade OrigenNavigation { get; set; } = null!;
        public virtual ICollection<Reservasvuelo> Reservasvuelos { get; set; }
    }
}
