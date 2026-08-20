using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class FrmClienteDetalle
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private Label lblNombre, lblTelefono, lblCorreo, lblDireccion, lblEstado;
        private TextBox txtNombre, txtTelefono, txtCorreo, txtDireccion;
        private ComboBox cboEstado;
        private Button btnGuardar, btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombre = new Label();
            lblTelefono = new Label();
            lblCorreo = new Label();
            lblDireccion = new Label();
            lblEstado = new Label();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtDireccion = new TextBox();
            cboEstado = new ComboBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();

            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(25, 20);
            lblTitulo.AutoSize = true;

            ConfigurarEtiqueta(lblNombre, "Nombre completo", 25, 65);
            ConfigurarCampo(txtNombre, 25, 88);

            ConfigurarEtiqueta(lblTelefono, "Teléfono", 25, 128);
            ConfigurarCampo(txtTelefono, 25, 151);

            ConfigurarEtiqueta(lblCorreo, "Correo", 25, 191);
            ConfigurarCampo(txtCorreo, 25, 214);

            ConfigurarEtiqueta(lblDireccion, "Dirección", 25, 254);
            ConfigurarCampo(txtDireccion, 25, 277);

            ConfigurarEtiqueta(lblEstado, "Estado", 25, 317);
            cboEstado.Location = new Point(25, 340);
            cboEstado.Size = new Size(340, 32);
            cboEstado.Font = new Font("Segoe UI", 10F);
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FlatStyle = FlatStyle.Flat;
            cboEstado.BackColor = Color.FromArgb(245, 250, 255);
            cboEstado.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cboEstado.SelectedIndex = 0;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(25, 395);
            btnCancelar.Size = new Size(160, 42);
            btnCancelar.BackColor = Color.White;
            btnCancelar.ForeColor = Color.FromArgb(51, 65, 85);
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancelar.FlatAppearance.BorderSize = 1;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Click += btnCancelar_Click;

            btnGuardar.Text = "Guardar";
            btnGuardar.Location = new Point(205, 395);
            btnGuardar.Size = new Size(160, 42);
            btnGuardar.BackColor = Color.FromArgb(0, 191, 255);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Click += btnGuardar_Click;

            BackColor = Color.FromArgb(240, 248, 255);
            Font = new Font("Segoe UI", 9F);
            ClientSize = new Size(390, 460);
            Controls.AddRange(new Control[] {
                lblTitulo, lblNombre, txtNombre, lblTelefono, txtTelefono,
                lblCorreo, txtCorreo, lblDireccion, txtDireccion,
                lblEstado, cboEstado, btnCancelar, btnGuardar
            });
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigurarEtiqueta(Label lbl, string texto, int x, int y)
        {
            lbl.Text = texto;
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(71, 85, 105);
        }

        private void ConfigurarCampo(TextBox box, int x, int y)
        {
            box.Location = new Point(x, y);
            box.Size = new Size(340, 31);
            box.BackColor = Color.FromArgb(245, 250, 255);
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Font = new Font("Segoe UI", 10F);
            box.ForeColor = Color.FromArgb(51, 65, 85);
        }
    }
}
