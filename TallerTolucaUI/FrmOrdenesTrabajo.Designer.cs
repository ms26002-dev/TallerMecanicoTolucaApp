using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class FrmOrdenesTrabajo
    {
        private System.ComponentModel.IContainer components = null;

        // Encabezado
        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnNuevaOrden;

        // Filtros y Búsqueda
        private Panel pnlFiltros;
        private TextBox txtBuscar;
        private ComboBox cboEstadoFiltro;

        // Tabla
        private DataGridView dgvOrdenes;

        // Paginación / Resumen
        private Panel pnlPaginacion;
        private Label lblResumenRegistros;

        // Panel Modal/Slide para Registro y Finalización
        private Panel pnlModalCrear;
        private Label lblTituloModalCrear;
        private Label lblClienteID;
        private TextBox txtClienteID;
        private Label lblVehiculoID;
        private TextBox txtVehiculoID;
        private Label lblEmpleadoID;
        private TextBox txtEmpleadoID;
        private Label lblKM;
        private TextBox txtKM;
        private Label lblDiagnostico;
        private TextBox txtDiagnostico;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Button btnCancelarCrear;
        private Button btnGuardarCrear;

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
            btnNuevaOrden = new Button();

            pnlFiltros = new Panel();
            txtBuscar = new TextBox();
            cboEstadoFiltro = new ComboBox();

            dgvOrdenes = new DataGridView();
            pnlPaginacion = new Panel();
            lblResumenRegistros = new Label();

            pnlModalCrear = new Panel();
            lblTituloModalCrear = new Label();
            lblClienteID = new Label();
            txtClienteID = new TextBox();
            lblVehiculoID = new Label();
            txtVehiculoID = new TextBox();
            lblEmpleadoID = new Label();
            txtEmpleadoID = new TextBox();
            lblKM = new Label();
            txtKM = new TextBox();
            lblDiagnostico = new Label();
            txtDiagnostico = new TextBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            btnCancelarCrear = new Button();
            btnGuardarCrear = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            pnlHeader.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlPaginacion.SuspendLayout();
            pnlModalCrear.SuspendLayout();
            SuspendLayout();

            // ============================================
            // pnlHeader (Encabezado Superior)
            // ============================================
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 75;
            pnlHeader.BackColor = Color.FromArgb(240, 248, 255);
            pnlHeader.Controls.Add(btnNuevaOrden);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);

            lblTitulo.Text = "Gestión de Órdenes de Trabajo";
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Administración, seguimiento de mecánicos y finalización de servicios mecánicos.";
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitulo.Location = new Point(27, 47);
            lblSubtitulo.AutoSize = true;

            btnNuevaOrden.Text = "+ Crear Orden de Trabajo";
            btnNuevaOrden.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevaOrden.BackColor = Color.FromArgb(0, 191, 255); // #00BFFF
            btnNuevaOrden.ForeColor = Color.White;
            btnNuevaOrden.FlatStyle = FlatStyle.Flat;
            btnNuevaOrden.FlatAppearance.BorderSize = 0;
            btnNuevaOrden.Size = new Size(210, 40);
            btnNuevaOrden.Location = new Point(735, 18);
            btnNuevaOrden.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaOrden.Cursor = Cursors.Hand;
            btnNuevaOrden.Click += btnNuevaOrden_Click;

            // ============================================
            // pnlFiltros (Barra de Búsqueda y Filtros)
            // ============================================
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Height = 55;
            pnlFiltros.BackColor = Color.FromArgb(240, 248, 255);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(cboEstadoFiltro);

            txtBuscar.Location = new Point(25, 8);
            txtBuscar.Size = new Size(680, 33);
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.BackColor = Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            txtBuscar.PlaceholderText = "🔍  Buscar orden por ID, cliente, mecánico o diagnóstico...";
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();

            cboEstadoFiltro.Location = new Point(720, 8);
            cboEstadoFiltro.Size = new Size(225, 33);
            cboEstadoFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboEstadoFiltro.Font = new Font("Segoe UI", 10F);
            cboEstadoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoFiltro.FlatStyle = FlatStyle.Flat;
            cboEstadoFiltro.BackColor = Color.FromArgb(248, 250, 252);
            cboEstadoFiltro.Items.AddRange(new object[] { "Todos los estados", "Pendiente", "En Proceso", "Finalizada" });
            cboEstadoFiltro.SelectedIndex = 0;
            cboEstadoFiltro.SelectedIndexChanged += (s, e) => AplicarFiltros();

            // ============================================
            // dgvOrdenes (Tabla)
            // ============================================
            dgvOrdenes.Dock = DockStyle.Fill;
            dgvOrdenes.BackgroundColor = Color.White;
            dgvOrdenes.BorderStyle = BorderStyle.None;
            dgvOrdenes.GridColor = Color.FromArgb(226, 232, 240);
            dgvOrdenes.RowHeadersVisible = false;
            dgvOrdenes.EnableHeadersVisualStyles = false;
            dgvOrdenes.ColumnHeadersHeight = 42;
            dgvOrdenes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvOrdenes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvOrdenes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvOrdenes.DefaultCellStyle.BackColor = Color.White;
            dgvOrdenes.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvOrdenes.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvOrdenes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 245, 255);
            dgvOrdenes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvOrdenes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
            dgvOrdenes.RowTemplate.Height = 44;
            dgvOrdenes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.MultiSelect = false;
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.AllowUserToDeleteRows = false;
            dgvOrdenes.ReadOnly = true;
            ConfigurarColumnasOrdenes(dgvOrdenes);
            dgvOrdenes.CellContentClick += dgvOrdenes_CellContentClick;
            dgvOrdenes.CellFormatting += dgvOrdenes_CellFormatting;

            // ============================================
            // pnlPaginacion (Pie de página)
            // ============================================
            pnlPaginacion.Dock = DockStyle.Bottom;
            pnlPaginacion.Height = 45;
            pnlPaginacion.BackColor = Color.FromArgb(240, 248, 255);
            pnlPaginacion.Controls.Add(lblResumenRegistros);

            lblResumenRegistros.AutoSize = true;
            lblResumenRegistros.Font = new Font("Segoe UI", 9.5F);
            lblResumenRegistros.ForeColor = Color.FromArgb(100, 116, 139);
            lblResumenRegistros.Location = new Point(25, 12);

            // ============================================
            // pnlModalCrear (Formulario Crear Orden)
            // ============================================
            pnlModalCrear.Visible = false;
            pnlModalCrear.Size = new Size(740, 460);
            pnlModalCrear.BackColor = Color.White;
            pnlModalCrear.Location = new Point(120, 60);
            pnlModalCrear.Anchor = AnchorStyles.None;
            pnlModalCrear.BorderStyle = BorderStyle.FixedSingle;

            lblTituloModalCrear.Text = "🛠️ Apertura de Orden de Trabajo";
            lblTituloModalCrear.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloModalCrear.ForeColor = Color.FromArgb(15, 23, 42);
            lblTituloModalCrear.Location = new Point(30, 20);
            lblTituloModalCrear.AutoSize = true;

            // Cliente ID y Vehículo ID
            ConfigurarEtiqueta(lblClienteID, "ID del Cliente *", 30, 65);
            ConfigurarInput(txtClienteID, "Ej. 1", 30, 90, 320);

            ConfigurarEtiqueta(lblVehiculoID, "ID del Vehículo *", 380, 65);
            ConfigurarInput(txtVehiculoID, "Ej. 1", 380, 90, 320);

            // Mecánico ID y KM
            ConfigurarEtiqueta(lblEmpleadoID, "ID del Mecánico Responsable * (Máx. 1 activa)", 30, 135);
            ConfigurarInput(txtEmpleadoID, "Ej. 2", 30, 160, 320);

            ConfigurarEtiqueta(lblKM, "Kilometraje de Entrada *", 380, 135);
            ConfigurarInput(txtKM, "Ej. 45200", 380, 160, 320);

            // Diagnóstico y Observaciones
            ConfigurarEtiqueta(lblDiagnostico, "Diagnóstico Inicial / Motivo de Ingreso *", 30, 205);
            txtDiagnostico.Location = new Point(30, 230);
            txtDiagnostico.Size = new Size(670, 50);
            txtDiagnostico.Multiline = true;
            txtDiagnostico.Font = new Font("Segoe UI", 9.5F);
            txtDiagnostico.BackColor = Color.FromArgb(248, 250, 252);
            txtDiagnostico.BorderStyle = BorderStyle.FixedSingle;
            txtDiagnostico.ForeColor = Color.FromArgb(30, 41, 59);

            ConfigurarEtiqueta(lblObservaciones, "Observaciones adicionales", 30, 290);
            txtObservaciones.Location = new Point(30, 315);
            txtObservaciones.Size = new Size(670, 50);
            txtObservaciones.Multiline = true;
            txtObservaciones.Font = new Font("Segoe UI", 9.5F);
            txtObservaciones.BackColor = Color.FromArgb(248, 250, 252);
            txtObservaciones.BorderStyle = BorderStyle.FixedSingle;
            txtObservaciones.ForeColor = Color.FromArgb(30, 41, 59);

            // Botones
            btnCancelarCrear.Text = "CANCELAR";
            btnCancelarCrear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancelarCrear.BackColor = Color.White;
            btnCancelarCrear.ForeColor = Color.FromArgb(71, 85, 105);
            btnCancelarCrear.FlatStyle = FlatStyle.Flat;
            btnCancelarCrear.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancelarCrear.Size = new Size(140, 42);
            btnCancelarCrear.Location = new Point(370, 395);
            btnCancelarCrear.Cursor = Cursors.Hand;
            btnCancelarCrear.Click += (s, e) => pnlModalCrear.Visible = false;

            btnGuardarCrear.Text = "💾 CREAR ORDEN";
            btnGuardarCrear.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardarCrear.BackColor = Color.FromArgb(0, 191, 255);
            btnGuardarCrear.ForeColor = Color.White;
            btnGuardarCrear.FlatStyle = FlatStyle.Flat;
            btnGuardarCrear.FlatAppearance.BorderSize = 0;
            btnGuardarCrear.Size = new Size(190, 42);
            btnGuardarCrear.Location = new Point(520, 395);
            btnGuardarCrear.Cursor = Cursors.Hand;
            btnGuardarCrear.Click += btnGuardarCrear_Click;

            pnlModalCrear.Controls.AddRange(new Control[] {
                lblTituloModalCrear, lblClienteID, txtClienteID, lblVehiculoID, txtVehiculoID,
                lblEmpleadoID, txtEmpleadoID, lblKM, txtKM, lblDiagnostico, txtDiagnostico,
                lblObservaciones, txtObservaciones, btnCancelarCrear, btnGuardarCrear
            });

            // ============================================
            // FrmOrdenesTrabajo (Formulario)
            // ============================================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(980, 600);
            Controls.Add(pnlModalCrear);
            Controls.Add(dgvOrdenes);
            Controls.Add(pnlPaginacion);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmOrdenesTrabajo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Órdenes de Trabajo";
            Padding = new Padding(20, 10, 20, 15);

            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlPaginacion.ResumeLayout(false);
            pnlPaginacion.PerformLayout();
            pnlModalCrear.ResumeLayout(false);
            pnlModalCrear.PerformLayout();
            ResumeLayout(false);
        }

        private void ConfigurarEtiqueta(Label lbl, string texto, int x, int y)
        {
            lbl.Text = texto;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(71, 85, 105);
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
        }

        private void ConfigurarInput(TextBox txt, string placeholder, int x, int y, int width)
        {
            txt.Location = new Point(x, y);
            txt.Size = new Size(width, 31);
            txt.Font = new Font("Segoe UI", 10F);
            txt.BackColor = Color.FromArgb(248, 250, 252);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.ForeColor = Color.FromArgb(30, 41, 59);
            txt.PlaceholderText = placeholder;
        }

        private void ConfigurarColumnasOrdenes(DataGridView grid)
        {
            grid.Columns.Add("OrdenID", "ORDEN ID");
            grid.Columns.Add("Fecha", "FECHA");
            grid.Columns.Add("ClienteID", "CLIENTE");
            grid.Columns.Add("VehiculoID", "VEHÍCULO");
            grid.Columns.Add("EmpleadoID", "MECÁNICO");
            grid.Columns.Add("Kilometraje", "KM");
            grid.Columns.Add("Diagnostico", "DIAGNÓSTICO");
            grid.Columns.Add("Estado", "ESTADO");

            var colFinalizar = new DataGridViewButtonColumn
            {
                Name = "Finalizar",
                HeaderText = "ACCIONES",
                Text = "Finalizar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            colFinalizar.DefaultCellStyle.BackColor = Color.FromArgb(220, 252, 231);
            colFinalizar.DefaultCellStyle.ForeColor = Color.FromArgb(21, 128, 61);
            colFinalizar.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colFinalizar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 252, 231);
            colFinalizar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(21, 128, 61);
            grid.Columns.Add(colFinalizar);

            grid.Columns["OrdenID"].FillWeight = 70;
            grid.Columns["Fecha"].FillWeight = 80;
            grid.Columns["ClienteID"].FillWeight = 75;
            grid.Columns["VehiculoID"].FillWeight = 75;
            grid.Columns["EmpleadoID"].FillWeight = 75;
            grid.Columns["Kilometraje"].FillWeight = 65;
            grid.Columns["Diagnostico"].FillWeight = 160;
            grid.Columns["Estado"].FillWeight = 85;
            grid.Columns["Finalizar"].FillWeight = 80;

            grid.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
