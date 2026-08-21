namespace TallerToluca.EN
{
    public class UsuarioEN
    {
        public int UsuarioID { get; set; }
        public int EmpleadoID { get; set; }
        public string NombreUsuario { get; set; }
        public string ClaveHash { get; set; }
        public string Rol { get; set; } // Administrador, Recepcionista, Mecánico
        public string Estado { get; set; } = "Activo";
    }
}
