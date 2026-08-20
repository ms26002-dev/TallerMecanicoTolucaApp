using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmVehiculos : Form
    {
        private readonly VehiculoBL _vehiculoBL = new VehiculoBL();
        private List<VehiculoEN> _todosLosVehiculos = new List<VehiculoEN>();
        private List<VehiculoEN> _vehiculosFiltrados = new List<VehiculoEN>();

        public FrmVehiculos()
        {
            InitializeComponent();
            CargarVehiculos();
        }

        private void CargarVehiculos()
        {
            try
            {
                _todosLosVehiculos = _vehiculoBL.ObtenerTodosLosVehiculos();
            }
            catch (Exception)
            {
                _todosLosVehiculos = new List<VehiculoEN>();
            }
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim();
            IEnumerable<VehiculoEN> consulta = _todosLosVehiculos;

            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(v =>
                    (v.Placa ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (v.Marca ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (v.Modelo ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    v.ClienteID.ToString().Contains(texto));
            }

            _vehiculosFiltrados = consulta.ToList();
            MostrarTabla();
        }

        private void MostrarTabla()
        {
            dgvVehiculos.Rows.Clear();
            foreach (var v in _vehiculosFiltrados)
            {
                int fila = dgvVehiculos.Rows.Add(
                    $"VEH-{v.VehiculoID:000}",
                    $"CLI-{v.ClienteID:000}",
                    v.Placa,
                    v.Marca,
                    v.Modelo,
                    v.Anio,
                    v.Color,
                    v.TipoVehiculo,
                    "Eliminar");
                dgvVehiculos.Rows[fila].Tag = v.VehiculoID;
            }

            lblResumenRegistros.Text = _vehiculosFiltrados.Count == 0
                ? "No se encontraron vehículos registrados"
                : $"Total de vehículos registrados: {_vehiculosFiltrados.Count}";
        }

        private void dgvVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columna = dgvVehiculos.Columns[e.ColumnIndex].Name;
            if (columna != "Eliminar") return;

            int vehiculoId = (int)dgvVehiculos.Rows[e.RowIndex].Tag;
            var vehiculo = _todosLosVehiculos.FirstOrDefault(v => v.VehiculoID == vehiculoId);
            if (vehiculo == null) return;

            var r = MessageBox.Show($"¿Desea eliminar el vehículo con placa \"{vehiculo.Placa}\"?",
                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                try
                {
                    _vehiculoBL.EliminarVehiculo(vehiculoId);
                    MessageBox.Show("Vehículo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarVehiculos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevoVehiculo_Click(object? sender, EventArgs e)
        {
            txtFormClienteID.Clear();
            txtFormPlaca.Clear();
            txtFormMarca.Clear();
            txtFormModelo.Clear();
            txtFormAnio.Text = DateTime.Now.Year.ToString();
            txtFormColor.Clear();
            cboFormTipo.SelectedIndex = 0;
            pnlFormularioRegistro.Visible = true;
            pnlFormularioRegistro.BringToFront();
            txtFormClienteID.Focus();
        }

        private void btnFormGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtFormClienteID.Text.Trim(), out int clienteId) || clienteId <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un ID de cliente válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFormClienteID.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFormPlaca.Text))
                {
                    MessageBox.Show("El número de placa es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFormPlaca.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFormMarca.Text))
                {
                    MessageBox.Show("La marca del automóvil es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFormMarca.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFormModelo.Text))
                {
                    MessageBox.Show("El modelo del automóvil es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFormModelo.Focus();
                    return;
                }

                if (!int.TryParse(txtFormAnio.Text.Trim(), out int anio) || anio < 1900 || anio > DateTime.Now.Year + 1)
                {
                    MessageBox.Show("Ingrese un año de fabricación válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFormAnio.Focus();
                    return;
                }

                VehiculoEN vehiculo = new VehiculoEN
                {
                    ClienteID = clienteId,
                    Placa = txtFormPlaca.Text.Trim().ToUpper(),
                    Marca = txtFormMarca.Text.Trim(),
                    Modelo = txtFormModelo.Text.Trim(),
                    Anio = anio,
                    Color = txtFormColor.Text.Trim(),
                    TipoVehiculo = cboFormTipo.SelectedItem?.ToString() ?? "Liviano"
                };

                _vehiculoBL.RegistrarVehiculo(vehiculo);
                MessageBox.Show("Vehículo registrado exitosamente.", "Taller Mecánico Toluca", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pnlFormularioRegistro.Visible = false;
                CargarVehiculos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restricción de Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
