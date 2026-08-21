using System;
using System.Data.SqlClient;
using TallerToluca.EN;

namespace TallerToluca.DAL
{
    public class UsuarioDAL
    {
        public int CrearUsuario(UsuarioEN usuario)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"INSERT INTO Usuarios (EmpleadoID, NombreUsuario, ClaveHash, Rol) 
                                 VALUES (@EmpleadoID, @Usuario, @Clave, @Rol)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpleadoID", usuario.EmpleadoID);
                cmd.Parameters.AddWithValue("@Usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Clave", usuario.ClaveHash);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                return cmd.ExecuteNonQuery();
            }
        }

        public UsuarioEN ValidarLogin(string usuario, string clave)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT UsuarioID, EmpleadoID, NombreUsuario, Rol, Estado 
                                 FROM Usuarios 
                                 WHERE NombreUsuario = @User AND ClaveHash = @Pass AND Estado = 'Activo'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@User", usuario);
                cmd.Parameters.AddWithValue("@Pass", clave);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new UsuarioEN
                    {
                        UsuarioID = reader.GetInt32(0),
                        EmpleadoID = reader.GetInt32(1),
                        NombreUsuario = reader.GetString(2),
                        Rol = reader.GetString(3),
                        Estado = reader.GetString(4)
                    };
                }
            }
            return null;
        }
    }
}
