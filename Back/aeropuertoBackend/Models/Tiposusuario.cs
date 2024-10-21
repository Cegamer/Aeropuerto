using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Tiposusuario
    {
        public Tiposusuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdtipoUsuario { get; set; }
        public string? TipoUsuario { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
