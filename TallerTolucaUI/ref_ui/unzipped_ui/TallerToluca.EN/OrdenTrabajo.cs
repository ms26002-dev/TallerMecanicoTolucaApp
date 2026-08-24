namespace TallerToluca.EN
{
    public class OrdenTrabajoEN
    {
        public int OrdenID { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int ClienteID { get; set; }
        public int VehiculoID { get; set; }
        public int EmpleadoID { get; set; } // Mecánico asignado
        public string Estado { get; set; } = "Pendiente"; // Pendiente, En Proceso, Finalizada
        public int KilometrajeEntrada { get; set; }
        public string UbicacionTaller { get; set; } = "Taller Mecánico Toluca";
        public string DescripcionDiagnostico { get; set; }
        public string Observaciones { get; set; }
    }
}
