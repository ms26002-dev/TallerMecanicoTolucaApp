using System;
using System.Collections.Generic;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class CitaBL
    {
        private readonly CitaDAL _citaDAL = new CitaDAL();

        public int ProgramarCita(CitaEN cita)
        {
            if (cita.ClienteID <= 0)
                throw new ArgumentException("Debe seleccionar un cliente para programar la cita.");

            if (cita.VehiculoID <= 0)
                throw new ArgumentException("Debe seleccionar un vehículo asociado al cliente.");

            if (cita.FechaHora < DateTime.Now.AddMinutes(-5))
                throw new ArgumentException("No se puede programar una cita en una fecha u hora que ya ha pasado.");

            if (string.IsNullOrWhiteSpace(cita.Motivo))
                throw new ArgumentException("Debe especificar el motivo del servicio o mantenimiento para la cita.");

            if (string.IsNullOrWhiteSpace(cita.Estado))
                cita.Estado = "Programada";

            return _citaDAL.Programar(cita);
        }

        public int ModificarCita(CitaEN cita)
        {
            if (cita.CitaID <= 0)
                throw new ArgumentException("ID de cita no válido.");

            if (cita.ClienteID <= 0)
                throw new ArgumentException("Debe seleccionar un cliente.");

            if (cita.VehiculoID <= 0)
                throw new ArgumentException("Debe seleccionar un vehículo.");

            if (string.IsNullOrWhiteSpace(cita.Motivo))
                throw new ArgumentException("Debe especificar el motivo de la cita.");

            return _citaDAL.Modificar(cita);
        }

        public int ActualizarEstadoCita(int citaID, string estado)
        {
            if (citaID <= 0)
                throw new ArgumentException("ID de cita no válido.");

            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("Estado no válido.");

            return _citaDAL.ActualizarEstado(citaID, estado);
        }

        public int CancelarCita(int citaID)
        {
            if (citaID <= 0)
                throw new ArgumentException("ID de cita no válido.");

            return _citaDAL.ActualizarEstado(citaID, "Cancelada");
        }

        public List<CitaEN> ObtenerTodasCitas()
        {
            return _citaDAL.ConsultarTodas();
        }

        // Restricción #3: Evalúa y marca citas vencidas como "No Recibida"
        public void ProcesarCitasVencidas(int minutosTolerancia = 30)
        {
            _citaDAL.MarcarCitasVencidas(minutosTolerancia);
        }
    }
}
