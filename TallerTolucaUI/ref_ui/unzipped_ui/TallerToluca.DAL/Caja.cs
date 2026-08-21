using System;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class CajaDAL
    {
        public int AbrirCaja(decimal montoInicial)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO ControlCaja (MontoApertura, Estado) 
                                 VALUES (@Monto, 'Abierta'); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Monto", montoInicial);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public ControlCajaEN ObtenerCajaAbierta()
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT TOP 1 CajaID, FechaApertura, MontoApertura, MontoIngresos, MontoEgresos, Estado FROM ControlCaja WHERE Estado = 'Abierta' ORDER BY CajaID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new ControlCajaEN
                    {
                        CajaID = reader.GetInt32(0),
                        FechaApertura = reader.GetDateTime(1),
                        MontoApertura = reader.GetDecimal(2),
                        MontoIngresos = reader.GetDecimal(3),
                        MontoEgresos = reader.GetDecimal(4),
                        Estado = reader.GetString(5)
                    };
                }
            }
            return null;
        }

        public int RegistrarMovimiento(int cajaID, decimal monto, string tipo)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string campo = tipo == "Ingreso" ? "MontoIngresos" : "MontoEgresos";
                string query = $"UPDATE ControlCaja SET {campo} = {campo} + @Monto WHERE CajaID = @CajaID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Monto", monto);
                cmd.Parameters.AddWithValue("@CajaID", cajaID);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
