using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class FrmVehiculos
    {
        private System.ComponentModel.IContainer components = null;

        // Encabezado
        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnNuevoVehiculo;

        // Filtros y Búsqueda
        private Panel pnlFiltros;
        private TextBox txtBuscar;

        // Tabla
        private DataGridView dgvVehiculos;

        // Paginación / Resumen
        private Panel pnlPaginacion;
        private Label lblResumenRegistros;

        // Panel Modal/Slide para Registro (según imagen 7)
        private Panel pnlFormularioRegistro;
        private Label lblTituloForm;
        private Label lblClienteID;
        private TextBox txtFormClienteID;
        private Label lblPlaca;
        private TextBox txtFormPlaca;
        private Label lblMarca;
        private TextBox txtFormMarca;
        private Label lblModelo;
        private TextBox txtFormModelo;
        private Label lblAnio;
        private TextBox txtFormAnio;
        private Label lblColor;
        private TextBox txtFormColor;
        private Label lblTipoVehiculo;
        private ComboBox cboFormTipo;
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
            btnNuevoVehiculo = new Button();

            pnlFiltros = new Panel();
            txtBuscar = new TextBox();

            dgvVehiculos = new DataGridView();
            pnlPaginacion = new Panel();
            lblResumenRegistros = new Label();

            pnlFormularioRegistro = new Panel();
            lblTituloForm = new Label();
            lblClienteID = new Label();
            txtFormClienteID = new TextBox();
            lblPlaca = new Label();
            txtFormPlaca = new TextBox();
            lblMarca = new Label();
            txtFormMarca = new TextBox();
            lblModelo = new Label();
            txtFormModelo = new TextBox();
            lblAnio = new Label();
            txtFormAnio = new TextBox();
            lblColor = new Label();
            txtFormColor = new TextBox();
            lblTipoVehiculo = new Label();
            cboFormTipo = new ComboBox();
            btnFormCancelar = new Button();
            btnFormGuardar = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
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
            pnlHeader.Controls.Add(btnNuevoVehiculo);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);

            lblTitulo.Text = "Gestión de Vehículos";
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Registro y administración del parque vehicular del taller automotriz.";
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitulo.Location = new Point(27, 47);
            lblSubtitulo.AutoSize = true;

            btnNuevoVehiculo.Text = "+ Registrar Vehículo";
            btnNuevoVehiculo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoVehiculo.BackColor = Color.FromArgb(0, 191, 255); // #00BFFF
            btnNuevoVehiculo.ForeColor = Color.White;
            btnNuevoVehiculo.FlatStyle = FlatStyle.Flat;
            btnNuevoVehiculo.FlatAppearance.BorderSize = 0;
            btnNuevoVehiculo.Size = new Size(180, 40);
            btnNuevoVehiculo.Location = new Point(765, 18);
            btnNuevoVehiculo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoVehiculo.Cursor = Cursors.Hand;
            btnNuevoVehiculo.Click += btnNuevoVehiculo_Click;

            // ============================================
            // pnlFiltros (Barra de Búsqueda)
            // ============================================
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Height = 55;
            pnlFiltros.BackColor = Color.FromArgb(240, 248, 255);
            pnlFiltros.Controls.Add(txtBuscar);

            txtBuscar.Location = new Point(25, 8);
            txtBuscar.Size = new Size(920, 33);
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.BackColor = Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            txtBuscar.PlaceholderText = "🔍  Buscar vehículo por placa, marca, modelo o cliente...";
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();

            // ============================================
            // dgvVehiculos (Tabla)
            // ============================================
            dgvVehiculos.Dock = DockStyle.Fill;
            dgvVehiculos.BackgroundColor = Color.White;
            dgvVehiculos.BorderStyle = BorderStyle.None;
            dgvVehiculos.GridColor = Color.FromArgb(226, 232, 240);
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.EnableHeadersVisualStyles = false;
            dgvVehiculos.ColumnHeadersHeight = 42;
            dgvVehiculos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvVehiculos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvVehiculos.DefaultCellStyle.BackColor = Color.White;
            dgvVehiculos.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvVehiculos.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvVehiculos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 245, 255);
            dgvVehiculos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvVehiculos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
            dgvVehiculos.RowTemplate.Height = 44;
            dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AllowUserToDeleteRows = false;
            dgvVehiculos.ReadOnly = true;
            ConfigurarColumnasVehiculos(dgvVehiculos);
            dgvVehiculos.CellContentClick += dgvVehiculos_CellContentClick;

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
            // pnlFormularioRegistro (Modal Formulario)
            // ============================================
            pnlFormularioRegistro.Visible = false;
            pnlFormularioRegistro.Size = new Size(740, 420);
            pnlFormularioRegistro.BackColor = Color.White;
            pnlFormularioRegistro.Location = new Point(120, 80);
            pnlFormularioRegistro.Anchor = AnchorStyles.None;
            pnlFormularioRegistro.BorderStyle = BorderStyle.FixedSingle;

            lblTituloForm.Text = "🚗 Registrar Nuevo Vehículo";
            lblTituloForm.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloForm.ForeColor = Color.FromArgb(15, 23, 42);
            lblTituloForm.Location = new Point(30, 20);
            lblTituloForm.AutoSize = true;

            // Cliente ID y Placa
            ConfigurarEtiqueta(lblClienteID, "ID del Propietario (Cliente ID) *", 30, 65);
            ConfigurarInput(txtFormClienteID, "Ej. 1", 30, 90, 320);

            ConfigurarEtiqueta(lblPlaca, "Número de Placa *", 380, 65);
            ConfigurarInput(txtFormPlaca, "Ej. P-123456", 380, 90, 320);

            // Marca y Modelo
            ConfigurarEtiqueta(lblMarca, "Marca del Automóvil *", 30, 135);
            ConfigurarInput(txtFormMarca, "Ej. Toyota", 30, 160, 320);

            ConfigurarEtiqueta(lblModelo, "Modelo del Automóvil *", 380, 135);
            ConfigurarInput(txtFormModelo, "Ej. Corolla", 380, 160, 320);

            // Año y Color
            ConfigurarEtiqueta(lblAnio, "Año de Fabricación *", 30, 205);
            ConfigurarInput(txtFormAnio, "Ej. 2022", 30, 230, 320);

            ConfigurarEtiqueta(lblColor, "Color del Vehículo", 380, 205);
            ConfigurarInput(txtFormColor, "Ej. Gris Plata", 380, 230, 320);

            // Tipo de Vehículo
            ConfigurarEtiqueta(lblTipoVehiculo, "Tipo de Vehículo * (Regla: Solo Liviano)", 30, 275);
            cboFormTipo.Location = new Point(30, 300);
            cboFormTipo.Size = new Size(670, 33);
            cboFormTipo.Font = new Font("Segoe UI", 10F);
            cboFormTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFormTipo.FlatStyle = FlatStyle.Flat;
            cboFormTipo.BackColor = Color.FromArgb(248, 250, 252);
            cboFormTipo.Items.AddRange(new object[] { "Liviano", "Pesado", "Motocicleta" });
            cboFormTipo.SelectedIndex = 0;

            // Botones
            btnFormCancelar.Text = "CANCELAR";
            btnFormCancelar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnFormCancelar.BackColor = Color.White;
            btnFormCancelar.ForeColor = Color.FromArgb(71, 85, 105);
            btnFormCancelar.FlatStyle = FlatStyle.Flat;
            btnFormCancelar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnFormCancelar.Size = new Size(140, 42);
            btnFormCancelar.Location = new Point(380, 355);
            btnFormCancelar.Cursor = Cursors.Hand;
            btnFormCancelar.Click += (s, e) => pnlFormularioRegistro.Visible = false;

            btnFormGuardar.Text = "💾 GUARDAR VEHÍCULO";
            btnFormGuardar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnFormGuardar.BackColor = Color.FromArgb(2, 132, 199);
            btnFormGuardar.ForeColor = Color.White;
            btnFormGuardar.FlatStyle = FlatStyle.Flat;
            btnFormGuardar.FlatAppearance.BorderSize = 0;
            btnFormGuardar.Size = new Size(180, 42);
            btnFormGuardar.Location = new Point(530, 355);
            btnFormGuardar.Cursor = Cursors.Hand;
            btnFormGuardar.Click += btnFormGuardar_Click;

            pnlFormularioRegistro.Controls.AddRange(new Control[] {
                lblTituloForm, lblClienteID, txtFormClienteID, lblPlaca, txtFormPlaca,
                lblMarca, txtFormMarca, lblModelo, txtFormModelo, lblAnio, txtFormAnio,
                lblColor, txtFormColor, lblTipoVehiculo, cboFormTipo,
                btnFormCancelar, btnFormGuardar
            });

            // ============================================
            // FrmVehiculos (Formulario)
            // ============================================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(980, 600);
            Controls.Add(pnlFormularioRegistro);
            Controls.Add(dgvVehiculos);
            Controls.Add(pnlPaginacion);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmVehiculos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Vehículos";
            Padding = new Padding(20, 10, 20, 15);

            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
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

        private void ConfigurarColumnasVehiculos(DataGridView grid)
        {
            grid.Columns.Add("VehiculoID", "ID");
            grid.Columns.Add("ClienteID", "CLIENTE ID");
            grid.Columns.Add("Placa", "PLACA");
            grid.Columns.Add("Marca", "MARCA");
            grid.Columns.Add("Modelo", "MODELO");
            grid.Columns.Add("Anio", "AÑO");
            grid.Columns.Add("Color", "COLOR");
            grid.Columns.Add("Tipo", "TIPO");

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
            grid.Columns.Add(colEliminar);

            grid.Columns["VehiculoID"].FillWeight = 50;
            grid.Columns["ClienteID"].FillWeight = 80;
            grid.Columns["Placa"].FillWeight = 90;
            grid.Columns["Marca"].FillWeight = 110;
            grid.Columns["Modelo"].FillWeight = 110;
            grid.Columns["Anio"].FillWeight = 70;
            grid.Columns["Color"].FillWeight = 90;
            grid.Columns["Tipo"].FillWeight = 80;
            grid.Columns["Eliminar"].FillWeight = 80;
        }
    }
}
