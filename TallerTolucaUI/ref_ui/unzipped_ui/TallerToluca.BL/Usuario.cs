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
            if (usuario.EmpleadoID <= 0)
                throw new ArgumentException("Debe seleccionar un empleado válido.");

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.ClaveHash))
                throw new ArgumentException("La contraseña es obligatoria.");

            return _usuarioDAL.CrearUsuario(usuario);
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