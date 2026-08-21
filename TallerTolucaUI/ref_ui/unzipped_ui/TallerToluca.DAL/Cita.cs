using System;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class CitaDAL
    {
        public int Programar(CitaEN cita)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO Citas (ClienteID, VehiculoID, FechaHora, Motivo, Estado) 
                                 VALUES (@ClienteID, @VehiculoID, @FechaHora, @Motivo, 'Programada')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClienteID", cita.ClienteID);
                cmd.Parameters.AddWithValue("@VehiculoID", cita.VehiculoID);
                cmd.Parameters.AddWithValue("@FechaHora", cita.FechaHora);
                cmd.Parameters.AddWithValue("@Motivo", cita.Motivo);
                return cmd.ExecuteNonQuery();
            }
        }

        public int ActualizarEstado(int citaID, string estado)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "UPDATE Citas SET Estado = @Estado WHERE CitaID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Estado", estado);
                cmd.Parameters.AddWithValue("@ID", citaID);
                return cmd.ExecuteNonQuery();
            }
        }

        public void MarcarCitasVencidas(int minutosTolerancia)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE Citas 
                                 SET Estado = 'No Recibida' 
                                 WHERE Estado IN ('Programada', 'Reprogramada') 
                                 AND DATEADD(minute, @Tolerancia, FechaHora) < GETDATE()";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Tolerancia", minutosTolerancia);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
