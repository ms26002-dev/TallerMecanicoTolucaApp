namespace TallerTolucaUI
{
    partial class FrmClientes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre, txtTelefono, txtCorreo, txtDireccion;
        private System.Windows.Forms.Button btnGuardar, btnEliminar;
        private System.Windows.Forms.DataGridView dgvClientes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtNombre = new System.Windows.Forms.TextBox();
            txtTelefono = new System.Windows.Forms.TextBox();
            txtCorreo = new System.Windows.Forms.TextBox();
            txtDireccion = new System.Windows.Forms.TextBox();
            btnGuardar = new System.Windows.Forms.Button();
            btnEliminar = new System.Windows.Forms.Button();
            dgvClientes = new System.Windows.Forms.DataGridView();
            SuspendLayout();

            ConfigureText(txtNombre, "txtNombre", 25, 25);
            ConfigureText(txtTelefono, "txtTelefono", 25, 65);
            ConfigureText(txtCorreo, "txtCorreo", 25, 105);
            ConfigureText(txtDireccion, "txtDireccion", 25, 145);

            btnGuardar.Location = new System.Drawing.Point(230, 25);
            btnGuardar.Size = new System.Drawing.Size(150, 40);
            btnGuardar.Text = "Guardar";
            btnGuardar.Name = "btnGuardar";
            btnGuardar.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnGuardar.ForeColor = System.Drawing.Color.White;
            btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnGuardar.Click += btnGuardar_Click;

            btnEliminar.Location = new System.Drawing.Point(230, 75);
            btnEliminar.Size = new System.Drawing.Size(150, 40);
            btnEliminar.Text = "Eliminar";
            btnEliminar.Name = "btnEliminar";
            btnEliminar.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);
            btnEliminar.ForeColor = System.Drawing.Color.FromArgb(185, 28, 28);
            btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEliminar.Click += btnEliminar_Click;

            dgvClientes.Location = new System.Drawing.Point(25, 205);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new System.Drawing.Size(740, 220);
            dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            EstilizarGrid(dgvClientes);

            BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ClientSize = new System.Drawing.Size(800, 460);
            Controls.AddRange(new System.Windows.Forms.Control[] { txtNombre, txtTelefono, txtCorreo, txtDireccion, btnGuardar, btnEliminar, dgvClientes });
            Text = "Clientes";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigureText(System.Windows.Forms.TextBox box, string name, int x, int y)
        {
            box.Location = new System.Drawing.Point(x, y);
            box.Name = name;
            box.Size = new System.Drawing.Size(180, 31);
            box.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            box.Font = new System.Drawing.Font("Segoe UI", 10F);
            box.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
        }

        private void EstilizarGrid(System.Windows.Forms.DataGridView grid)
        {
            grid.BackgroundColor = System.Drawing.Color.White;
            grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            grid.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeight = 36;
            grid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            grid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            grid.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grid.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            grid.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 245, 255);
            grid.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            grid.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 252, 255);
            grid.RowTemplate.Height = 32;
        }
    }
}
