using System;
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
    }
}
