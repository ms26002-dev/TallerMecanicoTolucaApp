namespace TallerTolucaUI
{
    partial class FrmCitas
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
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cboHora;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCancelarCita;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.Panel pnlTableCard;
        private System.Windows.Forms.Label lblTableTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblTotalCitas;
        private System.Windows.Forms.DataGridView dgvCitas;

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
            lblFechaHora = new System.Windows.Forms.Label();
            dtpFecha = new System.Windows.Forms.DateTimePicker();
            cboHora = new System.Windows.Forms.ComboBox();
            lblEstado = new System.Windows.Forms.Label();
            cboEstado = new System.Windows.Forms.ComboBox();
            lblMotivo = new System.Windows.Forms.Label();
            txtMotivo = new System.Windows.Forms.TextBox();
            lblMensaje = new System.Windows.Forms.Label();
            btnGuardar = new System.Windows.Forms.Button();
            btnModificar = new System.Windows.Forms.Button();
            btnCancelarCita = new System.Windows.Forms.Button();
            btnLimpiar = new System.Windows.Forms.Button();

            pnlTableCard = new System.Windows.Forms.Panel();
            lblTableTitulo = new System.Windows.Forms.Label();
            lblBuscar = new System.Windows.Forms.Label();
            txtBuscar = new System.Windows.Forms.TextBox();
            btnRefrescar = new System.Windows.Forms.Button();
            lblTotalCitas = new System.Windows.Forms.Label();
            dgvCitas = new System.Windows.Forms.DataGridView();

            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).BeginInit();
            pnlFormCard.SuspendLayout();
            pnlTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).BeginInit();
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
            pnlHeader.Size = new System.Drawing.Size(980, 68);
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
            lblHeaderTitle.Size = new System.Drawing.Size(245, 25);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Agenda y Control de Citas";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblHeaderSubtitle.Location = new System.Drawing.Point(76, 38);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new System.Drawing.Size(450, 15);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "Sistema de Gestión Automotriz - Taller Toluca | Programación de Citas";

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
            btnCerrarForm.Location = new System.Drawing.Point(860, 16);
            btnCerrarForm.Name = "btnCerrarForm";
            btnCerrarForm.Size = new System.Drawing.Size(100, 36);
            btnCerrarForm.TabIndex = 3;
            btnCerrarForm.Text = "Volver al Menú";
            btnCerrarForm.UseVisualStyleBackColor = false;
            btnCerrarForm.Click += (s, e) => this.Close();

            // 
            // pnlFormCard
            // 
            pnlFormCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            pnlFormCard.BackColor = System.Drawing.Color.White;
            pnlFormCard.Controls.Add(lblFormTitulo);
            pnlFormCard.Controls.Add(lblCamposObligatorios);
            pnlFormCard.Controls.Add(lblCliente);
            pnlFormCard.Controls.Add(cboCliente);
            pnlFormCard.Controls.Add(lblVehiculo);
            pnlFormCard.Controls.Add(cboVehiculo);
            pnlFormCard.Controls.Add(lblFechaHora);
            pnlFormCard.Controls.Add(dtpFecha);
            pnlFormCard.Controls.Add(cboHora);
            pnlFormCard.Controls.Add(lblEstado);
            pnlFormCard.Controls.Add(cboEstado);
            pnlFormCard.Controls.Add(lblMotivo);
            pnlFormCard.Controls.Add(txtMotivo);
            pnlFormCard.Controls.Add(lblMensaje);
            pnlFormCard.Controls.Add(btnGuardar);
            pnlFormCard.Controls.Add(btnModificar);
            pnlFormCard.Controls.Add(btnCancelarCita);
            pnlFormCard.Controls.Add(btnLimpiar);
            pnlFormCard.Location = new System.Drawing.Point(20, 84);
            pnlFormCard.Name = "pnlFormCard";
            pnlFormCard.Size = new System.Drawing.Size(360, 536);
            pnlFormCard.TabIndex = 1;
            pnlFormCard.Paint += PnlCard_Paint;

            // 
            // lblFormTitulo
            // 
            lblFormTitulo.AutoSize = true;
            lblFormTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblFormTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFormTitulo.Location = new System.Drawing.Point(20, 16);
            lblFormTitulo.Name = "lblFormTitulo";
            lblFormTitulo.Size = new System.Drawing.Size(126, 20);
            lblFormTitulo.TabIndex = 0;
            lblFormTitulo.Text = "Datos de la Cita";

            // 
            // lblCamposObligatorios
            // 
            lblCamposObligatorios.AutoSize = true;
            lblCamposObligatorios.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblCamposObligatorios.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblCamposObligatorios.Location = new System.Drawing.Point(20, 38);
            lblCamposObligatorios.Name = "lblCamposObligatorios";
            lblCamposObligatorios.Size = new System.Drawing.Size(262, 13);
            lblCamposObligatorios.TabIndex = 1;
            lblCamposObligatorios.Text = "Los campos obligatorios están marcados con un asterisco *";

            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCliente.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblCliente.Location = new System.Drawing.Point(20, 60);
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
            cboCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboCliente.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboCliente.Location = new System.Drawing.Point(20, 79);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new System.Drawing.Size(320, 25);
            cboCliente.TabIndex = 0;
            cboCliente.SelectedIndexChanged += CboCliente_SelectedIndexChanged;

            // 
            // lblVehiculo
            // 
            lblVehiculo.AutoSize = true;
            lblVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblVehiculo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblVehiculo.Location = new System.Drawing.Point(20, 110);
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
            cboVehiculo.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboVehiculo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboVehiculo.Location = new System.Drawing.Point(20, 129);
            cboVehiculo.Name = "cboVehiculo";
            cboVehiculo.Size = new System.Drawing.Size(320, 25);
            cboVehiculo.TabIndex = 1;
            cboVehiculo.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblFechaHora
            // 
            lblFechaHora.AutoSize = true;
            lblFechaHora.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblFechaHora.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblFechaHora.Location = new System.Drawing.Point(20, 160);
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new System.Drawing.Size(161, 15);
            lblFechaHora.TabIndex = 4;
            lblFechaHora.Text = "Fecha y Hora Programada *";

            // 
            // dtpFecha
            // 
            dtpFecha.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFecha.Location = new System.Drawing.Point(20, 179);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new System.Drawing.Size(170, 25);
            dtpFecha.TabIndex = 2;
            dtpFecha.ValueChanged += Input_TextChanged;

            // 
            // cboHora
            // 
            cboHora.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboHora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            cboHora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboHora.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboHora.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboHora.Items.AddRange(new object[] {
                "08:00 AM", "08:30 AM", "09:00 AM", "09:30 AM",
                "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM",
                "12:00 PM", "12:30 PM", "01:00 PM", "01:30 PM",
                "02:00 PM", "02:30 PM", "03:00 PM", "03:30 PM",
                "04:00 PM", "04:30 PM", "05:00 PM", "05:30 PM",
                "06:00 PM", "06:30 PM", "07:00 PM"
            });
            cboHora.Location = new System.Drawing.Point(198, 179);
            cboHora.Name = "cboHora";
            cboHora.Size = new System.Drawing.Size(142, 25);
            cboHora.TabIndex = 3;
            cboHora.TextChanged += Input_TextChanged;
            cboHora.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblEstado.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblEstado.Location = new System.Drawing.Point(20, 210);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new System.Drawing.Size(117, 15);
            lblEstado.TabIndex = 5;
            lblEstado.Text = "Estado de la Cita *";

            // 
            // cboEstado
            // 
            cboEstado.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboEstado.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboEstado.Items.AddRange(new object[] { "Programada", "Atendida", "Reprogramada", "Cancelada", "No Recibida" });
            cboEstado.Location = new System.Drawing.Point(20, 229);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new System.Drawing.Size(320, 25);
            cboEstado.TabIndex = 3;
            cboEstado.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblMotivo
            // 
            lblMotivo.AutoSize = true;
            lblMotivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblMotivo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblMotivo.Location = new System.Drawing.Point(20, 260);
            lblMotivo.Name = "lblMotivo";
            lblMotivo.Size = new System.Drawing.Size(227, 15);
            lblMotivo.TabIndex = 6;
            lblMotivo.Text = "Motivo del Servicio / Mantenimiento *";

            // 
            // txtMotivo
            // 
            txtMotivo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMotivo.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtMotivo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtMotivo.Location = new System.Drawing.Point(20, 279);
            txtMotivo.MaxLength = 300;
            txtMotivo.Multiline = true;
            txtMotivo.Name = "txtMotivo";
            txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtMotivo.Size = new System.Drawing.Size(320, 48);
            txtMotivo.TabIndex = 4;
            txtMotivo.TextChanged += Input_TextChanged;

            // 
            // lblMensaje
            // 
            lblMensaje.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblMensaje.Location = new System.Drawing.Point(20, 328);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(320, 24);
            lblMensaje.TabIndex = 7;
            lblMensaje.Text = "";
            lblMensaje.Visible = false;

            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(20, 355);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(155, 42);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Programar Cita";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // btnModificar
            // 
            btnModificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnModificar.BackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnModificar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnModificar.ForeColor = System.Drawing.Color.White;
            btnModificar.Location = new System.Drawing.Point(185, 355);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new System.Drawing.Size(155, 42);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "Modificar / Reprog.";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;

            // 
            // btnCancelarCita
            // 
            btnCancelarCita.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnCancelarCita.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnCancelarCita.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancelarCita.FlatAppearance.BorderSize = 0;
            btnCancelarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancelarCita.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnCancelarCita.ForeColor = System.Drawing.Color.White;
            btnCancelarCita.Location = new System.Drawing.Point(20, 407);
            btnCancelarCita.Name = "btnCancelarCita";
            btnCancelarCita.Size = new System.Drawing.Size(155, 42);
            btnCancelarCita.TabIndex = 7;
            btnCancelarCita.Text = "Cancelar Cita";
            btnCancelarCita.UseVisualStyleBackColor = false;
            btnCancelarCita.Click += btnCancelarCita_Click;

            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnLimpiar.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnLimpiar.ForeColor = System.Drawing.Color.White;
            btnLimpiar.Location = new System.Drawing.Point(185, 407);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new System.Drawing.Size(155, 42);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Nueva / Limpiar";
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
            pnlTableCard.Controls.Add(btnRefrescar);
            pnlTableCard.Controls.Add(lblTotalCitas);
            pnlTableCard.Controls.Add(dgvCitas);
            pnlTableCard.Location = new System.Drawing.Point(395, 84);
            pnlTableCard.Name = "pnlTableCard";
            pnlTableCard.Size = new System.Drawing.Size(565, 536);
            pnlTableCard.TabIndex = 2;
            pnlTableCard.Paint += PnlCard_Paint;

            // 
            // lblTableTitulo
            // 
            lblTableTitulo.AutoSize = true;
            lblTableTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTableTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTableTitulo.Location = new System.Drawing.Point(20, 16);
            lblTableTitulo.Name = "lblTableTitulo";
            lblTableTitulo.Size = new System.Drawing.Size(186, 20);
            lblTableTitulo.TabIndex = 0;
            lblTableTitulo.Text = "Listado y Agenda de Citas";

            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblBuscar.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblBuscar.Location = new System.Drawing.Point(20, 48);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new System.Drawing.Size(47, 15);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar:";

            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtBuscar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtBuscar.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtBuscar.Location = new System.Drawing.Point(73, 44);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Filtrar por cliente, placa, vehículo, motivo o estado...";
            txtBuscar.Size = new System.Drawing.Size(350, 25);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRefrescar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btnRefrescar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnRefrescar.Location = new System.Drawing.Point(433, 43);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new System.Drawing.Size(110, 27);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += BtnRefrescar_Click;

            // 
            // lblTotalCitas
            // 
            lblTotalCitas.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalCitas.AutoSize = true;
            lblTotalCitas.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblTotalCitas.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTotalCitas.Location = new System.Drawing.Point(20, 505);
            lblTotalCitas.Name = "lblTotalCitas";
            lblTotalCitas.Size = new System.Drawing.Size(142, 15);
            lblTotalCitas.TabIndex = 2;
            lblTotalCitas.Text = "Total citas registradas: 0";

            // 
            // dgvCitas
            // 
            dgvCitas.AllowUserToAddRows = false;
            dgvCitas.AllowUserToDeleteRows = false;
            dgvCitas.AllowUserToResizeRows = false;
            dgvCitas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvCitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvCitas.BackgroundColor = System.Drawing.Color.White;
            dgvCitas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCitas.Location = new System.Drawing.Point(20, 80);
            dgvCitas.MultiSelect = false;
            dgvCitas.Name = "dgvCitas";
            dgvCitas.ReadOnly = true;
            dgvCitas.RowHeadersVisible = false;
            dgvCitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvCitas.Size = new System.Drawing.Size(525, 415);
            dgvCitas.TabIndex = 2;
            dgvCitas.CellClick += DgvCitas_CellClick;
            dgvCitas.SelectionChanged += DgvCitas_SelectionChanged;

            // 
            // FrmCitas
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            ClientSize = new System.Drawing.Size(980, 640);
            Controls.Add(pnlTableCard);
            Controls.Add(pnlFormCard);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new System.Drawing.Size(950, 620);
            Name = "FrmCitas";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Text = "Agenda y Control de Citas";
            Load += FrmCitas_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).EndInit();
            pnlFormCard.ResumeLayout(false);
            pnlFormCard.PerformLayout();
            pnlTableCard.ResumeLayout(false);
            pnlTableCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCitas).EndInit();
            ResumeLayout(false);
        }
    }
}
