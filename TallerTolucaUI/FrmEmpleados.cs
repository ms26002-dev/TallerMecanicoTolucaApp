using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmEmpleados : Form
    {
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();

        private List<EmpleadoEN> _todosLosEmpleados = new List<EmpleadoEN>();
        private List<EmpleadoEN> _empleadosFiltrados = new List<EmpleadoEN>();

        private const int TamanoPagina = 6;
        private int _paginaActual = 1;
        private int _empleadoIdEnEdicion = 0;

        public FrmEmpleados()
        {
            InitializeComponent();
            CargarEmpleados();
        }

        // ============================================
        // Carga y Filtrado
        // ============================================

        private void CargarEmpleados()
        {
            try
            {
                _todosLosEmpleados = _empleadoBL.ObtenerTodosLosEmpleados();
            }
            catch (Exception)
            {
                // Si la tabla aún no tiene datos o conexión local
                _todosLosEmpleados = new List<EmpleadoEN>();
            }

            _paginaActual = 1;
            AplicarFiltros();
        }

        private void FiltrosCambiaron(object? sender, EventArgs e)
        {
            _paginaActual = 1;
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim();
            string cargo = cboCargoFiltro.SelectedItem?.ToString() ?? "Todos los cargos";
            string estado = cboEstadoFiltro.SelectedItem?.ToString() ?? "Todos los estados";

            IEnumerable<EmpleadoEN> consulta = _todosLosEmpleados;

            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(e =>
                    (e.NombreCompleto ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (e.Telefono ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    e.EmpleadoID.ToString().Contains(texto));
            }

            if (cargo != "Todos los cargos")
            {
                consulta = consulta.Where(e => e.Cargo == cargo);
            }

            if (estado != "Todos los estados")
            {
                consulta = consulta.Where(e => e.Estado == estado);
            }

            _empleadosFiltrados = consulta.ToList();
            MostrarPagina();
        }

        // ============================================
        // Paginación
        // ============================================

        private int TotalPaginas => Math.Max(1, (int)Math.Ceiling(_empleadosFiltrados.Count / (double)TamanoPagina));

        private void MostrarPagina()
        {
            if (_paginaActual > TotalPaginas) _paginaActual = TotalPaginas;
            if (_paginaActual < 1) _paginaActual = 1;

            var pagina = _empleadosFiltrados
                .Skip((_paginaActual - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .ToList();

            dgvEmpleados.Rows.Clear();
            foreach (var emp in pagina)
            {
                int fila = dgvEmpleados.Rows.Add(
                    $"EMP-{emp.EmpleadoID:000}",
                    emp.NombreCompleto,
                    emp.Cargo,
                    emp.Telefono,
                    emp.Estado,
                    "Editar",
                    "Eliminar");
                dgvEmpleados.Rows[fila].Tag = emp.EmpleadoID;
            }

            ActualizarResumenYPaginador();
        }

        private void ActualizarResumenYPaginador()
        {
            int total = _empleadosFiltrados.Count;
            int desde = total == 0 ? 0 : ((_paginaActual - 1) * TamanoPagina) + 1;
            int hasta = Math.Min(_paginaActual * TamanoPagina, total);
            lblResumenRegistros.Text = total == 0
                ? "No se encontraron empleados"
                : $"Mostrando {desde}–{hasta} de {total} empleados";

            flpPaginas.Controls.Clear();

            var btnAnterior = CrearBotonPagina("‹", false);
            btnAnterior.Enabled = _paginaActual > 1;
            btnAnterior.Click += (s, e) => { _paginaActual--; MostrarPagina(); };
            flpPaginas.Controls.Add(btnAnterior);

            for (int i = 1; i <= TotalPaginas; i++)
            {
                int numeroPagina = i;
                var btnPagina = CrearBotonPagina(i.ToString(), i == _paginaActual);
                btnPagina.Click += (s, e) => { _paginaActual = numeroPagina; MostrarPagina(); };
                flpPaginas.Controls.Add(btnPagina);
            }

            var btnSiguiente = CrearBotonPagina("›", false);
            btnSiguiente.Enabled = _paginaActual < TotalPaginas;
            btnSiguiente.Click += (s, e) => { _paginaActual++; MostrarPagina(); };
            flpPaginas.Controls.Add(btnSiguiente);
        }

        private Button CrearBotonPagina(string texto, bool activa)
        {
            var btn = new Button
            {
                Text = texto,
                Size = new Size(32, 32),
                Font = new Font("Segoe UI", 9.5F, activa ? FontStyle.Bold : FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(3, 0, 0, 0)
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btn.FlatAppearance.BorderSize = 1;
            if (activa)
            {
                btn.BackColor = Color.FromArgb(0, 191, 255);
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
            }
            else
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(51, 65, 85);
            }
            return btn;
        }

        // ============================================
        // Badge de Estado y Botones de Acción
        // ============================================

        private void dgvEmpleados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvEmpleados.Columns[e.ColumnIndex].Name != "Estado" || e.Value == null) return;

            bool activo = e.Value.ToString() == "Activo";
            var celda = dgvEmpleados.Rows[e.RowIndex].Cells[e.ColumnIndex];
            celda.Style.BackColor = activo ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
            celda.Style.ForeColor = activo ? Color.FromArgb(21, 128, 61) : Color.FromArgb(185, 28, 28);
            celda.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            celda.Style.SelectionBackColor = celda.Style.BackColor;
            celda.Style.SelectionForeColor = celda.Style.ForeColor;
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columna = dgvEmpleados.Columns[e.ColumnIndex].Name;
            if (columna != "Editar" && columna != "Eliminar") return;

            int empleadoId = (int)dgvEmpleados.Rows[e.RowIndex].Tag;
            var empleado = _todosLosEmpleados.FirstOrDefault(x => x.EmpleadoID == empleadoId);
            if (empleado == null) return;

            if (columna == "Editar")
            {
                AbrirFormularioEdicion(empleado);
            }
            else if (columna == "Eliminar")
            {
                var resp = MessageBox.Show($"¿Desea cambiar el estado del empleado \"{empleado.NombreCompleto}\" a Inactivo?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    try
                    {
                        _empleadoBL.EliminarEmpleado(empleadoId);
                        MessageBox.Show("Empleado actualizado a estado Inactivo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEmpleados();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ============================================
        // Formulario de Registro y Edición
        // ============================================

        private void btnNuevoRegistro_Click(object? sender, EventArgs e)
        {
            _empleadoIdEnEdicion = 0;
            lblTituloForm.Text = "➕ Registrar Nuevo Empleado";
            txtFormId.Text = "Auto-generado";
            txtFormNombre.Clear();
            txtFormTelefono.Clear();
            cboFormCargo.SelectedIndex = 0;
            cboFormEstado.SelectedIndex = 0;
            pnlFormularioRegistro.Visible = true;
            pnlFormularioRegistro.BringToFront();
            txtFormNombre.Focus();
        }

        private void AbrirFormularioEdicion(EmpleadoEN emp)
        {
            _empleadoIdEnEdicion = emp.EmpleadoID;
            lblTituloForm.Text = $"✏️ Editar Empleado (EMP-{emp.EmpleadoID:000})";
            txtFormId.Text = $"EMP-{emp.EmpleadoID:000}";
            txtFormNombre.Text = emp.NombreCompleto;
            txtFormTelefono.Text = emp.Telefono;
            cboFormCargo.SelectedItem = emp.Cargo;
            cboFormEstado.SelectedItem = emp.Estado;
            pnlFormularioRegistro.Visible = true;
            pnlFormularioRegistro.BringToFront();
            txtFormNombre.Focus();
        }

        private void btnFormCancelar_Click(object? sender, EventArgs e)
        {
            pnlFormularioRegistro.Visible = false;
        }

        private void btnFormGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                string nombre = txtFormNombre.Text.Trim();
                string telefono = txtFormTelefono.Text.Trim();
                string cargo = cboFormCargo.SelectedItem?.ToString() ?? "Ayudante General";
                string estado = cboFormEstado.SelectedItem?.ToString() ?? "Activo";

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre completo del empleado es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_empleadoIdEnEdicion == 0)
                {
                    // Nuevo
                    var nuevo = new EmpleadoEN
                    {
                        NombreCompleto = nombre,
                        Cargo = cargo,
                        Telefono = telefono,
                        Estado = estado
                    };
                    _empleadoBL.RegistrarEmpleado(nuevo);
                    MessageBox.Show("Empleado registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Modificar
                    var editado = new EmpleadoEN
                    {
                        EmpleadoID = _empleadoIdEnEdicion,
                        NombreCompleto = nombre,
                        Cargo = cargo,
                        Telefono = telefono,
                        Estado = estado
                    };
                    _empleadoBL.ModificarEmpleado(editado);
                    MessageBox.Show("Datos del empleado actualizados exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                pnlFormularioRegistro.Visible = false;
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Guardar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
