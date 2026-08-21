using System;
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
                string query = @"INSERT INTO Empleados (NombreCompleto, Cargo, Telefono) 
                                 VALUES (@Nombre, @Cargo, @Telefono); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", empleado.NombreCompleto);
                cmd.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                cmd.Parameters.AddWithValue("@Telefono", (object)empleado.Telefono ?? DBNull.Value);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
