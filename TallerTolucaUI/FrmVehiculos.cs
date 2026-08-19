using System;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmVehiculos : Form
    {
        private readonly VehiculoBL _vehiculoBL = new VehiculoBL();

        public FrmVehiculos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VehiculoEN vehiculo = new VehiculoEN
                {
                    ClienteID = Convert.ToInt32(txtClienteID.Text),
                    Placa = txtPlaca.Text.Trim(),
                    Marca = txtMarca.Text.Trim(),
                    Modelo = txtModelo.Text.Trim(),
                    Anio = Convert.ToInt32(txtAnio.Text),
                    TipoVehiculo = cboTipoVehiculo.SelectedItem?.ToString() ?? "Liviano"
                };

                _vehiculoBL.RegistrarVehiculo(vehiculo);
                MessageBox.Show("Vehículo registrado correctamente.", "Taller Mecánico Toluca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Muestra la alerta si se intenta registrar vehículos pesados o motocicletas
                MessageBox.Show(ex.Message, "Restricción de Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
