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
                string query = @"INSERT INTO Facturas (OrdenID, ClienteID, CajaID, Fecha, SubTotal, Total, MetodoPago) 
                                 VALUES (@OrdenID, @ClienteID, @CajaID, @Fecha, @SubTotal, @Total, 'Efectivo');
                                 SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrdenID", factura.OrdenID);
                cmd.Parameters.AddWithValue("@ClienteID", factura.ClienteID);
                cmd.Parameters.AddWithValue("@CajaID", factura.CajaID);
                cmd.Parameters.AddWithValue("@Fecha", factura.Fecha);
                cmd.Parameters.AddWithValue("@SubTotal", factura.SubTotal);
                cmd.Parameters.AddWithValue("@Total", factura.Total);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<FacturaEN> ConsultarTodas()
        {
            List<FacturaEN> lista = new List<FacturaEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT f.FacturaID, f.OrdenID, f.ClienteID, f.CajaID, f.Fecha, f.SubTotal, f.Total, f.MetodoPago,
                                        cl.NombreCompleto AS NombreCliente,
                                        cl.Telefono AS TelefonoCliente,
                                        v.Placa AS PlacaVehiculo
                                 FROM Facturas f
                                 INNER JOIN Clientes cl ON f.ClienteID = cl.ClienteID
                                 LEFT JOIN OrdenesTrabajo ot ON f.OrdenID = ot.OrdenID
                                 LEFT JOIN Vehiculos v ON ot.VehiculoID = v.VehiculoID
                                 ORDER BY f.FacturaID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
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
                            MetodoPago = reader.GetString(7),
                            NombreCliente = reader.IsDBNull(8) ? null : reader.GetString(8),
                            TelefonoCliente = reader.IsDBNull(9) ? null : reader.GetString(9),
                            PlacaVehiculo = reader.IsDBNull(10) ? null : reader.GetString(10)
                        });
                    }
                }
            }
            return lista;
        }
    }
}
