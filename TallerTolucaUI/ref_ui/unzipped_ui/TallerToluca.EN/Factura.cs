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
        public string MetodoPago { get; set; } = "Efectivo"; // Solo efectivo
    }
}
