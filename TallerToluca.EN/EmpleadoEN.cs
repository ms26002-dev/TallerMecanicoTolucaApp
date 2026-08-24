namespace TallerToluca.EN
{
    public class EmpleadoEN
    {
        public int EmpleadoID { get; set; }
        public string NombreCompleto { get; set; }
        public string Cargo { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; } = "Activo";
    }
}
