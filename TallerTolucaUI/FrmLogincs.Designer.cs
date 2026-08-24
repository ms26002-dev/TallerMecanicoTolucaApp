namespace TallerTolucaUI
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Label lblTituloModulo;
        private System.Windows.Forms.Label lblCamposObligatorios;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.CheckBox chkMostrarClave;
        private System.Windows.Forms.Label lblCapsLock;
        private System.Windows.Forms.Label lblMensajeError;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard = new System.Windows.Forms.Panel();
            picLogo = new System.Windows.Forms.PictureBox();
            lblTituloPrincipal = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();
            lblSeparador = new System.Windows.Forms.Label();
            lblTituloModulo = new System.Windows.Forms.Label();
            lblCamposObligatorios = new System.Windows.Forms.Label();
            lblUsuario = new System.Windows.Forms.Label();
            txtUsuario = new System.Windows.Forms.TextBox();
            lblClave = new System.Windows.Forms.Label();
            txtClave = new System.Windows.Forms.TextBox();
            chkMostrarClave = new System.Windows.Forms.CheckBox();
            lblCapsLock = new System.Windows.Forms.Label();
            lblMensajeError = new System.Windows.Forms.Label();
            btnIngresar = new System.Windows.Forms.Button();
            btnSalir = new System.Windows.Forms.Button();

            pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();

            // 
            // pnlCard
            // 
            pnlCard.BackColor = System.Drawing.Color.White;
            pnlCard.Controls.Add(picLogo);
            pnlCard.Controls.Add(lblTituloPrincipal);
            pnlCard.Controls.Add(lblSubtitulo);
            pnlCard.Controls.Add(lblSeparador);
            pnlCard.Controls.Add(lblTituloModulo);
            pnlCard.Controls.Add(lblCamposObligatorios);
            pnlCard.Controls.Add(lblUsuario);
            pnlCard.Controls.Add(txtUsuario);
            pnlCard.Controls.Add(lblClave);
            pnlCard.Controls.Add(txtClave);
            pnlCard.Controls.Add(chkMostrarClave);
            pnlCard.Controls.Add(lblCapsLock);
            pnlCard.Controls.Add(lblMensajeError);
            pnlCard.Controls.Add(btnIngresar);
            pnlCard.Controls.Add(btnSalir);
            pnlCard.Location = new System.Drawing.Point(25, 20);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new System.Drawing.Size(410, 520);
            pnlCard.TabIndex = 0;
            pnlCard.Paint += PnlCard_Paint;

            // 
            // picLogo
            // 
            picLogo.Location = new System.Drawing.Point(180, 16);
            picLogo.Name = "picLogo";
            picLogo.Size = new System.Drawing.Size(50, 45);
            picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;

            // 
            // lblTituloPrincipal
            // 
            lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTituloPrincipal.Location = new System.Drawing.Point(15, 63);
            lblTituloPrincipal.Name = "lblTituloPrincipal";
            lblTituloPrincipal.Size = new System.Drawing.Size(380, 28);
            lblTituloPrincipal.TabIndex = 1;
            lblTituloPrincipal.Text = "Taller Mecánico Toluca";
            lblTituloPrincipal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblSubtitulo.Location = new System.Drawing.Point(15, 91);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new System.Drawing.Size(380, 18);
            lblSubtitulo.TabIndex = 2;
            lblSubtitulo.Text = "Sistema de Gestión Automotriz - Radiator Springs";
            lblSubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblSeparador
            // 
            lblSeparador.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            lblSeparador.Location = new System.Drawing.Point(30, 116);
            lblSeparador.Name = "lblSeparador";
            lblSeparador.Size = new System.Drawing.Size(350, 1);
            lblSeparador.TabIndex = 3;

            // 
            // lblTituloModulo
            // 
            lblTituloModulo.AutoSize = true;
            lblTituloModulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTituloModulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTituloModulo.Location = new System.Drawing.Point(30, 126);
            lblTituloModulo.Name = "lblTituloModulo";
            lblTituloModulo.Size = new System.Drawing.Size(123, 20);
            lblTituloModulo.TabIndex = 4;
            lblTituloModulo.Text = "Inicio de Sesión";

            // 
            // lblCamposObligatorios
            // 
            lblCamposObligatorios.AutoSize = true;
            lblCamposObligatorios.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblCamposObligatorios.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblCamposObligatorios.Location = new System.Drawing.Point(30, 149);
            lblCamposObligatorios.Name = "lblCamposObligatorios";
            lblCamposObligatorios.Size = new System.Drawing.Size(262, 13);
            lblCamposObligatorios.TabIndex = 5;
            lblCamposObligatorios.Text = "Los campos obligatorios están marcados con un asterisco *";

            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblUsuario.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblUsuario.Location = new System.Drawing.Point(30, 175);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new System.Drawing.Size(140, 17);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Nombre de usuario *";

            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtUsuario.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtUsuario.Location = new System.Drawing.Point(30, 198);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new System.Drawing.Size(350, 26);
            txtUsuario.TabIndex = 0;
            txtUsuario.TextChanged += Campos_TextChanged;

            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblClave.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblClave.Location = new System.Drawing.Point(30, 236);
            lblClave.Name = "lblClave";
            lblClave.Size = new System.Drawing.Size(89, 17);
            lblClave.TabIndex = 7;
            lblClave.Text = "Contraseña *";

            // 
            // txtClave
            // 
            txtClave.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtClave.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            txtClave.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtClave.Location = new System.Drawing.Point(30, 259);
            txtClave.MaxLength = 100;
            txtClave.Name = "txtClave";
            txtClave.Size = new System.Drawing.Size(350, 26);
            txtClave.TabIndex = 1;
            txtClave.UseSystemPasswordChar = true;
            txtClave.TextChanged += Campos_TextChanged;
            txtClave.KeyDown += TxtClave_KeyDown;

            // 
            // chkMostrarClave
            // 
            chkMostrarClave.AutoSize = true;
            chkMostrarClave.Cursor = System.Windows.Forms.Cursors.Hand;
            chkMostrarClave.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            chkMostrarClave.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            chkMostrarClave.Location = new System.Drawing.Point(30, 293);
            chkMostrarClave.Name = "chkMostrarClave";
            chkMostrarClave.Size = new System.Drawing.Size(126, 17);
            chkMostrarClave.TabIndex = 2;
            chkMostrarClave.Text = "Mostrar contraseña";
            chkMostrarClave.UseVisualStyleBackColor = true;
            chkMostrarClave.CheckedChanged += ChkMostrarClave_CheckedChanged;

            // 
            // lblCapsLock
            // 
            lblCapsLock.AutoSize = true;
            lblCapsLock.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            lblCapsLock.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            lblCapsLock.Location = new System.Drawing.Point(210, 294);
            lblCapsLock.Name = "lblCapsLock";
            lblCapsLock.Size = new System.Drawing.Size(170, 13);
            lblCapsLock.TabIndex = 8;
            lblCapsLock.Text = "⚠️ Bloq Mayús está activado";
            lblCapsLock.Visible = false;

            // 
            // lblMensajeError
            // 
            lblMensajeError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblMensajeError.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblMensajeError.Location = new System.Drawing.Point(30, 318);
            lblMensajeError.Name = "lblMensajeError";
            lblMensajeError.Size = new System.Drawing.Size(350, 35);
            lblMensajeError.TabIndex = 9;
            lblMensajeError.Text = "";
            lblMensajeError.Visible = false;

            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            btnIngresar.ForeColor = System.Drawing.Color.White;
            btnIngresar.Location = new System.Drawing.Point(30, 360);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new System.Drawing.Size(350, 44);
            btnIngresar.TabIndex = 3;
            btnIngresar.Text = "Iniciar Sesión";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;

            // 
            // btnSalir
            // 
            btnSalir.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            btnSalir.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnSalir.Location = new System.Drawing.Point(30, 415);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new System.Drawing.Size(350, 36);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir del Sistema";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;

            // 
            // FrmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            CancelButton = btnSalir;
            ClientSize = new System.Drawing.Size(460, 560);
            Controls.Add(pnlCard);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión - Sistema de Gestión de Taller Mecánico";
            Load += FrmLogin_Load;
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
        }
    }
}

