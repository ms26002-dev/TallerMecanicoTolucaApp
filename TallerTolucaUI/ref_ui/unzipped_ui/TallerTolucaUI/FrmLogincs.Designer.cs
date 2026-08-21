namespace TallerTolucaUI
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Button btnIngresar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtUsuario = new System.Windows.Forms.TextBox();
            txtClave = new System.Windows.Forms.TextBox();
            btnIngresar = new System.Windows.Forms.Button();
            SuspendLayout();

            txtUsuario.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtUsuario.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtUsuario.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            txtUsuario.Location = new System.Drawing.Point(250, 100);
            txtUsuario.Size = new System.Drawing.Size(300, 31);
            txtUsuario.Name = "txtUsuario";

            txtClave.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtClave.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtClave.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            txtClave.Location = new System.Drawing.Point(250, 145);
            txtClave.Size = new System.Drawing.Size(300, 31);
            txtClave.Name = "txtClave";
            txtClave.UseSystemPasswordChar = true;

            btnIngresar.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnIngresar.ForeColor = System.Drawing.Color.White;
            btnIngresar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnIngresar.Location = new System.Drawing.Point(250, 195);
            btnIngresar.Size = new System.Drawing.Size(300, 45);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Text = "Iniciar Sesión";
            btnIngresar.Click += btnIngresar_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(txtUsuario);
            Controls.Add(txtClave);
            Controls.Add(btnIngresar);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            Text = "Inicio de sesión";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
