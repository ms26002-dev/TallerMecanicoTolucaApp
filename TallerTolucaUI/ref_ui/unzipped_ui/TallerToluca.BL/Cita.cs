using System;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class CitaBL
    {
        private readonly CitaDAL _citaDAL = new CitaDAL();

        public int ProgramarCita(CitaEN cita)
        {
            if (cita.FechaHora < DateTime.Now)
                throw new ArgumentException("No se puede programar una cita en una fecha u hora que ya ha pasado.");

            if (string.IsNullOrWhiteSpace(cita.Motivo))
                throw new ArgumentException("Debe especificar el motivo de la cita.");

            return _citaDAL.Programar(cita);
        }

        public int ActualizarEstadoCita(int citaID, string estado)
        {
            return _citaDAL.ActualizarEstado(citaID, estado);
        }

        // Restricción #3: Evalúa y marca citas vencidas como "No Recibida"
        public void ProcesarCitasVencidas(int minutosTolerancia = 30)
        {
            _citaDAL.MarcarCitasVencidas(minutosTolerancia);
        }
    }
}
