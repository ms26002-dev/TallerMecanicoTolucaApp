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
    public partial class FrmVehiculos : Form
    {
        private readonly VehiculoBL _vehiculoBL = new VehiculoBL();
        private readonly ClienteBL _clienteBL = new ClienteBL();
        private List<VehiculoEN> _listaVehiculos = new List<VehiculoEN>();
        private List<ClienteEN> _listaClientes = new List<ClienteEN>();
        private int _vehiculoSeleccionadoID = 0;

        // Clase auxiliar para el ComboBox de clientes
        private class ClienteComboItem
        {
            public int ClienteID { get; set; }
            public string NombreCompleto { get; set; } = string.Empty;
            public string DisplayText { get; set; } = string.Empty;

            public override string ToString()
            {
                return DisplayText;
            }
        }

        public FrmVehiculos()
        {
            InitializeComponent();
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            CargarLogotipo();
            EstilizarGrid();
            CargarClientesCombo();
            cboTipoVehiculo.SelectedItem = "Liviano";
            if (cboMarca.Items.Count > 0) cboMarca.SelectedIndex = 0;
            txtAnio.Text = DateTime.Now.Year.ToString();
            CargarVehiculos();
            ActualizarEstadoBotones(false);
        }

        private void CargarLogotipo()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string[] possiblePaths = new string[]
                {
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

                // Generar icono vectorial si no existe la imagen
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
                        g.DrawString("🚗", new Font("Segoe UI", 12F), Brushes.DarkBlue, 8, 8);
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
            dgvVehiculos.BackgroundColor = Color.White;
            dgvVehiculos.BorderStyle = BorderStyle.None;
            dgvVehiculos.GridColor = Color.FromArgb(241, 245, 249);
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.EnableHeadersVisualStyles = false;
            dgvVehiculos.ColumnHeadersHeight = 36;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvVehiculos.DefaultCellStyle.BackColor = Color.White;
            dgvVehiculos.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvVehiculos.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvVehiculos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvVehiculos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvVehiculos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvVehiculos.RowTemplate.Height = 34;

            dgvVehiculos.AutoGenerateColumns = false;
            dgvVehiculos.Columns.Clear();

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "VehiculoID",
                HeaderText = "ID",
                Width = 45,
                FillWeight = 25
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Placa",
                HeaderText = "Placa",
                Width = 85,
                FillWeight = 45
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Marca",
                HeaderText = "Marca",
                Width = 85,
                FillWeight = 45
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Modelo",
                HeaderText = "Modelo",
                Width = 90,
                FillWeight = 50
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Anio",
                HeaderText = "Año",
                Width = 55,
                FillWeight = 30
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Color",
                HeaderText = "Color",
                Width = 70,
                FillWeight = 40
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TipoVehiculo",
                HeaderText = "Tipo",
                Width = 75,
                FillWeight = 40
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombrePropietario",
                HeaderText = "Propietario / Cliente",
                FillWeight = 110
            });
        }

        private void CargarClientesCombo()
        {
            try
            {
                _listaClientes = _clienteBL.ObtenerClientesActivos() ?? new List<ClienteEN>();
                cboCliente.Items.Clear();

                cboCliente.Items.Add(new ClienteComboItem
                {
                    ClienteID = 0,
                    NombreCompleto = "",
                    DisplayText = "-- Seleccione un Propietario --"
                });

                foreach (var c in _listaClientes)
                {
                    string tel = string.IsNullOrWhiteSpace(c.Telefono) ? "" : $" (Tel: {c.Telefono})";
                    cboCliente.Items.Add(new ClienteComboItem
                    {
                        ClienteID = c.ClienteID,
                        NombreCompleto = c.NombreCompleto,
                        DisplayText = $"#{c.ClienteID} - {c.NombreCompleto}{tel}"
                    });
                }

                cboCliente.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar clientes: {ex.Message}", true);
            }
        }

        private void CargarVehiculos()
        {
            try
            {
                _listaVehiculos = _vehiculoBL.ObtenerVehiculosActivos() ?? new List<VehiculoEN>();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar vehículos: {ex.Message}", true);
            }
        }

        private void AplicarFiltro()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            List<VehiculoEN> filtrados;
            if (string.IsNullOrEmpty(filtro))
            {
                filtrados = _listaVehiculos;
            }
            else
            {
                filtrados = _listaVehiculos.Where(v =>
                    (v.Placa != null && v.Placa.ToLower().Contains(filtro)) ||
                    (v.Marca != null && v.Marca.ToLower().Contains(filtro)) ||
                    (v.Modelo != null && v.Modelo.ToLower().Contains(filtro)) ||
                    (v.Color != null && v.Color.ToLower().Contains(filtro)) ||
                    (v.TipoVehiculo != null && v.TipoVehiculo.ToLower().Contains(filtro)) ||
                    (v.NombrePropietario != null && v.NombrePropietario.ToLower().Contains(filtro)) ||
                    v.Anio.ToString().Contains(filtro)
                ).ToList();
            }

            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = filtrados;
            lblTotalVehiculos.Text = $"Total vehículos registrados: {filtrados.Count}";
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarClientesCombo();
            CargarVehiculos();
            MostrarMensaje("Listado de vehículos actualizado.", false);
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (lblMensaje.Visible)
            {
                lblMensaje.Visible = false;
                lblMensaje.Text = string.Empty;
                txtPlaca.BackColor = Color.FromArgb(248, 250, 252);
                cboMarca.BackColor = Color.FromArgb(248, 250, 252);
                txtModelo.BackColor = Color.FromArgb(248, 250, 252);
                txtAnio.BackColor = Color.FromArgb(248, 250, 252);
                cboCliente.BackColor = Color.FromArgb(248, 250, 252);
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

            btnEliminar.Enabled = haySeleccion;
            btnEliminar.BackColor = haySeleccion ? Color.FromArgb(220, 38, 38) : Color.FromArgb(148, 163, 184);
        }

        private void DgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarVehiculoSeleccionado();
        }

        private void DgvVehiculos_SelectionChanged(object sender, EventArgs e)
        {
            CargarVehiculoSeleccionado();
        }

        private void CargarVehiculoSeleccionado()
        {
            if (dgvVehiculos.CurrentRow != null && dgvVehiculos.CurrentRow.DataBoundItem is VehiculoEN vehiculo)
            {
                _vehiculoSeleccionadoID = vehiculo.VehiculoID;
                txtPlaca.Text = vehiculo.Placa ?? string.Empty;
                cboMarca.Text = vehiculo.Marca ?? string.Empty;
                txtModelo.Text = vehiculo.Modelo ?? string.Empty;
                txtAnio.Text = vehiculo.Anio > 0 ? vehiculo.Anio.ToString() : string.Empty;
                txtColor.Text = vehiculo.Color ?? string.Empty;
                
                if (!string.IsNullOrWhiteSpace(vehiculo.TipoVehiculo))
                {
                    cboTipoVehiculo.SelectedItem = vehiculo.TipoVehiculo;
                }

                // Seleccionar cliente en combo
                bool encontrado = false;
                for (int i = 0; i < cboCliente.Items.Count; i++)
                {
                    if (cboCliente.Items[i] is ClienteComboItem item && item.ClienteID == vehiculo.ClienteID)
                    {
                        cboCliente.SelectedIndex = i;
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado && cboCliente.Items.Count > 0)
                {
                    cboCliente.SelectedIndex = 0;
                }

                ActualizarEstadoBotones(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!(cboCliente.SelectedItem is ClienteComboItem clienteSeleccionado) || clienteSeleccionado.ClienteID <= 0)
            {
                MostrarMensaje("Debe seleccionar un cliente propietario de la lista.", true, cboCliente);
                return;
            }

            string placa = txtPlaca.Text.Trim().ToUpper();
            string marca = cboMarca.Text.Trim();
            string modelo = txtModelo.Text.Trim();
            string color = txtColor.Text.Trim();
            string tipo = cboTipoVehiculo.SelectedItem?.ToString() ?? "Liviano";

            if (string.IsNullOrWhiteSpace(placa))
            {
                MostrarMensaje("La placa o matrícula del vehículo es obligatoria.", true, txtPlaca);
                return;
            }

            if (string.IsNullOrWhiteSpace(marca))
            {
                MostrarMensaje("La marca del vehículo es obligatoria.", true, cboMarca);
                return;
            }

            if (string.IsNullOrWhiteSpace(modelo))
            {
                MostrarMensaje("El modelo del vehículo es obligatorio.", true, txtModelo);
                return;
            }

            if (!int.TryParse(txtAnio.Text.Trim(), out int anio) || anio < 1900 || anio > DateTime.Now.Year + 1)
            {
                MostrarMensaje($"Ingrese un año válido (entre 1900 y {DateTime.Now.Year + 1}).", true, txtAnio);
                return;
            }

            // Restricción #4 del sistema: Solo vehículos livianos
            if (tipo != "Liviano")
            {
                MostrarMensaje("Restricción: El taller solo atiende vehículos livianos.", true, cboTipoVehiculo);
                MessageBox.Show("Restricción del Sistema (Regla #4):\nEl taller mecánico únicamente atiende y registra vehículos livianos.", "Restricción de Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                VehiculoEN nuevoVehiculo = new VehiculoEN
                {
                    ClienteID = clienteSeleccionado.ClienteID,
                    Placa = placa,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    Color = string.IsNullOrWhiteSpace(color) ? null : color,
                    TipoVehiculo = tipo,
                    Estado = "Activo"
                };

                _vehiculoBL.RegistrarVehiculo(nuevoVehiculo);
                MostrarMensaje("Vehículo registrado exitosamente.", false);
                MessageBox.Show($"Vehículo con placa {placa} asociado exitosamente a {clienteSeleccionado.NombreCompleto}.", "Vehículo Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarVehiculos();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true, txtPlaca);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_vehiculoSeleccionadoID <= 0)
            {
                MostrarMensaje("Seleccione un vehículo del listado para modificar.", true);
                return;
            }

            if (!(cboCliente.SelectedItem is ClienteComboItem clienteSeleccionado) || clienteSeleccionado.ClienteID <= 0)
            {
                MostrarMensaje("Debe seleccionar un cliente propietario.", true, cboCliente);
                return;
            }

            string placa = txtPlaca.Text.Trim().ToUpper();
            string marca = cboMarca.Text.Trim();
            string modelo = txtModelo.Text.Trim();
            string color = txtColor.Text.Trim();
            string tipo = cboTipoVehiculo.SelectedItem?.ToString() ?? "Liviano";

            if (string.IsNullOrWhiteSpace(placa))
            {
                MostrarMensaje("La placa es obligatoria.", true, txtPlaca);
                return;
            }

            if (string.IsNullOrWhiteSpace(marca))
            {
                MostrarMensaje("La marca es obligatoria.", true, cboMarca);
                return;
            }

            if (string.IsNullOrWhiteSpace(modelo))
            {
                MostrarMensaje("El modelo es obligatorio.", true, txtModelo);
                return;
            }

            if (!int.TryParse(txtAnio.Text.Trim(), out int anio) || anio < 1900 || anio > DateTime.Now.Year + 1)
            {
                MostrarMensaje($"Ingrese un año válido (entre 1900 y {DateTime.Now.Year + 1}).", true, txtAnio);
                return;
            }

            if (tipo != "Liviano")
            {
                MostrarMensaje("Restricción: El taller solo atiende vehículos livianos.", true, cboTipoVehiculo);
                MessageBox.Show("Restricción del Sistema (Regla #4):\nEl taller mecánico únicamente atiende vehículos livianos.", "Restricción de Vehículos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                VehiculoEN vehiculoModificar = new VehiculoEN
                {
                    VehiculoID = _vehiculoSeleccionadoID,
                    ClienteID = clienteSeleccionado.ClienteID,
                    Placa = placa,
                    Marca = marca,
                    Modelo = modelo,
                    Anio = anio,
                    Color = string.IsNullOrWhiteSpace(color) ? null : color,
                    TipoVehiculo = tipo,
                    Estado = "Activo"
                };

                _vehiculoBL.ModificarVehiculo(vehiculoModificar);
                MostrarMensaje("Vehículo modificado correctamente.", false);
                MessageBox.Show("Los datos del vehículo han sido actualizados exitosamente.", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarVehiculos();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_vehiculoSeleccionadoID <= 0)
            {
                MostrarMensaje("Seleccione un vehículo para eliminar.", true);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro de que desea eliminar el vehículo con placa '{txtPlaca.Text.Trim()}'?",
                "Confirmar Eliminación de Vehículo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _vehiculoBL.EliminarVehiculo(_vehiculoSeleccionadoID);
                    MostrarMensaje("Vehículo eliminado correctamente.", false);
                    MessageBox.Show("El vehículo ha sido eliminado del sistema.", "Vehículo Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarVehiculos();
                }
                catch (Exception ex)
                {
                    MostrarMensaje($"No se pudo eliminar el vehículo: {ex.Message}", true);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _vehiculoSeleccionadoID = 0;
            if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;
            txtPlaca.Clear();
            if (cboMarca.Items.Count > 0) cboMarca.SelectedIndex = 0;
            txtModelo.Clear();
            txtAnio.Text = DateTime.Now.Year.ToString();
            txtColor.Clear();
            cboTipoVehiculo.SelectedItem = "Liviano";
            lblMensaje.Visible = false;
            lblMensaje.Text = string.Empty;

            txtPlaca.BackColor = Color.FromArgb(248, 250, 252);
            cboMarca.BackColor = Color.FromArgb(248, 250, 252);
            txtModelo.BackColor = Color.FromArgb(248, 250, 252);
            txtAnio.BackColor = Color.FromArgb(248, 250, 252);
            cboCliente.BackColor = Color.FromArgb(248, 250, 252);

            dgvVehiculos.ClearSelection();
            ActualizarEstadoBotones(false);
        }
    }
}
