using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class FrmEmpleados
    {
        private System.ComponentModel.IContainer components = null;

        // Encabezado
        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnNuevoRegistro;

        // Filtros y Búsqueda
        private Panel pnlFiltros;
        private TextBox txtBuscar;
        private ComboBox cboEstadoFiltro;
        private ComboBox cboCargoFiltro;

        // Tabla
        private DataGridView dgvEmpleados;

        // Paginación
        private Panel pnlPaginacion;
        private Label lblResumenRegistros;
        private FlowLayoutPanel flpPaginas;

        // Panel Modal/Slide para Registro y Edición (según imagen 7)
        private Panel pnlFormularioRegistro;
        private Label lblTituloForm;
        private Label lblIdEmpleado;
        private TextBox txtFormId;
        private Label lblCargo;
        private ComboBox cboFormCargo;
        private Label lblNombre;
        private TextBox txtFormNombre;
        private Label lblTelefono;
        private TextBox txtFormTelefono;
        private Label lblEstado;
        private ComboBox cboFormEstado;
        private Button btnFormCancelar;
        private Button btnFormGuardar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            btnNuevoRegistro = new Button();

            pnlFiltros = new Panel();
            txtBuscar = new TextBox();
            cboEstadoFiltro = new ComboBox();
            cboCargoFiltro = new ComboBox();

            dgvEmpleados = new DataGridView();
            pnlPaginacion = new Panel();
            lblResumenRegistros = new Label();
            flpPaginas = new FlowLayoutPanel();

            pnlFormularioRegistro = new Panel();
            lblTituloForm = new Label();
            lblIdEmpleado = new Label();
            txtFormId = new TextBox();
            lblCargo = new Label();
            cboFormCargo = new ComboBox();
            lblNombre = new Label();
            txtFormNombre = new TextBox();
            lblTelefono = new Label();
            txtFormTelefono = new TextBox();
            lblEstado = new Label();
            cboFormEstado = new ComboBox();
            btnFormCancelar = new Button();
            btnFormGuardar = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
            pnlHeader.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlPaginacion.SuspendLayout();
            pnlFormularioRegistro.SuspendLayout();
            SuspendLayout();

            // ============================================
            // pnlHeader (Encabezado Superior)
            // ============================================
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 75;
            pnlHeader.BackColor = Color.FromArgb(240, 248, 255);
            pnlHeader.Controls.Add(btnNuevoRegistro);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);

            lblTitulo.Text = "Gestión de Empleados";
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Registra y gestiona el personal técnico y administrativo del taller.";
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitulo.Location = new Point(27, 47);
            lblSubtitulo.AutoSize = true;

            btnNuevoRegistro.Text = "+ Nuevo Registro";
            btnNuevoRegistro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoRegistro.BackColor = Color.FromArgb(0, 191, 255); // #00BFFF Cyan
            btnNuevoRegistro.ForeColor = Color.White;
            btnNuevoRegistro.FlatStyle = FlatStyle.Flat;
            btnNuevoRegistro.FlatAppearance.BorderSize = 0;
            btnNuevoRegistro.Size = new Size(165, 40);
            btnNuevoRegistro.Location = new Point(780, 18);
            btnNuevoRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoRegistro.Cursor = Cursors.Hand;
            btnNuevoRegistro.Click += btnNuevoRegistro_Click;

            // ============================================
            // pnlFiltros (Barra de Búsqueda y Filtros)
            // ============================================
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Height = 55;
            pnlFiltros.BackColor = Color.FromArgb(240, 248, 255);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(cboCargoFiltro);
            pnlFiltros.Controls.Add(cboEstadoFiltro);

            txtBuscar.Location = new Point(25, 8);
            txtBuscar.Size = new Size(420, 33);
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.BackColor = Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            txtBuscar.PlaceholderText = "🔍  Buscar empleado por nombre o teléfono...";
            txtBuscar.TextChanged += FiltrosCambiaron;

            cboCargoFiltro.Location = new Point(460, 8);
            cboCargoFiltro.Size = new Size(240, 33);
            cboCargoFiltro.Font = new Font("Segoe UI", 10F);
            cboCargoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCargoFiltro.FlatStyle = FlatStyle.Flat;
            cboCargoFiltro.BackColor = Color.FromArgb(248, 250, 252);
            cboCargoFiltro.Items.AddRange(new object[] { "Todos los cargos", "Mecánico Jefe", "Especialista Eléctrico", "Ayudante General", "Atención al Cliente", "Administrador" });
            cboCargoFiltro.SelectedIndex = 0;
            cboCargoFiltro.SelectedIndexChanged += FiltrosCambiaron;

            cboEstadoFiltro.Location = new Point(715, 8);
            cboEstadoFiltro.Size = new Size(180, 33);
            cboEstadoFiltro.Font = new Font("Segoe UI", 10F);
            cboEstadoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoFiltro.FlatStyle = FlatStyle.Flat;
            cboEstadoFiltro.BackColor = Color.FromArgb(248, 250, 252);
            cboEstadoFiltro.Items.AddRange(new object[] { "Todos los estados", "Activo", "Inactivo" });
            cboEstadoFiltro.SelectedIndex = 0;
            cboEstadoFiltro.SelectedIndexChanged += FiltrosCambiaron;

            // ============================================
            // dgvEmpleados (Tabla Principal)
            // ============================================
            dgvEmpleados.Dock = DockStyle.Fill;
            dgvEmpleados.BackgroundColor = Color.White;
            dgvEmpleados.BorderStyle = BorderStyle.None;
            dgvEmpleados.GridColor = Color.FromArgb(226, 232, 240);
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.EnableHeadersVisualStyles = false;
            dgvEmpleados.ColumnHeadersHeight = 42;
            dgvEmpleados.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvEmpleados.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvEmpleados.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvEmpleados.DefaultCellStyle.BackColor = Color.White;
            dgvEmpleados.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvEmpleados.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvEmpleados.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 245, 255);
            dgvEmpleados.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvEmpleados.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
            dgvEmpleados.RowTemplate.Height = 44;
            dgvEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.ReadOnly = true;
            ConfigurarColumnasEmpleados(dgvEmpleados);
            dgvEmpleados.CellFormatting += dgvEmpleados_CellFormatting;
            dgvEmpleados.CellContentClick += dgvEmpleados_CellContentClick;

            // ============================================
            // pnlPaginacion (Pie de página)
            // ============================================
            pnlPaginacion.Dock = DockStyle.Bottom;
            pnlPaginacion.Height = 50;
            pnlPaginacion.BackColor = Color.FromArgb(240, 248, 255);
            pnlPaginacion.Controls.Add(lblResumenRegistros);
            pnlPaginacion.Controls.Add(flpPaginas);

            lblResumenRegistros.AutoSize = true;
            lblResumenRegistros.Font = new Font("Segoe UI", 9.5F);
            lblResumenRegistros.ForeColor = Color.FromArgb(100, 116, 139);
            lblResumenRegistros.Location = new Point(25, 15);

            flpPaginas.FlowDirection = FlowDirection.LeftToRight;
            flpPaginas.Location = new Point(620, 8);
            flpPaginas.Size = new Size(330, 36);
            flpPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpPaginas.WrapContents = false;

            // ============================================
            // pnlFormularioRegistro (Tarjeta de Formulario)
            // ============================================
            pnlFormularioRegistro.Visible = false;
            pnlFormularioRegistro.Size = new Size(720, 340);
            pnlFormularioRegistro.BackColor = Color.White;
            pnlFormularioRegistro.Location = new Point(120, 120);
            pnlFormularioRegistro.Anchor = AnchorStyles.None;
            pnlFormularioRegistro.BorderStyle = BorderStyle.FixedSingle;

            lblTituloForm.Text = "➕ Registrar Nuevo Empleado";
            lblTituloForm.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.FromArgb(15, 23, 42);
            lblTituloForm.Location = new Point(30, 20);
            lblTituloForm.AutoSize = true;

            // ID del Empleado
            lblIdEmpleado.Text = "ID del Empleado";
            lblIdEmpleado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIdEmpleado.ForeColor = Color.FromArgb(71, 85, 105);
            lblIdEmpleado.Location = new Point(30, 65);
            lblIdEmpleado.AutoSize = true;

            txtFormId.Location = new Point(30, 90);
            txtFormId.Size = new Size(310, 31);
            txtFormId.Font = new Font("Segoe UI", 10F);
            txtFormId.BackColor = Color.FromArgb(241, 245, 249);
            txtFormId.ReadOnly = true;
            txtFormId.Text = "Auto-generado";

            // Cargo / Puesto
            lblCargo.Text = "Cargo / Puesto *";
            lblCargo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCargo.ForeColor = Color.FromArgb(71, 85, 105);
            lblCargo.Location = new Point(370, 65);
            lblCargo.AutoSize = true;

            cboFormCargo.Location = new Point(370, 90);
            cboFormCargo.Size = new Size(310, 31);
            cboFormCargo.Font = new Font("Segoe UI", 10F);
            cboFormCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormCargo.FlatStyle = FlatStyle.Flat;
            cboFormCargo.BackColor = Color.FromArgb(248, 250, 252);
            cboFormCargo.Items.AddRange(new object[] { "Mecánico Jefe", "Especialista Eléctrico", "Ayudante General", "Atención al Cliente", "Administrador" });
            cboFormCargo.SelectedIndex = 0;

            // Nombre Completo
            lblNombre.Text = "Nombre Completo *";
            lblNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNombre.ForeColor = Color.FromArgb(71, 85, 105);
            lblNombre.Location = new Point(30, 135);
            lblNombre.AutoSize = true;

            txtFormNombre.Location = new Point(30, 160);
            txtFormNombre.Size = new Size(650, 31);
            txtFormNombre.Font = new Font("Segoe UI", 10F);
            txtFormNombre.BackColor = Color.FromArgb(248, 250, 252);
            txtFormNombre.PlaceholderText = "Ej. Juan Pérez García";

            // Teléfono
            lblTelefono.Text = "Teléfono de Contacto *";
            lblTelefono.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTelefono.ForeColor = Color.FromArgb(71, 85, 105);
            lblTelefono.Location = new Point(30, 205);
            lblTelefono.AutoSize = true;

            txtFormTelefono.Location = new Point(30, 230);
            txtFormTelefono.Size = new Size(310, 31);
            txtFormTelefono.Font = new Font("Segoe UI", 10F);
            txtFormTelefono.BackColor = Color.FromArgb(248, 250, 252);
            txtFormTelefono.PlaceholderText = "Ej. 7788-9900";

            // Estado
            lblEstado.Text = "Estado Actual";
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.ForeColor = Color.FromArgb(71, 85, 105);
            lblEstado.Location = new Point(370, 205);
            lblEstado.AutoSize = true;

            cboFormEstado.Location = new Point(370, 230);
            cboFormEstado.Size = new Size(310, 31);
            cboFormEstado.Font = new Font("Segoe UI", 10F);
            cboFormEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormEstado.FlatStyle = FlatStyle.Flat;
            cboFormEstado.BackColor = Color.FromArgb(248, 250, 252);
            cboFormEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cboFormEstado.SelectedIndex = 0;

            // Botones Formulario
            btnFormCancelar.Text = "CANCELAR";
            btnFormCancelar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnFormCancelar.BackColor = Color.White;
            btnFormCancelar.ForeColor = Color.FromArgb(71, 85, 105);
            btnFormCancelar.FlatStyle = FlatStyle.Flat;
            btnFormCancelar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnFormCancelar.Size = new Size(140, 42);
            btnFormCancelar.Location = new Point(370, 280);
            btnFormCancelar.Cursor = Cursors.Hand;
            btnFormCancelar.Click += btnFormCancelar_Click;

            btnFormGuardar.Text = "💾 GUARDAR EMPLEADO";
            btnFormGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnFormGuardar.BackColor = Color.FromArgb(2, 132, 199); // DeepSkyBlue / Blue
            btnFormGuardar.ForeColor = Color.White;
            btnFormGuardar.FlatStyle = FlatStyle.Flat;
            btnFormGuardar.FlatAppearance.BorderSize = 0;
            btnFormGuardar.Size = new Size(180, 42);
            btnFormGuardar.Location = new Point(520, 280);
            btnFormGuardar.Cursor = Cursors.Hand;
            btnFormGuardar.Click += btnFormGuardar_Click;

            pnlFormularioRegistro.Controls.AddRange(new Control[] {
                lblTituloForm, lblIdEmpleado, txtFormId, lblCargo, cboFormCargo,
                lblNombre, txtFormNombre, lblTelefono, txtFormTelefono,
                lblEstado, cboFormEstado, btnFormCancelar, btnFormGuardar
            });

            // ============================================
            // FrmEmpleados (Contenedor Principal)
            // ============================================
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(980, 600);
            Controls.Add(pnlFormularioRegistro);
            Controls.Add(dgvEmpleados);
            Controls.Add(pnlPaginacion);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmEmpleados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Empleados";
            Padding = new Padding(20, 10, 20, 15);

            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlPaginacion.ResumeLayout(false);
            pnlPaginacion.PerformLayout();
            pnlFormularioRegistro.ResumeLayout(false);
            pnlFormularioRegistro.PerformLayout();
            ResumeLayout(false);
        }

        private void ConfigurarColumnasEmpleados(DataGridView grid)
        {
            grid.Columns.Add("EmpleadoID", "EMPLEADOID");
            grid.Columns.Add("NombreCompleto", "NOMBRE COMPLETO");
            grid.Columns.Add("Cargo", "CARGO");
            grid.Columns.Add("Telefono", "TELÉFONO");
            grid.Columns.Add("Estado", "ESTADO");

            var colEditar = new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            colEditar.DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199);
            colEditar.DefaultCellStyle.ForeColor = Color.FromArgb(146, 64, 14);
            colEditar.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colEditar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 243, 199);
            colEditar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(146, 64, 14);

            var colEliminar = new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                HeaderText = "ACCIONES",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            colEliminar.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
            colEliminar.DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            colEliminar.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colEliminar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 226);
            colEliminar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(185, 28, 28);

            grid.Columns.Add(colEditar);
            grid.Columns.Add(colEliminar);

            grid.Columns["EmpleadoID"].FillWeight = 80;
            grid.Columns["NombreCompleto"].FillWeight = 200;
            grid.Columns["Cargo"].FillWeight = 140;
            grid.Columns["Telefono"].FillWeight = 100;
            grid.Columns["Estado"].FillWeight = 80;
            grid.Columns["Editar"].FillWeight = 70;
            grid.Columns["Eliminar"].FillWeight = 80;

            grid.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
