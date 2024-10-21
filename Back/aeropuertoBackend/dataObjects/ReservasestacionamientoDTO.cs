namespace aeropuertoBackend.dataObjects
{
    public class ReservasestacionamientoDTO
    {

        public int IdReservasEstacionamiento { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstacionamiento { get; set; }
        public string HoraEntrada { get; set; }
        public string HoraSalida { get; set; }
        public DateTime? Fecha { get; set; }

    }
}
