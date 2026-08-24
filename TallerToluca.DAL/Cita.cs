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
                                 VALUES (@ClienteID, @VehiculoID, @FechaHora, @Motivo, @Estado);
                                 SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClienteID", cita.ClienteID);
                cmd.Parameters.AddWithValue("@VehiculoID", cita.VehiculoID);
                cmd.Parameters.AddWithValue("@FechaHora", cita.FechaHora);
                cmd.Parameters.AddWithValue("@Motivo", cita.Motivo);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(cita.Estado) ? "Programada" : cita.Estado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int Modificar(CitaEN cita)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE Citas 
                                 SET ClienteID = @ClienteID, VehiculoID = @VehiculoID, 
                                     FechaHora = @FechaHora, Motivo = @Motivo, Estado = @Estado 
                                 WHERE CitaID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", cita.CitaID);
                cmd.Parameters.AddWithValue("@ClienteID", cita.ClienteID);
                cmd.Parameters.AddWithValue("@VehiculoID", cita.VehiculoID);
                cmd.Parameters.AddWithValue("@FechaHora", cita.FechaHora);
                cmd.Parameters.AddWithValue("@Motivo", cita.Motivo);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(cita.Estado) ? "Programada" : cita.Estado);
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
            try
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
            catch { }
        }

        public List<CitaEN> ConsultarTodas()
        {
            List<CitaEN> lista = new List<CitaEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT c.CitaID, c.ClienteID, c.VehiculoID, c.FechaHora, c.Motivo, c.Estado,
                                        cl.NombreCompleto AS NombreCliente,
                                        cl.Telefono AS TelefonoCliente,
                                        v.Placa AS PlacaVehiculo,
                                        CONCAT(v.Marca, ' ', v.Modelo, ' (', v.Anio, ')') AS DetalleVehiculo
                                 FROM Citas c
                                 INNER JOIN Clientes cl ON c.ClienteID = cl.ClienteID
                                 INNER JOIN Vehiculos v ON c.VehiculoID = v.VehiculoID
                                 ORDER BY c.FechaHora DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new CitaEN
                        {
                            CitaID = reader.GetInt32(0),
                            ClienteID = reader.GetInt32(1),
                            VehiculoID = reader.GetInt32(2),
                            FechaHora = reader.GetDateTime(3),
                            Motivo = reader.GetString(4),
                            Estado = reader.GetString(5),
                            NombreCliente = reader.IsDBNull(6) ? null : reader.GetString(6),
                            TelefonoCliente = reader.IsDBNull(7) ? null : reader.GetString(7),
                            PlacaVehiculo = reader.IsDBNull(8) ? null : reader.GetString(8),
                            DetalleVehiculo = reader.IsDBNull(9) ? null : reader.GetString(9)
                        });
                    }
                }
            }
            return lista;
        }
    }
}
