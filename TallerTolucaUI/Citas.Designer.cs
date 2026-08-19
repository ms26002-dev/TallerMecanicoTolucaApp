namespace TallerTolucaUI
{
    partial class FrmCitas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtClienteID, txtVehiculoID, txtMotivo, txtCitaID;
        private System.Windows.Forms.DateTimePicker dtpFechaHora;
        private System.Windows.Forms.ComboBox cboEstadoCita;
        private System.Windows.Forms.Button btnProgramarCita, btnActualizarEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtClienteID = new System.Windows.Forms.TextBox();
            txtVehiculoID = new System.Windows.Forms.TextBox();
            txtMotivo = new System.Windows.Forms.TextBox();
            txtCitaID = new System.Windows.Forms.TextBox();
            dtpFechaHora = new System.Windows.Forms.DateTimePicker();
            cboEstadoCita = new System.Windows.Forms.ComboBox();
            btnProgramarCita = new System.Windows.Forms.Button();
            btnActualizarEstado = new System.Windows.Forms.Button();
            SuspendLayout();

            ConfigureText(txtClienteID, "txtClienteID", 30, 30);
            ConfigureText(txtVehiculoID, "txtVehiculoID", 30, 70);
            ConfigureText(txtMotivo, "txtMotivo", 30, 110);
            ConfigureText(txtCitaID, "txtCitaID", 30, 150);

            dtpFechaHora.Location = new System.Drawing.Point(250, 30);
            dtpFechaHora.Name = "dtpFechaHora";
            dtpFechaHora.Size = new System.Drawing.Size(300, 31);
            dtpFechaHora.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpFechaHora.CalendarMonthBackground = System.Drawing.Color.White;
            dtpFechaHora.CalendarForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dtpFechaHora.CalendarTitleBackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            dtpFechaHora.CalendarTitleForeColor = System.Drawing.Color.White;

            cboEstadoCita.Location = new System.Drawing.Point(250, 75);
            cboEstadoCita.Name = "cboEstadoCita";
            cboEstadoCita.Size = new System.Drawing.Size(300, 33);
            cboEstadoCita.Items.AddRange(new object[] { "Programada", "Cancelada", "Atendida", "No Recibida" });
            cboEstadoCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboEstadoCita.BackColor = System.Drawing.Color.FromArgb(245, 250, 255);
            cboEstadoCita.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            cboEstadoCita.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboEstadoCita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            btnProgramarCita.Location = new System.Drawing.Point(250, 125);
            btnProgramarCita.Size = new System.Drawing.Size(180, 40);
            btnProgramarCita.Text = "Programar cita";
            btnProgramarCita.Name = "btnProgramarCita";
            btnProgramarCita.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnProgramarCita.ForeColor = System.Drawing.Color.White;
            btnProgramarCita.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnProgramarCita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnProgramarCita.FlatAppearance.BorderSize = 0;
            btnProgramarCita.Cursor = System.Windows.Forms.Cursors.Hand;
            btnProgramarCita.Click += btnProgramarCita_Click;

            btnActualizarEstado.Location = new System.Drawing.Point(450, 125);
            btnActualizarEstado.Size = new System.Drawing.Size(180, 40);
            btnActualizarEstado.Text = "Actualizar estado";
            btnActualizarEstado.Name = "btnActualizarEstado";
            btnActualizarEstado.BackColor = System.Drawing.Color.FromArgb(224, 231, 255);
            btnActualizarEstado.ForeColor = System.Drawing.Color.FromArgb(55, 48, 163);
            btnActualizarEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnActualizarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnActualizarEstado.FlatAppearance.BorderSize = 0;
            btnActualizarEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            btnActualizarEstado.Click += btnActualizarEstado_Click;

            BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ClientSize = new System.Drawing.Size(680, 230);
            Controls.AddRange(new System.Windows.Forms.Control[] { txtClienteID, txtVehiculoID, txtMotivo, txtCitaID, dtpFechaHora, cboEstadoCita, btnProgramarCita, btnActualizarEstado });
            Text = "Citas";
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
    }
}
