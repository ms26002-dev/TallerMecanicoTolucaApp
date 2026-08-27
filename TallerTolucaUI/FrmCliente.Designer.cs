namespace TallerTolucaUI
{
    partial class FrmClientes
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
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
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
        private System.Windows.Forms.Label lblTotalClientes;
        private System.Windows.Forms.DataGridView dgvClientes;

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
            lblTelefono = new System.Windows.Forms.Label();
            txtTelefono = new System.Windows.Forms.TextBox();
            lblCorreo = new System.Windows.Forms.Label();
            txtCorreo = new System.Windows.Forms.TextBox();
            lblDireccion = new System.Windows.Forms.Label();
            txtDireccion = new System.Windows.Forms.TextBox();
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
            lblTotalClientes = new System.Windows.Forms.Label();
            dgvClientes = new System.Windows.Forms.DataGridView();

            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).BeginInit();
            pnlFormCard.SuspendLayout();
            pnlTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
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
            lblHeaderTitle.Size = new System.Drawing.Size(248, 25);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Administración de Clientes";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblHeaderSubtitle.Location = new System.Drawing.Point(76, 38);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new System.Drawing.Size(395, 15);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "Sistema de Gestión Automotriz - Taller Toluca | Módulo de Clientes";

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
            pnlFormCard.Controls.Add(lblNombre);
            pnlFormCard.Controls.Add(txtNombre);
            pnlFormCard.Controls.Add(lblTelefono);
            pnlFormCard.Controls.Add(txtTelefono);
            pnlFormCard.Controls.Add(lblCorreo);
            pnlFormCard.Controls.Add(txtCorreo);
            pnlFormCard.Controls.Add(lblDireccion);
            pnlFormCard.Controls.Add(txtDireccion);
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
            lblFormTitulo.Location = new System.Drawing.Point(20, 16);
            lblFormTitulo.Name = "lblFormTitulo";
            lblFormTitulo.Size = new System.Drawing.Size(126, 20);
            lblFormTitulo.TabIndex = 0;
            lblFormTitulo.Text = "Datos del Cliente";

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
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblNombre.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblNombre.Location = new System.Drawing.Point(20, 66);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new System.Drawing.Size(117, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre Completo *";

            // 
            // txtNombre
            // 
            txtNombre.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtNombre.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtNombre.Location = new System.Drawing.Point(20, 85);
            txtNombre.MaxLength = 150;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new System.Drawing.Size(320, 25);
            txtNombre.TabIndex = 0;
            txtNombre.TextChanged += Input_TextChanged;

            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTelefono.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblTelefono.Location = new System.Drawing.Point(20, 120);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new System.Drawing.Size(64, 15);
            lblTelefono.TabIndex = 3;
            lblTelefono.Text = "Teléfono *";

            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTelefono.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtTelefono.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtTelefono.Location = new System.Drawing.Point(20, 139);
            txtTelefono.MaxLength = 30;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new System.Drawing.Size(320, 25);
            txtTelefono.TabIndex = 1;
            txtTelefono.TextChanged += Input_TextChanged;

            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCorreo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblCorreo.Location = new System.Drawing.Point(20, 174);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new System.Drawing.Size(111, 15);
            lblCorreo.TabIndex = 4;
            lblCorreo.Text = "Correo Electrónico";

            // 
            // txtCorreo
            // 
            txtCorreo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtCorreo.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtCorreo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtCorreo.Location = new System.Drawing.Point(20, 193);
            txtCorreo.MaxLength = 150;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new System.Drawing.Size(320, 25);
            txtCorreo.TabIndex = 2;
            txtCorreo.TextChanged += Input_TextChanged;

            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDireccion.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblDireccion.Location = new System.Drawing.Point(20, 228);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new System.Drawing.Size(60, 15);
            lblDireccion.TabIndex = 5;
            lblDireccion.Text = "Dirección";

            // 
            // txtDireccion
            // 
            txtDireccion.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtDireccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtDireccion.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtDireccion.Location = new System.Drawing.Point(20, 247);
            txtDireccion.MaxLength = 250;
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new System.Drawing.Size(320, 60);
            txtDireccion.TabIndex = 3;
            txtDireccion.TextChanged += Input_TextChanged;

            // 
            // lblMensaje
            // 
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblMensaje.Location = new System.Drawing.Point(20, 313);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(320, 36);
            lblMensaje.TabIndex = 6;
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
            btnGuardar.Location = new System.Drawing.Point(20, 355);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(155, 42);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar Cliente";
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
            btnModificar.Location = new System.Drawing.Point(185, 355);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new System.Drawing.Size(155, 42);
            btnModificar.TabIndex = 5;
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
            btnEliminar.Location = new System.Drawing.Point(20, 407);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new System.Drawing.Size(155, 42);
            btnEliminar.TabIndex = 6;
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
            btnLimpiar.Location = new System.Drawing.Point(185, 407);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new System.Drawing.Size(155, 42);
            btnLimpiar.TabIndex = 7;
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
            pnlTableCard.Controls.Add(lblTotalClientes);
            pnlTableCard.Controls.Add(dgvClientes);
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
            lblTableTitulo.Size = new System.Drawing.Size(200, 20);
            lblTableTitulo.TabIndex = 0;
            lblTableTitulo.Text = "Listado de Clientes Activos";

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
            txtBuscar.PlaceholderText = "Filtrar por nombre, teléfono, correo o dirección...";
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
            btnRefrescar.Text = "↻ Limpiar Filtro";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += BtnRefrescar_Click;

            // 
            // lblTotalClientes
            // 
            lblTotalClientes.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalClientes.AutoSize = true;
            lblTotalClientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotalClientes.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199);
            lblTotalClientes.Location = new System.Drawing.Point(20, 502);
            lblTotalClientes.Name = "lblTotalClientes";
            lblTotalClientes.Size = new System.Drawing.Size(139, 15);
            lblTotalClientes.TabIndex = 3;
            lblTotalClientes.Text = "Total clientes activos: 0";

            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = System.Drawing.Color.White;
            dgvClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new System.Drawing.Point(20, 80);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new System.Drawing.Size(523, 408);
            dgvClientes.TabIndex = 2;
            dgvClientes.CellClick += DgvClientes_CellClick;
            dgvClientes.SelectionChanged += DgvClientes_SelectionChanged;

            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            ClientSize = new System.Drawing.Size(980, 635);
            Controls.Add(pnlTableCard);
            Controls.Add(pnlFormCard);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new System.Drawing.Size(950, 600);
            Name = "FrmClientes";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Text = "Administración de Clientes - Taller Toluca";
            Load += FrmClientes_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).EndInit();
            pnlFormCard.ResumeLayout(false);
            pnlFormCard.PerformLayout();
            pnlTableCard.ResumeLayout(false);
            pnlTableCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
        }
    }
}

