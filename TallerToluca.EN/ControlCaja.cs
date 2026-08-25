namespace TallerToluca.EN
{
    public class ControlCajaEN
    {
        public int CajaID { get; set; }
        public DateTime FechaApertura { get; set; } = DateTime.Now;
        public DateTime? FechaCierre { get; set; }
        public decimal MontoApertura { get; set; }
        public decimal MontoIngresos { get; set; } = 0;
        public decimal MontoEgresos { get; set; } = 0;
        public string Estado { get; set; } = "Abierta"; // Abierta, Cerrada

        public string FechaAperturaFormateada => FechaApertura.ToString("dd/MM/yyyy hh:mm tt");
        public string FechaCierreFormateada => FechaCierre.HasValue ? FechaCierre.Value.ToString("dd/MM/yyyy hh:mm tt") : "En curso...";
        public string MontoAperturaFormateado => MontoApertura.ToString("C2");
        public string MontoIngresosFormateado => MontoIngresos.ToString("C2");
        public string MontoEgresosFormateado => MontoEgresos.ToString("C2");
        public decimal SaldoTotal => MontoApertura + MontoIngresos - MontoEgresos;
        public string SaldoTotalFormateado => SaldoTotal.ToString("C2");
        public string EstadoBadge => Estado == "Abierta" ? "🟢 Abierta" : "🔴 Cerrada";
    }
}
