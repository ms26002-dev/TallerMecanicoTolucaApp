namespace TallerTolucaUI
{
    partial class FrmEmpleados
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
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.ComboBox cboCargo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.Panel pnlTableCard;
        private System.Windows.Forms.Label lblTableTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblTotalEmpleados;
        private System.Windows.Forms.DataGridView dgvEmpleados;

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
            lblNombre = new System.Windows.Forms.Label();
            txtNombre = new System.Windows.Forms.TextBox();
            lblCargo = new System.Windows.Forms.Label();
            cboCargo = new System.Windows.Forms.ComboBox();
            lblTelefono = new System.Windows.Forms.Label();
            txtTelefono = new System.Windows.Forms.TextBox();
            lblCorreo = new System.Windows.Forms.Label();
            txtCorreo = new System.Windows.Forms.TextBox();
            lblEstado = new System.Windows.Forms.Label();
            cboEstado = new System.Windows.Forms.ComboBox();
            lblMensaje = new System.Windows.Forms.Label();
            btnGuardar = new System.Windows.Forms.Button();
            btnModificar = new System.Windows.Forms.Button();
            btnEliminar = new System.Windows.Forms.Button();
            btnLimpiar = new System.Windows.Forms.Button();

            pnlTableCard = new System.Windows.Forms.Panel();
            lblTableTitulo = new System.Windows.Forms.Label();
            lblBuscar = new System.Windows.Forms.Label();
            txtBuscar = new System.Windows.Forms.TextBox();
            btnRefrescar = new System.Windows.Forms.Button();
            lblTotalEmpleados = new System.Windows.Forms.Label();
            dgvEmpleados = new System.Windows.Forms.DataGridView();

            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).BeginInit();
            pnlFormCard.SuspendLayout();
            pnlTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).BeginInit();
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
            lblHeaderTitle.Size = new System.Drawing.Size(262, 25);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Administración de Empleados";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblHeaderSubtitle.Location = new System.Drawing.Point(76, 38);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new System.Drawing.Size(425, 15);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "Sistema de Gestión Automotriz - Radiator Springs | Gestión de Personal (TMS-25 / TMS-26)";

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
           

            // 
            // pnlFormCard
            // 
            pnlFormCard.BackColor = System.Drawing.Color.White;
            pnlFormCard.Controls.Add(lblFormTitulo);
            pnlFormCard.Controls.Add(lblCamposObligatorios);
            pnlFormCard.Controls.Add(lblNombre);
            pnlFormCard.Controls.Add(txtNombre);
            pnlFormCard.Controls.Add(lblCargo);
            pnlFormCard.Controls.Add(cboCargo);
            pnlFormCard.Controls.Add(lblTelefono);
            pnlFormCard.Controls.Add(txtTelefono);
            pnlFormCard.Controls.Add(lblCorreo);
            pnlFormCard.Controls.Add(txtCorreo);
            pnlFormCard.Controls.Add(lblEstado);
            pnlFormCard.Controls.Add(cboEstado);
            pnlFormCard.Controls.Add(lblMensaje);
            pnlFormCard.Controls.Add(btnGuardar);
            pnlFormCard.Controls.Add(btnModificar);
            pnlFormCard.Controls.Add(btnEliminar);
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
            lblFormTitulo.Location = new System.Drawing.Point(20, 14);
            lblFormTitulo.Name = "lblFormTitulo";
            lblFormTitulo.Size = new System.Drawing.Size(143, 20);
            lblFormTitulo.TabIndex = 0;
            lblFormTitulo.Text = "Datos del Empleado";

            // 
            // lblCamposObligatorios
            // 
            lblCamposObligatorios.AutoSize = true;
            lblCamposObligatorios.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblCamposObligatorios.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblCamposObligatorios.Location = new System.Drawing.Point(20, 35);
            lblCamposObligatorios.Name = "lblCamposObligatorios";
            lblCamposObligatorios.Size = new System.Drawing.Size(262, 13);
            lblCamposObligatorios.TabIndex = 1;
            lblCamposObligatorios.Text = "Los campos obligatorios están marcados con un asterisco *";

            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblNombre.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblNombre.Location = new System.Drawing.Point(20, 58);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(117, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre Completo *";

            // 
            // txtNombre
            // 
            txtNombre.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtNombre.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtNombre.Location = new System.Drawing.Point(20, 75);
            txtNombre.MaxLength = 150;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(320, 24);
            txtNombre.TabIndex = 0;
            txtNombre.TextChanged += Input_TextChanged;

            // 
            // lblCargo
            // 
            lblCargo.AutoSize = true;
            lblCargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCargo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblCargo.Location = new System.Drawing.Point(20, 105);
            lblCargo.Name = "lblCargo";
            lblCargo.Size = new System.Drawing.Size(84, 15);
            lblCargo.TabIndex = 3;
            lblCargo.Text = "Cargo / Rol *";

            // 
            // cboCargo
            // 
            cboCargo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboCargo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cboCargo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboCargo.FormattingEnabled = true;
            cboCargo.Items.AddRange(new object[] {
                "Administrador",
                "Mecánico",
                "Recepcionista",
                "Jefe de Taller",
                "Cajero",
                "Técnico de Diagnóstico",
                "Asesor de Servicio"
            });
            cboCargo.Location = new System.Drawing.Point(20, 122);
            cboCargo.Name = "cboCargo";
            cboCargo.Size = new System.Drawing.Size(320, 24);
            cboCargo.TabIndex = 1;
            cboCargo.TextChanged += Input_TextChanged;

            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTelefono.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblTelefono.Location = new System.Drawing.Point(20, 152);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new System.Drawing.Size(56, 15);
            lblTelefono.TabIndex = 4;
            lblTelefono.Text = "Teléfono";

            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtTelefono.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtTelefono.Location = new System.Drawing.Point(20, 169);
            txtTelefono.MaxLength = 30;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new System.Drawing.Size(320, 24);
            txtTelefono.TabIndex = 2;
            txtTelefono.TextChanged += Input_TextChanged;

            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCorreo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblCorreo.Location = new System.Drawing.Point(20, 199);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new System.Drawing.Size(111, 15);
            lblCorreo.TabIndex = 5;
            lblCorreo.Text = "Correo Electrónico";

            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtCorreo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtCorreo.Location = new System.Drawing.Point(20, 216);
            txtCorreo.MaxLength = 150;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new System.Drawing.Size(320, 24);
            txtCorreo.TabIndex = 3;
            txtCorreo.TextChanged += Input_TextChanged;

            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblEstado.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblEstado.Location = new System.Drawing.Point(20, 246);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new System.Drawing.Size(51, 15);
            lblEstado.TabIndex = 6;
            lblEstado.Text = "Estado *";

            // 
            // cboEstado
            // 
            cboEstado.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cboEstado.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboEstado.FormattingEnabled = true;
            cboEstado.Items.AddRange(new object[] {
                "Activo",
                "Inactivo"
            });
            cboEstado.Location = new System.Drawing.Point(20, 263);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new System.Drawing.Size(320, 24);
            cboEstado.TabIndex = 4;
            cboEstado.SelectedIndex = 0;
            cboEstado.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblMensaje
            // 
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblMensaje.Location = new System.Drawing.Point(20, 295);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(320, 34);
            lblMensaje.TabIndex = 7;
            lblMensaje.Text = "";
            lblMensaje.Visible = false;

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Location = new System.Drawing.Point(20, 345);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(155, 42);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar Empleado";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;

            // 
            // btnModificar
            // 
            btnModificar.BackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnModificar.FlatAppearance.BorderSize = 0;
            btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnModificar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnModificar.ForeColor = System.Drawing.Color.White;
            btnModificar.Location = new System.Drawing.Point(185, 345);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new System.Drawing.Size(155, 42);
            btnModificar.TabIndex = 6;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;

            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnEliminar.ForeColor = System.Drawing.Color.White;
            btnEliminar.Location = new System.Drawing.Point(20, 397);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(155, 42);
            btnEliminar.TabIndex = 7;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;

            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnLimpiar.ForeColor = System.Drawing.Color.White;
            btnLimpiar.Location = new System.Drawing.Point(185, 397);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new System.Drawing.Size(155, 42);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Nuevo / Limpiar";
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
            pnlTableCard.Controls.Add(lblTotalEmpleados);
            pnlTableCard.Controls.Add(dgvEmpleados);
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
            lblTableTitulo.Location = new System.Drawing.Point(20, 14);
            lblTableTitulo.Name = "lblTableTitulo";
            lblTableTitulo.Size = new System.Drawing.Size(217, 20);
            lblTableTitulo.TabIndex = 0;
            lblTableTitulo.Text = "Listado de Empleados Activos";

            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblBuscar.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblBuscar.Location = new System.Drawing.Point(20, 46);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new System.Drawing.Size(47, 15);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar:";

            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtBuscar.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtBuscar.Location = new System.Drawing.Point(73, 42);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Filtrar por nombre, cargo, teléfono o correo...";
            txtBuscar.Size = new System.Drawing.Size(350, 25);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            // 
            // btnRefrescar
            // 
            btnRefrescar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btnRefrescar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnRefrescar.Location = new System.Drawing.Point(433, 41);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new System.Drawing.Size(110, 27);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "↻ Limpiar Filtro";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += BtnRefrescar_Click;

            // 
            // lblTotalEmpleados
            // 
            lblTotalEmpleados.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalEmpleados.AutoSize = true;
            lblTotalEmpleados.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotalEmpleados.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199);
            lblTotalEmpleados.Location = new System.Drawing.Point(20, 502);
            lblTotalEmpleados.Name = "lblTotalEmpleados";
            lblTotalEmpleados.Size = new System.Drawing.Size(156, 15);
            lblTotalEmpleados.TabIndex = 3;
            lblTotalEmpleados.Text = "Total empleados activos: 0";

            // 
            // dgvEmpleados
            // 
            dgvEmpleados.AllowUserToAddRows = false;
            dgvEmpleados.AllowUserToDeleteRows = false;
            dgvEmpleados.AllowUserToResizeRows = false;
            dgvEmpleados.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmpleados.BackgroundColor = System.Drawing.Color.White;
            dgvEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmpleados.Location = new System.Drawing.Point(20, 78);
            dgvEmpleados.MultiSelect = false;
            dgvEmpleados.Name = "dgvEmpleados";
            dgvEmpleados.ReadOnly = true;
            dgvEmpleados.RowHeadersVisible = false;
            dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleados.Size = new System.Drawing.Size(523, 410);
            dgvEmpleados.TabIndex = 2;
            dgvEmpleados.CellClick += DgvEmpleados_CellClick;
            dgvEmpleados.SelectionChanged += DgvEmpleados_SelectionChanged;

            // 
            // FrmEmpleados
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            ClientSize = new System.Drawing.Size(980, 635);
            Controls.Add(pnlTableCard);
            Controls.Add(pnlFormCard);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmEmpleados";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Administración de Empleados - Taller Mecánico Radiator Springs / Toluca";
            Load += FrmEmpleados_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).EndInit();
            pnlFormCard.ResumeLayout(false);
            pnlFormCard.PerformLayout();
            pnlTableCard.ResumeLayout(false);
            pnlTableCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmpleados).EndInit();
            ResumeLayout(false);
        }
    }
}


