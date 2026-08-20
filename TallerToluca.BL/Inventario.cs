using System;
using System.Collections.Generic;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class InventarioBL
    {
        private readonly InventarioDAL _inventarioDAL = new InventarioDAL();

        public int RegistrarRepuesto(RepuestoEN repuesto)
        {
            if (string.IsNullOrWhiteSpace(repuesto.Codigo) || string.IsNullOrWhiteSpace(repuesto.NombreRepuesto))
                throw new ArgumentException("El código y el nombre del repuesto son obligatorios.");

            if (repuesto.PrecioUnitario <= 0)
                throw new ArgumentException("El precio unitario debe ser mayor a cero.");

            return _inventarioDAL.RegistrarRepuesto(repuesto);
        }

        public int RegistrarMovimiento(MovimientoInventarioEN mov)
        {
            if (mov.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");

            // Restricción #7: Las salidas de inventario deben estar justificadas por uso en taller
            if (mov.TipoMovimiento == "Salida" && string.IsNullOrWhiteSpace(mov.Motivo))
            {
                throw new ArgumentException("Las salidas de repuestos deben registrar el motivo u orden de trabajo asociada.");
            }

            return _inventarioDAL.RegistrarMovimiento(mov);
        }

        public List<RepuestoEN> ObtenerTodosLosRepuestos()
        {
            return _inventarioDAL.ConsultarRepuestos();
        }
    }
}