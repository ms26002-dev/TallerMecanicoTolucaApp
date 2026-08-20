using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class FacturaDAL
    {
        public int GenerarFactura(FacturaEN factura)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO Facturas (OrdenID, ClienteID, CajaID, SubTotal, Total, MetodoPago) 
                                 VALUES (@OrdenID, @ClienteID, @CajaID, @SubTotal, @Total, 'Efectivo')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrdenID", factura.OrdenID);
                cmd.Parameters.AddWithValue("@ClienteID", factura.ClienteID);
                cmd.Parameters.AddWithValue("@CajaID", factura.CajaID);
                cmd.Parameters.AddWithValue("@SubTotal", factura.SubTotal);
                cmd.Parameters.AddWithValue("@Total", factura.Total);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<FacturaEN> ConsultarTodas()
        {
            List<FacturaEN> lista = new List<FacturaEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT FacturaID, OrdenID, ClienteID, CajaID, Fecha, SubTotal, Total, MetodoPago FROM Facturas ORDER BY FacturaID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new FacturaEN
                    {
                        FacturaID = reader.GetInt32(0),
                        OrdenID = reader.GetInt32(1),
                        ClienteID = reader.GetInt32(2),
                        CajaID = reader.GetInt32(3),
                        Fecha = reader.GetDateTime(4),
                        SubTotal = reader.GetDecimal(5),
                        Total = reader.GetDecimal(6),
                        MetodoPago = reader.GetString(7)
                    });
                }
            }
            return lista;
        }
    }
}
