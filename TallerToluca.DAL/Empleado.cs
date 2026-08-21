using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class EmpleadoDAL
    {
        public EmpleadoDAL()
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
                        IF COL_LENGTH('dbo.Empleados', 'Correo') IS NULL
                        BEGIN
                            ALTER TABLE dbo.Empleados ADD Correo NVARCHAR(150) NULL;
                        END";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { }
        }

        public int Registrar(EmpleadoEN empleado)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO Empleados (NombreCompleto, Cargo, Telefono, Correo, Estado) 
                                 VALUES (@Nombre, @Cargo, @Telefono, @Correo, @Estado); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", empleado.NombreCompleto);
                cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                cmd.Parameters.AddWithValue("@Telefono", (object)empleado.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Correo", (object)empleado.Correo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(empleado.Estado) ? "Activo" : empleado.Estado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int Modificar(EmpleadoEN empleado)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE Empleados 
                                 SET NombreCompleto = @Nombre, Cargo = @Cargo, Telefono = @Telefono, 
                                     Correo = @Correo, Estado = @Estado 
                                 WHERE EmpleadoID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", empleado.EmpleadoID);
                cmd.Parameters.AddWithValue("@Nombre", empleado.NombreCompleto);
                cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                cmd.Parameters.AddWithValue("@Telefono", (object)empleado.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Correo", (object)empleado.Correo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(empleado.Estado) ? "Activo" : empleado.Estado);
                return cmd.ExecuteNonQuery();
            }
        }

        public int EliminarLogico(int empleadoID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE Empleados SET Estado = 'Inactivo' WHERE EmpleadoID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", empleadoID);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<EmpleadoEN> ConsultarTodos()
        {
            List<EmpleadoEN> lista = new List<EmpleadoEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT EmpleadoID, NombreCompleto, Cargo, Telefono, Correo, Estado 
                                 FROM Empleados 
                                 ORDER BY EmpleadoID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new EmpleadoEN
                    {
                        EmpleadoID = reader.GetInt32(0),
                        NombreCompleto = reader.GetString(1),
                        Cargo = reader.GetString(2),
                        Telefono = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Correo = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Estado = reader.IsDBNull(5) ? "Activo" : reader.GetString(5)
                    });
                }
            }
            return lista;
        }
    }
}


