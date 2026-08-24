using System;
using System.Collections.Generic;
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

        public int CerrarCaja(int cajaID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE ControlCaja 
                                 SET Estado = 'Cerrada', FechaCierre = GETDATE() 
                                 WHERE CajaID = @CajaID AND Estado = 'Abierta'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CajaID", cajaID);
                return cmd.ExecuteNonQuery();
            }
        }

        public ControlCajaEN? ObtenerCajaAbierta()
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT TOP 1 CajaID, FechaApertura, MontoApertura, MontoIngresos, MontoEgresos, Estado FROM ControlCaja WHERE Estado = 'Abierta' ORDER BY CajaID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
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

        public List<ControlCajaEN> ConsultarHistorial()
        {
            List<ControlCajaEN> lista = new List<ControlCajaEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT CajaID, FechaApertura, FechaCierre, MontoApertura, MontoIngresos, MontoEgresos, Estado FROM ControlCaja ORDER BY CajaID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new ControlCajaEN
                        {
                            CajaID = reader.GetInt32(0),
                            FechaApertura = reader.GetDateTime(1),
                            FechaCierre = reader.IsDBNull(2) ? null : reader.GetDateTime(2),
                            MontoApertura = reader.GetDecimal(3),
                            MontoIngresos = reader.GetDecimal(4),
                            MontoEgresos = reader.GetDecimal(5),
                            Estado = reader.GetString(6)
                        });
                    }
                }
            }
            return lista;
        }
    }
}
