using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class VehiculoDAL
    {
        public VehiculoDAL()
        {
            AsegurarEsquema();
        }

        private void AsegurarEsquema()
        {
            try
            {
                using (SqlConnection conn = ConexionDAL.ObtenerConexion())
                {
                    string sql = @"
                        IF COL_LENGTH('dbo.Vehiculos', 'Estado') IS NULL
                        BEGIN
                            ALTER TABLE dbo.Vehiculos ADD Estado NVARCHAR(20) NOT NULL DEFAULT 'Activo';
                        END";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        public int Registrar(VehiculoEN vehiculo)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO Vehiculos (ClienteID, Placa, Marca, Modelo, Anio, Color, TipoVehiculo, Estado) 
                                 VALUES (@ClienteID, @Placa, @Marca, @Modelo, @Anio, @Color, @TipoVehiculo, @Estado);
                                 SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClienteID", vehiculo.ClienteID);
                cmd.Parameters.AddWithValue("@Placa", vehiculo.Placa);
                cmd.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                cmd.Parameters.AddWithValue("@Anio", vehiculo.Anio);
                cmd.Parameters.AddWithValue("@Color", (object?)vehiculo.Color ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoVehiculo", string.IsNullOrWhiteSpace(vehiculo.TipoVehiculo) ? "Liviano" : vehiculo.TipoVehiculo);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(vehiculo.Estado) ? "Activo" : vehiculo.Estado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int Modificar(VehiculoEN vehiculo)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE Vehiculos 
                                 SET ClienteID = @ClienteID, Placa = @Placa, Marca = @Marca, 
                                     Modelo = @Modelo, Anio = @Anio, Color = @Color, 
                                     TipoVehiculo = @TipoVehiculo, Estado = @Estado 
                                 WHERE VehiculoID = @VehiculoID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@VehiculoID", vehiculo.VehiculoID);
                cmd.Parameters.AddWithValue("@ClienteID", vehiculo.ClienteID);
                cmd.Parameters.AddWithValue("@Placa", vehiculo.Placa);
                cmd.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                cmd.Parameters.AddWithValue("@Anio", vehiculo.Anio);
                cmd.Parameters.AddWithValue("@Color", (object?)vehiculo.Color ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TipoVehiculo", string.IsNullOrWhiteSpace(vehiculo.TipoVehiculo) ? "Liviano" : vehiculo.TipoVehiculo);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(vehiculo.Estado) ? "Activo" : vehiculo.Estado);
                return cmd.ExecuteNonQuery();
            }
        }

        public int EliminarLogico(int vehiculoID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE Vehiculos SET Estado = 'Inactivo' WHERE VehiculoID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", vehiculoID);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<VehiculoEN> ConsultarTodos()
        {
            List<VehiculoEN> lista = new List<VehiculoEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT v.VehiculoID, v.ClienteID, v.Placa, v.Marca, v.Modelo, v.Anio, 
                                        v.Color, v.TipoVehiculo, 
                                        ISNULL(v.Estado, 'Activo') AS Estado,
                                        c.NombreCompleto AS NombrePropietario,
                                        c.Telefono AS TelefonoPropietario
                                 FROM Vehiculos v
                                 INNER JOIN Clientes c ON v.ClienteID = c.ClienteID
                                 ORDER BY v.VehiculoID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
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
                            Color = reader.IsDBNull(6) ? null : reader.GetString(6),
                            TipoVehiculo = reader.GetString(7),
                            Estado = reader.GetString(8),
                            NombrePropietario = reader.IsDBNull(9) ? null : reader.GetString(9),
                            TelefonoPropietario = reader.IsDBNull(10) ? null : reader.GetString(10)
                        });
                    }
                }
            }
            return lista;
        }

        public List<VehiculoEN> ConsultarActivos()
        {
            List<VehiculoEN> lista = new List<VehiculoEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT v.VehiculoID, v.ClienteID, v.Placa, v.Marca, v.Modelo, v.Anio, 
                                        v.Color, v.TipoVehiculo, 
                                        ISNULL(v.Estado, 'Activo') AS Estado,
                                        c.NombreCompleto AS NombrePropietario,
                                        c.Telefono AS TelefonoPropietario
                                 FROM Vehiculos v
                                 INNER JOIN Clientes c ON v.ClienteID = c.ClienteID
                                 WHERE ISNULL(v.Estado, 'Activo') = 'Activo'
                                 ORDER BY v.VehiculoID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
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
                            Color = reader.IsDBNull(6) ? null : reader.GetString(6),
                            TipoVehiculo = reader.GetString(7),
                            Estado = reader.GetString(8),
                            NombrePropietario = reader.IsDBNull(9) ? null : reader.GetString(9),
                            TelefonoPropietario = reader.IsDBNull(10) ? null : reader.GetString(10)
                        });
                    }
                }
            }
            return lista;
        }

        public List<VehiculoEN> ConsultarPorCliente(int clienteID)
        {
            List<VehiculoEN> lista = new List<VehiculoEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT v.VehiculoID, v.ClienteID, v.Placa, v.Marca, v.Modelo, v.Anio, 
                                        v.Color, v.TipoVehiculo, 
                                        ISNULL(v.Estado, 'Activo') AS Estado,
                                        c.NombreCompleto AS NombrePropietario,
                                        c.Telefono AS TelefonoPropietario
                                 FROM Vehiculos v
                                 INNER JOIN Clientes c ON v.ClienteID = c.ClienteID
                                 WHERE v.ClienteID = @ClienteID AND ISNULL(v.Estado, 'Activo') = 'Activo'
                                 ORDER BY v.VehiculoID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
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
                            Color = reader.IsDBNull(6) ? null : reader.GetString(6),
                            TipoVehiculo = reader.GetString(7),
                            Estado = reader.GetString(8),
                            NombrePropietario = reader.IsDBNull(9) ? null : reader.GetString(9),
                            TelefonoPropietario = reader.IsDBNull(10) ? null : reader.GetString(10)
                        });
                    }
                }
            }
            return lista;
        }

        public bool ExistePlaca(string placa, int vehiculoIDExcluir = 0)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT COUNT(1) FROM Vehiculos 
                                 WHERE LOWER(LTRIM(RTRIM(Placa))) = LOWER(LTRIM(RTRIM(@Placa))) 
                                   AND VehiculoID != @VehiculoIDExcluir";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Placa", placa);
                cmd.Parameters.AddWithValue("@VehiculoIDExcluir", vehiculoIDExcluir);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}