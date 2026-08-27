using System;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class UsuarioBL
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        public int CrearUsuario(UsuarioEN usuario)
        {
            ValidarDatosBasicos(usuario);

            if (string.IsNullOrWhiteSpace(usuario.ClaveHash))
                throw new ArgumentException("La contraseña es obligatoria.");

            if (usuario.ClaveHash.Trim().Length < 4)
                throw new ArgumentException("La contraseña debe tener al menos 4 caracteres.");

            if (_usuarioDAL.ExisteNombreUsuario(usuario.NombreUsuario))
                throw new InvalidOperationException("Ya existe un usuario con ese nombre. Elija otro.");

            if (string.IsNullOrWhiteSpace(usuario.Estado))
                usuario.Estado = "Activo";

            return _usuarioDAL.CrearUsuario(usuario);
        }

        public int ModificarUsuario(UsuarioEN usuario, string nuevaClave)
        {
            if (usuario.UsuarioID <= 0)
                throw new ArgumentException("ID de usuario no válido.");

            ValidarDatosBasicos(usuario);

            if (_usuarioDAL.ExisteNombreUsuario(usuario.NombreUsuario, usuario.UsuarioID))
                throw new InvalidOperationException("Ya existe otro usuario con ese nombre. Elija otro.");

            bool actualizarClave = !string.IsNullOrWhiteSpace(nuevaClave);
            if (actualizarClave)
            {
                if (nuevaClave.Trim().Length < 4)
                    throw new ArgumentException("La contraseña debe tener al menos 4 caracteres.");
                usuario.ClaveHash = nuevaClave.Trim();
            }

            return _usuarioDAL.ModificarUsuario(usuario, actualizarClave);
        }

        public int CambiarEstado(int usuarioID, string nuevoEstado)
        {
            if (usuarioID <= 0)
                throw new ArgumentException("ID de usuario no válido.");

            return _usuarioDAL.CambiarEstado(usuarioID, nuevoEstado);
        }

        public System.Collections.Generic.List<UsuarioEN> ObtenerTodosUsuarios()
        {
            return _usuarioDAL.ConsultarTodos();
        }

        private void ValidarDatosBasicos(UsuarioEN usuario)
        {
            if (usuario.EmpleadoID <= 0)
                throw new ArgumentException("Debe seleccionar un empleado válido.");

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Rol))
                throw new ArgumentException("Debe seleccionar un rol para el usuario.");
        }

        public UsuarioEN IniciarSesion(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("Debe ingresar el usuario y la contraseña.");

            UsuarioEN usuario = _usuarioDAL.ValidarLogin(nombreUsuario, clave);

            if (usuario == null)
                throw new InvalidOperationException("Nombre de usuario o contraseña incorrectos.");

            return usuario;
        }
    }
}