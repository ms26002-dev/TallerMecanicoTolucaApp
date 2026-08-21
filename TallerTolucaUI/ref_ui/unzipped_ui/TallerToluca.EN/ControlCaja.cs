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
    }
}
