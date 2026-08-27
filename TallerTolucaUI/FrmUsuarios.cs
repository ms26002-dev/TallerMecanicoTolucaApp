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
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();
        private List<UsuarioEN> _listaUsuarios = new List<UsuarioEN>();
        private int _usuarioSeleccionadoID = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarLogotipo();
            EstilizarGrid();
            CargarEmpleadosEnCombo();
            cboEstado.SelectedItem = "Activo";
            CargarUsuarios();
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
                        g.DrawString("🔑", new Font("Segoe UI", 12F), Brushes.DarkBlue, 8, 8);
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
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.GridColor = Color.FromArgb(241, 245, 249);
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.EnableHeadersVisualStyles = false;
            dgvUsuarios.ColumnHeadersHeight = 36;
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvUsuarios.DefaultCellStyle.BackColor = Color.White;
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvUsuarios.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvUsuarios.RowTemplate.Height = 34;

            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UsuarioID",
                HeaderText = "ID",
                Width = 45,
                FillWeight = 25
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreUsuario",
                HeaderText = "Usuario",
                FillWeight = 90
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreEmpleado",
                HeaderText = "Empleado",
                FillWeight = 110
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Rol",
                HeaderText = "Rol",
                Width = 100,
                FillWeight = 65
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Estado",
                HeaderText = "Estado",
                Width = 75,
                FillWeight = 40
            });
        }

        private void CargarEmpleadosEnCombo()
        {
            try
            {
                var empleados = _empleadoBL.ObtenerEmpleadosActivos() ?? new List<EmpleadoEN>();
                cboEmpleado.DataSource = empleados;
                cboEmpleado.DisplayMember = "NombreCompleto";
                cboEmpleado.ValueMember = "EmpleadoID";
                cboEmpleado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar empleados: {ex.Message}", true);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                _listaUsuarios = _usuarioBL.ObtenerTodosUsuarios() ?? new List<UsuarioEN>();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar usuarios: {ex.Message}", true);
            }
        }

        private void AplicarFiltro()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            List<UsuarioEN> filtrados;
            if (string.IsNullOrEmpty(filtro))
            {
                filtrados = _listaUsuarios;
            }
            else
            {
                filtrados = _listaUsuarios.Where(u =>
                    (u.NombreUsuario != null && u.NombreUsuario.ToLower().Contains(filtro)) ||
                    (u.NombreEmpleado != null && u.NombreEmpleado.ToLower().Contains(filtro)) ||
                    (u.Rol != null && u.Rol.ToLower().Contains(filtro)) ||
                    (u.Estado != null && u.Estado.ToLower().Contains(filtro))
                ).ToList();
            }

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = filtrados;

            int activos = filtrados.Count(u => u.Estado == "Activo");
            lblTotalUsuarios.Text = $"Total usuarios: {filtrados.Count} ({activos} activos)";
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnRefrescar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarUsuarios();
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (lblMensaje.Visible)
            {
                lblMensaje.Visible = false;
                lblMensaje.Text = string.Empty;
                txtNombreUsuario.BackColor = Color.FromArgb(248, 250, 252);
                txtClave.BackColor = Color.FromArgb(248, 250, 252);
                txtConfirmarClave.BackColor = Color.FromArgb(248, 250, 252);
                cboEmpleado.BackColor = Color.FromArgb(248, 250, 252);
                cboRol.BackColor = Color.FromArgb(248, 250, 252);
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

            btnDesactivar.Enabled = haySeleccion;
            btnDesactivar.BackColor = haySeleccion ? Color.FromArgb(220, 38, 38) : Color.FromArgb(148, 163, 184);

            // Al editar un usuario existente, la contraseña es opcional (solo se cambia si se escribe algo)
            lblClave.Text = haySeleccion ? "Nueva Contraseña (opcional)" : "Contraseña *";
            lblConfirmarClave.Text = haySeleccion ? "Confirmar Nueva Contraseña" : "Confirmar Contraseña *";
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarUsuarioSeleccionado();
        }

        private void DgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            CargarUsuarioSeleccionado();
        }

        private void CargarUsuarioSeleccionado()
        {
            if (dgvUsuarios.CurrentRow != null && dgvUsuarios.CurrentRow.DataBoundItem is UsuarioEN usu)
            {
                _usuarioSeleccionadoID = usu.UsuarioID;
                cboEmpleado.SelectedValue = usu.EmpleadoID;
                txtNombreUsuario.Text = usu.NombreUsuario ?? string.Empty;
                txtClave.Clear();
                txtConfirmarClave.Clear();
                cboRol.Text = usu.Rol ?? string.Empty;
                cboEstado.SelectedItem = string.IsNullOrWhiteSpace(usu.Estado) ? "Activo" : usu.Estado;

                ActualizarEstadoBotones(true);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario(esNuevo: true, out string nombreUsuario, out string clave, out string rol, out string estado))
                return;

            try
            {
                UsuarioEN nuevoUsuario = new UsuarioEN
                {
                    EmpleadoID = (int)cboEmpleado.SelectedValue,
                    NombreUsuario = nombreUsuario,
                    ClaveHash = clave,
                    Rol = rol,
                    Estado = estado
                };

                _usuarioBL.CrearUsuario(nuevoUsuario);
                MostrarMensaje("Usuario creado exitosamente.", false);
                MessageBox.Show("El usuario fue creado y ya puede iniciar sesión con la contraseña asignada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true, txtNombreUsuario);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionadoID <= 0)
            {
                MostrarMensaje("Seleccione un usuario del listado para modificar.", true);
                return;
            }

            if (!ValidarFormulario(esNuevo: false, out string nombreUsuario, out string clave, out string rol, out string estado))
                return;

            try
            {
                UsuarioEN usuarioModificar = new UsuarioEN
                {
                    UsuarioID = _usuarioSeleccionadoID,
                    EmpleadoID = (int)cboEmpleado.SelectedValue,
                    NombreUsuario = nombreUsuario,
                    Rol = rol,
                    Estado = estado
                };

                _usuarioBL.ModificarUsuario(usuarioModificar, clave);
                MostrarMensaje("Usuario actualizado correctamente.", false);
                MessageBox.Show("Usuario modificado exitosamente.", "Modificación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true);
            }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (_usuarioSeleccionadoID <= 0)
            {
                MostrarMensaje("Seleccione un usuario para desactivar su acceso.", true);
                return;
            }

            if (_usuarioSeleccionadoID == SesionSistema.UsuarioID)
            {
                MostrarMensaje("No puede desactivar el usuario con el que tiene la sesión iniciada.", true);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"¿Está seguro de que desea desactivar el acceso del usuario '{txtNombreUsuario.Text.Trim()}'?\nNo podrá iniciar sesión hasta que sea reactivado.",
                "Confirmar Desactivación de Usuario",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _usuarioBL.CambiarEstado(_usuarioSeleccionadoID, "Inactivo");
                    MostrarMensaje("Acceso del usuario desactivado.", false);
                    MessageBox.Show("El usuario ya no podrá iniciar sesión.", "Operación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarFormulario();
                    CargarUsuarios();
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

        private bool ValidarFormulario(bool esNuevo, out string nombreUsuario, out string clave, out string rol, out string estado)
        {
            nombreUsuario = txtNombreUsuario.Text.Trim();
            clave = txtClave.Text;
            rol = cboRol.Text.Trim();
            estado = cboEstado.SelectedItem?.ToString() ?? "Activo";

            if (cboEmpleado.SelectedValue == null)
            {
                MostrarMensaje("Seleccione el empleado al que pertenece este usuario.", true, cboEmpleado);
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                MostrarMensaje("El nombre de usuario es obligatorio.", true, txtNombreUsuario);
                return false;
            }

            if (string.IsNullOrWhiteSpace(rol))
            {
                MostrarMensaje("Debe seleccionar un rol para el usuario.", true, cboRol);
                return false;
            }

            // En creación la contraseña es obligatoria; en edición solo si se desea cambiar
            if (esNuevo && string.IsNullOrWhiteSpace(clave))
            {
                MostrarMensaje("La contraseña es obligatoria.", true, txtClave);
                return false;
            }

            if (!string.IsNullOrEmpty(clave) || esNuevo)
            {
                if (clave.Trim().Length < 4)
                {
                    MostrarMensaje("La contraseña debe tener al menos 4 caracteres.", true, txtClave);
                    return false;
                }

                if (clave != txtConfirmarClave.Text)
                {
                    MostrarMensaje("Las contraseñas no coinciden.", true, txtConfirmarClave);
                    return false;
                }
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            _usuarioSeleccionadoID = 0;
            cboEmpleado.SelectedIndex = -1;
            txtNombreUsuario.Clear();
            txtClave.Clear();
            txtConfirmarClave.Clear();
            cboRol.SelectedIndex = -1;
            cboRol.Text = string.Empty;
            cboEstado.SelectedItem = "Activo";
            lblMensaje.Visible = false;
            lblMensaje.Text = string.Empty;

            txtNombreUsuario.BackColor = Color.FromArgb(248, 250, 252);
            txtClave.BackColor = Color.FromArgb(248, 250, 252);
            txtConfirmarClave.BackColor = Color.FromArgb(248, 250, 252);
            cboEmpleado.BackColor = Color.FromArgb(248, 250, 252);
            cboRol.BackColor = Color.FromArgb(248, 250, 252);

            ActualizarEstadoBotones(false);
            cboEmpleado.Focus();
        }
    }
}
