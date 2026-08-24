namespace TallerToluca.EN
{
    public class OrdenRepuestoEN
    {
        public int DetalleID { get; set; }
        public int OrdenID { get; set; }
        public int RepuestoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
