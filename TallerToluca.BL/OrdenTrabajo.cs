using System;
using System.Collections.Generic;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class OrdenTrabajoBL
    {
        private readonly OrdenTrabajoDAL _ordenDAL = new OrdenTrabajoDAL();

        public int CrearOrden(OrdenTrabajoEN orden)
        {
            if (orden.ClienteID <= 0)
                throw new ArgumentException("Debe seleccionar un cliente para la orden de trabajo.");

            if (orden.VehiculoID <= 0)
                throw new ArgumentException("Debe seleccionar un vehículo asociado para la orden de trabajo.");

            if (orden.EmpleadoID <= 0)
                throw new ArgumentException("Debe asignar un mecánico responsable para la orden.");

            if (orden.KilometrajeEntrada < 0)
                throw new ArgumentException("El kilometraje de entrada no puede ser negativo.");

            if (string.IsNullOrWhiteSpace(orden.DescripcionDiagnostico))
                throw new ArgumentException("El diagnóstico inicial o motivo del servicio es obligatorio.");

            // Restricción #8: Exclusivamente en Taller Mecánico Toluca
            if (string.IsNullOrWhiteSpace(orden.UbicacionTaller))
                orden.UbicacionTaller = "Taller Mecánico Toluca";

            if (orden.UbicacionTaller != "Taller Mecánico Toluca")
            {
                throw new InvalidOperationException("Restricción del Sistema (Regla #8): No se permiten órdenes de trabajo fuera de 'Taller Mecánico Toluca'.");
            }

            // Restricción #2: Un mecánico solo puede tener una orden activa a la vez
            if (_ordenDAL.MecanicoTieneOrdenActiva(orden.EmpleadoID, 0))
            {
                throw new InvalidOperationException("Restricción de Personal (Regla #2): El mecánico seleccionado ya tiene una orden de trabajo activa (Pendiente o En Proceso). Asigne otro mecánico disponible.");
            }

            return _ordenDAL.CrearOrden(orden);
        }

        public int ModificarOrden(OrdenTrabajoEN orden)
        {
            if (orden.OrdenID <= 0)
                throw new ArgumentException("ID de orden no válido.");

            string estadoActual = _ordenDAL.ObtenerEstadoOrden(orden.OrdenID);

            // Restricción #6: Órdenes finalizadas no se pueden modificar
            if (estadoActual == "Finalizada")
            {
                throw new InvalidOperationException("Restricción de Integridad (Regla #6): La orden de trabajo ya ha sido finalizada y no puede modificarse.");
            }

            if (orden.ClienteID <= 0)
                throw new ArgumentException("Debe seleccionar un cliente para la orden de trabajo.");

            if (orden.VehiculoID <= 0)
                throw new ArgumentException("Debe seleccionar un vehículo para la orden de trabajo.");

            if (orden.EmpleadoID <= 0)
                throw new ArgumentException("Debe asignar un mecánico responsable.");

            if (string.IsNullOrWhiteSpace(orden.DescripcionDiagnostico))
                throw new ArgumentException("El diagnóstico inicial es obligatorio.");

            // Si la orden sigue activa y se asigna a un mecánico, validar que no tenga otra activa
            if (orden.Estado != "Finalizada" && orden.Estado != "Cancelada")
            {
                if (_ordenDAL.MecanicoTieneOrdenActiva(orden.EmpleadoID, orden.OrdenID))
                {
                    throw new InvalidOperationException("El mecánico seleccionado ya tiene otra orden de trabajo activa asignada.");
                }
            }

            return _ordenDAL.ModificarOrden(orden);
        }

        public void CambiarEstadoOrden(int ordenID, string nuevoEstado)
        {
            if (ordenID <= 0)
                throw new ArgumentException("ID de orden no válido.");

            string estadoActual = _ordenDAL.ObtenerEstadoOrden(ordenID);

            // Restricción #6: Órdenes finalizadas no se pueden modificar
            if (estadoActual == "Finalizada")
            {
                throw new InvalidOperationException("Restricción de Integridad (Regla #6): La orden de trabajo ya ha sido finalizada y no puede alterarse.");
            }

            _ordenDAL.ActualizarEstado(ordenID, nuevoEstado);
        }

        public List<OrdenTrabajoEN> ObtenerTodasOrdenes()
        {
            return _ordenDAL.ConsultarTodas();
        }

        public OrdenTrabajoEN? ObtenerOrdenPorID(int ordenID)
        {
            if (ordenID <= 0) return null;
            return _ordenDAL.ConsultarPorID(ordenID);
        }

        public bool MecanicoTieneOrdenActiva(int empleadoID, int ordenIDExcluir = 0)
        {
            if (empleadoID <= 0) return false;
            return _ordenDAL.MecanicoTieneOrdenActiva(empleadoID, ordenIDExcluir);
        }
    }
}
