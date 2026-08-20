using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class FrmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        // Sidebar
        private Panel pnlSidebar;
        private Panel pnlLogo;
        private Label lblLogoIcon;
        private Label lblLogoTitle;
        private Label lblLogoSubtitle;
        private Panel pnlNavButtons;
        private Button btnNavInicio;
        private Button btnNavEmpleados;
        private Button btnNavClientes;
        private Button btnNavInventario;
        private Button btnNavVehiculos;
        private Button btnNavOrdenes;
        private Button btnNavCaja;
        private Button btnNavFacturacion;
        private Button btnNavCitas;
        private Panel pnlUserFooter;
        private Label lblUserAvatar;
        private Label lblUserName;
        private Label lblUserRole;
        private Button btnCerrarSesion;

        // Panel contenedor dinámico
        private Panel pnlContenedorPrincipal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlSidebar = new Panel();
            pnlLogo = new Panel();
            lblLogoIcon = new Label();
            lblLogoTitle = new Label();
            lblLogoSubtitle = new Label();
            pnlNavButtons = new Panel();
            btnNavInicio = new Button();
            btnNavEmpleados = new Button();
            btnNavClientes = new Button();
            btnNavInventario = new Button();
            btnNavVehiculos = new Button();
            btnNavOrdenes = new Button();
            btnNavCaja = new Button();
            btnNavFacturacion = new Button();
            btnNavCitas = new Button();
            pnlUserFooter = new Panel();
            lblUserAvatar = new Label();
            lblUserName = new Label();
            lblUserRole = new Label();
            btnCerrarSesion = new Button();
            pnlContenedorPrincipal = new Panel();

            pnlSidebar.SuspendLayout();
            pnlLogo.SuspendLayout();
            pnlNavButtons.SuspendLayout();
            pnlUserFooter.SuspendLayout();
            SuspendLayout();

            // ============================================
            // pnlSidebar (Barra Lateral Izquierda Oscura)
            // ============================================
            pnlSidebar.BackColor = Color.FromArgb(15, 23, 42); // #0F172A Deep Dark Slate
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Width = 240;
            pnlSidebar.Controls.Add(pnlNavButtons);
            pnlSidebar.Controls.Add(pnlUserFooter);
            pnlSidebar.Controls.Add(pnlLogo);

            // ------------------ Logo Header ------------------
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Height = 85;
            pnlLogo.BackColor = Color.FromArgb(11, 15, 25); // #0B0F19
            pnlLogo.Controls.Add(lblLogoIcon);
            pnlLogo.Controls.Add(lblLogoTitle);
            pnlLogo.Controls.Add(lblLogoSubtitle);

            lblLogoIcon.Text = "⚙️";
            lblLogoIcon.Font = new Font("Segoe UI Emoji", 14F);
            lblLogoIcon.ForeColor = Color.FromArgb(0, 191, 255);
            lblLogoIcon.Location = new Point(15, 18);
            lblLogoIcon.Size = new Size(30, 30);

            lblLogoTitle.Text = "Gestión Mecánica";
            lblLogoTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblLogoTitle.ForeColor = Color.FromArgb(0, 191, 255); // #00BFFF Cyan
            lblLogoTitle.Location = new Point(48, 16);
            lblLogoTitle.AutoSize = true;

            lblLogoSubtitle.Text = "PANEL DE CONTROL";
            lblLogoSubtitle.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblLogoSubtitle.ForeColor = Color.FromArgb(148, 163, 184); // #94A3B8
            lblLogoSubtitle.Location = new Point(50, 42);
            lblLogoSubtitle.AutoSize = true;

            // ------------------ Botones de Navegación ------------------
            pnlNavButtons.Dock = DockStyle.Fill;
            pnlNavButtons.AutoScroll = true;
            pnlNavButtons.Padding = new Padding(10, 10, 10, 10);
            pnlNavButtons.BackColor = Color.FromArgb(15, 23, 42);

            int yPos = 10;
            int btnHeight = 44;
            int btnSpacing = 5;

            ConfigurarBotonNav(btnNavInicio, "🏠  Inicio", yPos); yPos += btnHeight + btnSpacing;
            ConfigurarBotonNav(btnNavEmpleados, "👥  Empleados", yPos); yPos += btnHeight + btnSpacing;
            ConfigurarBotonNav(btnNavClientes, "👤  Clientes", yPos); yPos += btnHeight + btnSpacing;
            ConfigurarBotonNav(btnNavInventario, "📦  Inventario", yPos); yPos += btnHeight + btnSpacing;
            ConfigurarBotonNav(btnNavVehiculos, "🚗  Vehículos", yPos); yPos += btnHeight + btnSpacing;
            ConfigurarBotonNav(btnNavOrdenes, "🛠️  Órdenes Trabajo", yPos); yPos += btnHeight + btnSpacing;
            ConfigurarBotonNav(btnNavCaja, "💵  Caja", yPos); yPos += btnHeight + btnSpacing;
            ConfigurarBotonNav(btnNavFacturacion, "🧾  Facturación", yPos); yPos += btnHeight + btnSpacing;
            ConfigurarBotonNav(btnNavCitas, "📅  Citas y Agenda", yPos);

            pnlNavButtons.Controls.AddRange(new Control[] {
                btnNavInicio, btnNavEmpleados, btnNavClientes, btnNavInventario,
                btnNavVehiculos, btnNavOrdenes, btnNavCaja, btnNavFacturacion, btnNavCitas
            });

            // ------------------ Pie de Usuario ------------------
            pnlUserFooter.Dock = DockStyle.Bottom;
            pnlUserFooter.Height = 120;
            pnlUserFooter.BackColor = Color.FromArgb(11, 15, 25);
            pnlUserFooter.Controls.Add(lblUserAvatar);
            pnlUserFooter.Controls.Add(lblUserName);
            pnlUserFooter.Controls.Add(lblUserRole);
            pnlUserFooter.Controls.Add(btnCerrarSesion);

            lblUserAvatar.Text = "👤";
            lblUserAvatar.Font = new Font("Segoe UI Emoji", 14F);
            lblUserAvatar.ForeColor = Color.FromArgb(0, 191, 255);
            lblUserAvatar.Location = new Point(15, 12);
            lblUserAvatar.Size = new Size(30, 30);

            lblUserName.Text = "Admin Taller";
            lblUserName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUserName.ForeColor = Color.White;
            lblUserName.Location = new Point(48, 10);
            lblUserName.Size = new Size(180, 20);

            lblUserRole.Text = "Administrador";
            lblUserRole.Font = new Font("Segoe UI", 8F);
            lblUserRole.ForeColor = Color.FromArgb(148, 163, 184);
            lblUserRole.Location = new Point(48, 30);
            lblUserRole.Size = new Size(180, 18);

            btnCerrarSesion.Text = "🚪 Cerrar Sesión";
            btnCerrarSesion.Location = new Point(15, 60);
            btnCerrarSesion.Size = new Size(210, 40);
            btnCerrarSesion.BackColor = Color.FromArgb(24, 30, 42);
            btnCerrarSesion.ForeColor = Color.FromArgb(239, 68, 68); // #EF4444 Red
            btnCerrarSesion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.FlatAppearance.BorderColor = Color.FromArgb(185, 28, 28);
            btnCerrarSesion.FlatAppearance.BorderSize = 1;
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            // ============================================
            // pnlContenedorPrincipal (Panel Central para Vistas)
            // ============================================
            pnlContenedorPrincipal.Dock = DockStyle.Fill;
            pnlContenedorPrincipal.BackColor = Color.FromArgb(240, 248, 255); // #F0F8FF AliciaBlue

            // ============================================
            // FrmMenuPrincipal
            // ============================================
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(1220, 740);
            MinimumSize = new Size(1050, 680);
            Controls.Add(pnlContenedorPrincipal);
            Controls.Add(pnlSidebar);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Taller Mecánico - Sistema de Gestión";
            WindowState = FormWindowState.Maximized;

            pnlSidebar.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            pnlNavButtons.ResumeLayout(false);
            pnlUserFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ConfigurarBotonNav(Button btn, string texto, int y)
        {
            btn.Text = texto;
            btn.Location = new Point(10, y);
            btn.Size = new Size(220, 44);
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.FromArgb(203, 213, 225); // #CBD5E1 Slate light
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59); // #1E293B
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(51, 65, 85);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(12, 0, 0, 0);
            btn.Cursor = Cursors.Hand;
        }
    }
}
