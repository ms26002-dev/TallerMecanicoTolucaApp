namespace TallerToluca.EN
{
    public class CitaEN
    {
        public int CitaID { get; set; }
        public int ClienteID { get; set; }
        public int VehiculoID { get; set; }
        public DateTime FechaHora { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; } = "Programada"; // Programada, Cancelada, Atendida, No Recibida
    }
}

