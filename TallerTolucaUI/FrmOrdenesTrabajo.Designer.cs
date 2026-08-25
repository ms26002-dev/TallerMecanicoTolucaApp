namespace TallerTolucaUI
{
    partial class FrmOrdenesTrabajo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogoHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Button btnCerrarForm;

        private System.Windows.Forms.Panel pnlFormCard;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.Label lblCamposObligatorios;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblVehiculo;
        private System.Windows.Forms.ComboBox cboVehiculo;
        private System.Windows.Forms.Label lblMecanico;
        private System.Windows.Forms.ComboBox cboMecanico;
        private System.Windows.Forms.Label lblKilometraje;
        private System.Windows.Forms.TextBox txtKilometraje;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.TextBox txtDiagnostico;
        private System.Windows.Forms.Label lblObservaciones;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label lblUbicacionInfo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.Panel pnlTableCard;
        private System.Windows.Forms.Label lblTableTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblFiltroEstado;
        private System.Windows.Forms.ComboBox cboFiltroEstado;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblTotalOrdenes;
        private System.Windows.Forms.DataGridView dgvOrdenes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new System.Windows.Forms.Panel();
            picLogoHeader = new System.Windows.Forms.PictureBox();
            lblHeaderTitle = new System.Windows.Forms.Label();
            lblHeaderSubtitle = new System.Windows.Forms.Label();
            btnCerrarForm = new System.Windows.Forms.Button();

            pnlFormCard = new System.Windows.Forms.Panel();
            lblFormTitulo = new System.Windows.Forms.Label();
            lblCamposObligatorios = new System.Windows.Forms.Label();
            lblCliente = new System.Windows.Forms.Label();
            cboCliente = new System.Windows.Forms.ComboBox();
            lblVehiculo = new System.Windows.Forms.Label();
            cboVehiculo = new System.Windows.Forms.ComboBox();
            lblMecanico = new System.Windows.Forms.Label();
            cboMecanico = new System.Windows.Forms.ComboBox();
            lblKilometraje = new System.Windows.Forms.Label();
            txtKilometraje = new System.Windows.Forms.TextBox();
            lblEstado = new System.Windows.Forms.Label();
            cboEstado = new System.Windows.Forms.ComboBox();
            lblDiagnostico = new System.Windows.Forms.Label();
            txtDiagnostico = new System.Windows.Forms.TextBox();
            lblObservaciones = new System.Windows.Forms.Label();
            txtObservaciones = new System.Windows.Forms.TextBox();
            lblUbicacionInfo = new System.Windows.Forms.Label();
            lblMensaje = new System.Windows.Forms.Label();
            btnGuardar = new System.Windows.Forms.Button();
            btnModificar = new System.Windows.Forms.Button();
            btnFinalizar = new System.Windows.Forms.Button();
            btnCancelar = new System.Windows.Forms.Button();
            btnLimpiar = new System.Windows.Forms.Button();

            pnlTableCard = new System.Windows.Forms.Panel();
            lblTableTitulo = new System.Windows.Forms.Label();
            lblBuscar = new System.Windows.Forms.Label();
            txtBuscar = new System.Windows.Forms.TextBox();
            lblFiltroEstado = new System.Windows.Forms.Label();
            cboFiltroEstado = new System.Windows.Forms.ComboBox();
            btnRefrescar = new System.Windows.Forms.Button();
            lblTotalOrdenes = new System.Windows.Forms.Label();
            dgvOrdenes = new System.Windows.Forms.DataGridView();

            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).BeginInit();
            pnlFormCard.SuspendLayout();
            pnlTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).BeginInit();
            SuspendLayout();

            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.White;
            pnlHeader.Controls.Add(picLogoHeader);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(btnCerrarForm);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1060, 68);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += PnlCard_Paint;

            // 
            // picLogoHeader
            // 
            picLogoHeader.Location = new System.Drawing.Point(20, 12);
            picLogoHeader.Name = "picLogoHeader";
            picLogoHeader.Size = new System.Drawing.Size(46, 44);
            picLogoHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picLogoHeader.TabIndex = 0;
            picLogoHeader.TabStop = false;

            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblHeaderTitle.Location = new System.Drawing.Point(75, 12);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(280, 25);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Control de Órdenes de Trabajo";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblHeaderSubtitle.Location = new System.Drawing.Point(76, 38);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new System.Drawing.Size(460, 15);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "Sistema de Gestión Automotriz - Taller Toluca | Gestión de Servicios (TMS-16 / TMS-17 / TMS-18)";

            // 
            // btnCerrarForm
            // 
            btnCerrarForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCerrarForm.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            btnCerrarForm.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrarForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnCerrarForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrarForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnCerrarForm.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnCerrarForm.Location = new System.Drawing.Point(935, 16);
            btnCerrarForm.Name = "btnCerrarForm";
            btnCerrarForm.Size = new System.Drawing.Size(105, 36);
            btnCerrarForm.TabIndex = 3;
            btnCerrarForm.Text = "Volver al Menú";
            btnCerrarForm.UseVisualStyleBackColor = false;
            btnCerrarForm.Click += (s, e) => this.Close();

            // 
            // pnlFormCard
            // 
            pnlFormCard.BackColor = System.Drawing.Color.White;
            pnlFormCard.Controls.Add(lblFormTitulo);
            pnlFormCard.Controls.Add(lblCamposObligatorios);
            pnlFormCard.Controls.Add(lblCliente);
            pnlFormCard.Controls.Add(cboCliente);
            pnlFormCard.Controls.Add(lblVehiculo);
            pnlFormCard.Controls.Add(cboVehiculo);
            pnlFormCard.Controls.Add(lblMecanico);
            pnlFormCard.Controls.Add(cboMecanico);
            pnlFormCard.Controls.Add(lblKilometraje);
            pnlFormCard.Controls.Add(txtKilometraje);
            pnlFormCard.Controls.Add(lblEstado);
            pnlFormCard.Controls.Add(cboEstado);
            pnlFormCard.Controls.Add(lblDiagnostico);
            pnlFormCard.Controls.Add(txtDiagnostico);
            pnlFormCard.Controls.Add(lblObservaciones);
            pnlFormCard.Controls.Add(txtObservaciones);
            pnlFormCard.Controls.Add(lblUbicacionInfo);
            pnlFormCard.Controls.Add(lblMensaje);
            pnlFormCard.Controls.Add(btnGuardar);
            pnlFormCard.Controls.Add(btnModificar);
            pnlFormCard.Controls.Add(btnFinalizar);
            pnlFormCard.Controls.Add(btnCancelar);
            pnlFormCard.Controls.Add(btnLimpiar);
            pnlFormCard.Location = new System.Drawing.Point(20, 80);
            pnlFormCard.Name = "pnlFormCard";
            pnlFormCard.Size = new System.Drawing.Size(390, 595);
            pnlFormCard.TabIndex = 1;
            pnlFormCard.Paint += PnlCard_Paint;

            // 
            // lblFormTitulo
            // 
            lblFormTitulo.AutoSize = true;
            lblFormTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblFormTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFormTitulo.Location = new System.Drawing.Point(18, 10);
            lblFormTitulo.Name = "lblFormTitulo";
            lblFormTitulo.Size = new System.Drawing.Size(199, 20);
            lblFormTitulo.TabIndex = 0;
            lblFormTitulo.Text = "Datos de la Orden de Trabajo";

            // 
            // lblCamposObligatorios
            // 
            lblCamposObligatorios.AutoSize = true;
            lblCamposObligatorios.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblCamposObligatorios.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblCamposObligatorios.Location = new System.Drawing.Point(18, 30);
            lblCamposObligatorios.Name = "lblCamposObligatorios";
            lblCamposObligatorios.Size = new System.Drawing.Size(257, 13);
            lblCamposObligatorios.TabIndex = 1;
            lblCamposObligatorios.Text = "Los campos obligatorios están marcados con un asterisco *";

            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblCliente.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblCliente.Location = new System.Drawing.Point(18, 48);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new System.Drawing.Size(55, 15);
            lblCliente.TabIndex = 2;
            lblCliente.Text = "Cliente *";

            // 
            // cboCliente
            // 
            cboCliente.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboCliente.Font = new System.Drawing.Font("Segoe UI", 9F);
            cboCliente.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboCliente.Location = new System.Drawing.Point(18, 65);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new System.Drawing.Size(354, 23);
            cboCliente.TabIndex = 0;
            cboCliente.SelectedIndexChanged += CboCliente_SelectedIndexChanged;

            // 
            // lblVehiculo
            // 
            lblVehiculo.AutoSize = true;
            lblVehiculo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblVehiculo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblVehiculo.Location = new System.Drawing.Point(18, 92);
            lblVehiculo.Name = "lblVehiculo";
            lblVehiculo.Size = new System.Drawing.Size(63, 15);
            lblVehiculo.TabIndex = 3;
            lblVehiculo.Text = "Vehículo *";

            // 
            // cboVehiculo
            // 
            cboVehiculo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F);
            cboVehiculo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboVehiculo.Location = new System.Drawing.Point(18, 109);
            cboVehiculo.Name = "cboVehiculo";
            cboVehiculo.Size = new System.Drawing.Size(354, 23);
            cboVehiculo.TabIndex = 1;
            cboVehiculo.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblMecanico
            // 
            lblMecanico.AutoSize = true;
            lblMecanico.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblMecanico.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblMecanico.Location = new System.Drawing.Point(18, 136);
            lblMecanico.Name = "lblMecanico";
            lblMecanico.Size = new System.Drawing.Size(127, 15);
            lblMecanico.TabIndex = 4;
            lblMecanico.Text = "Mecánico Asignado *";

            // 
            // cboMecanico
            // 
            cboMecanico.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboMecanico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboMecanico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboMecanico.Font = new System.Drawing.Font("Segoe UI", 9F);
            cboMecanico.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboMecanico.Location = new System.Drawing.Point(18, 153);
            cboMecanico.Name = "cboMecanico";
            cboMecanico.Size = new System.Drawing.Size(354, 23);
            cboMecanico.TabIndex = 2;
            cboMecanico.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblKilometraje
            // 
            lblKilometraje.AutoSize = true;
            lblKilometraje.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblKilometraje.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblKilometraje.Location = new System.Drawing.Point(18, 180);
            lblKilometraje.Name = "lblKilometraje";
            lblKilometraje.Size = new System.Drawing.Size(142, 15);
            lblKilometraje.TabIndex = 5;
            lblKilometraje.Text = "Kilometraje Entrada (km) *";

            // 
            // txtKilometraje
            // 
            txtKilometraje.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtKilometraje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtKilometraje.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtKilometraje.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtKilometraje.Location = new System.Drawing.Point(18, 197);
            txtKilometraje.MaxLength = 10;
            txtKilometraje.Name = "txtKilometraje";
            txtKilometraje.Size = new System.Drawing.Size(165, 23);
            txtKilometraje.TabIndex = 3;
            txtKilometraje.TextChanged += Input_TextChanged;

            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblEstado.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblEstado.Location = new System.Drawing.Point(200, 180);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new System.Drawing.Size(117, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado de la Orden *";

            // 
            // cboEstado
            // 
            cboEstado.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            cboEstado.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboEstado.Items.AddRange(new object[] { "Pendiente", "En Proceso", "Finalizada", "Cancelada" });
            cboEstado.Location = new System.Drawing.Point(200, 197);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new System.Drawing.Size(172, 23);
            cboEstado.TabIndex = 4;
            cboEstado.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblDiagnostico
            // 
            lblDiagnostico.AutoSize = true;
            lblDiagnostico.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblDiagnostico.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblDiagnostico.Location = new System.Drawing.Point(18, 225);
            lblDiagnostico.Name = "lblDiagnostico";
            lblDiagnostico.Size = new System.Drawing.Size(217, 15);
            lblDiagnostico.TabIndex = 7;
            lblDiagnostico.Text = "Diagnóstico Inicial / Motivo del Servicio *";

            // 
            // txtDiagnostico
            // 
            txtDiagnostico.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtDiagnostico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDiagnostico.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtDiagnostico.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtDiagnostico.Location = new System.Drawing.Point(18, 242);
            txtDiagnostico.MaxLength = 500;
            txtDiagnostico.Multiline = true;
            txtDiagnostico.Name = "txtDiagnostico";
            txtDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtDiagnostico.Size = new System.Drawing.Size(354, 55);
            txtDiagnostico.TabIndex = 5;
            txtDiagnostico.TextChanged += Input_TextChanged;

            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblObservaciones.Location = new System.Drawing.Point(18, 302);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new System.Drawing.Size(176, 15);
            lblObservaciones.TabIndex = 8;
            lblObservaciones.Text = "Observaciones / Reparaciones";

            // 
            // txtObservaciones
            // 
            txtObservaciones.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtObservaciones.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtObservaciones.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtObservaciones.Location = new System.Drawing.Point(18, 319);
            txtObservaciones.MaxLength = 500;
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtObservaciones.Size = new System.Drawing.Size(354, 45);
            txtObservaciones.TabIndex = 6;
            txtObservaciones.TextChanged += Input_TextChanged;

            // 
            // lblUbicacionInfo
            // 
            lblUbicacionInfo.AutoSize = true;
            lblUbicacionInfo.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Italic);
            lblUbicacionInfo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblUbicacionInfo.Location = new System.Drawing.Point(18, 368);
            lblUbicacionInfo.Name = "lblUbicacionInfo";
            lblUbicacionInfo.Size = new System.Drawing.Size(262, 13);
            lblUbicacionInfo.TabIndex = 9;
            lblUbicacionInfo.Text = "🏢 Ubicación: Taller Mecánico Toluca (Regla de negocio #8)";

            // 
            // lblMensaje
            // 
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblMensaje.Location = new System.Drawing.Point(18, 388);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(354, 150);
            lblMensaje.TabIndex = 10;
            lblMensaje.Text = "Mensaje de estado";
            lblMensaje.Visible = false;

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(14, 545);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(74, 34);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Crear";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // btnModificar
            // 
            btnModificar.BackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnModificar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btnModificar.ForeColor = System.Drawing.Color.White;
            btnModificar.Location = new System.Drawing.Point(90, 545);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new System.Drawing.Size(76, 34);
            btnModificar.TabIndex = 8;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;

            // 
            // btnFinalizar
            // 
            btnFinalizar.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFinalizar.FlatAppearance.BorderSize = 0;
            btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFinalizar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btnFinalizar.ForeColor = System.Drawing.Color.White;
            btnFinalizar.Location = new System.Drawing.Point(168, 545);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new System.Drawing.Size(74, 34);
            btnFinalizar.TabIndex = 9;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = false;
            btnFinalizar.Click += btnFinalizar_Click;

            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btnCancelar.ForeColor = System.Drawing.Color.White;
            btnCancelar.Location = new System.Drawing.Point(244, 545);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new System.Drawing.Size(70, 34);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;

            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnLimpiar.Location = new System.Drawing.Point(316, 545);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new System.Drawing.Size(58, 34);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;

            // 
            // pnlTableCard
            // 
            pnlTableCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlTableCard.BackColor = System.Drawing.Color.White;
            pnlTableCard.Controls.Add(lblTableTitulo);
            pnlTableCard.Controls.Add(lblBuscar);
            pnlTableCard.Controls.Add(txtBuscar);
            pnlTableCard.Controls.Add(lblFiltroEstado);
            pnlTableCard.Controls.Add(cboFiltroEstado);
            pnlTableCard.Controls.Add(btnRefrescar);
            pnlTableCard.Controls.Add(lblTotalOrdenes);
            pnlTableCard.Controls.Add(dgvOrdenes);
            pnlTableCard.Location = new System.Drawing.Point(420, 80);
            pnlTableCard.Name = "pnlTableCard";
            pnlTableCard.Size = new System.Drawing.Size(620, 595);
            pnlTableCard.TabIndex = 2;
            pnlTableCard.Paint += PnlCard_Paint;

            // 
            // lblTableTitulo
            // 
            lblTableTitulo.AutoSize = true;
            lblTableTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTableTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTableTitulo.Location = new System.Drawing.Point(18, 10);
            lblTableTitulo.Name = "lblTableTitulo";
            lblTableTitulo.Size = new System.Drawing.Size(262, 20);
            lblTableTitulo.TabIndex = 0;
            lblTableTitulo.Text = "Seguimiento de Órdenes de Trabajo";

            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblBuscar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblBuscar.Location = new System.Drawing.Point(18, 38);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new System.Drawing.Size(46, 15);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar:";

            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtBuscar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9F);
            txtBuscar.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtBuscar.Location = new System.Drawing.Point(70, 36);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new System.Drawing.Size(240, 23);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            // 
            // lblFiltroEstado
            // 
            lblFiltroEstado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblFiltroEstado.AutoSize = true;
            lblFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            lblFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblFiltroEstado.Location = new System.Drawing.Point(318, 38);
            lblFiltroEstado.Name = "lblFiltroEstado";
            lblFiltroEstado.Size = new System.Drawing.Size(46, 15);
            lblFiltroEstado.TabIndex = 2;
            lblFiltroEstado.Text = "Estado:";

            // 
            // cboFiltroEstado
            // 
            cboFiltroEstado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cboFiltroEstado.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFiltroEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            cboFiltroEstado.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboFiltroEstado.Items.AddRange(new object[] { "Todos", "Pendiente", "En Proceso", "Finalizada", "Cancelada" });
            cboFiltroEstado.Location = new System.Drawing.Point(368, 36);
            cboFiltroEstado.Name = "cboFiltroEstado";
            cboFiltroEstado.Size = new System.Drawing.Size(140, 21);
            cboFiltroEstado.TabIndex = 1;
            cboFiltroEstado.SelectedIndexChanged += CboFiltroEstado_SelectedIndexChanged;

            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRefrescar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            btnRefrescar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnRefrescar.Location = new System.Drawing.Point(516, 34);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new System.Drawing.Size(85, 26);
            btnRefrescar.TabIndex = 2;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += BtnRefrescar_Click;

            // 
            // lblTotalOrdenes
            // 
            lblTotalOrdenes.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalOrdenes.AutoSize = true;
            lblTotalOrdenes.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblTotalOrdenes.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTotalOrdenes.Location = new System.Drawing.Point(18, 568);
            lblTotalOrdenes.Name = "lblTotalOrdenes";
            lblTotalOrdenes.Size = new System.Drawing.Size(145, 15);
            lblTotalOrdenes.TabIndex = 3;
            lblTotalOrdenes.Text = "Total órdenes de trabajo: 0";

            // 
            // dgvOrdenes
            // 
            dgvOrdenes.AllowUserToAddRows = false;
            dgvOrdenes.AllowUserToDeleteRows = false;
            dgvOrdenes.AllowUserToResizeRows = false;
            dgvOrdenes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvOrdenes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrdenes.BackgroundColor = System.Drawing.Color.White;
            dgvOrdenes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvOrdenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrdenes.Location = new System.Drawing.Point(18, 68);
            dgvOrdenes.MultiSelect = false;
            dgvOrdenes.Name = "dgvOrdenes";
            dgvOrdenes.ReadOnly = true;
            dgvOrdenes.RowHeadersVisible = false;
            dgvOrdenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvOrdenes.Size = new System.Drawing.Size(585, 490);
            dgvOrdenes.TabIndex = 3;
            dgvOrdenes.CellClick += DgvOrdenes_CellClick;
            dgvOrdenes.SelectionChanged += DgvOrdenes_SelectionChanged;

            // 
            // FrmOrdenesTrabajo
            // 
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            ClientSize = new System.Drawing.Size(1060, 690);
            Controls.Add(pnlTableCard);
            Controls.Add(pnlFormCard);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(1000, 640);
            Name = "FrmOrdenesTrabajo";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Control de Órdenes de Trabajo";
            Load += FrmOrdenesTrabajo_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).EndInit();
            pnlFormCard.ResumeLayout(false);
            pnlFormCard.PerformLayout();
            pnlTableCard.ResumeLayout(false);
            pnlTableCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrdenes).EndInit();
            ResumeLayout(false);
        }
    }
}
