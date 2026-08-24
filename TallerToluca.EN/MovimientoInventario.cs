using System;

namespace TallerToluca.EN
{
    public class MovimientoInventarioEN
    {
        public int MovimientoID { get; set; }
        public int RepuestoID { get; set; }
        public string NombreRepuesto { get; set; }
        public string TipoMovimiento { get; set; } // Entrada, Salida
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Motivo { get; set; }
    }
}

