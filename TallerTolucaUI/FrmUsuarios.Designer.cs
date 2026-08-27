namespace TallerTolucaUI
{
    partial class FrmUsuarios
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
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cboEmpleado;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblConfirmarClave;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.Button btnLimpiar;

        private System.Windows.Forms.Panel pnlTableCard;
        private System.Windows.Forms.Label lblTableTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblTotalUsuarios;
        private System.Windows.Forms.DataGridView dgvUsuarios;

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
            lblEmpleado = new System.Windows.Forms.Label();
            cboEmpleado = new System.Windows.Forms.ComboBox();
            lblNombreUsuario = new System.Windows.Forms.Label();
            txtNombreUsuario = new System.Windows.Forms.TextBox();
            lblClave = new System.Windows.Forms.Label();
            txtClave = new System.Windows.Forms.TextBox();
            lblConfirmarClave = new System.Windows.Forms.Label();
            txtConfirmarClave = new System.Windows.Forms.TextBox();
            lblRol = new System.Windows.Forms.Label();
            cboRol = new System.Windows.Forms.ComboBox();
            lblEstado = new System.Windows.Forms.Label();
            cboEstado = new System.Windows.Forms.ComboBox();
            lblMensaje = new System.Windows.Forms.Label();
            btnGuardar = new System.Windows.Forms.Button();
            btnModificar = new System.Windows.Forms.Button();
            btnDesactivar = new System.Windows.Forms.Button();
            btnLimpiar = new System.Windows.Forms.Button();

            pnlTableCard = new System.Windows.Forms.Panel();
            lblTableTitulo = new System.Windows.Forms.Label();
            lblBuscar = new System.Windows.Forms.Label();
            txtBuscar = new System.Windows.Forms.TextBox();
            btnRefrescar = new System.Windows.Forms.Button();
            lblTotalUsuarios = new System.Windows.Forms.Label();
            dgvUsuarios = new System.Windows.Forms.DataGridView();

            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).BeginInit();
            pnlFormCard.SuspendLayout();
            pnlTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
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
            lblHeaderTitle.Text = "Administración de Usuarios";

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
            lblHeaderSubtitle.Text = "Sistema de Gestión Automotriz - Taller Toluca | Cuentas de Acceso al Sistema";

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
            pnlFormCard.Controls.Add(lblEmpleado);
            pnlFormCard.Controls.Add(cboEmpleado);
            pnlFormCard.Controls.Add(lblNombreUsuario);
            pnlFormCard.Controls.Add(txtNombreUsuario);
            pnlFormCard.Controls.Add(lblClave);
            pnlFormCard.Controls.Add(txtClave);
            pnlFormCard.Controls.Add(lblConfirmarClave);
            pnlFormCard.Controls.Add(txtConfirmarClave);
            pnlFormCard.Controls.Add(lblRol);
            pnlFormCard.Controls.Add(cboRol);
            pnlFormCard.Controls.Add(lblEstado);
            pnlFormCard.Controls.Add(cboEstado);
            pnlFormCard.Controls.Add(lblMensaje);
            pnlFormCard.Controls.Add(btnGuardar);
            pnlFormCard.Controls.Add(btnModificar);
            pnlFormCard.Controls.Add(btnDesactivar);
            pnlFormCard.Controls.Add(btnLimpiar);
            pnlFormCard.Location = new System.Drawing.Point(20, 84);
            pnlFormCard.Name = "pnlFormCard";
            pnlFormCard.Size = new System.Drawing.Size(360, 596);
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
            lblFormTitulo.Text = "Datos del Usuario";

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
            // lblEmpleado
            //
            lblEmpleado.AutoSize = true;
            lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblEmpleado.Location = new System.Drawing.Point(20, 58);
            lblEmpleado.Name = "lblEmpleado";
            lblEmpleado.Size = new System.Drawing.Size(90, 15);
            lblEmpleado.TabIndex = 2;
            lblEmpleado.Text = "Empleado *";

            //
            // cboEmpleado
            //
            cboEmpleado.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEmpleado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cboEmpleado.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboEmpleado.FormattingEnabled = true;
            cboEmpleado.Location = new System.Drawing.Point(20, 75);
            cboEmpleado.Name = "cboEmpleado";
            cboEmpleado.Size = new System.Drawing.Size(320, 24);
            cboEmpleado.TabIndex = 0;
            cboEmpleado.SelectedIndexChanged += Input_TextChanged;

            //
            // lblNombreUsuario
            //
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblNombreUsuario.Location = new System.Drawing.Point(20, 105);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new System.Drawing.Size(120, 15);
            lblNombreUsuario.TabIndex = 3;
            lblNombreUsuario.Text = "Nombre de Usuario *";

            //
            // txtNombreUsuario
            //
            txtNombreUsuario.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtNombreUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtNombreUsuario.Location = new System.Drawing.Point(20, 122);
            txtNombreUsuario.MaxLength = 50;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new System.Drawing.Size(320, 24);
            txtNombreUsuario.TabIndex = 1;
            txtNombreUsuario.TextChanged += Input_TextChanged;

            //
            // lblClave
            //
            lblClave.AutoSize = true;
            lblClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblClave.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblClave.Location = new System.Drawing.Point(20, 152);
            lblClave.Name = "lblClave";
            lblClave.Size = new System.Drawing.Size(90, 15);
            lblClave.TabIndex = 4;
            lblClave.Text = "Contraseña *";

            //
            // txtClave
            //
            txtClave.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtClave.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtClave.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtClave.Location = new System.Drawing.Point(20, 169);
            txtClave.MaxLength = 100;
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '●';
            txtClave.Size = new System.Drawing.Size(320, 24);
            txtClave.TabIndex = 2;
            txtClave.TextChanged += Input_TextChanged;

            //
            // lblConfirmarClave
            //
            lblConfirmarClave.AutoSize = true;
            lblConfirmarClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblConfirmarClave.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblConfirmarClave.Location = new System.Drawing.Point(20, 199);
            lblConfirmarClave.Name = "lblConfirmarClave";
            lblConfirmarClave.Size = new System.Drawing.Size(140, 15);
            lblConfirmarClave.TabIndex = 5;
            lblConfirmarClave.Text = "Confirmar Contraseña *";

            //
            // txtConfirmarClave
            //
            txtConfirmarClave.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtConfirmarClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtConfirmarClave.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            txtConfirmarClave.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtConfirmarClave.Location = new System.Drawing.Point(20, 216);
            txtConfirmarClave.MaxLength = 100;
            txtConfirmarClave.Name = "txtConfirmarClave";
            txtConfirmarClave.PasswordChar = '●';
            txtConfirmarClave.Size = new System.Drawing.Size(320, 24);
            txtConfirmarClave.TabIndex = 3;
            txtConfirmarClave.TextChanged += Input_TextChanged;

            //
            // lblRol
            //
            lblRol.AutoSize = true;
            lblRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblRol.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblRol.Location = new System.Drawing.Point(20, 246);
            lblRol.Name = "lblRol";
            lblRol.Size = new System.Drawing.Size(50, 15);
            lblRol.TabIndex = 6;
            lblRol.Text = "Rol *";

            //
            // cboRol
            //
            cboRol.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboRol.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            cboRol.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboRol.FormattingEnabled = true;
            cboRol.Items.AddRange(new object[] {
                "Administrador",
                "Recepcionista",
                "Mecánico"
            });
            cboRol.Location = new System.Drawing.Point(20, 263);
            cboRol.Name = "cboRol";
            cboRol.Size = new System.Drawing.Size(320, 24);
            cboRol.TabIndex = 4;
            cboRol.SelectedIndexChanged += Input_TextChanged;

            //
            // lblEstado
            //
            lblEstado.AutoSize = true;
            lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblEstado.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblEstado.Location = new System.Drawing.Point(20, 293);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new System.Drawing.Size(51, 15);
            lblEstado.TabIndex = 7;
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
            cboEstado.Location = new System.Drawing.Point(20, 310);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new System.Drawing.Size(320, 24);
            cboEstado.TabIndex = 5;
            cboEstado.SelectedIndex = 0;
            cboEstado.SelectedIndexChanged += Input_TextChanged;

            //
            // lblMensaje
            //
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblMensaje.Location = new System.Drawing.Point(20, 342);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(320, 34);
            lblMensaje.TabIndex = 8;
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
            btnGuardar.Location = new System.Drawing.Point(20, 392);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new System.Drawing.Size(155, 42);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Crear Usuario";
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
            btnModificar.Location = new System.Drawing.Point(185, 392);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new System.Drawing.Size(155, 42);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;

            //
            // btnDesactivar
            //
            btnDesactivar.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnDesactivar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDesactivar.FlatAppearance.BorderSize = 0;
            btnDesactivar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDesactivar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnDesactivar.ForeColor = System.Drawing.Color.White;
            btnDesactivar.Location = new System.Drawing.Point(20, 444);
            btnDesactivar.Name = "btnDesactivar";
            btnDesactivar.Size = new System.Drawing.Size(155, 42);
            btnDesactivar.TabIndex = 8;
            btnDesactivar.Text = "Desactivar Acceso";
            btnDesactivar.UseVisualStyleBackColor = false;
            btnDesactivar.Click += btnDesactivar_Click;

            //
            // btnLimpiar
            //
            btnLimpiar.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnLimpiar.ForeColor = System.Drawing.Color.White;
            btnLimpiar.Location = new System.Drawing.Point(185, 444);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new System.Drawing.Size(155, 42);
            btnLimpiar.TabIndex = 9;
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
            pnlTableCard.Controls.Add(lblTotalUsuarios);
            pnlTableCard.Controls.Add(dgvUsuarios);
            pnlTableCard.Location = new System.Drawing.Point(395, 84);
            pnlTableCard.Name = "pnlTableCard";
            pnlTableCard.Size = new System.Drawing.Size(565, 596);
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
            lblTableTitulo.Text = "Listado de Usuarios";

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
            txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtBuscar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtBuscar.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtBuscar.Location = new System.Drawing.Point(73, 42);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Filtrar por usuario, empleado o rol...";
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
            btnRefrescar.Location = new System.Drawing.Point(433, 41);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new System.Drawing.Size(110, 27);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "↻ Limpiar Filtro";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += BtnRefrescar_Click;

            //
            // lblTotalUsuarios
            //
            lblTotalUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalUsuarios.AutoSize = true;
            lblTotalUsuarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotalUsuarios.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199);
            lblTotalUsuarios.Location = new System.Drawing.Point(20, 562);
            lblTotalUsuarios.Name = "lblTotalUsuarios";
            lblTotalUsuarios.Size = new System.Drawing.Size(156, 15);
            lblTotalUsuarios.TabIndex = 3;
            lblTotalUsuarios.Text = "Total usuarios: 0";

            //
            // dgvUsuarios
            //
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new System.Drawing.Point(20, 78);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new System.Drawing.Size(523, 470);
            dgvUsuarios.TabIndex = 2;
            dgvUsuarios.CellClick += DgvUsuarios_CellClick;
            dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;

            //
            // FrmUsuarios
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            ClientSize = new System.Drawing.Size(980, 695);
            Controls.Add(pnlTableCard);
            Controls.Add(pnlFormCard);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new System.Drawing.Size(950, 660);
            Name = "FrmUsuarios";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Text = "Administración de Usuarios - Taller Toluca";
            Load += FrmUsuarios_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).EndInit();
            pnlFormCard.ResumeLayout(false);
            pnlFormCard.PerformLayout();
            pnlTableCard.ResumeLayout(false);
            pnlTableCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }
    }
}
