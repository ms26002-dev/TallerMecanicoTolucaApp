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
            ControlCajaEN? cajaActiva = _cajaDAL.ObtenerCajaAbierta();
            if (cajaActiva == null)
            {
                throw new InvalidOperationException("Debe realizar la Apertura de Caja antes de registrar cobros o facturar.");
            }

            if (factura.Total <= 0)
                throw new ArgumentException("El monto total de la factura debe ser mayor a cero.");

            if (factura.ClienteID <= 0)
                throw new ArgumentException("Debe seleccionar un cliente para emitir la factura.");

            // Restricción #1: Solo cobro en efectivo
            factura.MetodoPago = "Efectivo";
            factura.CajaID = cajaActiva.CajaID;
            factura.Fecha = DateTime.Now;

            // Genera la factura y suma el ingreso a la caja activa
            int resultado = _facturaDAL.GenerarFactura(factura);
            _cajaDAL.RegistrarMovimiento(cajaActiva.CajaID, factura.Total, "Ingreso");

            return resultado;
        }

        public List<FacturaEN> ObtenerTodasFacturas()
        {
            return _facturaDAL.ConsultarTodas();
        }
    }
}