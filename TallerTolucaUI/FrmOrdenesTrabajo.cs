using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmOrdenesTrabajo : Form
    {
        private readonly OrdenTrabajoBL _ordenBL = new OrdenTrabajoBL();
        private readonly ClienteBL _clienteBL = new ClienteBL();
        private readonly VehiculoBL _vehiculoBL = new VehiculoBL();
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();

        private List<OrdenTrabajoEN> _listaOrdenes = new List<OrdenTrabajoEN>();
        private List<ClienteEN> _listaClientes = new List<ClienteEN>();
        private List<VehiculoEN> _listaVehiculos = new List<VehiculoEN>();
        private List<EmpleadoEN> _listaEmpleados = new List<EmpleadoEN>();

        private int _ordenSeleccionadaID = 0;

        // Clases auxiliares para combos
        private class ComboItem<T>
        {
            public T Value { get; set; }
            public string Text { get; set; } = string.Empty;

            public ComboItem(T value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString() => Text;
        }

        public FrmOrdenesTrabajo()
        {
            InitializeComponent();
        }

        private void FrmOrdenesTrabajo_Load(object sender, EventArgs e)
        {
            CargarLogotipo();
            EstilizarGrid();
            CargarCombosMaestros();
            cboEstado.SelectedItem = "Pendiente";
            cboFiltroEstado.SelectedIndex = 0;
            CargarOrdenes();
            ActualizarEstadoBotones(false, string.Empty);
        }

        private void CargarLogotipo()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string[] possiblePaths = new string[]
                {
                    Path.Combine(basePath, "Assets", "logo.png"),
                    Path.Combine(basePath, "image1.png"),
                    Path.Combine(basePath, "..", "..", "..", "doc_extracted", "image1.png")
                };

                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        using (var img = Image.FromFile(path))
                        {
                            picLogoHeader.Image = new Bitmap(img);
                        }
                        return;
                    }
                }

                Bitmap bmp = new Bitmap(46, 44);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Brush b = new SolidBrush(Color.FromArgb(224, 242, 254)))
                    {
                        g.FillEllipse(b, 2, 2, 40, 40);
                    }
                    using (Pen p = new Pen(Color.FromArgb(2, 132, 199), 2))
                    {
                        g.DrawEllipse(p, 2, 2, 40, 40);
                        g.DrawString("📋", new Font("Segoe UI", 12F), Brushes.DarkBlue, 8, 8);
                    }
                }
                picLogoHeader.Image = bmp;
            }
            catch { }
        }

        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel? pnl = sender as Panel;
            if (pnl == null) return;

            using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1));
            }
        }

        private void EstilizarGrid()
        {
            dgvOrdenes.BackgroundColor = Color.White;
            dgvOrdenes.BorderStyle = BorderStyle.None;
            dgvOrdenes.GridColor = Color.FromArgb(241, 245, 249);
            dgvOrdenes.RowHeadersVisible = false;
            dgvOrdenes.EnableHeadersVisualStyles = false;
            dgvOrdenes.ColumnHeadersHeight = 36;
            dgvOrdenes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvOrdenes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvOrdenes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dgvOrdenes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvOrdenes.DefaultCellStyle.BackColor = Color.White;
            dgvOrdenes.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvOrdenes.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F);
            dgvOrdenes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvOrdenes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvOrdenes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvOrdenes.RowTemplate.Height = 32;

            dgvOrdenes.AutoGenerateColumns = false;
            dgvOrdenes.Columns.Clear();

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrdenID",
                HeaderText = "N° Orden",
                Width = 60,
                FillWeight = 25
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaFormateada",
                HeaderText = "Fecha",
                Width = 105,
                FillWeight = 45
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCliente",
                HeaderText = "Cliente",
                FillWeight = 85
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PlacaVehiculo",
                HeaderText = "Placa",
                Width = 75,
                FillWeight = 35
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DetalleVehiculo",
                HeaderText = "Vehículo",
                FillWeight = 85
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreMecanico",
                HeaderText = "Mecánico",
                FillWeight = 80
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "KilometrajeEntrada",
                HeaderText = "KM Entrada",
                Width = 75,
                FillWeight = 35
            });

            dgvOrdenes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Width = 85,
                FillWeight = 40
            });

            dgvOrdenes.CellFormatting += DgvOrdenes_CellFormatting;
        }

        private void DgvOrdenes_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvOrdenes.Columns[e.ColumnIndex].DataPropertyName == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString() ?? "";
                if (estado == "Pendiente")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
                    e.CellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }
                else if (estado == "En Proceso")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(2, 132, 199);
                    e.CellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }
                else if (estado == "Finalizada")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129);
                    e.CellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }
                else if (estado == "Cancelada")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    e.CellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }
            }
        }

        private void CargarCombosMaestros()
        {
            try
            {
                // 1. Clientes
                _listaClientes = _clienteBL.ObtenerClientesActivos() ?? new List<ClienteEN>();
                cboCliente.Items.Clear();
                cboCliente.Items.Add(new ComboItem<int>(0, "-- Seleccione un Cliente --"));
                foreach (var c in _listaClientes)
                {
                    cboCliente.Items.Add(new ComboItem<int>(c.ClienteID, $"#{c.ClienteID} - {c.NombreCompleto}"));
                }
                cboCliente.SelectedIndex = 0;

                // 2. Vehículos
                _listaVehiculos = _vehiculoBL.ObtenerVehiculosActivos() ?? new List<VehiculoEN>();
                ActualizarComboVehiculos(0);

                // 3. Mecánicos / Empleados
                _listaEmpleados = _empleadoBL.ObtenerEmpleadosActivos() ?? new List<EmpleadoEN>();
                ActualizarComboMecanicos();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al inicializar listas: {ex.Message}", true);
            }
        }

        private void ActualizarComboVehiculos(int clienteID)
        {
            cboVehiculo.Items.Clear();
            cboVehiculo.Items.Add(new ComboItem<int>(0, "-- Seleccione un Vehículo --"));

            var filtrados = clienteID > 0
                ? _listaVehiculos.Where(v => v.ClienteID == clienteID).ToList()
                : _listaVehiculos;

            foreach (var v in filtrados)
            {
                cboVehiculo.Items.Add(new ComboItem<int>(v.VehiculoID, $"{v.Placa} - {v.Marca} {v.Modelo} ({v.Anio})"));
            }

            if (cboVehiculo.Items.Count > 0)
                cboVehiculo.SelectedIndex = 0;
        }

        private void ActualizarComboMecanicos()
        {
            cboMecanico.Items.Clear();
            cboMecanico.Items.Add(new ComboItem<int>(0, "-- Seleccione un Mecánico Asignado --"));

            foreach (var emp in _listaEmpleados)
            {
                bool ocupado = _ordenBL.MecanicoTieneOrdenActiva(emp.EmpleadoID, _ordenSeleccionadaID);
                string estadoTexto = ocupado ? " [⚠️ Ocupado]" : " [✅ Disponible]";
                cboMecanico.Items.Add(new ComboItem<int>(emp.EmpleadoID, $"{emp.NombreCompleto} ({emp.Cargo}){estadoTexto}"));
            }

            if (cboMecanico.Items.Count > 0)
                cboMecanico.SelectedIndex = 0;
        }

        private void CboCliente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboCliente.SelectedItem is ComboItem<int> item)
            {
                ActualizarComboVehiculos(item.Value);
            }
            Input_TextChanged(sender, e);
        }

        private void CargarOrdenes()
        {
            try
            {
                _listaOrdenes = _ordenBL.ObtenerTodasOrdenes() ?? new List<OrdenTrabajoEN>();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar órdenes de trabajo: {ex.Message}", true);
            }
        }

        private void AplicarFiltro()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            string estadoFiltro = cboFiltroEstado.SelectedItem?.ToString() ?? "Todos";

            List<OrdenTrabajoEN> filtrados = _listaOrdenes;

            if (estadoFiltro != "Todos")
            {
                filtrados = filtrados.Where(o => o.Estado == estadoFiltro).ToList();
            }

            if (!string.IsNullOrEmpty(filtro))
            {
                filtrados = filtrados.Where(o =>
                    o.OrdenID.ToString().Contains(filtro) ||
                    (o.NombreCliente != null && o.NombreCliente.ToLower().Contains(filtro)) ||
                    (o.PlacaVehiculo != null && o.PlacaVehiculo.ToLower().Contains(filtro)) ||
                    (o.DetalleVehiculo != null && o.DetalleVehiculo.ToLower().Contains(filtro)) ||
                    (o.NombreMecanico != null && o.NombreMecanico.ToLower().Contains(filtro)) ||
                    (o.DescripcionDiagnostico != null && o.DescripcionDiagnostico.ToLower().Contains(filtro)) ||
                    (o.Estado != null && o.Estado.ToLower().Contains(filtro))
                ).ToList();
            }

            dgvOrdenes.DataSource = null;
            dgvOrdenes.DataSource = filtrados;
            lblTotalOrdenes.Text = $"Total órdenes de trabajo: {filtrados.Count}";
        }

        private void TxtBuscar_TextChanged(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void CboFiltroEstado_SelectedIndexChanged(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnRefrescar_Click(object? sender, EventArgs e)
        {
            txtBuscar.Clear();
            cboFiltroEstado.SelectedIndex = 0;
            CargarCombosMaestros();
            CargarOrdenes();
            MostrarMensaje("Listado de órdenes actualizado.", false);
        }

        private void Input_TextChanged(object? sender, EventArgs? e)
        {
            if (lblMensaje.Visible)
            {
                lblMensaje.Visible = false;
                lblMensaje.Text = string.Empty;
                txtKilometraje.BackColor = Color.FromArgb(248, 250, 252);
                txtDiagnostico.BackColor = Color.FromArgb(248, 250, 252);
                cboCliente.BackColor = Color.FromArgb(248, 250, 252);
                cboVehiculo.BackColor = Color.FromArgb(248, 250, 252);
                cboMecanico.BackColor = Color.FromArgb(248, 250, 252);
            }
        }

        private void MostrarMensaje(string mensaje, bool esError, Control? controlObjetivo = null)
        {
            lblMensaje.Text = (esError ? "⚠️ " : "✅ ") + mensaje;
            lblMensaje.ForeColor = esError ? Color.FromArgb(220, 38, 38) : Color.FromArgb(16, 185, 129);
            lblMensaje.Visible = true;

            if (controlObjetivo != null)
            {
                controlObjetivo.BackColor = esError ? Color.FromArgb(254, 242, 242) : Color.FromArgb(240, 253, 244);
                controlObjetivo.Focus();
            }
        }

        private void ActualizarEstadoBotones(bool haySeleccion, string estadoOrden)
        {
            bool esFinalizada = estadoOrden == "Finalizada";
            bool esCancelada = estadoOrden == "Cancelada";

            btnGuardar.Enabled = !haySeleccion;
            btnGuardar.BackColor = !haySeleccion ? Color.FromArgb(2, 132, 199) : Color.FromArgb(148, 163, 184);

            btnModificar.Enabled = haySeleccion && !esFinalizada && !esCancelada;
            btnModificar.BackColor = (haySeleccion && !esFinalizada && !esCancelada) ? Color.FromArgb(13, 148, 136) : Color.FromArgb(148, 163, 184);

            btnFinalizar.Enabled = haySeleccion && !esFinalizada && !esCancelada;
            btnFinalizar.BackColor = (haySeleccion && !esFinalizada && !esCancelada) ? Color.FromArgb(217, 119, 6) : Color.FromArgb(148, 163, 184);

            btnCancelar.Enabled = haySeleccion && !esFinalizada && !esCancelada;
            btnCancelar.BackColor = (haySeleccion && !esFinalizada && !esCancelada) ? Color.FromArgb(220, 38, 38) : Color.FromArgb(148, 163, 184);

            if (haySeleccion && esFinalizada)
            {
                MostrarMensaje("Esta orden se encuentra FINALIZADA y no puede modificarse (Regla #6).", true);
            }
        }

        private void DgvOrdenes_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            CargarOrdenSeleccionada();
        }

        private void DgvOrdenes_SelectionChanged(object? sender, EventArgs e)
        {
            CargarOrdenSeleccionada();
        }

        private void CargarOrdenSeleccionada()
        {
            if (dgvOrdenes.CurrentRow != null && dgvOrdenes.CurrentRow.DataBoundItem is OrdenTrabajoEN orden)
            {
                _ordenSeleccionadaID = orden.OrdenID;
                txtKilometraje.Text = orden.KilometrajeEntrada.ToString();
                txtDiagnostico.Text = orden.DescripcionDiagnostico ?? string.Empty;
                txtObservaciones.Text = orden.Observaciones ?? string.Empty;
                cboEstado.SelectedItem = orden.Estado;

                // Seleccionar cliente
                for (int i = 0; i < cboCliente.Items.Count; i++)
                {
                    if (cboCliente.Items[i] is ComboItem<int> item && item.Value == orden.ClienteID)
                    {
                        cboCliente.SelectedIndex = i;
                        break;
                    }
                }

                // Asegurar carga de vehículos y seleccionar el vehículo
                ActualizarComboVehiculos(orden.ClienteID);
                for (int i = 0; i < cboVehiculo.Items.Count; i++)
                {
                    if (cboVehiculo.Items[i] is ComboItem<int> item && item.Value == orden.VehiculoID)
                    {
                        cboVehiculo.SelectedIndex = i;
                        break;
                    }
                }

                // Seleccionar mecánico
                ActualizarComboMecanicos();
                for (int i = 0; i < cboMecanico.Items.Count; i++)
                {
                    if (cboMecanico.Items[i] is ComboItem<int> item && item.Value == orden.EmpleadoID)
                    {
                        cboMecanico.SelectedIndex = i;
                        break;
                    }
                }

                ActualizarEstadoBotones(true, orden.Estado);
            }
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!(cboCliente.SelectedItem is ComboItem<int> clienteItem) || clienteItem.Value <= 0)
            {
                MostrarMensaje("Debe seleccionar un cliente para la orden de trabajo.", true, cboCliente);
                return;
            }

            if (!(cboVehiculo.SelectedItem is ComboItem<int> vehiculoItem) || vehiculoItem.Value <= 0)
            {
                MostrarMensaje("Debe seleccionar un vehículo asociado al cliente.", true, cboVehiculo);
                return;
            }

            if (!(cboMecanico.SelectedItem is ComboItem<int> mecanicoItem) || mecanicoItem.Value <= 0)
            {
                MostrarMensaje("Debe asignar un mecánico responsable.", true, cboMecanico);
                return;
            }

            if (!int.TryParse(txtKilometraje.Text.Trim(), out int km) || km < 0)
            {
                MostrarMensaje("Ingrese un kilometraje de entrada válido (número positivo).", true, txtKilometraje);
                return;
            }

            string diagnostico = txtDiagnostico.Text.Trim();
            if (string.IsNullOrWhiteSpace(diagnostico))
            {
                MostrarMensaje("El diagnóstico inicial o motivo del servicio es obligatorio.", true, txtDiagnostico);
                return;
            }

            string estado = cboEstado.SelectedItem?.ToString() ?? "Pendiente";
            string observaciones = txtObservaciones.Text.Trim();

            try
            {
                OrdenTrabajoEN nuevaOrden = new OrdenTrabajoEN
                {
                    ClienteID = clienteItem.Value,
                    VehiculoID = vehiculoItem.Value,
                    EmpleadoID = mecanicoItem.Value,
                    KilometrajeEntrada = km,
                    DescripcionDiagnostico = diagnostico,
                    Observaciones = string.IsNullOrWhiteSpace(observaciones) ? null : observaciones,
                    Estado = estado,
                    UbicacionTaller = "Taller Mecánico Toluca"
                };

                int nuevoId = _ordenBL.CrearOrden(nuevaOrden);
                MostrarMensaje($"Orden #{nuevoId} creada exitosamente.", false);
                MessageBox.Show($"Orden de trabajo #{nuevoId} creada y mecánico asignado con éxito.", "Orden de Trabajo Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarOrdenes();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true);
                MessageBox.Show(ex.Message, "Validación de Orden de Trabajo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object? sender, EventArgs e)
        {
            if (_ordenSeleccionadaID <= 0)
            {
                MostrarMensaje("Seleccione una orden de trabajo del listado para modificar.", true);
                return;
            }

            if (!(cboCliente.SelectedItem is ComboItem<int> clienteItem) || clienteItem.Value <= 0)
            {
                MostrarMensaje("Debe seleccionar un cliente.", true, cboCliente);
                return;
            }

            if (!(cboVehiculo.SelectedItem is ComboItem<int> vehiculoItem) || vehiculoItem.Value <= 0)
            {
                MostrarMensaje("Debe seleccionar un vehículo.", true, cboVehiculo);
                return;
            }

            if (!(cboMecanico.SelectedItem is ComboItem<int> mecanicoItem) || mecanicoItem.Value <= 0)
            {
                MostrarMensaje("Debe asignar un mecánico.", true, cboMecanico);
                return;
            }

            if (!int.TryParse(txtKilometraje.Text.Trim(), out int km) || km < 0)
            {
                MostrarMensaje("Ingrese un kilometraje válido.", true, txtKilometraje);
                return;
            }

            string diagnostico = txtDiagnostico.Text.Trim();
            if (string.IsNullOrWhiteSpace(diagnostico))
            {
                MostrarMensaje("El diagnóstico inicial es obligatorio.", true, txtDiagnostico);
                return;
            }

            string estado = cboEstado.SelectedItem?.ToString() ?? "Pendiente";
            string observaciones = txtObservaciones.Text.Trim();

            try
            {
                OrdenTrabajoEN ordenModificar = new OrdenTrabajoEN
                {
                    OrdenID = _ordenSeleccionadaID,
                    ClienteID = clienteItem.Value,
                    VehiculoID = vehiculoItem.Value,
                    EmpleadoID = mecanicoItem.Value,
                    KilometrajeEntrada = km,
                    DescripcionDiagnostico = diagnostico,
                    Observaciones = string.IsNullOrWhiteSpace(observaciones) ? null : observaciones,
                    Estado = estado,
                    UbicacionTaller = "Taller Mecánico Toluca"
                };

                _ordenBL.ModificarOrden(ordenModificar);
                MostrarMensaje($"Orden #{_ordenSeleccionadaID} modificada exitosamente.", false);
                MessageBox.Show("Los datos de la orden de trabajo han sido actualizados.", "Orden Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarOrdenes();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true);
                MessageBox.Show(ex.Message, "Error al Modificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFinalizar_Click(object? sender, EventArgs e)
        {
            if (_ordenSeleccionadaID <= 0)
            {
                MostrarMensaje("Seleccione una orden para finalizar.", true);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro de que desea marcar la Orden #{_ordenSeleccionadaID} como FINALIZADA?\n\nNota importante: Una vez finalizada, la orden no podrá modificarse (Regla #6 del taller).",
                "Confirmar Finalización de Orden",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _ordenBL.CambiarEstadoOrden(_ordenSeleccionadaID, "Finalizada");
                    MostrarMensaje($"Orden #{_ordenSeleccionadaID} marcada como FINALIZADA.", false);
                    MessageBox.Show("La orden fue marcada como Finalizada con éxito. El mecánico ha quedado libre para nuevas asignaciones.", "Orden Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarOrdenes();
                }
                catch (Exception ex)
                {
                    MostrarMensaje(ex.Message, true);
                    MessageBox.Show(ex.Message, "Orden Inmutable", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            if (_ordenSeleccionadaID <= 0)
            {
                MostrarMensaje("Seleccione una orden para cancelar.", true);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro de que desea CANCELAR la Orden #{_ordenSeleccionadaID}?",
                "Confirmar Cancelación de Orden",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _ordenBL.CambiarEstadoOrden(_ordenSeleccionadaID, "Cancelada");
                    MostrarMensaje($"Orden #{_ordenSeleccionadaID} cancelada.", false);
                    MessageBox.Show("La orden de trabajo fue cancelada.", "Orden Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarOrdenes();
                }
                catch (Exception ex)
                {
                    MostrarMensaje(ex.Message, true);
                }
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _ordenSeleccionadaID = 0;
            if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;
            ActualizarComboVehiculos(0);
            ActualizarComboMecanicos();
            txtKilometraje.Clear();
            cboEstado.SelectedItem = "Pendiente";
            txtDiagnostico.Clear();
            txtObservaciones.Clear();
            lblMensaje.Visible = false;
            lblMensaje.Text = string.Empty;

            txtKilometraje.BackColor = Color.FromArgb(248, 250, 252);
            txtDiagnostico.BackColor = Color.FromArgb(248, 250, 252);
            cboCliente.BackColor = Color.FromArgb(248, 250, 252);
            cboVehiculo.BackColor = Color.FromArgb(248, 250, 252);
            cboMecanico.BackColor = Color.FromArgb(248, 250, 252);

            dgvOrdenes.ClearSelection();
            ActualizarEstadoBotones(false, string.Empty);
        }
    }
}
