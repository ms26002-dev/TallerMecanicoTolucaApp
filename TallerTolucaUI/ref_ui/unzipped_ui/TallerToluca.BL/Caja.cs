using System;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class CajaBL
    {
        private readonly CajaDAL _cajaDAL = new CajaDAL();

        public int AbrirCaja(decimal montoInicial)
        {
            ControlCajaEN cajaAbierta = _cajaDAL.ObtenerCajaAbierta();
            if (cajaAbierta != null)
            {
                throw new InvalidOperationException("Ya existe una caja abierta actualmente.");
            }

            if (montoInicial < 0)
                throw new ArgumentException("El monto de apertura no puede ser negativo.");

            return _cajaDAL.AbrirCaja(montoInicial);
        }

        public ControlCajaEN ObtenerCajaActiva()
        {
            return _cajaDAL.ObtenerCajaAbierta();
        }
    }
}