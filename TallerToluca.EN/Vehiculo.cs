namespace TallerToluca.EN
{
    public class VehiculoEN
    {
        public int VehiculoID { get; set; }
        public int ClienteID { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public string TipoVehiculo { get; set; } = "Liviano"; // Solo livianos
    }
}