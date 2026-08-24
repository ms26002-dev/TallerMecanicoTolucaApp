namespace TallerTolucaUI
{
    partial class FrmInventario
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtCodigo, txtNombreRepuesto, txtPrecioUnitario, txtStockInicial, txtRepuestoID, txtCantidadMovimiento, txtMotivoMovimiento;
        private System.Windows.Forms.ComboBox cboTipoMovimiento;
        private System.Windows.Forms.Button btnRegistrarRepuesto, btnRegistrarMovimiento;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtCodigo = new System.Windows.Forms.TextBox();
            txtNombreRepuesto = new System.Windows.Forms.TextBox();
            txtPrecioUnitario = new System.Windows.Forms.TextBox();
            txtStockInicial = new System.Windows.Forms.TextBox();
            txtRepuestoID = new System.Windows.Forms.TextBox();
            txtCantidadMovimiento = new System.Windows.Forms.TextBox();
            txtMotivoMovimiento = new System.Windows.Forms.TextBox();
            cboTipoMovimiento = new System.Windows.Forms.ComboBox();
            btnRegistrarRepuesto = new System.Windows.Forms.Button();
            btnRegistrarMovimiento = new System.Windows.Forms.Button();
            SuspendLayout();

            ConfigureText(txtCodigo, "txtCodigo", 25, 25);
            ConfigureText(txtNombreRepuesto, "txtNombreRepuesto", 25, 65);
            ConfigureText(txtPrecioUnitario, "txtPrecioUnitario", 25, 105);
            ConfigureText(txtStockInicial, "txtStockInicial", 25, 145);
            ConfigureText(txtRepuestoID, "txtRepuestoID", 350, 25);
            ConfigureText(txtCantidadMovimiento, "txtCantidadMovimiento", 350, 65);
            ConfigureText(txtMotivoMovimiento, "txtMotivoMovimiento", 350, 105);

            cboTipoMovimiento.Location = new System.Drawing.Point(350, 145);
            cboTipoMovimiento.Name = "cboTipoMovimiento";
            cboTipoMovimiento.Size = new System.Drawing.Size(220, 33);
            cboTipoMovimiento.Items.AddRange(new object[] { "Entrada", "Salida" });
            cboTipoMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboTipoMovimiento.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            cboTipoMovimiento.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            cboTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            btnRegistrarRepuesto.Location = new System.Drawing.Point(25, 195);
            btnRegistrarRepuesto.Size = new System.Drawing.Size(220, 45);
            btnRegistrarRepuesto.Text = "Registrar repuesto";
            btnRegistrarRepuesto.Name = "btnRegistrarRepuesto";
            btnRegistrarRepuesto.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnRegistrarRepuesto.ForeColor = System.Drawing.Color.White;
            btnRegistrarRepuesto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnRegistrarRepuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRegistrarRepuesto.FlatAppearance.BorderSize = 0;
            btnRegistrarRepuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRegistrarRepuesto.Click += btnRegistrarRepuesto_Click;

            btnRegistrarMovimiento.Location = new System.Drawing.Point(350, 195);
            btnRegistrarMovimiento.Size = new System.Drawing.Size(220, 45);
            btnRegistrarMovimiento.Text = "Registrar movimiento";
            btnRegistrarMovimiento.Name = "btnRegistrarMovimiento";
            btnRegistrarMovimiento.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnRegistrarMovimiento.ForeColor = System.Drawing.Color.White;
            btnRegistrarMovimiento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnRegistrarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRegistrarMovimiento.FlatAppearance.BorderSize = 0;
            btnRegistrarMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRegistrarMovimiento.Click += btnRegistrarMovimiento_Click;

            BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ClientSize = new System.Drawing.Size(620, 290);
            Controls.AddRange(new System.Windows.Forms.Control[] { txtCodigo, txtNombreRepuesto, txtPrecioUnitario, txtStockInicial, txtRepuestoID, txtCantidadMovimiento, txtMotivoMovimiento, cboTipoMovimiento, btnRegistrarRepuesto, btnRegistrarMovimiento });
            Text = "Inventario";
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
