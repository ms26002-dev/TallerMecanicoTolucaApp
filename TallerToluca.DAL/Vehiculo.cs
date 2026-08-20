using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class VehiculoDAL
    {
        public int Registrar(VehiculoEN vehiculo)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO Vehiculos (ClienteID, Placa, Marca, Modelo, Anio, Color, TipoVehiculo) 
                                 VALUES (@ClienteID, @Placa, @Marca, @Modelo, @Anio, @Color, 'Liviano')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClienteID", vehiculo.ClienteID);
                cmd.Parameters.AddWithValue("@Placa", vehiculo.Placa);
                cmd.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                cmd.Parameters.AddWithValue("@Anio", vehiculo.Anio);
                cmd.Parameters.AddWithValue("@Color", (object)vehiculo.Color ?? DBNull.Value);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<VehiculoEN> ConsultarTodos()
        {
            List<VehiculoEN> lista = new List<VehiculoEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT VehiculoID, ClienteID, Placa, Marca, Modelo, Anio, Color, TipoVehiculo FROM Vehiculos ORDER BY VehiculoID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new VehiculoEN
                    {
                        VehiculoID = reader.GetInt32(0),
                        ClienteID = reader.GetInt32(1),
                        Placa = reader.GetString(2),
                        Marca = reader.GetString(3),
                        Modelo = reader.GetString(4),
                        Anio = reader.GetInt32(5),
                        Color = reader.IsDBNull(6) ? "" : reader.GetString(6),
                        TipoVehiculo = reader.GetString(7)
                    });
                }
            }
            return lista;
        }

        public int Eliminar(int vehiculoID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "DELETE FROM Vehiculos WHERE VehiculoID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", vehiculoID);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}