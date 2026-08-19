using System;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class OrdenTrabajoBL
    {
        private readonly OrdenTrabajoDAL _ordenDAL = new OrdenTrabajoDAL();

        public int CrearOrden(OrdenTrabajoEN orden)
        {
            // Restricción #8: Exclusivamente en Taller Mecánico Toluca
            if (orden.UbicacionTaller != "Taller Mecánico Toluca")
            {
                throw new InvalidOperationException("No se permiten órdenes de trabajo fuera de Taller Mecánico Toluca.");
            }

            // Restricción #2: Un mecánico solo puede tener una orden activa a la vez
            if (_ordenDAL.MecanicoTieneOrdenActiva(orden.EmpleadoID))
            {
                throw new InvalidOperationException("El mecánico seleccionado ya tiene una orden de trabajo activa asignada.");
            }

            if (string.IsNullOrWhiteSpace(orden.DescripcionDiagnostico))
                throw new ArgumentException("El diagnóstico inicial es obligatorio.");

            return _ordenDAL.CrearOrden(orden);
        }

        public void CambiarEstadoOrden(int ordenID, string nuevoEstado)
        {
            string estadoActual = _ordenDAL.ObtenerEstadoOrden(ordenID);

            // Restricción #6: Órdenes finalizadas no se pueden modificar
            if (estadoActual == "Finalizada")
            {
                throw new InvalidOperationException("La orden de trabajo ya ha sido finalizada y no puede modificarse.");
            }

            _ordenDAL.ActualizarEstado(ordenID, nuevoEstado);
        }
    }
}
