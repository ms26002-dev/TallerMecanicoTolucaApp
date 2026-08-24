namespace TallerToluca.EN
{
    public class VehiculoEN
    {
        public int VehiculoID { get; set; }
        public int ClienteID { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string? Color { get; set; }
        public string TipoVehiculo { get; set; } = "Liviano"; // Solo livianos
        public string Estado { get; set; } = "Activo";

        // Propiedades de navegación / visualización para DataGridView y reportes
        public string? NombrePropietario { get; set; }
        public string? TelefonoPropietario { get; set; }

        public string DescripcionCompleta => $"{Marca} {Modelo} ({Anio}) - Placa: {Placa}";
    }
}