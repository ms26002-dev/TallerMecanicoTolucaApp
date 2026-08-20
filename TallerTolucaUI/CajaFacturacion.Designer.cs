using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class FrmCajaFacturacion
    {
        private System.ComponentModel.IContainer components = null;

        // Encabezado
        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;

        // Tarjeta Apertura de Caja
        private Panel pnlApertura;
        private Label lblAperturaTitulo;
        private Label lblAperturaSub;
        private Label lblMontoApertura;
        private TextBox txtMontoApertura;
        private Button btnAbrirCaja;

        // Tarjeta Facturación y Cobro
        private Panel pnlFacturacion;
        private Label lblFacturacionTitulo;
        private Label lblOrdenID;
        private TextBox txtOrdenID;
        private Label lblClienteID;
        private TextBox txtClienteID;
        private Label lblSubTotal;
        private TextBox txtSubTotal;
        private Label lblTotal;
        private TextBox txtTotal;
        private Label lblMetodoPago;
        private TextBox txtMetodoPago;
        private Button btnFacturarCobrar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();

            pnlApertura = new Panel();
            lblAperturaTitulo = new Label();
            lblAperturaSub = new Label();
            lblMontoApertura = new Label();
            txtMontoApertura = new TextBox();
            btnAbrirCaja = new Button();

            pnlFacturacion = new Panel();
            lblFacturacionTitulo = new Label();
            lblOrdenID = new Label();
            txtOrdenID = new TextBox();
            lblClienteID = new Label();
            txtClienteID = new TextBox();
            lblSubTotal = new Label();
            txtSubTotal = new TextBox();
            lblTotal = new Label();
            txtTotal = new TextBox();
            lblMetodoPago = new Label();
            txtMetodoPago = new TextBox();
            btnFacturarCobrar = new Button();

            pnlHeader.SuspendLayout();
            pnlApertura.SuspendLayout();
            pnlFacturacion.SuspendLayout();
            SuspendLayout();

            // ============================================
            // pnlHeader (Encabezado Superior)
            // ============================================
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 75;
            pnlHeader.BackColor = Color.FromArgb(240, 248, 255);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);

            lblTitulo.Text = "Caja y Facturación";
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Apertura de caja operativa, procesamiento de cobros y emisión de facturas en efectivo.";
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitulo.Location = new Point(27, 47);
            lblSubtitulo.AutoSize = true;

            // ============================================
            // pnlApertura (Tarjeta Izquierda: Apertura de Caja)
            // ============================================
            pnlApertura.BackColor = Color.White;
            pnlApertura.Location = new Point(30, 95);
            pnlApertura.Size = new Size(380, 280);
            pnlApertura.BorderStyle = BorderStyle.FixedSingle;

            lblAperturaTitulo.Text = "💵 Apertura de Caja";
            lblAperturaTitulo.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblAperturaTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblAperturaTitulo.Location = new Point(25, 18);
            lblAperturaTitulo.AutoSize = true;

            lblAperturaSub.Text = "Registre el monto inicial en efectivo para iniciar la jornada operativa de caja.";
            lblAperturaSub.Font = new Font("Segoe UI", 8.5F);
            lblAperturaSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblAperturaSub.Location = new Point(25, 50);
            lblAperturaSub.Size = new Size(330, 40);

            ConfigurarEtiqueta(lblMontoApertura, "Monto Inicial de Apertura ($) *", 25, 105);
            ConfigurarInput(txtMontoApertura, "Ej. 100.00", 25, 130, 325);

            btnAbrirCaja.Text = "💵 ABRIR CAJA";
            btnAbrirCaja.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAbrirCaja.BackColor = Color.FromArgb(16, 185, 129); // Emerald / Green
            btnAbrirCaja.ForeColor = Color.White;
            btnAbrirCaja.FlatStyle = FlatStyle.Flat;
            btnAbrirCaja.FlatAppearance.BorderSize = 0;
            btnAbrirCaja.Size = new Size(325, 44);
            btnAbrirCaja.Location = new Point(25, 190);
            btnAbrirCaja.Cursor = Cursors.Hand;
            btnAbrirCaja.Click += btnAbrirCaja_Click;

            pnlApertura.Controls.AddRange(new Control[] {
                lblAperturaTitulo, lblAperturaSub, lblMontoApertura, txtMontoApertura, btnAbrirCaja
            });

            // ============================================
            // pnlFacturacion (Tarjeta Derecha: Cobro y Factura)
            // ============================================
            pnlFacturacion.BackColor = Color.White;
            pnlFacturacion.Location = new Point(435, 95);
            pnlFacturacion.Size = new Size(515, 440);
            pnlFacturacion.BorderStyle = BorderStyle.FixedSingle;

            lblFacturacionTitulo.Text = "🧾 Facturación y Cobro";
            lblFacturacionTitulo.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            lblFacturacionTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblFacturacionTitulo.Location = new Point(25, 18);
            lblFacturacionTitulo.AutoSize = true;

            ConfigurarEtiqueta(lblOrdenID, "ID de Orden Finalizada *", 25, 60);
            ConfigurarInput(txtOrdenID, "Ej. 1", 25, 85, 215);

            ConfigurarEtiqueta(lblClienteID, "ID del Cliente *", 265, 60);
            ConfigurarInput(txtClienteID, "Ej. 1", 265, 85, 215);

            ConfigurarEtiqueta(lblSubTotal, "SubTotal ($) *", 25, 130);
            ConfigurarInput(txtSubTotal, "Ej. 80.00", 25, 155, 215);

            ConfigurarEtiqueta(lblTotal, "Total a Pagar ($) *", 265, 130);
            ConfigurarInput(txtTotal, "Ej. 90.40", 265, 155, 215);

            ConfigurarEtiqueta(lblMetodoPago, "Método de Pago Permitido", 25, 200);
            txtMetodoPago.Location = new Point(25, 225);
            txtMetodoPago.Size = new Size(455, 31);
            txtMetodoPago.Font = new Font("Segoe UI", 10F);
            txtMetodoPago.BackColor = Color.FromArgb(241, 245, 249);
            txtMetodoPago.ReadOnly = true;
            txtMetodoPago.Text = "Efectivo (Único método permitido)";

            btnFacturarCobrar.Text = "🧾 GENERAR FACTURA Y COBRAR";
            btnFacturarCobrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnFacturarCobrar.BackColor = Color.FromArgb(0, 191, 255); // DeepSkyBlue
            btnFacturarCobrar.ForeColor = Color.White;
            btnFacturarCobrar.FlatStyle = FlatStyle.Flat;
            btnFacturarCobrar.FlatAppearance.BorderSize = 0;
            btnFacturarCobrar.Size = new Size(455, 46);
            btnFacturarCobrar.Location = new Point(25, 290);
            btnFacturarCobrar.Cursor = Cursors.Hand;
            btnFacturarCobrar.Click += btnFacturarCobrar_Click;

            pnlFacturacion.Controls.AddRange(new Control[] {
                lblFacturacionTitulo, lblOrdenID, txtOrdenID, lblClienteID, txtClienteID,
                lblSubTotal, txtSubTotal, lblTotal, txtTotal, lblMetodoPago, txtMetodoPago,
                btnFacturarCobrar
            });

            // ============================================
            // FrmCajaFacturacion (Formulario)
            // ============================================
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(980, 600);
            Controls.Add(pnlFacturacion);
            Controls.Add(pnlApertura);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmCajaFacturacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caja y Facturación";
            Padding = new Padding(20, 10, 20, 15);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlApertura.ResumeLayout(false);
            pnlApertura.PerformLayout();
            pnlFacturacion.ResumeLayout(false);
            pnlFacturacion.PerformLayout();
            ResumeLayout(false);
        }

        private void ConfigurarEtiqueta(Label lbl, string texto, int x, int y)
        {
            lbl.Text = texto;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(71, 85, 105);
            lbl.Location = new Point(x, y);
            lbl.AutoSize = true;
        }

        private void ConfigurarInput(TextBox txt, string placeholder, int x, int y, int width)
        {
            txt.Location = new Point(x, y);
            txt.Size = new Size(width, 31);
            txt.Font = new Font("Segoe UI", 10F);
            txt.BackColor = Color.FromArgb(248, 250, 252);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.ForeColor = Color.FromArgb(30, 41, 59);
            txt.PlaceholderText = placeholder;
        }
    }
}
