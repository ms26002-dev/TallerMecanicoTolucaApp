using System;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class ClienteDAL
    {
        public int Registrar(ClienteEN cliente)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "INSERT INTO Clientes (NombreCompleto, Telefono, Correo, Direccion) VALUES (@Nombre, @Telefono, @Correo, @Direccion)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", cliente.NombreCompleto);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Correo", (object)cliente.Correo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", (object)cliente.Direccion ?? DBNull.Value);
                return cmd.ExecuteNonQuery();
            }
        }

        public int Modificar(ClienteEN cliente)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "UPDATE Clientes SET NombreCompleto = @Nombre, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion WHERE ClienteID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", cliente.ClienteID);
                cmd.Parameters.AddWithValue("@Nombre", cliente.NombreCompleto);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Correo", (object)cliente.Correo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", (object)cliente.Direccion ?? DBNull.Value);
                return cmd.ExecuteNonQuery();
            }
        }

        public int EliminarLogico(int clienteID)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "UPDATE Clientes SET Estado = 'Inactivo' WHERE ClienteID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", clienteID);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<ClienteEN> ConsultarActivos()
        {
            List<ClienteEN> lista = new List<ClienteEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = "SELECT ClienteID, NombreCompleto, Telefono, Correo, Direccion, Estado FROM Clientes WHERE Estado = 'Activo'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new ClienteEN
                    {
                        ClienteID = reader.GetInt32(0),
                        NombreCompleto = reader.GetString(1),
                        Telefono = reader.GetString(2),
                        Correo = reader.IsDBNull(3) ? null : reader.GetString(3),
                        Direccion = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Estado = reader.GetString(5)
                    });
                }
            }
            return lista;
        }
    }
}
