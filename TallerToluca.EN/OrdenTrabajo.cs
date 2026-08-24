using System;

namespace TallerToluca.EN
{
    public class OrdenTrabajoEN
    {
        public int OrdenID { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int ClienteID { get; set; }
        public int VehiculoID { get; set; }
        public int EmpleadoID { get; set; } // Mecánico asignado
        public string Estado { get; set; } = "Pendiente"; // Pendiente, En Proceso, Finalizada, Cancelada
        public int KilometrajeEntrada { get; set; }
        public string UbicacionTaller { get; set; } = "Taller Mecánico Toluca";
        public string DescripcionDiagnostico { get; set; } = string.Empty;
        public string? Observaciones { get; set; }

        // Propiedades de navegación / visualización
        public string? NombreCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? DetalleVehiculo { get; set; }
        public string? NombreMecanico { get; set; }

        public string FechaFormateada => FechaCreacion.ToString("dd/MM/yyyy HH:mm");
    }
}
