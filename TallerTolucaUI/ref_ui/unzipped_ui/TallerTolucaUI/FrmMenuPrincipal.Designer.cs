namespace TallerTolucaUI
{
    partial class FrmMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblUsuarioActivo;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnFacturacion;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnVehiculos;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnOrdenesTrabajo;
        private System.Windows.Forms.Button btnCitas;
        private System.Windows.Forms.Button btnCerrarSesion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUsuarioActivo = new System.Windows.Forms.Label();
            btnClientes = new System.Windows.Forms.Button();
            btnCaja = new System.Windows.Forms.Button();
            btnFacturacion = new System.Windows.Forms.Button();
            btnEmpleados = new System.Windows.Forms.Button();
            btnVehiculos = new System.Windows.Forms.Button();
            btnInventario = new System.Windows.Forms.Button();
            btnOrdenesTrabajo = new System.Windows.Forms.Button();
            btnCitas = new System.Windows.Forms.Button();
            btnCerrarSesion = new System.Windows.Forms.Button();
            SuspendLayout();

            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblUsuarioActivo.ForeColor = System.Drawing.Color.FromArgb(90, 120, 150);
            lblUsuarioActivo.Location = new System.Drawing.Point(30, 25);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Text = "Usuario:";

            ConfigurarBotonModulo(btnClientes, "Clientes", 30, 70);
            ConfigurarBotonModulo(btnCaja, "Caja", 230, 70);
            ConfigurarBotonModulo(btnFacturacion, "Facturación", 430, 70);
            ConfigurarBotonModulo(btnEmpleados, "Empleados", 30, 130);
            ConfigurarBotonModulo(btnVehiculos, "Vehículos", 230, 130);
            ConfigurarBotonModulo(btnInventario, "Inventario", 430, 130);
            ConfigurarBotonModulo(btnOrdenesTrabajo, "Órdenes de Trabajo", 30, 190);
            ConfigurarBotonModulo(btnCitas, "Citas", 230, 190);

            btnCerrarSesion.Location = new System.Drawing.Point(430, 190);
            btnCerrarSesion.Size = new System.Drawing.Size(180, 45);
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);
            btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrarSesion.Click += btnCerrarSesion_Click;

            btnClientes.Click += btnClientes_Click;
            btnCaja.Click += btnCaja_Click;
            btnFacturacion.Click += btnFacturacion_Click;
            btnEmpleados.Click += btnEmpleados_Click;
            btnVehiculos.Click += btnVehiculos_Click;
            btnInventario.Click += btnInventario_Click;
            btnOrdenesTrabajo.Click += btnOrdenesTrabajo_Click;
            btnCitas.Click += btnCitas_Click;

            BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ClientSize = new System.Drawing.Size(650, 270);
            Controls.AddRange(new System.Windows.Forms.Control[] { lblUsuarioActivo, btnClientes, btnCaja, btnFacturacion, btnEmpleados, btnVehiculos, btnInventario, btnOrdenesTrabajo, btnCitas, btnCerrarSesion });
            Text = "Taller Mecánico Toluca";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigurarBotonModulo(System.Windows.Forms.Button btn, string texto, int x, int y)
        {
            btn.Location = new System.Drawing.Point(x, y);
            btn.Size = new System.Drawing.Size(180, 45);
            btn.Text = texto;
            btn.Name = "btn" + texto;
            btn.BackColor = System.Drawing.Color.White;
            btn.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            btn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}
