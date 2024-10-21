using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Estacionamiento
    {
        public Estacionamiento()
        {
            Reservasestacionamientos = new HashSet<Reservasestacionamiento>();
        }

        public int IdEstacionamiento { get; set; }
        public string NombreEstacionamiento { get; set; } = null!;
        public int DisponibilidadTotal { get; set; }

        public virtual ICollection<Reservasestacionamiento> Reservasestacionamientos { get; set; }
    }
}
