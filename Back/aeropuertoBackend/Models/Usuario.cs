using System;
using System.Collections.Generic;

namespace aeropuertoBackend.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Reporteincidencia = new HashSet<Reporteincidencia>();
            Reservasestacionamientos = new HashSet<Reservasestacionamiento>();
            Reservasvuelos = new HashSet<Reservasvuelo>();
            Turnosempleados = new HashSet<Turnosempleado>();
        }

        public int IdUsuarios { get; set; }
        public string? Correo { get; set; }
        public string? Password { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string? Nombre { get; set; }

        public virtual Tiposusuario? IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Reporteincidencia> Reporteincidencia { get; set; }
        public virtual ICollection<Reservasestacionamiento> Reservasestacionamientos { get; set; }
        public virtual ICollection<Reservasvuelo> Reservasvuelos { get; set; }
        public virtual ICollection<Turnosempleado> Turnosempleados { get; set; }
    }
}
