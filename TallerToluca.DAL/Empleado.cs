using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class EmpleadoDAL
    {
        public int Registrar(EmpleadoEN empleado)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO Empleados (NombreCompleto, Cargo, Telefono, Estado) 
                                 VALUES (@Nombre, @Cargo, @Telefono, @Estado); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", empleado.NombreCompleto);
                cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                cmd.Parameters.AddWithValue("@Telefono", (object)empleado.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(empleado.Estado) ? "Activo" : empleado.Estado);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int Modificar(EmpleadoEN empleado)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE Empleados 
                                 SET NombreCompleto = @Nombre, Cargo = @Cargo, Telefono = @Telefono, Estado = @Estado 
                                 WHERE EmpleadoID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", empleado.EmpleadoID);
                cmd.Parameters.AddWithValue("@Nombre", empleado.NombreCompleto);
                cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                cmd.Parameters.AddWithValue("@Telefono", (object)empleado.Telefono ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Estado", string.IsNullOrWhiteSpace(empleado.Estado) ? "Activo" : empleado.Estado);
                return cmd.ExecuteNonQuery();
            }
        }

        public int EliminarLogico(int empleadoID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "UPDATE Empleados SET Estado = 'Inactivo' WHERE EmpleadoID = @ID";
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
                string query = "SELECT EmpleadoID, NombreCompleto, Cargo, Telefono, Estado FROM Empleados ORDER BY EmpleadoID";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new EmpleadoEN
                    {
                        EmpleadoID = reader.GetInt32(0),
                        NombreCompleto = reader.GetString(1),
                        Cargo = reader.GetString(2),
                        Telefono = reader.IsDBNull(3) ? "" : reader.GetString(3),
                        Estado = reader.IsDBNull(4) ? "Activo" : reader.GetString(4)
                    });
                }
            }
            return lista;
        }
    }
}
