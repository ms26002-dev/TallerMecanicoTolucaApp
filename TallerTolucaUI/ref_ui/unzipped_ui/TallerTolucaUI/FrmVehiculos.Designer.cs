namespace TallerTolucaUI
{
    partial class FrmVehiculos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtClienteID, txtPlaca, txtMarca, txtModelo, txtAnio;
        private System.Windows.Forms.ComboBox cboTipoVehiculo;
        private System.Windows.Forms.Button btnGuardar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtClienteID = new System.Windows.Forms.TextBox();
            txtPlaca = new System.Windows.Forms.TextBox();
            txtMarca = new System.Windows.Forms.TextBox();
            txtModelo = new System.Windows.Forms.TextBox();
            txtAnio = new System.Windows.Forms.TextBox();
            cboTipoVehiculo = new System.Windows.Forms.ComboBox();
            btnGuardar = new System.Windows.Forms.Button();
            SuspendLayout();

            ConfigureText(txtClienteID, "txtClienteID", 30, 30);
            ConfigureText(txtPlaca, "txtPlaca", 30, 70);
            ConfigureText(txtMarca, "txtMarca", 30, 110);
            ConfigureText(txtModelo, "txtModelo", 30, 150);
            ConfigureText(txtAnio, "txtAnio", 30, 190);

            cboTipoVehiculo.Location = new System.Drawing.Point(280, 30);
            cboTipoVehiculo.Name = "cboTipoVehiculo";
            cboTipoVehiculo.Size = new System.Drawing.Size(220, 33);
            cboTipoVehiculo.Items.AddRange(new object[] { "Liviano", "Pesado", "Motocicleta" });
            cboTipoVehiculo.SelectedIndex = 0;
            cboTipoVehiculo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboTipoVehiculo.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            cboTipoVehiculo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            cboTipoVehiculo.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            btnGuardar.Location = new System.Drawing.Point(280, 90);
            btnGuardar.Size = new System.Drawing.Size(220, 45);
            btnGuardar.Text = "Guardar vehículo";
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
            ClientSize = new System.Drawing.Size(550, 280);
            Controls.AddRange(new System.Windows.Forms.Control[] { txtClienteID, txtPlaca, txtMarca, txtModelo, txtAnio, cboTipoVehiculo, btnGuardar });
            Text = "Vehículos";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureText(System.Windows.Forms.TextBox box, string name, int x, int y)
        {
            box.Location = new System.Drawing.Point(x, y);
            box.Name = name;
            box.Size = new System.Drawing.Size(200, 31);
            box.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            box.Font = new System.Drawing.Font("Segoe UI", 10F);
            box.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
        }
    }
}
