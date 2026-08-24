using System;
using System.Collections.Generic;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class CajaBL
    {
        private readonly CajaDAL _cajaDAL = new CajaDAL();

        public int AbrirCaja(decimal montoInicial)
        {
            ControlCajaEN? cajaAbierta = _cajaDAL.ObtenerCajaAbierta();
            if (cajaAbierta != null)
            {
                throw new InvalidOperationException("Ya existe una caja abierta actualmente. Debe realizar el cierre antes de abrir una nueva.");
            }

            if (montoInicial < 0)
                throw new ArgumentException("El monto inicial de apertura no puede ser negativo.");

            return _cajaDAL.AbrirCaja(montoInicial);
        }

        public int CerrarCaja(int cajaID)
        {
            if (cajaID <= 0)
                throw new ArgumentException("ID de caja no válido.");

            return _cajaDAL.CerrarCaja(cajaID);
        }

        public ControlCajaEN? ObtenerCajaActiva()
        {
            return _cajaDAL.ObtenerCajaAbierta();
        }

        public List<ControlCajaEN> ObtenerHistorialCajas()
        {
            return _cajaDAL.ConsultarHistorial();
        }
    }
}