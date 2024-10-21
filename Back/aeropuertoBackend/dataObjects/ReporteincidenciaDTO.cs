namespace aeropuertoBackend.dataObjects
{
    public class ReporteincidenciaDTO
    {
        public int IdreporteIncidencias { get; set; }
        public string Comentario { get; set; } = null!;
        public int IdUsuarioReporto { get; set; }

    }
}
