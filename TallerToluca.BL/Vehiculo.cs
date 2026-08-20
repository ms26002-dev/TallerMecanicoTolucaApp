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
            if (vehiculo.ClienteID <= 0)
                throw new ArgumentException("Debe ingresar un ID de cliente válido.");

            if (string.IsNullOrWhiteSpace(vehiculo.Placa))
                throw new ArgumentException("El número de placa es obligatorio.");

            if (string.IsNullOrWhiteSpace(vehiculo.Marca))
                throw new ArgumentException("La marca del vehículo es obligatoria.");

            if (string.IsNullOrWhiteSpace(vehiculo.Modelo))
                throw new ArgumentException("El modelo del vehículo es obligatorio.");

            if (vehiculo.Anio <= 1900 || vehiculo.Anio > DateTime.Now.Year + 1)
                throw new ArgumentException("El año del vehículo no es válido.");

            // Regla de Negocio: Restricción de Tipo de Vehículo (Solo Liviano)
            if (vehiculo.TipoVehiculo != "Liviano")
                throw new InvalidOperationException("Solo se permite el registro y atención de vehículos tipo 'Liviano'.");

            return _vehiculoDAL.Registrar(vehiculo);
        }

        public List<VehiculoEN> ObtenerTodosLosVehiculos()
        {
            return _vehiculoDAL.ConsultarTodos();
        }

        public int EliminarVehiculo(int vehiculoID)
        {
            if (vehiculoID <= 0)
                throw new ArgumentException("ID de vehículo no válido.");

            return _vehiculoDAL.Eliminar(vehiculoID);
        }
    }
}
