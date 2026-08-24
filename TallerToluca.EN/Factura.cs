using System;

namespace TallerToluca.EN
{
    public class FacturaEN
    {
        public int FacturaID { get; set; }
        public int OrdenID { get; set; }
        public int ClienteID { get; set; }
        public int CajaID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; } = "Efectivo"; // Solo efectivo - Regla #1

        // Propiedades de navegación / visualización
        public string? NombreCliente { get; set; }
        public string? TelefonoCliente { get; set; }
        public string? PlacaVehiculo { get; set; }
        public string FechaFormateada => Fecha.ToString("dd/MM/yyyy hh:mm tt");
        public string SubTotalFormateado => SubTotal.ToString("C2");
        public string TotalFormateado => Total.ToString("C2");
    }
}
