using System;
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
    }
}