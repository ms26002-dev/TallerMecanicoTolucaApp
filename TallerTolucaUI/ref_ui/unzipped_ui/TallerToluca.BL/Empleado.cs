using System;
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
    }
}