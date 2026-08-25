namespace TallerTolucaUI
{
    partial class FrmVehiculos
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
        private System.Windows.Forms.Label lblPlaca;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label lblTipoVehiculo;
        private System.Windows.Forms.ComboBox cboTipoVehiculo;
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
        private System.Windows.Forms.Label lblTotalVehiculos;
        private System.Windows.Forms.DataGridView dgvVehiculos;

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
            lblPlaca = new System.Windows.Forms.Label();
            txtPlaca = new System.Windows.Forms.TextBox();
            lblMarca = new System.Windows.Forms.Label();
            cboMarca = new System.Windows.Forms.ComboBox();
            lblModelo = new System.Windows.Forms.Label();
            txtModelo = new System.Windows.Forms.TextBox();
            lblAnio = new System.Windows.Forms.Label();
            txtAnio = new System.Windows.Forms.TextBox();
            lblColor = new System.Windows.Forms.Label();
            txtColor = new System.Windows.Forms.TextBox();
            lblTipoVehiculo = new System.Windows.Forms.Label();
            cboTipoVehiculo = new System.Windows.Forms.ComboBox();
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
            lblTotalVehiculos = new System.Windows.Forms.Label();
            dgvVehiculos = new System.Windows.Forms.DataGridView();

            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).BeginInit();
            pnlFormCard.SuspendLayout();
            pnlTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).BeginInit();
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
            lblHeaderTitle.Size = new System.Drawing.Size(256, 25);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Administración de Vehículos";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblHeaderSubtitle.Location = new System.Drawing.Point(76, 38);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new System.Drawing.Size(445, 15);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "Sistema de Gestión Automotriz - Taller Toluca | Gestión de Vehículos (TMS-13 / TMS-14)";

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
            pnlFormCard.BackColor = System.Drawing.Color.White;
            pnlFormCard.Controls.Add(lblFormTitulo);
            pnlFormCard.Controls.Add(lblCamposObligatorios);
            pnlFormCard.Controls.Add(lblCliente);
            pnlFormCard.Controls.Add(cboCliente);
            pnlFormCard.Controls.Add(lblPlaca);
            pnlFormCard.Controls.Add(txtPlaca);
            pnlFormCard.Controls.Add(lblMarca);
            pnlFormCard.Controls.Add(cboMarca);
            pnlFormCard.Controls.Add(lblModelo);
            pnlFormCard.Controls.Add(txtModelo);
            pnlFormCard.Controls.Add(lblAnio);
            pnlFormCard.Controls.Add(txtAnio);
            pnlFormCard.Controls.Add(lblColor);
            pnlFormCard.Controls.Add(txtColor);
            pnlFormCard.Controls.Add(lblTipoVehiculo);
            pnlFormCard.Controls.Add(cboTipoVehiculo);
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
            lblFormTitulo.Size = new System.Drawing.Size(140, 20);
            lblFormTitulo.TabIndex = 0;
            lblFormTitulo.Text = "Datos del Vehículo";

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
            lblCliente.Location = new System.Drawing.Point(20, 62);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new System.Drawing.Size(125, 15);
            lblCliente.TabIndex = 2;
            lblCliente.Text = "Cliente Propietario *";

            // 
            // cboCliente
            // 
            cboCliente.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboCliente.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboCliente.Location = new System.Drawing.Point(20, 81);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new System.Drawing.Size(320, 25);
            cboCliente.TabIndex = 0;
            cboCliente.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblPlaca.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblPlaca.Location = new System.Drawing.Point(20, 114);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new System.Drawing.Size(111, 15);
            lblPlaca.TabIndex = 3;
            lblPlaca.Text = "Placa / Matrícula *";

            // 
            // txtPlaca
            // 
            txtPlaca.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPlaca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtPlaca.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtPlaca.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtPlaca.Location = new System.Drawing.Point(20, 133);
            txtPlaca.MaxLength = 20;
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new System.Drawing.Size(150, 25);
            txtPlaca.TabIndex = 1;
            txtPlaca.TextChanged += Input_TextChanged;

            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblMarca.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblMarca.Location = new System.Drawing.Point(185, 114);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new System.Drawing.Size(51, 15);
            lblMarca.TabIndex = 4;
            lblMarca.Text = "Marca *";

            // 
            // cboMarca
            // 
            cboMarca.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboMarca.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboMarca.FormattingEnabled = true;
            cboMarca.Items.AddRange(new object[] {
                "Toyota",
                "Nissan",
                "Honda",
                "Hyundai",
                "Kia",
                "Mazda",
                "Ford",
                "Chevrolet",
                "Volkswagen",
                "Mitsubishi",
                "Suzuki",
                "BMW",
                "Mercedes-Benz",
                "Jeep",
                "Audi",
                "Subaru",
                "Renault",
                "Peugeot",
                "Otro"
            });
            cboMarca.Location = new System.Drawing.Point(185, 133);
            cboMarca.MaxLength = 50;
            cboMarca.Name = "cboMarca";
            cboMarca.Size = new System.Drawing.Size(155, 25);
            cboMarca.TabIndex = 2;
            cboMarca.TextChanged += Input_TextChanged;

            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblModelo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblModelo.Location = new System.Drawing.Point(20, 166);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new System.Drawing.Size(59, 15);
            lblModelo.TabIndex = 5;
            lblModelo.Text = "Modelo *";

            // 
            // txtModelo
            // 
            txtModelo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtModelo.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtModelo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtModelo.Location = new System.Drawing.Point(20, 185);
            txtModelo.MaxLength = 50;
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new System.Drawing.Size(320, 25);
            txtModelo.TabIndex = 3;
            txtModelo.TextChanged += Input_TextChanged;

            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblAnio.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblAnio.Location = new System.Drawing.Point(20, 218);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new System.Drawing.Size(117, 15);
            lblAnio.TabIndex = 6;
            lblAnio.Text = "Año de Fabricación *";

            // 
            // txtAnio
            // 
            txtAnio.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtAnio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtAnio.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtAnio.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtAnio.Location = new System.Drawing.Point(20, 237);
            txtAnio.MaxLength = 4;
            txtAnio.Name = "txtAnio";
            txtAnio.Size = new System.Drawing.Size(150, 25);
            txtAnio.TabIndex = 4;
            txtAnio.TextChanged += Input_TextChanged;

            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblColor.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblColor.Location = new System.Drawing.Point(185, 218);
            lblColor.Name = "lblColor";
            lblColor.Size = new System.Drawing.Size(36, 15);
            lblColor.TabIndex = 7;
            lblColor.Text = "Color";

            // 
            // txtColor
            // 
            txtColor.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtColor.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtColor.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtColor.Location = new System.Drawing.Point(185, 237);
            txtColor.MaxLength = 30;
            txtColor.Name = "txtColor";
            txtColor.Size = new System.Drawing.Size(155, 25);
            txtColor.TabIndex = 5;
            txtColor.TextChanged += Input_TextChanged;

            // 
            // lblTipoVehiculo
            // 
            lblTipoVehiculo.AutoSize = true;
            lblTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTipoVehiculo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblTipoVehiculo.Location = new System.Drawing.Point(20, 270);
            lblTipoVehiculo.Name = "lblTipoVehiculo";
            lblTipoVehiculo.Size = new System.Drawing.Size(256, 15);
            lblTipoVehiculo.TabIndex = 8;
            lblTipoVehiculo.Text = "Tipo de Vehículo * (Restricción: Solo Livianos)";

            // 
            // cboTipoVehiculo
            // 
            cboTipoVehiculo.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTipoVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboTipoVehiculo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboTipoVehiculo.Items.AddRange(new object[] { "Liviano" });
            cboTipoVehiculo.Location = new System.Drawing.Point(20, 289);
            cboTipoVehiculo.Name = "cboTipoVehiculo";
            cboTipoVehiculo.Size = new System.Drawing.Size(320, 25);
            cboTipoVehiculo.TabIndex = 6;
            cboTipoVehiculo.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblMensaje
            // 
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblMensaje.Location = new System.Drawing.Point(20, 318);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(320, 32);
            lblMensaje.TabIndex = 9;
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
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar Vehículo";
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
            btnModificar.TabIndex = 8;
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
            btnEliminar.TabIndex = 9;
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
            btnLimpiar.TabIndex = 10;
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
            pnlTableCard.Controls.Add(lblTotalVehiculos);
            pnlTableCard.Controls.Add(dgvVehiculos);
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
            lblTableTitulo.Size = new System.Drawing.Size(236, 20);
            lblTableTitulo.TabIndex = 0;
            lblTableTitulo.Text = "Listado de Vehículos Registrados";

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
            txtBuscar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtBuscar.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtBuscar.Location = new System.Drawing.Point(73, 44);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Filtrar por placa, marca, modelo, cliente...";
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
            btnRefrescar.Location = new System.Drawing.Point(433, 43);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new System.Drawing.Size(110, 27);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += BtnRefrescar_Click;

            // 
            // lblTotalVehiculos
            // 
            lblTotalVehiculos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalVehiculos.AutoSize = true;
            lblTotalVehiculos.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblTotalVehiculos.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTotalVehiculos.Location = new System.Drawing.Point(20, 505);
            lblTotalVehiculos.Name = "lblTotalVehiculos";
            lblTotalVehiculos.Size = new System.Drawing.Size(161, 15);
            lblTotalVehiculos.TabIndex = 2;
            lblTotalVehiculos.Text = "Total vehículos activos: 0";

            // 
            // dgvVehiculos
            // 
            dgvVehiculos.AllowUserToAddRows = false;
            dgvVehiculos.AllowUserToDeleteRows = false;
            dgvVehiculos.AllowUserToResizeRows = false;
            dgvVehiculos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvVehiculos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvVehiculos.BackgroundColor = System.Drawing.Color.White;
            dgvVehiculos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVehiculos.Location = new System.Drawing.Point(20, 80);
            dgvVehiculos.MultiSelect = false;
            dgvVehiculos.Name = "dgvVehiculos";
            dgvVehiculos.ReadOnly = true;
            dgvVehiculos.RowHeadersVisible = false;
            dgvVehiculos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvVehiculos.Size = new System.Drawing.Size(525, 415);
            dgvVehiculos.TabIndex = 2;
            dgvVehiculos.CellClick += DgvVehiculos_CellClick;
            dgvVehiculos.SelectionChanged += DgvVehiculos_SelectionChanged;

            // 
            // FrmVehiculos
            // 
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            ClientSize = new System.Drawing.Size(980, 640);
            Controls.Add(pnlTableCard);
            Controls.Add(pnlFormCard);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(950, 620);
            Name = "FrmVehiculos";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Administración de Vehículos";
            Load += FrmVehiculos_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).EndInit();
            pnlFormCard.ResumeLayout(false);
            pnlFormCard.PerformLayout();
            pnlTableCard.ResumeLayout(false);
            pnlTableCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVehiculos).EndInit();
            ResumeLayout(false);
        }
    }
}
