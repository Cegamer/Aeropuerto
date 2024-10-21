using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Ciudade
    {
        public Ciudade()
        {
            VueloDestinoNavigations = new HashSet<Vuelo>();
            VueloOrigenNavigations = new HashSet<Vuelo>();
        }

        public int IdCiudad { get; set; }
        public string? NombreCiudad { get; set; }

        public virtual ICollection<Vuelo> VueloDestinoNavigations { get; set; }
        public virtual ICollection<Vuelo> VueloOrigenNavigations { get; set; }
    }
}
