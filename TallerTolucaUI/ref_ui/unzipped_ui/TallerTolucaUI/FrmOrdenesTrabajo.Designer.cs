namespace TallerTolucaUI
{
    partial class FrmOrdenesTrabajo
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtClienteID, txtVehiculoID, txtMecanicoID, txtKilometraje, txtDiagnostico, txtOrdenID;
        private System.Windows.Forms.Button btnCrearOrden, btnFinalizarOrden;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtClienteID = new System.Windows.Forms.TextBox();
            txtVehiculoID = new System.Windows.Forms.TextBox();
            txtMecanicoID = new System.Windows.Forms.TextBox();
            txtKilometraje = new System.Windows.Forms.TextBox();
            txtDiagnostico = new System.Windows.Forms.TextBox();
            txtOrdenID = new System.Windows.Forms.TextBox();
            btnCrearOrden = new System.Windows.Forms.Button();
            btnFinalizarOrden = new System.Windows.Forms.Button();
            SuspendLayout();

            ConfigureText(txtClienteID, "txtClienteID", 30, 30);
            ConfigureText(txtVehiculoID, "txtVehiculoID", 30, 70);
            ConfigureText(txtMecanicoID, "txtMecanicoID", 30, 110);
            ConfigureText(txtKilometraje, "txtKilometraje", 30, 150);
            ConfigureText(txtDiagnostico, "txtDiagnostico", 30, 190);
            ConfigureText(txtOrdenID, "txtOrdenID", 30, 230);

            btnCrearOrden.Location = new System.Drawing.Point(300, 50);
            btnCrearOrden.Size = new System.Drawing.Size(220, 45);
            btnCrearOrden.Text = "Crear orden";
            btnCrearOrden.Name = "btnCrearOrden";
            btnCrearOrden.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnCrearOrden.ForeColor = System.Drawing.Color.White;
            btnCrearOrden.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCrearOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCrearOrden.FlatAppearance.BorderSize = 0;
            btnCrearOrden.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCrearOrden.Click += btnCrearOrden_Click;

            btnFinalizarOrden.Location = new System.Drawing.Point(300, 110);
            btnFinalizarOrden.Size = new System.Drawing.Size(220, 45);
            btnFinalizarOrden.Text = "Finalizar orden";
            btnFinalizarOrden.Name = "btnFinalizarOrden";
            btnFinalizarOrden.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            btnFinalizarOrden.ForeColor = System.Drawing.Color.FromArgb(146, 64, 14);
            btnFinalizarOrden.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnFinalizarOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFinalizarOrden.FlatAppearance.BorderSize = 0;
            btnFinalizarOrden.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFinalizarOrden.Click += btnFinalizarOrden_Click;

            BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ClientSize = new System.Drawing.Size(580, 320);
            Controls.AddRange(new System.Windows.Forms.Control[] { txtClienteID, txtVehiculoID, txtMecanicoID, txtKilometraje, txtDiagnostico, txtOrdenID, btnCrearOrden, btnFinalizarOrden });
            Text = "Órdenes de Trabajo";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureText(System.Windows.Forms.TextBox box, string name, int x, int y)
        {
            box.Location = new System.Drawing.Point(x, y);
            box.Name = name;
            box.Size = new System.Drawing.Size(230, 31);
            box.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            box.Font = new System.Drawing.Font("Segoe UI", 10F);
            box.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
        }
    }
}
