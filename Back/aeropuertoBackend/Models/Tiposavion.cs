using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Tiposavion
    {
        public Tiposavion()
        {
            Vuelos = new HashSet<Vuelo>();
        }

        public int IdTiposAvion { get; set; }
        public int? AsientosBusiness { get; set; }
        public int? AsientosPreferencial { get; set; }
        public int? AsientosEstandar { get; set; }

        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
