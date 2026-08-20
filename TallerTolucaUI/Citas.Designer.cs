using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class Citas
    {
        private System.ComponentModel.IContainer components = null;

        // Encabezado
        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnNuevaCita;

        // Filtros y Búsqueda
        private Panel pnlFiltros;
        private TextBox txtBuscar;
        private ComboBox cboEstadoFiltro;

        // Tabla
        private DataGridView dgvCitas;

        // Paginación / Resumen
        private Panel pnlPaginacion;
        private Label lblResumenRegistros;

        // Panel Modal Agendamiento
        private Panel pnlModalAgendar;
        private Label lblTituloModal;
        private Label lblClienteID;
        private TextBox txtClienteID;
        private Label lblVehiculoID;
        private TextBox txtVehiculoID;
        private Label lblFechaHora;
        private DateTimePicker dtpFechaHora;
        private Label lblMotivo;
        private TextBox txtMotivo;
        private Button btnCancelarAgendar;
        private Button btnGuardarAgendar;

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
            btnNuevaCita = new Button();

            pnlFiltros = new Panel();
            txtBuscar = new TextBox();
            cboEstadoFiltro = new ComboBox();

            dgvCitas = new DataGridView();
            pnlPaginacion = new Panel();
            lblResumenRegistros = new Label();

            pnlModalAgendar = new Panel();
            lblTituloModal = new Label();
            lblClienteID = new Label();
            txtClienteID = new TextBox();
            lblVehiculoID = new Label();
            txtVehiculoID = new TextBox();
            lblFechaHora = new Label();
            dtpFechaHora = new DateTimePicker();
            lblMotivo = new Label();
            txtMotivo = new TextBox();
            btnCancelarAgendar = new Button();
            btnGuardarAgendar = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
            pnlHeader.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlPaginacion.SuspendLayout();
            pnlModalAgendar.SuspendLayout();
            SuspendLayout();

            // ============================================
            // pnlHeader (Encabezado Superior)
            // ============================================
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 75;
            pnlHeader.BackColor = Color.FromArgb(240, 248, 255);
            pnlHeader.Controls.Add(btnNuevaCita);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);

            lblTitulo.Text = "Agenda y Gestión de Citas";
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Programación, control de asistencia y seguimiento de citas de servicio.";
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitulo.Location = new Point(27, 47);
            lblSubtitulo.AutoSize = true;

            btnNuevaCita.Text = "+ Programar Cita";
            btnNuevaCita.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevaCita.BackColor = Color.FromArgb(0, 191, 255); // #00BFFF
            btnNuevaCita.ForeColor = Color.White;
            btnNuevaCita.FlatStyle = FlatStyle.Flat;
            btnNuevaCita.FlatAppearance.BorderSize = 0;
            btnNuevaCita.Size = new Size(180, 40);
            btnNuevaCita.Location = new Point(765, 18);
            btnNuevaCita.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevaCita.Cursor = Cursors.Hand;
            btnNuevaCita.Click += btnNuevaCita_Click;

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
            txtBuscar.PlaceholderText = "🔍  Buscar citas por cliente, vehículo o motivo...";
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();

            cboEstadoFiltro.Location = new Point(720, 8);
            cboEstadoFiltro.Size = new Size(225, 33);
            cboEstadoFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboEstadoFiltro.Font = new Font("Segoe UI", 10F);
            cboEstadoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoFiltro.FlatStyle = FlatStyle.Flat;
            cboEstadoFiltro.BackColor = Color.FromArgb(248, 250, 252);
            cboEstadoFiltro.Items.AddRange(new object[] { "Todos los estados", "Programada", "Atendida", "Cancelada", "No Recibida" });
            cboEstadoFiltro.SelectedIndex = 0;
            cboEstadoFiltro.SelectedIndexChanged += (s, e) => AplicarFiltros();

            // ============================================
            // dgvCitas (Tabla)
            // ============================================
            dgvCitas.Dock = DockStyle.Fill;
            dgvCitas.BackgroundColor = Color.White;
            dgvCitas.BorderStyle = BorderStyle.None;
            dgvCitas.GridColor = Color.FromArgb(226, 232, 240);
            dgvCitas.RowHeadersVisible = false;
            dgvCitas.EnableHeadersVisualStyles = false;
            dgvCitas.ColumnHeadersHeight = 42;
            dgvCitas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvCitas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvCitas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvCitas.DefaultCellStyle.BackColor = Color.White;
            dgvCitas.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvCitas.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvCitas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 245, 255);
            dgvCitas.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvCitas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
            dgvCitas.RowTemplate.Height = 44;
            dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCitas.MultiSelect = false;
            dgvCitas.AllowUserToAddRows = false;
            dgvCitas.AllowUserToDeleteRows = false;
            dgvCitas.ReadOnly = true;
            ConfigurarColumnasCitas(dgvCitas);
            dgvCitas.CellContentClick += dgvCitas_CellContentClick;
            dgvCitas.CellFormatting += dgvCitas_CellFormatting;

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
            // pnlModalAgendar (Formulario Modal Agendamiento)
            // ============================================
            pnlModalAgendar.Visible = false;
            pnlModalAgendar.Size = new Size(740, 390);
            pnlModalAgendar.BackColor = Color.White;
            pnlModalAgendar.Location = new Point(120, 80);
            pnlModalAgendar.Anchor = AnchorStyles.None;
            pnlModalAgendar.BorderStyle = BorderStyle.FixedSingle;

            lblTituloModal.Text = "📅 Programación de Cita";
            lblTituloModal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloModal.ForeColor = Color.FromArgb(15, 23, 42);
            lblTituloModal.Location = new Point(30, 20);
            lblTituloModal.AutoSize = true;

            // Cliente ID y Vehículo ID
            ConfigurarEtiqueta(lblClienteID, "ID del Cliente *", 30, 65);
            ConfigurarInput(txtClienteID, "Ej. 1", 30, 90, 320);

            ConfigurarEtiqueta(lblVehiculoID, "ID del Vehículo *", 380, 65);
            ConfigurarInput(txtVehiculoID, "Ej. 1", 380, 90, 320);

            // Fecha y Hora
            ConfigurarEtiqueta(lblFechaHora, "Fecha y Hora de la Cita *", 30, 135);
            dtpFechaHora.Location = new Point(30, 160);
            dtpFechaHora.Size = new Size(320, 31);
            dtpFechaHora.Font = new Font("Segoe UI", 10F);
            dtpFechaHora.Format = DateTimePickerFormat.Custom;
            dtpFechaHora.CustomFormat = "yyyy-MM-dd HH:mm";

            // Motivo
            ConfigurarEtiqueta(lblMotivo, "Motivo o Servicio Requerido *", 380, 135);
            txtMotivo.Location = new Point(380, 160);
            txtMotivo.Size = new Size(320, 90);
            txtMotivo.Multiline = true;
            txtMotivo.Font = new Font("Segoe UI", 9.5F);
            txtMotivo.BackColor = Color.FromArgb(248, 250, 252);
            txtMotivo.BorderStyle = BorderStyle.FixedSingle;
            txtMotivo.ForeColor = Color.FromArgb(30, 41, 59);

            // Botones
            btnCancelarAgendar.Text = "CANCELAR";
            btnCancelarAgendar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancelarAgendar.BackColor = Color.White;
            btnCancelarAgendar.ForeColor = Color.FromArgb(71, 85, 105);
            btnCancelarAgendar.FlatStyle = FlatStyle.Flat;
            btnCancelarAgendar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancelarAgendar.Size = new Size(140, 42);
            btnCancelarAgendar.Location = new Point(370, 320);
            btnCancelarAgendar.Cursor = Cursors.Hand;
            btnCancelarAgendar.Click += (s, e) => pnlModalAgendar.Visible = false;

            btnGuardarAgendar.Text = "💾 AGENDAR CITA";
            btnGuardarAgendar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardarAgendar.BackColor = Color.FromArgb(0, 191, 255);
            btnGuardarAgendar.ForeColor = Color.White;
            btnGuardarAgendar.FlatStyle = FlatStyle.Flat;
            btnGuardarAgendar.FlatAppearance.BorderSize = 0;
            btnGuardarAgendar.Size = new Size(190, 42);
            btnGuardarAgendar.Location = new Point(520, 320);
            btnGuardarAgendar.Cursor = Cursors.Hand;
            btnGuardarAgendar.Click += btnGuardarAgendar_Click;

            pnlModalAgendar.Controls.AddRange(new Control[] {
                lblTituloModal, lblClienteID, txtClienteID, lblVehiculoID, txtVehiculoID,
                lblFechaHora, dtpFechaHora, lblMotivo, txtMotivo,
                btnCancelarAgendar, btnGuardarAgendar
            });

            // ============================================
            // Citas (Formulario)
            // ============================================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(980, 600);
            Controls.Add(pnlModalAgendar);
            Controls.Add(dgvCitas);
            Controls.Add(pnlPaginacion);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "Citas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Agenda de Citas";
            Padding = new Padding(20, 10, 20, 15);

            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlPaginacion.ResumeLayout(false);
            pnlPaginacion.PerformLayout();
            pnlModalAgendar.ResumeLayout(false);
            pnlModalAgendar.PerformLayout();
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

        private void ConfigurarColumnasCitas(DataGridView grid)
        {
            grid.Columns.Add("CitaID", "CITA ID");
            grid.Columns.Add("ClienteID", "CLIENTE");
            grid.Columns.Add("VehiculoID", "VEHÍCULO");
            grid.Columns.Add("FechaHora", "FECHA Y HORA");
            grid.Columns.Add("Motivo", "MOTIVO / SERVICIO");
            grid.Columns.Add("Estado", "ESTADO");

            var colAtender = new DataGridViewButtonColumn
            {
                Name = "Atender",
                HeaderText = "ACCIONES",
                Text = "Atendida",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            colAtender.DefaultCellStyle.BackColor = Color.FromArgb(220, 252, 231);
            colAtender.DefaultCellStyle.ForeColor = Color.FromArgb(21, 128, 61);
            colAtender.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colAtender.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 252, 231);
            colAtender.DefaultCellStyle.SelectionForeColor = Color.FromArgb(21, 128, 61);

            var colCancelar = new DataGridViewButtonColumn
            {
                Name = "Cancelar",
                HeaderText = "",
                Text = "Cancelar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            colCancelar.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
            colCancelar.DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            colCancelar.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colCancelar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 226);
            colCancelar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(185, 28, 28);

            grid.Columns.Add(colAtender);
            grid.Columns.Add(colCancelar);

            grid.Columns["CitaID"].FillWeight = 70;
            grid.Columns["ClienteID"].FillWeight = 80;
            grid.Columns["VehiculoID"].FillWeight = 80;
            grid.Columns["FechaHora"].FillWeight = 110;
            grid.Columns["Motivo"].FillWeight = 170;
            grid.Columns["Estado"].FillWeight = 85;
            grid.Columns["Atender"].FillWeight = 75;
            grid.Columns["Cancelar"].FillWeight = 75;

            grid.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
