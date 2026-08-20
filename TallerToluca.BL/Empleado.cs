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
                throw new ArgumentException("El cargo del empleado es obligatorio.");

            return _empleadoDAL.Registrar(empleado);
        }

        public int ModificarEmpleado(EmpleadoEN empleado)
        {
            if (empleado.EmpleadoID <= 0)
                throw new ArgumentException("ID de empleado inválido.");

            if (string.IsNullOrWhiteSpace(empleado.NombreCompleto))
                throw new ArgumentException("El nombre del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Cargo))
                throw new ArgumentException("El cargo del empleado es obligatorio.");

            return _empleadoDAL.Modificar(empleado);
        }

        public int EliminarEmpleado(int empleadoID)
        {
            if (empleadoID <= 0)
                throw new ArgumentException("ID de empleado inválido.");

            return _empleadoDAL.EliminarLogico(empleadoID);
        }

        public List<EmpleadoEN> ObtenerTodosLosEmpleados()
        {
            return _empleadoDAL.ConsultarTodos();
        }
    }
}