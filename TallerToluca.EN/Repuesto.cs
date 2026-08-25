namespace TallerToluca.EN
{
    public class RepuestoEN
    {
        public int RepuestoID { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string NombreRepuesto { get; set; } = string.Empty;
        public string Proveedor { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public int Existencia { get; set; }
    }
}