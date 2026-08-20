using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlCard;
        private Panel pnlHeader;
        private Label lblHeaderIcon;
        private Label lblHeaderTitle;
        private Label lblHeaderSubtitle;
        private Panel pnlForm;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblClave;
        private TextBox txtClave;
        private Button btnIngresar;
        private Label lblFooter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard = new Panel();
            pnlHeader = new Panel();
            lblHeaderIcon = new Label();
            lblHeaderTitle = new Label();
            lblHeaderSubtitle = new Label();
            pnlForm = new Panel();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblClave = new Label();
            txtClave = new TextBox();
            btnIngresar = new Button();
            lblFooter = new Label();

            pnlCard.SuspendLayout();
            pnlHeader.SuspendLayout();
            pnlForm.SuspendLayout();
            SuspendLayout();

            // ============================================
            // pnlCard (Tarjeta central)
            // ============================================
            pnlCard.BackColor = Color.White;
            pnlCard.Size = new Size(460, 430);
            pnlCard.Controls.Add(pnlForm);
            pnlCard.Controls.Add(pnlHeader);

            // ============================================
            // pnlHeader (Encabezado oscuro de la tarjeta)
            // ============================================
            pnlHeader.BackColor = Color.FromArgb(24, 30, 42); // #181E2A Dark slate header
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 140;
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderIcon);

            // Ícono mecánico en cyan
            lblHeaderIcon.Text = "⚙️";
            lblHeaderIcon.Font = new Font("Segoe UI Emoji", 22F);
            lblHeaderIcon.ForeColor = Color.FromArgb(0, 191, 255); // #00BFFF
            lblHeaderIcon.Location = new Point(0, 12);
            lblHeaderIcon.Size = new Size(460, 40);
            lblHeaderIcon.TextAlign = ContentAlignment.MiddleCenter;

            // Título "Gestión Mecánica"
            lblHeaderTitle.Text = "Gestión Mecánica";
            lblHeaderTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblHeaderTitle.ForeColor = Color.White;
            lblHeaderTitle.Location = new Point(0, 56);
            lblHeaderTitle.Size = new Size(460, 38);
            lblHeaderTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Subtítulo
            lblHeaderSubtitle.Text = "Acceso al Sistema de Taller";
            lblHeaderSubtitle.Font = new Font("Segoe UI", 10F);
            lblHeaderSubtitle.ForeColor = Color.FromArgb(148, 163, 184); // #94A3B8
            lblHeaderSubtitle.Location = new Point(0, 96);
            lblHeaderSubtitle.Size = new Size(460, 26);
            lblHeaderSubtitle.TextAlign = ContentAlignment.MiddleCenter;

            // ============================================
            // pnlForm (Cuerpo blanco del formulario)
            // ============================================
            pnlForm.BackColor = Color.White;
            pnlForm.Dock = DockStyle.Fill;
            pnlForm.Controls.Add(lblUsuario);
            pnlForm.Controls.Add(txtUsuario);
            pnlForm.Controls.Add(lblClave);
            pnlForm.Controls.Add(txtClave);
            pnlForm.Controls.Add(btnIngresar);

            // Label Usuario
            lblUsuario.Text = "Nombre de usuario";
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(51, 65, 85);
            lblUsuario.Location = new Point(45, 18);
            lblUsuario.Size = new Size(370, 22);

            // TextBox Usuario
            txtUsuario.BackColor = Color.FromArgb(248, 250, 252);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 11F);
            txtUsuario.ForeColor = Color.FromArgb(30, 41, 59);
            txtUsuario.Location = new Point(45, 44);
            txtUsuario.Size = new Size(370, 32);
            txtUsuario.PlaceholderText = "👤 Ingrese su usuario";

            // Label Contraseña
            lblClave.Text = "Contraseña";
            lblClave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClave.ForeColor = Color.FromArgb(51, 65, 85);
            lblClave.Location = new Point(45, 88);
            lblClave.Size = new Size(370, 22);

            // TextBox Contraseña
            txtClave.BackColor = Color.FromArgb(248, 250, 252);
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Font = new Font("Segoe UI", 11F);
            txtClave.ForeColor = Color.FromArgb(30, 41, 59);
            txtClave.Location = new Point(45, 114);
            txtClave.Size = new Size(370, 32);
            txtClave.UseSystemPasswordChar = true;
            txtClave.PlaceholderText = "🔒 ••••••••";

            // Botón Ingresar
            btnIngresar.Text = "Ingresar  ➔";
            btnIngresar.Location = new Point(45, 175);
            btnIngresar.Size = new Size(370, 48);
            btnIngresar.BackColor = Color.FromArgb(0, 191, 255); // #00BFFF
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.Click += btnIngresar_Click;

            // ============================================
            // lblFooter (Versión y pie de página)
            // ============================================
            lblFooter.Text = "v1.1 2026 Taller Bladi's Corporation";
            lblFooter.Font = new Font("Segoe UI", 9.5F);
            lblFooter.ForeColor = Color.FromArgb(100, 116, 139);
            lblFooter.Size = new Size(600, 25);
            lblFooter.TextAlign = ContentAlignment.MiddleCenter;

            // ============================================
            // FrmLogin (Formulario principal)
            // ============================================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(11, 15, 25); // Dark background #0B0F19
            ClientSize = new Size(950, 620);
            MinimumSize = new Size(800, 550);
            Controls.Add(lblFooter);
            Controls.Add(pnlCard);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión Mecánica - Inicio de Sesión";
            WindowState = FormWindowState.Maximized; // Abre en pantalla completa

            pnlCard.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ResumeLayout(false);
        }
    }
}
