using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class InventarioDAL
    {
        public List<RepuestoEN> ObtenerRepuestos()
        {
            List<RepuestoEN> lista = new List<RepuestoEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT RepuestoID, Codigo, NombreRepuesto, PrecioUnitario, Existencia FROM Repuestos ORDER BY Codigo ASC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new RepuestoEN
                        {
                            RepuestoID = Convert.ToInt32(reader["RepuestoID"]),
                            Codigo = reader["Codigo"].ToString(),
                            NombreRepuesto = reader["NombreRepuesto"].ToString(),
                            PrecioUnitario = Convert.ToDecimal(reader["PrecioUnitario"]),
                            Existencia = Convert.ToInt32(reader["Existencia"])
                        });
                    }
                }
            }
            return lista;
        }

        public List<MovimientoInventarioEN> ObtenerMovimientos()
        {
            List<MovimientoInventarioEN> lista = new List<MovimientoInventarioEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT m.MovimientoID, m.RepuestoID, r.NombreRepuesto, m.TipoMovimiento, m.Cantidad, m.Fecha, m.Motivo 
                                 FROM MovimientosInventario m
                                 INNER JOIN Repuestos r ON m.RepuestoID = r.RepuestoID
                                 ORDER BY m.Fecha DESC, m.MovimientoID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new MovimientoInventarioEN
                        {
                            MovimientoID = Convert.ToInt32(reader["MovimientoID"]),
                            RepuestoID = Convert.ToInt32(reader["RepuestoID"]),
                            NombreRepuesto = reader["NombreRepuesto"].ToString(),
                            TipoMovimiento = reader["TipoMovimiento"].ToString(),
                            Cantidad = Convert.ToInt32(reader["Cantidad"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Motivo = reader["Motivo"] != DBNull.Value ? reader["Motivo"].ToString() : ""
                        });
                    }
                }
            }
            return lista;
        }

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

        public int ActualizarRepuesto(RepuestoEN repuesto)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE Repuestos 
                                 SET Codigo = @Codigo, NombreRepuesto = @Nombre, PrecioUnitario = @Precio, Existencia = @Existencia 
                                 WHERE RepuestoID = @RepuestoID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Codigo", repuesto.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", repuesto.NombreRepuesto);
                cmd.Parameters.AddWithValue("@Precio", repuesto.PrecioUnitario);
                cmd.Parameters.AddWithValue("@Existencia", repuesto.Existencia);
                cmd.Parameters.AddWithValue("@RepuestoID", repuesto.RepuestoID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int EliminarRepuesto(int repuestoId)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "DELETE FROM Repuestos WHERE RepuestoID = @RepuestoID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@RepuestoID", repuestoId);
                return cmd.ExecuteNonQuery();
            }
        }

        public int RegistrarMovimiento(MovimientoInventarioEN mov)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string queryMov = @"INSERT INTO MovimientosInventario (RepuestoID, TipoMovimiento, Cantidad, Fecha, Motivo) 
                                    VALUES (@RepuestoID, @Tipo, @Cantidad, @Fecha, @Motivo)";
                SqlCommand cmdMov = new SqlCommand(queryMov, conn);
                cmdMov.Parameters.AddWithValue("@RepuestoID", mov.RepuestoID);
                cmdMov.Parameters.AddWithValue("@Tipo", mov.TipoMovimiento);
                cmdMov.Parameters.AddWithValue("@Cantidad", mov.Cantidad);
                cmdMov.Parameters.AddWithValue("@Fecha", mov.Fecha);
                cmdMov.Parameters.AddWithValue("@Motivo", (object)mov.Motivo ?? DBNull.Value);
                cmdMov.ExecuteNonQuery();

                string operacion = mov.TipoMovimiento == "Entrada" ? "+" : "-";
                string queryStock = $"UPDATE Repuestos SET Existencia = Existencia {operacion} @Cantidad WHERE RepuestoID = @RepuestoID";
                SqlCommand cmdStock = new SqlCommand(queryStock, conn);
                cmdStock.Parameters.AddWithValue("@Cantidad", mov.Cantidad);
                cmdStock.Parameters.AddWithValue("@RepuestoID", mov.RepuestoID);

                return cmdStock.ExecuteNonQuery();
            }
        }

        public int EliminarMovimiento(int movimientoId)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "DELETE FROM MovimientosInventario WHERE MovimientoID = @MovimientoID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MovimientoID", movimientoId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}

