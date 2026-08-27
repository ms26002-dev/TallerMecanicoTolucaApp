namespace TallerTolucaUI
{
    partial class FrmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogoHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblUsuarioActivo;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel pnlDashboardArea;
        private System.Windows.Forms.Panel pnlCardsContainer;

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVehiculos;
        private System.Windows.Forms.Button btnOrdenesTrabajo;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnUsuarios;

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
            lblUsuarioActivo = new System.Windows.Forms.Label();
            btnCerrarSesion = new System.Windows.Forms.Button();

            pnlDashboardArea = new System.Windows.Forms.Panel();
            pnlCardsContainer = new System.Windows.Forms.Panel();

            btnClientes = new System.Windows.Forms.Button();
            btnVehiculos = new System.Windows.Forms.Button();
            btnOrdenesTrabajo = new System.Windows.Forms.Button();
            btnCitas = new System.Windows.Forms.Button();
            btnInventario = new System.Windows.Forms.Button();
            btnCaja = new System.Windows.Forms.Button();
            btnFacturacion = new System.Windows.Forms.Button();
            btnEmpleados = new System.Windows.Forms.Button();
            btnUsuarios = new System.Windows.Forms.Button();

            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).BeginInit();
            pnlDashboardArea.SuspendLayout();
            pnlCardsContainer.SuspendLayout();
            SuspendLayout();

            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.White;
            pnlHeader.Controls.Add(picLogoHeader);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblUsuarioActivo);
            pnlHeader.Controls.Add(btnCerrarSesion);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1080, 75);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += PnlHeader_Paint;

            // 
            // picLogoHeader
            // 
            picLogoHeader.Location = new System.Drawing.Point(24, 14);
            picLogoHeader.Name = "picLogoHeader";
            picLogoHeader.Size = new System.Drawing.Size(48, 46);
            picLogoHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picLogoHeader.TabIndex = 0;
            picLogoHeader.TabStop = false;

            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblHeaderTitle.Location = new System.Drawing.Point(82, 12);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(232, 28);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Taller Mecánico Toluca";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblHeaderSubtitle.Location = new System.Drawing.Point(84, 42);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new System.Drawing.Size(355, 15);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "Sistema Integral de Gestión Automotriz | Panel de Control Principal";

            // 
            // lblUsuarioActivo
            // 
            lblUsuarioActivo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblUsuarioActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblUsuarioActivo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblUsuarioActivo.Location = new System.Drawing.Point(540, 24);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new System.Drawing.Size(380, 26);
            lblUsuarioActivo.TabIndex = 3;
            lblUsuarioActivo.Text = "Usuario: Admin | Rol: Administrador";
            lblUsuarioActivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(254, 202, 202);
            btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            btnCerrarSesion.Location = new System.Drawing.Point(935, 18);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new System.Drawing.Size(120, 38);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            // 
            // pnlDashboardArea
            // 
            pnlDashboardArea.AutoScroll = true;
            pnlDashboardArea.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            pnlDashboardArea.Controls.Add(pnlCardsContainer);
            pnlDashboardArea.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlDashboardArea.Location = new System.Drawing.Point(0, 75);
            pnlDashboardArea.Name = "pnlDashboardArea";
            pnlDashboardArea.Size = new System.Drawing.Size(1080, 605);
            pnlDashboardArea.TabIndex = 1;

            // 
            // pnlCardsContainer
            // 
            pnlCardsContainer.BackColor = System.Drawing.Color.Transparent;
            pnlCardsContainer.Controls.Add(btnClientes);
            pnlCardsContainer.Controls.Add(btnVehiculos);
            pnlCardsContainer.Controls.Add(btnOrdenesTrabajo);
            pnlCardsContainer.Controls.Add(btnCitas);
            pnlCardsContainer.Controls.Add(btnInventario);
            pnlCardsContainer.Controls.Add(btnCaja);
            pnlCardsContainer.Controls.Add(btnFacturacion);
            pnlCardsContainer.Controls.Add(btnEmpleados);
            pnlCardsContainer.Controls.Add(btnUsuarios);
            pnlCardsContainer.Location = new System.Drawing.Point(40, 30);
            pnlCardsContainer.Name = "pnlCardsContainer";
            pnlCardsContainer.Size = new System.Drawing.Size(1000, 580);
            pnlCardsContainer.TabIndex = 0;

            // Fila 1
            ConfigurarTarjetaModulo(btnClientes, "👥 Clientes\n\nDirectorio y registro de clientes", 0, 10);
            ConfigurarTarjetaModulo(btnVehiculos, "🚗 Vehículos\n\nCatálogo y datos de vehículos", 255, 10);
            ConfigurarTarjetaModulo(btnOrdenesTrabajo, "📋 Órdenes de Trabajo\n\nServicios y diagnósticos", 510, 10);
            ConfigurarTarjetaModulo(btnCitas, "📅 Citas\n\nAgenda y programación", 765, 10);

            // Fila 2
            ConfigurarTarjetaModulo(btnInventario, "📦 Inventario\n\nRepuestos, stock y almacén", 0, 200);
            ConfigurarTarjetaModulo(btnCaja, "💵 Caja\n\nAperturas, cobros y arqueos", 255, 200);
            ConfigurarTarjetaModulo(btnFacturacion, "🧾 Facturación\n\nEmisión y comprobantes", 510, 200);
            ConfigurarTarjetaModulo(btnEmpleados, "👔 Empleados\n\nPersonal, roles y accesos", 765, 200);

            // Fila 3
            ConfigurarTarjetaModulo(btnUsuarios, "🔑 Usuarios\n\nCuentas de acceso al sistema", 0, 390);

            btnClientes.Click += btnClientes_Click;
            btnVehiculos.Click += btnVehiculos_Click;
            btnOrdenesTrabajo.Click += btnOrdenesTrabajo_Click;
            btnCitas.Click += btnCitas_Click;
            btnInventario.Click += btnInventario_Click;
            btnCaja.Click += btnCaja_Click;
            btnFacturacion.Click += btnFacturacion_Click;
            btnEmpleados.Click += btnEmpleados_Click;
            btnUsuarios.Click += btnUsuarios_Click;

            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            ClientSize = new System.Drawing.Size(1080, 680);
            Controls.Add(pnlDashboardArea);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new System.Drawing.Size(900, 600);
            Name = "FrmMenuPrincipal";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Text = "Taller Mecánico Toluca - Panel Principal";
            Load += FrmMenuPrincipal_Load;
            Resize += FrmMenuPrincipal_Resize;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).EndInit();
            pnlDashboardArea.ResumeLayout(false);
            pnlCardsContainer.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ConfigurarTarjetaModulo(System.Windows.Forms.Button btn, string texto, int x, int y)
        {
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(235, 170);
            btn.Text = texto;
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            btn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            btn.FlatAppearance.BorderSize = 1;
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
    }
}

