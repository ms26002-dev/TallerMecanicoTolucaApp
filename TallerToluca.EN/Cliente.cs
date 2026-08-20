namespace TallerToluca.EN
{
    public class ClienteEN
    {
        public int ClienteID { get; set; }
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Estado { get; set; } = "Activo";
        public int VehiculosAsociados { get; set; }
    }
}
