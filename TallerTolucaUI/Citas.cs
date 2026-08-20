using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class Citas : Form
    {
        private readonly CitaBL _citaBL = new CitaBL();
        private List<CitaEN> _todasLasCitas = new List<CitaEN>();
        private List<CitaEN> _citasFiltradas = new List<CitaEN>();

        public Citas()
        {
            InitializeComponent();
            _citaBL.ProcesarCitasVencidas();
            CargarCitas();
        }

        private void CargarCitas()
        {
            try
            {
                _todasLasCitas = _citaBL.ObtenerTodasLasCitas();
            }
            catch (Exception)
            {
                _todasLasCitas = new List<CitaEN>();
            }
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim();
            string estadoFiltro = cboEstadoFiltro.SelectedItem?.ToString() ?? "Todos los estados";

            IEnumerable<CitaEN> consulta = _todasLasCitas;

            if (estadoFiltro != "Todos los estados")
            {
                consulta = consulta.Where(c => c.Estado.Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(c =>
                    c.CitaID.ToString().Contains(texto) ||
                    c.ClienteID.ToString().Contains(texto) ||
                    c.VehiculoID.ToString().Contains(texto) ||
                    (c.Motivo ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase));
            }

            _citasFiltradas = consulta.ToList();
            MostrarTabla();
        }

        private void MostrarTabla()
        {
            dgvCitas.Rows.Clear();
            foreach (var c in _citasFiltradas)
            {
                int fila = dgvCitas.Rows.Add(
                    $"CIT-{c.CitaID:000}",
                    $"CLI-{c.ClienteID:000}",
                    $"VEH-{c.VehiculoID:000}",
                    c.FechaHora.ToString("dd/MM/yyyy HH:mm"),
                    c.Motivo,
                    c.Estado,
                    "Atendida",
                    "Cancelar");
                dgvCitas.Rows[fila].Tag = c.CitaID;
            }

            lblResumenRegistros.Text = _citasFiltradas.Count == 0
                ? "No se encontraron citas agendadas"
                : $"Total de citas: {_citasFiltradas.Count}";
        }

        private void dgvCitas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCitas.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();
                if (estado == "Atendida")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                }
                else if (estado == "Programada" || estado == "Reprogramada")
                {
                    e.CellStyle.BackColor = Color.FromArgb(224, 245, 255);
                    e.CellStyle.ForeColor = Color.FromArgb(2, 132, 199);
                }
                else if (estado == "Cancelada")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 226, 226);
                    e.CellStyle.ForeColor = Color.FromArgb(185, 28, 28);
                }
                else // No Recibida
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    e.CellStyle.ForeColor = Color.FromArgb(146, 64, 14);
                }
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void dgvCitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columna = dgvCitas.Columns[e.ColumnIndex].Name;
            int citaId = (int)dgvCitas.Rows[e.RowIndex].Tag;
            var cita = _todasLasCitas.FirstOrDefault(c => c.CitaID == citaId);
            if (cita == null) return;

            if (columna == "Atender")
            {
                try
                {
                    _citaBL.ActualizarEstadoCita(citaId, "Atendida");
                    MessageBox.Show("Cita marcada como ATENDIDA.", "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarCitas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (columna == "Cancelar")
            {
                var r = MessageBox.Show($"¿Desea cancelar la cita CIT-{citaId:000}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        _citaBL.ActualizarEstadoCita(citaId, "Cancelada");
                        MessageBox.Show("Cita CANCELADA correctamente.", "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCitas();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnNuevaCita_Click(object? sender, EventArgs e)
        {
            txtClienteID.Clear();
            txtVehiculoID.Clear();
            dtpFechaHora.Value = DateTime.Now.AddHours(2);
            txtMotivo.Clear();
            pnlModalAgendar.Visible = true;
            pnlModalAgendar.BringToFront();
            txtClienteID.Focus();
        }

        private void btnGuardarAgendar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtClienteID.Text.Trim(), out int clienteId) || clienteId <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un ID de cliente válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClienteID.Focus();
                    return;
                }

                if (!int.TryParse(txtVehiculoID.Text.Trim(), out int vehiculoId) || vehiculoId <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un ID de vehículo válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVehiculoID.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMotivo.Text))
                {
                    MessageBox.Show("El motivo o servicio de la cita es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMotivo.Focus();
                    return;
                }

                CitaEN cita = new CitaEN
                {
                    ClienteID = clienteId,
                    VehiculoID = vehiculoId,
                    FechaHora = dtpFechaHora.Value,
                    Motivo = txtMotivo.Text.Trim()
                };

                _citaBL.ProgramarCita(cita);
                MessageBox.Show("Cita agendada exitosamente.", "Agenda Taller", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pnlModalAgendar.Visible = false;
                CargarCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restricción de Citas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
