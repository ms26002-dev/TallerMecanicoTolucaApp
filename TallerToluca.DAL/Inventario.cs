using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class InventarioDAL
    {
        public int RegistrarRepuesto(RepuestoEN repuesto)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO Repuestos (Codigo, NombreRepuesto, PrecioUnitario, Existencia) 
                                 VALUES (@Codigo, @Nombre, @Precio, @Existencia)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", repuesto.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", repuesto.NombreRepuesto);
                cmd.Parameters.AddWithValue("@Precio", repuesto.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Existencia", repuesto.Existencia);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<RepuestoEN> ConsultarRepuestos()
        {
            List<RepuestoEN> lista = new List<RepuestoEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT RepuestoID, Codigo, NombreRepuesto, PrecioUnitario, Existencia FROM Repuestos ORDER BY RepuestoID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new RepuestoEN
                    {
                        RepuestoID = reader.GetInt32(0),
                        Codigo = reader.GetString(1),
                        NombreRepuesto = reader.GetString(2),
                        PrecioUnitario = reader.GetDecimal(3),
                        Existencia = reader.GetInt32(4)
                    });
                }
            }
            return lista;
        }

        public int RegistrarMovimiento(MovimientoInventarioEN mov)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string queryMov = @"INSERT INTO MovimientosInventario (RepuestoID, TipoMovimiento, Cantidad, Motivo) 
                                    VALUES (@RepuestoID, @Tipo, @Cantidad, @Motivo)";
                SqlCommand cmdMov = new SqlCommand(queryMov, conn);
                cmdMov.Parameters.AddWithValue("@RepuestoID", mov.RepuestoID);
                cmdMov.Parameters.AddWithValue("@Tipo", mov.TipoMovimiento);
                cmdMov.Parameters.AddWithValue("@Cantidad", mov.Cantidad);
                cmdMov.Parameters.AddWithValue("@Motivo", mov.Motivo);
                cmdMov.ExecuteNonQuery();

                string operacion = mov.TipoMovimiento == "Entrada" ? "+" : "-";
                string queryStock = $"UPDATE Repuestos SET Existencia = Existencia {operacion} @Cantidad WHERE RepuestoID = @RepuestoID";
                SqlCommand cmdStock = new SqlCommand(queryStock, conn);
                cmdStock.Parameters.AddWithValue("@Cantidad", mov.Cantidad);
                cmdStock.Parameters.AddWithValue("@RepuestoID", mov.RepuestoID);

                return cmdStock.ExecuteNonQuery();
            }
        }
    }
}
