namespace TallerTolucaUI
{
    partial class FrmCajaFacturacion
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtMontoApertura, txtOrdenID, txtClienteID, txtSubTotal, txtTotal;
        private System.Windows.Forms.Button btnAbrirCaja, btnFacturarCobrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtMontoApertura = new System.Windows.Forms.TextBox();
            txtOrdenID = new System.Windows.Forms.TextBox();
            txtClienteID = new System.Windows.Forms.TextBox();
            txtSubTotal = new System.Windows.Forms.TextBox();
            txtTotal = new System.Windows.Forms.TextBox();
            btnAbrirCaja = new System.Windows.Forms.Button();
            btnFacturarCobrar = new System.Windows.Forms.Button();
            SuspendLayout();

            ConfigureText(txtMontoApertura, "txtMontoApertura", 30, 30);
            ConfigureText(txtOrdenID, "txtOrdenID", 30, 70);
            ConfigureText(txtClienteID, "txtClienteID", 30, 110);
            ConfigureText(txtSubTotal, "txtSubTotal", 30, 150);
            ConfigureText(txtTotal, "txtTotal", 30, 190);

            btnAbrirCaja.Location = new System.Drawing.Point(270, 30);
            btnAbrirCaja.Size = new System.Drawing.Size(190, 40);
            btnAbrirCaja.Text = "Abrir caja";
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnAbrirCaja.ForeColor = System.Drawing.Color.White;
            btnAbrirCaja.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAbrirCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAbrirCaja.FlatAppearance.BorderSize = 0;
            btnAbrirCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAbrirCaja.Click += btnAbrirCaja_Click;

            btnFacturarCobrar.Location = new System.Drawing.Point(270, 90);
            btnFacturarCobrar.Size = new System.Drawing.Size(190, 40);
            btnFacturarCobrar.Text = "Facturar / Cobrar";
            btnFacturarCobrar.Name = "btnFacturarCobrar";
            btnFacturarCobrar.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnFacturarCobrar.ForeColor = System.Drawing.Color.White;
            btnFacturarCobrar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnFacturarCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFacturarCobrar.FlatAppearance.BorderSize = 0;
            btnFacturarCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFacturarCobrar.Click += btnFacturarCobrar_Click;

            BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ClientSize = new System.Drawing.Size(520, 280);
            Controls.AddRange(new System.Windows.Forms.Control[] { txtMontoApertura, txtOrdenID, txtClienteID, txtSubTotal, txtTotal, btnAbrirCaja, btnFacturarCobrar });
            Text = "Caja y Facturación";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureText(System.Windows.Forms.TextBox box, string name, int x, int y)
        {
            box.Location = new System.Drawing.Point(x, y);
            box.Name = name;
            box.Size = new System.Drawing.Size(210, 31);
            box.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            box.Font = new System.Drawing.Font("Segoe UI", 10F);
            box.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
        }
    }
}
