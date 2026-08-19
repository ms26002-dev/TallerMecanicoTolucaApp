namespace TallerTolucaUI
{
    partial class FrmEmpleados
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre, txtCargo, txtTelefono;
        private System.Windows.Forms.Button btnGuardar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtNombre = new System.Windows.Forms.TextBox();
            txtCargo = new System.Windows.Forms.TextBox();
            txtTelefono = new System.Windows.Forms.TextBox();
            btnGuardar = new System.Windows.Forms.Button();
            SuspendLayout();

            ConfigureText(txtNombre, "txtNombre", 30, 30);
            ConfigureText(txtCargo, "txtCargo", 30, 70);
            ConfigureText(txtTelefono, "txtTelefono", 30, 110);

            btnGuardar.Location = new System.Drawing.Point(30, 160);
            btnGuardar.Size = new System.Drawing.Size(220, 45);
            btnGuardar.Text = "Registrar empleado";
            btnGuardar.Name = "btnGuardar";
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGuardar.Click += btnGuardar_Click;

            BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ClientSize = new System.Drawing.Size(400, 240);
            Controls.AddRange(new System.Windows.Forms.Control[] { txtNombre, txtCargo, txtTelefono, btnGuardar });
            Text = "Empleados";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureText(System.Windows.Forms.TextBox box, string name, int x, int y)
        {
            box.Location = new System.Drawing.Point(x, y);
            box.Name = name;
            box.Size = new System.Drawing.Size(250, 31);
            box.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            box.Font = new System.Drawing.Font("Segoe UI", 10F);
            box.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
        }
    }
}
