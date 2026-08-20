using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmOrdenesTrabajo : Form
    {
        private readonly OrdenTrabajoBL _ordenBL = new OrdenTrabajoBL();
        private List<OrdenTrabajoEN> _todasLasOrdenes = new List<OrdenTrabajoEN>();
        private List<OrdenTrabajoEN> _ordenesFiltradas = new List<OrdenTrabajoEN>();

        public FrmOrdenesTrabajo()
        {
            InitializeComponent();
            CargarOrdenes();
        }

        private void CargarOrdenes()
        {
            try
            {
                _todasLasOrdenes = _ordenBL.ObtenerTodasLasOrdenes();
            }
            catch (Exception)
            {
                _todasLasOrdenes = new List<OrdenTrabajoEN>();
            }
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim();
            string estadoFiltro = cboEstadoFiltro.SelectedItem?.ToString() ?? "Todos los estados";

            IEnumerable<OrdenTrabajoEN> consulta = _todasLasOrdenes;

            if (estadoFiltro != "Todos los estados")
            {
                consulta = consulta.Where(o => o.Estado.Equals(estadoFiltro, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(o =>
                    o.OrdenID.ToString().Contains(texto) ||
                    o.ClienteID.ToString().Contains(texto) ||
                    o.EmpleadoID.ToString().Contains(texto) ||
                    (o.DescripcionDiagnostico ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase));
            }

            _ordenesFiltradas = consulta.ToList();
            MostrarTabla();
        }

        private void MostrarTabla()
        {
            dgvOrdenes.Rows.Clear();
            foreach (var o in _ordenesFiltradas)
            {
                int fila = dgvOrdenes.Rows.Add(
                    $"ORD-{o.OrdenID:000}",
                    o.FechaCreacion.ToString("dd/MM/yyyy"),
                    $"CLI-{o.ClienteID:000}",
                    $"VEH-{o.VehiculoID:000}",
                    $"EMP-{o.EmpleadoID:000}",
                    $"{o.KilometrajeEntrada:N0} km",
                    o.DescripcionDiagnostico,
                    o.Estado,
                    o.Estado == "Finalizada" ? "Concluida" : "Finalizar");
                dgvOrdenes.Rows[fila].Tag = o.OrdenID;
            }

            lblResumenRegistros.Text = _ordenesFiltradas.Count == 0
                ? "No se encontraron órdenes de trabajo"
                : $"Total de órdenes: {_ordenesFiltradas.Count}";
        }

        private void dgvOrdenes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrdenes.Columns[e.ColumnIndex].Name == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString();
                if (estado == "Finalizada")
                {
                    e.CellStyle.BackColor = Color.FromArgb(220, 252, 231);
                    e.CellStyle.ForeColor = Color.FromArgb(21, 128, 61);
                }
                else if (estado == "En Proceso")
                {
                    e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                    e.CellStyle.ForeColor = Color.FromArgb(146, 64, 14);
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(238, 242, 255);
                    e.CellStyle.ForeColor = Color.FromArgb(67, 56, 202);
                }
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void dgvOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columna = dgvOrdenes.Columns[e.ColumnIndex].Name;
            if (columna != "Finalizar") return;

            int ordenId = (int)dgvOrdenes.Rows[e.RowIndex].Tag;
            var orden = _todasLasOrdenes.FirstOrDefault(o => o.OrdenID == ordenId);
            if (orden == null) return;

            if (orden.Estado == "Finalizada")
            {
                MessageBox.Show("Esta orden de trabajo ya ha sido finalizada y no puede modificarse.",
                    "Orden Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var r = MessageBox.Show($"¿Desea dar por finalizada la orden ORD-{ordenId:000}?",
                "Finalizar Servicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                try
                {
                    _ordenBL.CambiarEstadoOrden(ordenId, "Finalizada");
                    MessageBox.Show("Orden finalizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarOrdenes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al Finalizar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNuevaOrden_Click(object? sender, EventArgs e)
        {
            txtClienteID.Clear();
            txtVehiculoID.Clear();
            txtEmpleadoID.Clear();
            txtKM.Clear();
            txtDiagnostico.Clear();
            txtObservaciones.Clear();
            pnlModalCrear.Visible = true;
            pnlModalCrear.BringToFront();
            txtClienteID.Focus();
        }

        private void btnGuardarCrear_Click(object? sender, EventArgs e)
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

                if (!int.TryParse(txtEmpleadoID.Text.Trim(), out int empleadoId) || empleadoId <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un ID de mecánico válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmpleadoID.Focus();
                    return;
                }

                if (!int.TryParse(txtKM.Text.Trim(), out int km) || km < 0)
                {
                    MessageBox.Show("Ingrese un kilometraje válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtKM.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtDiagnostico.Text))
                {
                    MessageBox.Show("El diagnóstico inicial es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiagnostico.Focus();
                    return;
                }

                OrdenTrabajoEN orden = new OrdenTrabajoEN
                {
                    ClienteID = clienteId,
                    VehiculoID = vehiculoId,
                    EmpleadoID = empleadoId,
                    KilometrajeEntrada = km,
                    DescripcionDiagnostico = txtDiagnostico.Text.Trim(),
                    Observaciones = txtObservaciones.Text.Trim(),
                    UbicacionTaller = "Taller Mecánico Toluca"
                };

                _ordenBL.CrearOrden(orden);
                MessageBox.Show("Orden de trabajo creada y asignada exitosamente.", "Taller Mecánico Toluca", MessageBoxButtons.OK, MessageBoxIcon.Information);

                pnlModalCrear.Visible = false;
                CargarOrdenes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restricción de Órdenes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
