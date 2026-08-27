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

        public bool ExisteNombreUsuario(string nombreUsuario, int usuarioIDExcluir = 0)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT COUNT(1) FROM Usuarios 
                                 WHERE NombreUsuario = @Usuario AND UsuarioID <> @ExcluirID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@ExcluirID", usuarioIDExcluir);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public System.Collections.Generic.List<UsuarioEN> ConsultarTodos()
        {
            var lista = new System.Collections.Generic.List<UsuarioEN>();
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"SELECT u.UsuarioID, u.EmpleadoID, u.NombreUsuario, u.Rol, u.Estado, e.NombreCompleto
                                 FROM Usuarios u
                                 INNER JOIN Empleados e ON u.EmpleadoID = e.EmpleadoID
                                 ORDER BY u.UsuarioID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new UsuarioEN
                    {
                        UsuarioID = reader.GetInt32(0),
                        EmpleadoID = reader.GetInt32(1),
                        NombreUsuario = reader.GetString(2),
                        Rol = reader.GetString(3),
                        Estado = reader.GetString(4),
                        NombreEmpleado = reader.GetString(5)
                    });
                }
            }
            return lista;
        }

        public int ModificarUsuario(UsuarioEN usuario, bool actualizarClave)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = actualizarClave
                    ? @"UPDATE Usuarios SET EmpleadoID = @EmpleadoID, NombreUsuario = @Usuario, 
                        ClaveHash = @Clave, Rol = @Rol, Estado = @Estado WHERE UsuarioID = @ID"
                    : @"UPDATE Usuarios SET EmpleadoID = @EmpleadoID, NombreUsuario = @Usuario, 
                        Rol = @Rol, Estado = @Estado WHERE UsuarioID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", usuario.UsuarioID);
                cmd.Parameters.AddWithValue("@EmpleadoID", usuario.EmpleadoID);
                cmd.Parameters.AddWithValue("@Usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Rol", usuario.Rol);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                if (actualizarClave)
                    cmd.Parameters.AddWithValue("@Clave", usuario.ClaveHash);
                return cmd.ExecuteNonQuery();
            }
        }

        public int CambiarEstado(int usuarioID, string nuevoEstado)
        {
            using (SqlConnection conn = ConexionDAL.ObtenerConexion())
            {
                string query = @"UPDATE Usuarios SET Estado = @Estado WHERE UsuarioID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", usuarioID);
                cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
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
