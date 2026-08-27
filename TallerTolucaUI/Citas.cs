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
    public partial class FrmCitas : Form
    {
        private readonly CitaBL _citaBL = new CitaBL();
        private readonly ClienteBL _clienteBL = new ClienteBL();
        private readonly VehiculoBL _vehiculoBL = new VehiculoBL();

        private List<CitaEN> _listaCitas = new List<CitaEN>();
        private List<ClienteEN> _listaClientes = new List<ClienteEN>();
        private List<VehiculoEN> _listaVehiculos = new List<VehiculoEN>();

        private int _citaSeleccionadaID = 0;

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

        public FrmCitas()
        {
            InitializeComponent();
        }

        private void FrmCitas_Load(object sender, EventArgs e)
        {
            CargarLogotipo();
            EstilizarGrid();
            CargarCombos();
            cboEstado.SelectedItem = "Programada";
            DateTime proxima = DateTime.Now.AddHours(2);
            dtpFecha.Value = proxima.Date;
            cboHora.Text = proxima.ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).ToUpper();
            CargarCitas();
            ActualizarEstadoBotones(false);
        }

        private bool TryObtenerFechaHoraProgramada(out DateTime fechaHoraResult)
        {
            fechaHoraResult = DateTime.MinValue;
            string horaTexto = cboHora.Text.Trim();

            if (string.IsNullOrWhiteSpace(horaTexto))
                return false;

            string[] formats = new string[]
            {
                "h:mm tt", "hh:mm tt", "H:mm", "HH:mm", "h:m tt", "hh:mmtt", "h:mmtt",
                "h tt", "hh tt", "H", "HH"
            };

            DateTime timeParsed;
            bool parsed = DateTime.TryParseExact(horaTexto, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out timeParsed) ||
                         DateTime.TryParseExact(horaTexto, formats, System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out timeParsed) ||
                         DateTime.TryParse(horaTexto, out timeParsed);

            if (!parsed)
                return false;

            fechaHoraResult = new DateTime(
                dtpFecha.Value.Year,
                dtpFecha.Value.Month,
                dtpFecha.Value.Day,
                timeParsed.Hour,
                timeParsed.Minute,
                0
            );

            return true;
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
                        g.DrawString("📅", new Font("Segoe UI", 12F), Brushes.DarkBlue, 8, 8);
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
            dgvCitas.BackgroundColor = Color.White;
            dgvCitas.BorderStyle = BorderStyle.None;
            dgvCitas.GridColor = Color.FromArgb(241, 245, 249);
            dgvCitas.RowHeadersVisible = false;
            dgvCitas.EnableHeadersVisualStyles = false;
            dgvCitas.ColumnHeadersHeight = 36;
            dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvCitas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvCitas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCitas.DefaultCellStyle.BackColor = Color.White;
            dgvCitas.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvCitas.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvCitas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvCitas.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvCitas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvCitas.RowTemplate.Height = 34;

            dgvCitas.AutoGenerateColumns = false;
            dgvCitas.Columns.Clear();

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CitaID",
                HeaderText = "ID",
                Width = 45,
                FillWeight = 25
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaHoraFormateada",
                HeaderText = "Fecha y Hora",
                Width = 135,
                FillWeight = 55
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCliente",
                HeaderText = "Cliente",
                FillWeight = 85
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PlacaVehiculo",
                HeaderText = "Placa",
                Width = 75,
                FillWeight = 35
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DetalleVehiculo",
                HeaderText = "Vehículo",
                FillWeight = 85
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Width = 90,
                FillWeight = 40
            });

            dgvCitas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Motivo",
                HeaderText = "Motivo del Servicio",
                FillWeight = 95
            });

            dgvCitas.CellFormatting += DgvCitas_CellFormatting;
        }

        private void DgvCitas_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCitas.Columns[e.ColumnIndex].DataPropertyName == "Estado" && e.Value != null)
            {
                string estado = e.Value.ToString() ?? "";
                if (estado == "Programada")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(2, 132, 199);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else if (estado == "Atendida")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(16, 185, 129);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else if (estado == "Reprogramada")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(147, 51, 234);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else if (estado == "Cancelada")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                else if (estado == "No Recibida")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(100, 116, 139);
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }
        }

        private void CargarCombos()
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
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al inicializar combos: {ex.Message}", true);
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

        private void CboCliente_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboCliente.SelectedItem is ComboItem<int> item)
            {
                ActualizarComboVehiculos(item.Value);
            }
            Input_TextChanged(sender, e);
        }

        private void CargarCitas()
        {
            try
            {
                // Evaluar citas vencidas automáticamente (Regla #3)
                _citaBL.ProcesarCitasVencidas(30);

                _listaCitas = _citaBL.ObtenerTodasCitas() ?? new List<CitaEN>();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar citas: {ex.Message}", true);
            }
        }

        private void AplicarFiltro()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            List<CitaEN> filtrados;
            if (string.IsNullOrEmpty(filtro))
            {
                filtrados = _listaCitas;
            }
            else
            {
                filtrados = _listaCitas.Where(c =>
                    c.CitaID.ToString().Contains(filtro) ||
                    (c.NombreCliente != null && c.NombreCliente.ToLower().Contains(filtro)) ||
                    (c.PlacaVehiculo != null && c.PlacaVehiculo.ToLower().Contains(filtro)) ||
                    (c.DetalleVehiculo != null && c.DetalleVehiculo.ToLower().Contains(filtro)) ||
                    (c.Motivo != null && c.Motivo.ToLower().Contains(filtro)) ||
                    (c.Estado != null && c.Estado.ToLower().Contains(filtro))
                ).ToList();
            }

            dgvCitas.DataSource = null;
            dgvCitas.DataSource = filtrados;
            lblTotalCitas.Text = $"Total citas registradas: {filtrados.Count}";
        }

        private void TxtBuscar_TextChanged(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnRefrescar_Click(object? sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarCombos();
            CargarCitas();
            MostrarMensaje("Agenda de citas actualizada.", false);
        }

        private void Input_TextChanged(object? sender, EventArgs? e)
        {
            if (lblMensaje.Visible)
            {
                lblMensaje.Visible = false;
                lblMensaje.Text = string.Empty;
                txtMotivo.BackColor = Color.FromArgb(248, 250, 252);
                cboCliente.BackColor = Color.FromArgb(248, 250, 252);
                cboVehiculo.BackColor = Color.FromArgb(248, 250, 252);
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

        private void ActualizarEstadoBotones(bool haySeleccion)
        {
            btnGuardar.Enabled = !haySeleccion;
            btnGuardar.BackColor = !haySeleccion ? Color.FromArgb(2, 132, 199) : Color.FromArgb(148, 163, 184);

            btnModificar.Enabled = haySeleccion;
            btnModificar.BackColor = haySeleccion ? Color.FromArgb(13, 148, 136) : Color.FromArgb(148, 163, 184);

            btnCancelarCita.Enabled = haySeleccion;
            btnCancelarCita.BackColor = haySeleccion ? Color.FromArgb(220, 38, 38) : Color.FromArgb(148, 163, 184);
        }

        private void DgvCitas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            CargarCitaSeleccionada();
        }

        private void DgvCitas_SelectionChanged(object? sender, EventArgs e)
        {
            CargarCitaSeleccionada();
        }

        private void CargarCitaSeleccionada()
        {
            if (dgvCitas.CurrentRow != null && dgvCitas.CurrentRow.DataBoundItem is CitaEN cita)
            {
                _citaSeleccionadaID = cita.CitaID;
                txtMotivo.Text = cita.Motivo ?? string.Empty;
                DateTime fechaValida = cita.FechaHora > DateTime.MinValue ? cita.FechaHora : DateTime.Now;
                dtpFecha.Value = fechaValida.Date;
                cboHora.Text = fechaValida.ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).ToUpper();
                cboEstado.SelectedItem = cita.Estado;

                // Seleccionar cliente
                for (int i = 0; i < cboCliente.Items.Count; i++)
                {
                    if (cboCliente.Items[i] is ComboItem<int> item && item.Value == cita.ClienteID)
                    {
                        cboCliente.SelectedIndex = i;
                        break;
                    }
                }

                // Cargar y seleccionar vehículo
                ActualizarComboVehiculos(cita.ClienteID);
                for (int i = 0; i < cboVehiculo.Items.Count; i++)
                {
                    if (cboVehiculo.Items[i] is ComboItem<int> item && item.Value == cita.VehiculoID)
                    {
                        cboVehiculo.SelectedIndex = i;
                        break;
                    }
                }

                ActualizarEstadoBotones(true);
            }
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (!(cboCliente.SelectedItem is ComboItem<int> clienteItem) || clienteItem.Value <= 0)
            {
                MostrarMensaje("Debe seleccionar un cliente para programar la cita.", true, cboCliente);
                return;
            }

            if (!(cboVehiculo.SelectedItem is ComboItem<int> vehiculoItem) || vehiculoItem.Value <= 0)
            {
                MostrarMensaje("Debe seleccionar un vehículo para la cita.", true, cboVehiculo);
                return;
            }

            if (!TryObtenerFechaHoraProgramada(out DateTime fechaHora))
            {
                MostrarMensaje("Ingrese una hora válida (ejemplo: 09:30 AM o 14:30).", true, cboHora);
                return;
            }

            if (fechaHora < DateTime.Now.AddMinutes(-5))
            {
                MostrarMensaje("No se puede programar una cita en el pasado.", true, dtpFecha);
                return;
            }

            string motivo = txtMotivo.Text.Trim();
            if (string.IsNullOrWhiteSpace(motivo))
            {
                MostrarMensaje("El motivo del servicio o mantenimiento es obligatorio.", true, txtMotivo);
                return;
            }

            string estado = cboEstado.SelectedItem?.ToString() ?? "Programada";

            try
            {
                CitaEN nuevaCita = new CitaEN
                {
                    ClienteID = clienteItem.Value,
                    VehiculoID = vehiculoItem.Value,
                    FechaHora = fechaHora,
                    Motivo = motivo,
                    Estado = estado
                };

                int idCita = _citaBL.ProgramarCita(nuevaCita);
                MostrarMensaje("Cita programada exitosamente.", false);
                MessageBox.Show($"Cita programada con éxito para {fechaHora:dd/MM/yyyy hh:mm tt}.", "Cita Programada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarCitas();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true);
                MessageBox.Show(ex.Message, "Error al Programar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object? sender, EventArgs e)
        {
            if (_citaSeleccionadaID <= 0)
            {
                MostrarMensaje("Seleccione una cita del listado para modificar.", true);
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

            if (!TryObtenerFechaHoraProgramada(out DateTime fechaHora))
            {
                MostrarMensaje("Ingrese una hora válida (ejemplo: 09:30 AM o 14:30).", true, cboHora);
                return;
            }

            string motivo = txtMotivo.Text.Trim();
            if (string.IsNullOrWhiteSpace(motivo))
            {
                MostrarMensaje("El motivo del servicio es obligatorio.", true, txtMotivo);
                return;
            }

            string estado = cboEstado.SelectedItem?.ToString() ?? "Programada";

            try
            {
                CitaEN citaModificar = new CitaEN
                {
                    CitaID = _citaSeleccionadaID,
                    ClienteID = clienteItem.Value,
                    VehiculoID = vehiculoItem.Value,
                    FechaHora = fechaHora,
                    Motivo = motivo,
                    Estado = estado
                };

                _citaBL.ModificarCita(citaModificar);
                MostrarMensaje("Cita modificada / reprogramada correctamente.", false);
                MessageBox.Show("Los datos de la cita han sido actualizados exitosamente.", "Cita Actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarCitas();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true);
                MessageBox.Show(ex.Message, "Error al Modificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelarCita_Click(object? sender, EventArgs e)
        {
            if (_citaSeleccionadaID <= 0)
            {
                MostrarMensaje("Seleccione una cita para cancelar.", true);
                return;
            }

            TryObtenerFechaHoraProgramada(out DateTime fechaHora);
            if (fechaHora == DateTime.MinValue) fechaHora = dtpFecha.Value;

            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro de que desea CANCELAR la Cita #{_citaSeleccionadaID} programada para {fechaHora:dd/MM/yyyy hh:mm tt}?",
                "Confirmar Cancelación de Cita",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _citaBL.CancelarCita(_citaSeleccionadaID);
                    MostrarMensaje("La cita ha sido marcada como CANCELADA.", false);
                    MessageBox.Show("Cita cancelada con éxito.", "Cita Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarCitas();
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
            _citaSeleccionadaID = 0;
            if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;
            ActualizarComboVehiculos(0);
            DateTime proxima = DateTime.Now.AddHours(2);
            dtpFecha.Value = proxima.Date;
            cboHora.Text = proxima.ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture).ToUpper();
            cboEstado.SelectedItem = "Programada";
            txtMotivo.Clear();
            lblMensaje.Visible = false;
            lblMensaje.Text = string.Empty;

            txtMotivo.BackColor = Color.FromArgb(248, 250, 252);
            cboCliente.BackColor = Color.FromArgb(248, 250, 252);
            cboVehiculo.BackColor = Color.FromArgb(248, 250, 252);

            dgvCitas.ClearSelection();
            ActualizarEstadoBotones(false);
        }
    }
}
