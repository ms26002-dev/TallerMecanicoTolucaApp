using System;
using System.Collections.Generic;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class VehiculoBL
    {
        private readonly VehiculoDAL _vehiculoDAL = new VehiculoDAL();

        public int RegistrarVehiculo(VehiculoEN vehiculo)
        {
            ValidarVehiculo(vehiculo, esNuevo: true);
            return _vehiculoDAL.Registrar(vehiculo);
        }

        public int ModificarVehiculo(VehiculoEN vehiculo)
        {
            if (vehiculo.VehiculoID <= 0)
                throw new ArgumentException("ID de vehículo no válido.");

            ValidarVehiculo(vehiculo, esNuevo: false);
            return _vehiculoDAL.Modificar(vehiculo);
        }

        public int EliminarVehiculo(int vehiculoID)
        {
            if (vehiculoID <= 0)
                throw new ArgumentException("ID de vehículo no válido.");

            return _vehiculoDAL.EliminarLogico(vehiculoID);
        }

        public List<VehiculoEN> ObtenerTodosVehiculos()
        {
            return _vehiculoDAL.ConsultarTodos();
        }

        public List<VehiculoEN> ObtenerVehiculosActivos()
        {
            return _vehiculoDAL.ConsultarActivos();
        }

        public List<VehiculoEN> ObtenerVehiculosPorCliente(int clienteID)
        {
            if (clienteID <= 0)
                return new List<VehiculoEN>();

            return _vehiculoDAL.ConsultarPorCliente(clienteID);
        }

        public bool ExistePlaca(string placa, int vehiculoIDExcluir = 0)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return false;

            return _vehiculoDAL.ExistePlaca(placa.Trim(), vehiculoIDExcluir);
        }

        private void ValidarVehiculo(VehiculoEN vehiculo, bool esNuevo)
        {
            if (vehiculo.ClienteID <= 0)
                throw new ArgumentException("Debe seleccionar un cliente propietario registrado para el vehículo.");

            if (string.IsNullOrWhiteSpace(vehiculo.Placa))
                throw new ArgumentException("La placa del vehículo es obligatoria.");

            if (string.IsNullOrWhiteSpace(vehiculo.Marca))
                throw new ArgumentException("La marca del vehículo es obligatoria.");

            if (string.IsNullOrWhiteSpace(vehiculo.Modelo))
                throw new ArgumentException("El modelo del vehículo es obligatorio.");

            int anioActual = DateTime.Now.Year;
            if (vehiculo.Anio < 1900 || vehiculo.Anio > anioActual + 1)
                throw new ArgumentException($"El año del vehículo debe estar entre 1900 y {anioActual + 1}.");

            // Restricción #4 del sistema: Solo vehículos livianos
            if (!string.Equals(vehiculo.TipoVehiculo, "Liviano", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Restricción del Sistema: El taller solo atiende y permite el registro de vehículos livianos (sedanes, hatchbacks, suvs, pickups). No se admiten vehículos pesados ni motocicletas.");
            }

            // Validar placa duplicada
            int idExcluir = esNuevo ? 0 : vehiculo.VehiculoID;
            if (_vehiculoDAL.ExistePlaca(vehiculo.Placa.Trim(), idExcluir))
            {
                throw new InvalidOperationException($"Ya existe un vehículo registrado con la placa '{vehiculo.Placa.Trim().ToUpper()}'.");
            }
        }
    }
}
