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
    public partial class FrmEmpleados : Form
    {
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();
        private List<EmpleadoEN> _listaEmpleados = new List<EmpleadoEN>();
        private int _empleadoSeleccionadoID = 0;

        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CargarLogotipo();
            EstilizarGrid();
            cboEstado.SelectedItem = "Activo";
            CargarEmpleados();
            ActualizarEstadoBotones(false);
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
                        g.DrawString("🔧", new Font("Segoe UI", 12F), Brushes.DarkBlue, 8, 8);
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
            dgvEmpleados.BackgroundColor = Color.White;
            dgvEmpleados.BorderStyle = BorderStyle.None;
            dgvEmpleados.GridColor = Color.FromArgb(241, 245, 249);
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.EnableHeadersVisualStyles = false;
            dgvEmpleados.ColumnHeadersHeight = 36;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmpleados.DefaultCellStyle.BackColor = Color.White;
            dgvEmpleados.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvEmpleados.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvEmpleados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvEmpleados.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvEmpleados.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvEmpleados.RowTemplate.Height = 34;

            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.Columns.Clear();

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EmpleadoID",
                HeaderText = "ID",
                Width = 45,
                FillWeight = 25
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompleto",
                HeaderText = "Nombre Completo",
                FillWeight = 110
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cargo",
                HeaderText = "Cargo / Rol",
                FillWeight = 85
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Telefono",
                HeaderText = "Teléfono",
                Width = 105,
                FillWeight = 55
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Correo",
                HeaderText = "Correo Electrónico",
                FillWeight = 95
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Width = 75,
                FillWeight = 40
            });
        }

        private void CargarEmpleados()
        {
            try
            {
                _listaEmpleados = _empleadoBL.ObtenerTodosEmpleados() ?? new List<EmpleadoEN>();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar empleados: {ex.Message}", true);
            }
        }

        private void AplicarFiltro()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            // Solo se muestran los empleados activos: los dados de baja (Eliminar)
            // no deben seguir apareciendo en el listado.
            IEnumerable<EmpleadoEN> baseLista = _listaEmpleados.Where(e => e.Estado == "Activo");

            List<EmpleadoEN> filtrados;
            if (string.IsNullOrEmpty(filtro))
            {
                filtrados = baseLista.ToList();
            }
            else
            {
                filtrados = baseLista.Where(e =>
                    (e.NombreCompleto != null && e.NombreCompleto.ToLower().Contains(filtro)) ||
                    (e.Cargo != null && e.Cargo.ToLower().Contains(filtro)) ||
                    (e.Telefono != null && e.Telefono.ToLower().Contains(filtro)) ||
                    (e.Correo != null && e.Correo.ToLower().Contains(filtro)) ||
                    (e.Estado != null && e.Estado.ToLower().Contains(filtro))
                ).ToList();
            }

            dgvEmpleados.DataSource = null;
            dgvEmpleados.DataSource = filtrados;

            int activos = filtrados.Count(e => e.Estado == "Activo");
            lblTotalEmpleados.Text = $"Total empleados: {filtrados.Count} ({activos} activos)";
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarEmpleados();
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (lblMensaje.Visible)
            {
                lblMensaje.Visible = false;
                lblMensaje.Text = string.Empty;
                txtNombre.BackColor = Color.FromArgb(248, 250, 252);
                cboCargo.BackColor = Color.FromArgb(248, 250, 252);
                txtTelefono.BackColor = Color.FromArgb(248, 250, 252);
                txtCorreo.BackColor = Color.FromArgb(248, 250, 252);
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

        private void DgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarEmpleadoSeleccionado();
        }

        private void DgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            CargarEmpleadoSeleccionado();
        }

        private void CargarEmpleadoSeleccionado()
        {
            if (dgvEmpleados.CurrentRow != null && dgvEmpleados.CurrentRow.DataBoundItem is EmpleadoEN emp)
            {
                _empleadoSeleccionadoID = emp.EmpleadoID;
                txtNombre.Text = emp.NombreCompleto ?? string.Empty;
                cboCargo.Text = emp.Cargo ?? string.Empty;
                txtTelefono.Text = emp.Telefono ?? string.Empty;
                txtCorreo.Text = emp.Correo ?? string.Empty;
                cboEstado.SelectedItem = string.IsNullOrWhiteSpace(emp.Estado) ? "Activo" : emp.Estado;

                ActualizarEstadoBotones(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string cargo = cboCargo.Text.Trim();
            string estado = cboEstado.SelectedItem?.ToString() ?? "Activo";

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarMensaje("El nombre completo del empleado es obligatorio.", true, txtNombre);
                return;
            }

            if (string.IsNullOrWhiteSpace(cargo))
            {
                MostrarMensaje("El cargo o rol del empleado es obligatorio.", true, cboCargo);
                return;
            }

            try
            {
                EmpleadoEN nuevoEmpleado = new EmpleadoEN
                {
                    NombreCompleto = nombre,
                    Cargo = cargo,
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Estado = estado
                };

                _empleadoBL.RegistrarEmpleado(nuevoEmpleado);
                MostrarMensaje("Empleado registrado exitosamente.", false);
                MessageBox.Show("Empleado registrado exitosamente en el sistema.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true, txtNombre);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_empleadoSeleccionadoID <= 0)
            {
                MostrarMensaje("Seleccione un empleado del listado para modificar.", true);
                return;
            }

            string nombre = txtNombre.Text.Trim();
            string cargo = cboCargo.Text.Trim();
            string estado = cboEstado.SelectedItem?.ToString() ?? "Activo";

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MostrarMensaje("El nombre completo es obligatorio.", true, txtNombre);
                return;
            }

            if (string.IsNullOrWhiteSpace(cargo))
            {
                MostrarMensaje("El cargo o rol es obligatorio.", true, cboCargo);
                return;
            }

            try
            {
                EmpleadoEN empleadoModificar = new EmpleadoEN
                {
                    EmpleadoID = _empleadoSeleccionadoID,
                    NombreCompleto = nombre,
                    Cargo = cargo,
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Estado = estado
                };

                _empleadoBL.ModificarEmpleado(empleadoModificar);
                MostrarMensaje("Datos del empleado actualizados correctamente.", false);
                MessageBox.Show("Empleado modificado exitosamente.", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_empleadoSeleccionadoID <= 0)
            {
                MostrarMensaje("Seleccione un empleado para dar de baja.", true);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro de que desea dar de baja al empleado '{txtNombre.Text.Trim()}'?",
                "Confirmar Baja de Empleado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _empleadoBL.EliminarEmpleado(_empleadoSeleccionadoID);
                    MostrarMensaje("Empleado dado de baja exitosamente.", false);
                    MessageBox.Show("El empleado ha sido dado de baja.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarEmpleados();
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
            _empleadoSeleccionadoID = 0;
            txtNombre.Clear();
            cboCargo.SelectedIndex = -1;
            cboCargo.Text = string.Empty;
            txtTelefono.Clear();
            txtCorreo.Clear();
            cboEstado.SelectedItem = "Activo";
            lblMensaje.Visible = false;
            lblMensaje.Text = string.Empty;

            txtNombre.BackColor = Color.FromArgb(248, 250, 252);
            cboCargo.BackColor = Color.FromArgb(248, 250, 252);
            txtTelefono.BackColor = Color.FromArgb(248, 250, 252);
            txtCorreo.BackColor = Color.FromArgb(248, 250, 252);

            ActualizarEstadoBotones(false);
            txtNombre.Focus();
        }
    }
}


