using System;
using System.Collections.Generic;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class FacturaBL
    {
        private readonly FacturaDAL _facturaDAL = new FacturaDAL();
        private readonly CajaDAL _cajaDAL = new CajaDAL();

        public int GenerarFacturaEfectivo(FacturaEN factura)
        {
            ControlCajaEN cajaActiva = _cajaDAL.ObtenerCajaAbierta();
            if (cajaActiva == null)
            {
                throw new InvalidOperationException("Debe realizar la Apertura de Caja antes de facturar.");
            }

            if (factura.Total <= 0)
                throw new ArgumentException("El monto total de la factura debe ser mayor a cero.");

            // Restricción #1: Solo cobro en efectivo
            factura.MetodoPago = "Efectivo";
            factura.CajaID = cajaActiva.CajaID;

            // Genera la factura y suma el ingreso a la caja activa
            int resultado = _facturaDAL.GenerarFactura(factura);
            _cajaDAL.RegistrarMovimiento(cajaActiva.CajaID, factura.Total, "Ingreso");

            return resultado;
        }

        public List<FacturaEN> ObtenerTodasLasFacturas()
        {
            return _facturaDAL.ConsultarTodas();
        }
    }
}