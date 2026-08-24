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
    public partial class FrmClientes : Form
    {
        private readonly ClienteBL _clienteBL = new ClienteBL();
        private List<ClienteEN> _listaClientes = new List<ClienteEN>();
        private int _clienteSeleccionadoID = 0;

        public FrmClientes()
        {
            InitializeComponent();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            CargarLogotipo();
            EstilizarGrid();
            CargarClientes();
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
                        g.DrawString("👥", new Font("Segoe UI", 12F), Brushes.DarkBlue, 8, 8);
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
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.GridColor = Color.FromArgb(241, 245, 249);
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.ColumnHeadersHeight = 36;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvClientes.DefaultCellStyle.BackColor = Color.White;
            dgvClientes.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvClientes.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvClientes.RowTemplate.Height = 34;

            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ClienteID",
                HeaderText = "ID",
                Width = 50,
                FillWeight = 30
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompleto",
                HeaderText = "Nombre Completo",
                FillWeight = 110
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Width = 110,
                FillWeight = 60
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo Electrónico",
                FillWeight = 90
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Direccion",
                HeaderText = "Dirección",
                FillWeight = 110
            });
        }

        private void CargarClientes()
        {
            try
            {
                _listaClientes = _clienteBL.ObtenerClientesActivos() ?? new List<ClienteEN>();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar clientes: {ex.Message}", true);
            }
        }

        private void AplicarFiltro()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            List<ClienteEN> filtrados;
            if (string.IsNullOrEmpty(filtro))
            {
                filtrados = _listaClientes;
            }
            else
            {
                filtrados = _listaClientes.Where(c =>
                    (c.NombreCompleto != null && c.NombreCompleto.ToLower().Contains(filtro)) ||
                    (c.Telefono != null && c.Telefono.ToLower().Contains(filtro)) ||
                    (c.Correo != null && c.Correo.ToLower().Contains(filtro)) ||
                    (c.Direccion != null && c.Direccion.ToLower().Contains(filtro))
                ).ToList();
            }

            dgvClientes.DataSource = null;
            dgvClientes.DataSource = filtrados;
            lblTotalClientes.Text = $"Total clientes activos: {filtrados.Count}";
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarClientes();
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (lblMensaje.Visible)
            {
                lblMensaje.Visible = false;
                lblMensaje.Text = string.Empty;
                txtNombre.BackColor = Color.FromArgb(248, 250, 252);
                txtTelefono.BackColor = Color.FromArgb(248, 250, 252);
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

        private void DgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarClienteSeleccionado();
        }

        private void DgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            CargarClienteSeleccionado();
        }

        private void CargarClienteSeleccionado()
        {
            if (dgvClientes.CurrentRow != null && dgvClientes.CurrentRow.DataBoundItem is ClienteEN cliente)
            {
                _clienteSeleccionadoID = cliente.ClienteID;
                txtNombre.Text = cliente.NombreCompleto ?? string.Empty;
                txtTelefono.Text = cliente.Telefono ?? string.Empty;
                txtCorreo.Text = cliente.Correo ?? string.Empty;
                txtDireccion.Text = cliente.Direccion ?? string.Empty;

                ActualizarEstadoBotones(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarMensaje("El nombre completo del cliente es obligatorio.", true, txtNombre);
                return;
            }

            if (string.IsNullOrWhiteSpace(telefono))
            {
                MostrarMensaje("El número de teléfono es obligatorio.", true, txtTelefono);
                return;
            }

            try
            {
                ClienteEN nuevoCliente = new ClienteEN
                {
                    NombreCompleto = nombre,
                    Telefono = telefono,
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                _clienteBL.RegistrarCliente(nuevoCliente);
                MostrarMensaje("Cliente registrado exitosamente.", false);
                MessageBox.Show("Cliente registrado exitosamente en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true, txtNombre);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionadoID <= 0)
            {
                MostrarMensaje("Seleccione un cliente del listado para modificar.", true);
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string telefono = txtTelefono.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarMensaje("El nombre completo es obligatorio.", true, txtNombre);
                return;
            }

            if (string.IsNullOrWhiteSpace(telefono))
            {
                MostrarMensaje("El teléfono es obligatorio.", true, txtTelefono);
                return;
            }

            try
            {
                ClienteEN clienteModificar = new ClienteEN
                {
                    ClienteID = _clienteSeleccionadoID,
                    NombreCompleto = nombre,
                    Telefono = telefono,
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Estado = "Activo"
                };

                _clienteBL.ModificarCliente(clienteModificar);
                MostrarMensaje("Datos del cliente actualizados correctamente.", false);
                MessageBox.Show("Cliente modificado exitosamente.", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarClientes();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_clienteSeleccionadoID <= 0)
            {
                MostrarMensaje("Seleccione un cliente para eliminar.", true);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro de que desea eliminar al cliente '{txtNombre.Text.Trim()}'?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _clienteBL.EliminarCliente(_clienteSeleccionadoID);
                    MostrarMensaje("Cliente dado de baja exitosamente.", false);
                    MessageBox.Show("El cliente ha sido eliminado.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarClientes();
                }
                catch (Exception ex)
                {
                    MostrarMensaje(ex.Message, true);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _clienteSeleccionadoID = 0;
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            lblMensaje.Visible = false;
            lblMensaje.Text = string.Empty;

            txtNombre.BackColor = Color.FromArgb(248, 250, 252);
            txtTelefono.BackColor = Color.FromArgb(248, 250, 252);
            txtCorreo.BackColor = Color.FromArgb(248, 250, 252);
            txtDireccion.BackColor = Color.FromArgb(248, 250, 252);

            ActualizarEstadoBotones(false);
            txtNombre.Focus();
        }
    }
}

