using System;

namespace TallerToluca.EN
{
    public class CitaEN
    {
        public int CitaID { get; set; }
        public int ClienteID { get; set; }
        public int VehiculoID { get; set; }
        public DateTime FechaHora { get; set; } = DateTime.Now;
        public string Motivo { get; set; } = string.Empty;
        public string Estado { get; set; } = "Programada"; // Programada, Cancelada, Atendida, No Recibida, Reprogramada

        // Propiedades de navegación / visualización
        public string? NombreCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string? DetalleVehiculo { get; set; }

        public string FechaHoraFormateada => FechaHora.ToString("dd/MM/yyyy hh:mm tt");
    }
}

