using System;
using System.Collections.Generic;
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

        public List<CitaEN> ConsultarTodas()
        {
            List<CitaEN> lista = new List<CitaEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT CitaID, ClienteID, VehiculoID, FechaHora, Motivo, Estado FROM Citas ORDER BY FechaHora DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new CitaEN
                    {
                        CitaID = reader.GetInt32(0),
                        ClienteID = reader.GetInt32(1),
                        VehiculoID = reader.GetInt32(2),
                        FechaHora = reader.GetDateTime(3),
                        Motivo = reader.GetString(4),
                        Estado = reader.GetString(5)
                    });
                }
            }
            return lista;
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
