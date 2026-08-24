using System;
using System.Collections.Generic;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class EmpleadoBL
    {
        private readonly EmpleadoDAL _empleadoDAL = new EmpleadoDAL();

        public int RegistrarEmpleado(EmpleadoEN empleado)
        {
            if (string.IsNullOrWhiteSpace(empleado.NombreCompleto))
                throw new ArgumentException("El nombre del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Cargo))
                throw new ArgumentException("El cargo o rol del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Estado))
                empleado.Estado = "Activo";

            return _empleadoDAL.Registrar(empleado);
        }

        public int ModificarEmpleado(EmpleadoEN empleado)
        {
            if (empleado.EmpleadoID <= 0)
                throw new ArgumentException("ID de empleado no válido.");

            if (string.IsNullOrWhiteSpace(empleado.NombreCompleto))
                throw new ArgumentException("El nombre del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Cargo))
                throw new ArgumentException("El cargo o rol del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Estado))
                empleado.Estado = "Activo";

            return _empleadoDAL.Modificar(empleado);
        }

        public int EliminarEmpleado(int empleadoID)
        {
            if (empleadoID <= 0)
                throw new ArgumentException("ID de empleado no válido.");

            return _empleadoDAL.EliminarLogico(empleadoID);
        }

        public List<EmpleadoEN> ObtenerTodosEmpleados()
        {
            return _empleadoDAL.ConsultarTodos();
        }

        public List<EmpleadoEN> ObtenerEmpleadosActivos()
        {
            var todos = _empleadoDAL.ConsultarTodos();
            return todos.FindAll(e => e.Estado == "Activo");
        }
    }
}