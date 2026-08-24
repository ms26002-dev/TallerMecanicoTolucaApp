using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class OrdenTrabajoDAL
    {
        public int CrearOrden(OrdenTrabajoEN orden)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO OrdenesTrabajo 
                                 (ClienteID, VehiculoID, EmpleadoID, KilometrajeEntrada, DescripcionDiagnostico, Observaciones, Estado, UbicacionTaller) 
                                 VALUES (@ClienteID, @VehiculoID, @EmpleadoID, @KM, @Diagnostico, @Observaciones, @Estado, @Ubicacion);
                                 SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClienteID", orden.ClienteID);
                cmd.Parameters.AddWithValue("@VehiculoID", orden.VehiculoID);
                cmd.Parameters.AddWithValue("@EmpleadoID", orden.EmpleadoID);
                cmd.Parameters.AddWithValue("@KM", orden.KilometrajeEntrada);
                cmd.Parameters.AddWithValue("@Diagnostico", orden.DescripcionDiagnostico);
                cmd.Parameters.AddWithValue("@Observaciones", (object?)orden.Observaciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(orden.Estado) ? "Pendiente" : orden.Estado);
                cmd.Parameters.AddWithValue("@Ubicacion", string.IsNullOrWhiteSpace(orden.UbicacionTaller) ? "Taller Mecánico Toluca" : orden.UbicacionTaller);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int ModificarOrden(OrdenTrabajoEN orden)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE OrdenesTrabajo 
                                 SET ClienteID = @ClienteID, VehiculoID = @VehiculoID, EmpleadoID = @EmpleadoID,
                                     KilometrajeEntrada = @KM, DescripcionDiagnostico = @Diagnostico, 
                                     Observaciones = @Observaciones, Estado = @Estado
                                 WHERE OrdenID = @OrdenID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrdenID", orden.OrdenID);
                cmd.Parameters.AddWithValue("@ClienteID", orden.ClienteID);
                cmd.Parameters.AddWithValue("@VehiculoID", orden.VehiculoID);
                cmd.Parameters.AddWithValue("@EmpleadoID", orden.EmpleadoID);
                cmd.Parameters.AddWithValue("@KM", orden.KilometrajeEntrada);
                cmd.Parameters.AddWithValue("@Diagnostico", orden.DescripcionDiagnostico);
                cmd.Parameters.AddWithValue("@Observaciones", (object?)orden.Observaciones ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(orden.Estado) ? "Pendiente" : orden.Estado);
                return cmd.ExecuteNonQuery();
            }
        }

        public bool MecanicoTieneOrdenActiva(int empleadoID, int ordenIDExcluir = 0)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT COUNT(*) FROM OrdenesTrabajo 
                                 WHERE EmpleadoID = @EID 
                                   AND Estado IN ('Pendiente', 'En Proceso')
                                   AND OrdenID != @OrdenIDExcluir";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EID", empleadoID);
                cmd.Parameters.AddWithValue("@OrdenIDExcluir", ordenIDExcluir);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public string ObtenerEstadoOrden(int ordenID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT Estado FROM OrdenesTrabajo WHERE OrdenID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", ordenID);
                object? result = cmd.ExecuteScalar();
                return result != null ? result.ToString() ?? string.Empty : string.Empty;
            }
        }

        public int ActualizarEstado(int ordenID, string nuevoEstado)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "UPDATE OrdenesTrabajo SET Estado = @Estado WHERE OrdenID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                cmd.Parameters.AddWithValue("@ID", ordenID);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<OrdenTrabajoEN> ConsultarTodas()
        {
            List<OrdenTrabajoEN> lista = new List<OrdenTrabajoEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT o.OrdenID, o.FechaCreacion, o.ClienteID, o.VehiculoID, o.EmpleadoID, 
                                        o.Estado, o.KilometrajeEntrada, o.UbicacionTaller, 
                                        o.DescripcionDiagnostico, o.Observaciones,
                                        c.NombreCompleto AS NombreCliente,
                                        c.Telefono AS TelefonoCliente,
                                        v.Placa AS PlacaVehiculo,
                                        CONCAT(v.Marca, ' ', v.Modelo, ' (', v.Anio, ')') AS DetalleVehiculo,
                                        e.NombreCompleto AS NombreMecanico
                                 FROM OrdenesTrabajo o
                                 INNER JOIN Clientes c ON o.ClienteID = c.ClienteID
                                 INNER JOIN Vehiculos v ON o.VehiculoID = v.VehiculoID
                                 INNER JOIN Empleados e ON o.EmpleadoID = e.EmpleadoID
                                 ORDER BY o.OrdenID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new OrdenTrabajoEN
                        {
                            OrdenID = reader.GetInt32(0),
                            FechaCreacion = reader.GetDateTime(1),
                            ClienteID = reader.GetInt32(2),
                            VehiculoID = reader.GetInt32(3),
                            EmpleadoID = reader.GetInt32(4),
                            Estado = reader.GetString(5),
                            KilometrajeEntrada = reader.GetInt32(6),
                            UbicacionTaller = reader.GetString(7),
                            DescripcionDiagnostico = reader.GetString(8),
                            Observaciones = reader.IsDBNull(9) ? null : reader.GetString(9),
                            NombreCliente = reader.IsDBNull(10) ? null : reader.GetString(10),
                            TelefonoCliente = reader.IsDBNull(11) ? null : reader.GetString(11),
                            PlacaVehiculo = reader.IsDBNull(12) ? null : reader.GetString(12),
                            DetalleVehiculo = reader.IsDBNull(13) ? null : reader.GetString(13),
                            NombreMecanico = reader.IsDBNull(14) ? null : reader.GetString(14)
                        });
                    }
                }
            }
            return lista;
        }

        public OrdenTrabajoEN? ConsultarPorID(int ordenID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT o.OrdenID, o.FechaCreacion, o.ClienteID, o.VehiculoID, o.EmpleadoID, 
                                        o.Estado, o.KilometrajeEntrada, o.UbicacionTaller, 
                                        o.DescripcionDiagnostico, o.Observaciones,
                                        c.NombreCompleto AS NombreCliente,
                                        c.Telefono AS TelefonoCliente,
                                        v.Placa AS PlacaVehiculo,
                                        CONCAT(v.Marca, ' ', v.Modelo, ' (', v.Anio, ')') AS DetalleVehiculo,
                                        e.NombreCompleto AS NombreMecanico
                                 FROM OrdenesTrabajo o
                                 INNER JOIN Clientes c ON o.ClienteID = c.ClienteID
                                 INNER JOIN Vehiculos v ON o.VehiculoID = v.VehiculoID
                                 INNER JOIN Empleados e ON o.EmpleadoID = e.EmpleadoID
                                 WHERE o.OrdenID = @OrdenID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrdenID", ordenID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new OrdenTrabajoEN
                        {
                            OrdenID = reader.GetInt32(0),
                            FechaCreacion = reader.GetDateTime(1),
                            ClienteID = reader.GetInt32(2),
                            VehiculoID = reader.GetInt32(3),
                            EmpleadoID = reader.GetInt32(4),
                            Estado = reader.GetString(5),
                            KilometrajeEntrada = reader.GetInt32(6),
                            UbicacionTaller = reader.GetString(7),
                            DescripcionDiagnostico = reader.GetString(8),
                            Observaciones = reader.IsDBNull(9) ? null : reader.GetString(9),
                            NombreCliente = reader.IsDBNull(10) ? null : reader.GetString(10),
                            TelefonoCliente = reader.IsDBNull(11) ? null : reader.GetString(11),
                            PlacaVehiculo = reader.IsDBNull(12) ? null : reader.GetString(12),
                            DetalleVehiculo = reader.IsDBNull(13) ? null : reader.GetString(13),
                            NombreMecanico = reader.IsDBNull(14) ? null : reader.GetString(14)
                        };
                    }
                }
            }
            return null;
        }
    }
}
