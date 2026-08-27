namespace TallerTolucaUI
{
    partial class FrmCajaFacturacion
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picLogoHeader;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Button btnCerrarForm;

        private System.Windows.Forms.Panel pnlStatusCard;
        private System.Windows.Forms.Label lblEstadoCajaBadge;
        private System.Windows.Forms.Label lblMontoAperturaInfo;
        private System.Windows.Forms.Label lblIngresosInfo;
        private System.Windows.Forms.Label lblSaldoTotalInfo;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.Button btnHistorialCajas;

        private System.Windows.Forms.Panel pnlFormCard;
        private System.Windows.Forms.Label lblFormTitulo;
        private System.Windows.Forms.Label lblCamposObligatorios;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.ComboBox cboOrden;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.TextBox txtMetodoPago;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnFacturarCobrar;
        private System.Windows.Forms.Button btnVerTicket;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnArqueo;

        private System.Windows.Forms.Panel pnlTableCard;
        private System.Windows.Forms.TabControl tabControlFinanciero;
        private System.Windows.Forms.TabPage tabFacturas;
        private System.Windows.Forms.TabPage tabHistorialCajas;
        private System.Windows.Forms.Label lblTableTitulo;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblTotalFacturas;
        private System.Windows.Forms.Label lblTotalRecaudado;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Label lblTableTituloCaja;
        private System.Windows.Forms.Label lblBuscarCaja;
        private System.Windows.Forms.TextBox txtBuscarCaja;
        private System.Windows.Forms.Button btnRefrescarHistorial;
        private System.Windows.Forms.Label lblTotalSesiones;
        private System.Windows.Forms.DataGridView dgvHistorialCajas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new System.Windows.Forms.Panel();
            picLogoHeader = new System.Windows.Forms.PictureBox();
            lblHeaderTitle = new System.Windows.Forms.Label();
            lblHeaderSubtitle = new System.Windows.Forms.Label();
            btnCerrarForm = new System.Windows.Forms.Button();

            pnlStatusCard = new System.Windows.Forms.Panel();
            lblEstadoCajaBadge = new System.Windows.Forms.Label();
            lblMontoAperturaInfo = new System.Windows.Forms.Label();
            lblIngresosInfo = new System.Windows.Forms.Label();
            lblSaldoTotalInfo = new System.Windows.Forms.Label();
            btnAbrirCaja = new System.Windows.Forms.Button();
            btnCerrarCaja = new System.Windows.Forms.Button();
            btnHistorialCajas = new System.Windows.Forms.Button();

            pnlFormCard = new System.Windows.Forms.Panel();
            lblFormTitulo = new System.Windows.Forms.Label();
            lblCamposObligatorios = new System.Windows.Forms.Label();
            lblOrden = new System.Windows.Forms.Label();
            cboOrden = new System.Windows.Forms.ComboBox();
            lblCliente = new System.Windows.Forms.Label();
            cboCliente = new System.Windows.Forms.ComboBox();
            lblSubTotal = new System.Windows.Forms.Label();
            txtSubTotal = new System.Windows.Forms.TextBox();
            lblTotal = new System.Windows.Forms.Label();
            txtTotal = new System.Windows.Forms.TextBox();
            lblMetodoPago = new System.Windows.Forms.Label();
            txtMetodoPago = new System.Windows.Forms.TextBox();
            lblMensaje = new System.Windows.Forms.Label();
            btnFacturarCobrar = new System.Windows.Forms.Button();
            btnVerTicket = new System.Windows.Forms.Button();
            btnLimpiar = new System.Windows.Forms.Button();
            btnArqueo = new System.Windows.Forms.Button();

            pnlTableCard = new System.Windows.Forms.Panel();
            tabControlFinanciero = new System.Windows.Forms.TabControl();
            tabFacturas = new System.Windows.Forms.TabPage();
            tabHistorialCajas = new System.Windows.Forms.TabPage();
            lblTableTitulo = new System.Windows.Forms.Label();
            lblBuscar = new System.Windows.Forms.Label();
            txtBuscar = new System.Windows.Forms.TextBox();
            btnRefrescar = new System.Windows.Forms.Button();
            lblTotalFacturas = new System.Windows.Forms.Label();
            lblTotalRecaudado = new System.Windows.Forms.Label();
            dgvFacturas = new System.Windows.Forms.DataGridView();
            lblTableTituloCaja = new System.Windows.Forms.Label();
            lblBuscarCaja = new System.Windows.Forms.Label();
            txtBuscarCaja = new System.Windows.Forms.TextBox();
            btnRefrescarHistorial = new System.Windows.Forms.Button();
            lblTotalSesiones = new System.Windows.Forms.Label();
            dgvHistorialCajas = new System.Windows.Forms.DataGridView();

            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).BeginInit();
            pnlStatusCard.SuspendLayout();
            pnlFormCard.SuspendLayout();
            pnlTableCard.SuspendLayout();
            tabControlFinanciero.SuspendLayout();
            tabFacturas.SuspendLayout();
            tabHistorialCajas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialCajas).BeginInit();
            SuspendLayout();

            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.White;
            pnlHeader.Controls.Add(picLogoHeader);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.Controls.Add(lblHeaderSubtitle);
            pnlHeader.Controls.Add(btnCerrarForm);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1080, 68);
            pnlHeader.TabIndex = 0;
            pnlHeader.Paint += PnlCard_Paint;

            // 
            // picLogoHeader
            // 
            picLogoHeader.Location = new System.Drawing.Point(20, 12);
            picLogoHeader.Name = "picLogoHeader";
            picLogoHeader.Size = new System.Drawing.Size(46, 44);
            picLogoHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picLogoHeader.TabIndex = 0;
            picLogoHeader.TabStop = false;

            // 
            // lblHeaderTitle
            // 
            lblHeaderTitle.AutoSize = true;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblHeaderTitle.Location = new System.Drawing.Point(75, 12);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(378, 25);
            lblHeaderTitle.TabIndex = 1;
            lblHeaderTitle.Text = "Control de Caja, Facturación y Cobros";

            // 
            // lblHeaderSubtitle
            // 
            lblHeaderSubtitle.AutoSize = true;
            lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblHeaderSubtitle.Location = new System.Drawing.Point(76, 38);
            lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            lblHeaderSubtitle.Size = new System.Drawing.Size(495, 15);
            lblHeaderSubtitle.TabIndex = 2;
            lblHeaderSubtitle.Text = "Sistema de Gestión Automotriz - Taller Toluca | Módulo Financiero";

            // 
            // btnCerrarForm
            // 
            btnCerrarForm.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCerrarForm.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            btnCerrarForm.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrarForm.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnCerrarForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrarForm.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnCerrarForm.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnCerrarForm.Location = new System.Drawing.Point(960, 16);
            btnCerrarForm.Name = "btnCerrarForm";
            btnCerrarForm.Size = new System.Drawing.Size(100, 36);
            btnCerrarForm.TabIndex = 3;
            btnCerrarForm.Text = "Volver al Menú";
            btnCerrarForm.UseVisualStyleBackColor = false;
            btnCerrarForm.Click += (s, e) => this.Close();

            // 
            // pnlStatusCard
            // 
            pnlStatusCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlStatusCard.BackColor = System.Drawing.Color.White;
            pnlStatusCard.Controls.Add(lblEstadoCajaBadge);
            pnlStatusCard.Controls.Add(lblMontoAperturaInfo);
            pnlStatusCard.Controls.Add(lblIngresosInfo);
            pnlStatusCard.Controls.Add(lblSaldoTotalInfo);
            pnlStatusCard.Controls.Add(btnAbrirCaja);
            pnlStatusCard.Controls.Add(btnCerrarCaja);
            pnlStatusCard.Controls.Add(btnHistorialCajas);
            pnlStatusCard.Location = new System.Drawing.Point(20, 78);
            pnlStatusCard.Name = "pnlStatusCard";
            pnlStatusCard.Size = new System.Drawing.Size(1040, 64);
            pnlStatusCard.TabIndex = 1;
            pnlStatusCard.Paint += PnlCard_Paint;

            // 
            // lblEstadoCajaBadge
            // 
            lblEstadoCajaBadge.AutoSize = true;
            lblEstadoCajaBadge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblEstadoCajaBadge.ForeColor = System.Drawing.Color.FromArgb(2, 132, 199);
            lblEstadoCajaBadge.Location = new System.Drawing.Point(15, 22);
            lblEstadoCajaBadge.Name = "lblEstadoCajaBadge";
            lblEstadoCajaBadge.Size = new System.Drawing.Size(155, 19);
            lblEstadoCajaBadge.TabIndex = 0;
            lblEstadoCajaBadge.Text = "Caja Activa: Verificando...";

            // 
            // lblMontoAperturaInfo
            // 
            lblMontoAperturaInfo.AutoSize = true;
            lblMontoAperturaInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblMontoAperturaInfo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblMontoAperturaInfo.Location = new System.Drawing.Point(190, 23);
            lblMontoAperturaInfo.Name = "lblMontoAperturaInfo";
            lblMontoAperturaInfo.Size = new System.Drawing.Size(111, 17);
            lblMontoAperturaInfo.TabIndex = 1;
            lblMontoAperturaInfo.Text = "Apertura: $ 0.00";

            // 
            // lblIngresosInfo
            // 
            lblIngresosInfo.AutoSize = true;
            lblIngresosInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblIngresosInfo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblIngresosInfo.Location = new System.Drawing.Point(325, 23);
            lblIngresosInfo.Name = "lblIngresosInfo";
            lblIngresosInfo.Size = new System.Drawing.Size(110, 17);
            lblIngresosInfo.TabIndex = 2;
            lblIngresosInfo.Text = "Cobros: $ 0.00";

            // 
            // lblSaldoTotalInfo
            // 
            lblSaldoTotalInfo.AutoSize = true;
            lblSaldoTotalInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblSaldoTotalInfo.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblSaldoTotalInfo.Location = new System.Drawing.Point(450, 22);
            lblSaldoTotalInfo.Name = "lblSaldoTotalInfo";
            lblSaldoTotalInfo.Size = new System.Drawing.Size(149, 19);
            lblSaldoTotalInfo.TabIndex = 3;
            lblSaldoTotalInfo.Text = "Total en Caja: $ 0.00";

            // 
            // btnAbrirCaja
            // 
            btnAbrirCaja.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAbrirCaja.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            btnAbrirCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAbrirCaja.FlatAppearance.BorderSize = 0;
            btnAbrirCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAbrirCaja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnAbrirCaja.ForeColor = System.Drawing.Color.White;
            btnAbrirCaja.Location = new System.Drawing.Point(630, 14);
            btnAbrirCaja.Name = "btnAbrirCaja";
            btnAbrirCaja.Size = new System.Drawing.Size(120, 36);
            btnAbrirCaja.TabIndex = 4;
            btnAbrirCaja.Text = "Abrir Caja...";
            btnAbrirCaja.UseVisualStyleBackColor = false;
            btnAbrirCaja.Click += btnAbrirCaja_Click;

            // 
            // btnCerrarCaja
            // 
            btnCerrarCaja.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCerrarCaja.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            btnCerrarCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCerrarCaja.FlatAppearance.BorderSize = 0;
            btnCerrarCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCerrarCaja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnCerrarCaja.ForeColor = System.Drawing.Color.White;
            btnCerrarCaja.Location = new System.Drawing.Point(760, 14);
            btnCerrarCaja.Name = "btnCerrarCaja";
            btnCerrarCaja.Size = new System.Drawing.Size(125, 36);
            btnCerrarCaja.TabIndex = 5;
            btnCerrarCaja.Text = "Cierre / Arqueo";
            btnCerrarCaja.UseVisualStyleBackColor = false;
            btnCerrarCaja.Click += btnCerrarCaja_Click;

            // 
            // btnHistorialCajas
            // 
            btnHistorialCajas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnHistorialCajas.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnHistorialCajas.Cursor = System.Windows.Forms.Cursors.Hand;
            btnHistorialCajas.FlatAppearance.BorderSize = 0;
            btnHistorialCajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnHistorialCajas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnHistorialCajas.ForeColor = System.Drawing.Color.White;
            btnHistorialCajas.Location = new System.Drawing.Point(895, 14);
            btnHistorialCajas.Name = "btnHistorialCajas";
            btnHistorialCajas.Size = new System.Drawing.Size(130, 36);
            btnHistorialCajas.TabIndex = 6;
            btnHistorialCajas.Text = "📋 Historial Cajas";
            btnHistorialCajas.UseVisualStyleBackColor = false;
            btnHistorialCajas.Click += BtnHistorialCajas_Click;

            // 
            // pnlFormCard
            // 
            pnlFormCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            pnlFormCard.BackColor = System.Drawing.Color.White;
            pnlFormCard.Controls.Add(lblFormTitulo);
            pnlFormCard.Controls.Add(lblCamposObligatorios);
            pnlFormCard.Controls.Add(lblOrden);
            pnlFormCard.Controls.Add(cboOrden);
            pnlFormCard.Controls.Add(lblCliente);
            pnlFormCard.Controls.Add(cboCliente);
            pnlFormCard.Controls.Add(lblSubTotal);
            pnlFormCard.Controls.Add(txtSubTotal);
            pnlFormCard.Controls.Add(lblTotal);
            pnlFormCard.Controls.Add(txtTotal);
            pnlFormCard.Controls.Add(lblMetodoPago);
            pnlFormCard.Controls.Add(txtMetodoPago);
            pnlFormCard.Controls.Add(lblMensaje);
            pnlFormCard.Controls.Add(btnFacturarCobrar);
            pnlFormCard.Controls.Add(btnVerTicket);
            pnlFormCard.Controls.Add(btnLimpiar);
            pnlFormCard.Controls.Add(btnArqueo);
            pnlFormCard.Location = new System.Drawing.Point(20, 152);
            pnlFormCard.Name = "pnlFormCard";
            pnlFormCard.Size = new System.Drawing.Size(380, 508);
            pnlFormCard.TabIndex = 2;
            pnlFormCard.Paint += PnlCard_Paint;

            // 
            // lblFormTitulo
            // 
            lblFormTitulo.AutoSize = true;
            lblFormTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblFormTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblFormTitulo.Location = new System.Drawing.Point(20, 16);
            lblFormTitulo.Name = "lblFormTitulo";
            lblFormTitulo.Size = new System.Drawing.Size(225, 20);
            lblFormTitulo.TabIndex = 0;
            lblFormTitulo.Text = "Registrar Factura y Cobro";

            // 
            // lblCamposObligatorios
            // 
            lblCamposObligatorios.AutoSize = true;
            lblCamposObligatorios.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            lblCamposObligatorios.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblCamposObligatorios.Location = new System.Drawing.Point(20, 38);
            lblCamposObligatorios.Name = "lblCamposObligatorios";
            lblCamposObligatorios.Size = new System.Drawing.Size(262, 13);
            lblCamposObligatorios.TabIndex = 1;
            lblCamposObligatorios.Text = "Los campos obligatorios están marcados con un asterisco *";

            // 
            // lblOrden
            // 
            lblOrden.AutoSize = true;
            lblOrden.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblOrden.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblOrden.Location = new System.Drawing.Point(20, 62);
            lblOrden.Name = "lblOrden";
            lblOrden.Size = new System.Drawing.Size(117, 15);
            lblOrden.TabIndex = 2;
            lblOrden.Text = "Orden de Trabajo *";

            // 
            // cboOrden
            // 
            cboOrden.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboOrden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboOrden.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboOrden.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboOrden.Location = new System.Drawing.Point(20, 81);
            cboOrden.Name = "cboOrden";
            cboOrden.Size = new System.Drawing.Size(340, 25);
            cboOrden.TabIndex = 0;
            cboOrden.SelectedIndexChanged += CboOrden_SelectedIndexChanged;

            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblCliente.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblCliente.Location = new System.Drawing.Point(20, 116);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new System.Drawing.Size(55, 15);
            lblCliente.TabIndex = 3;
            lblCliente.Text = "Cliente *";

            // 
            // cboCliente
            // 
            cboCliente.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboCliente.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            cboCliente.Location = new System.Drawing.Point(20, 135);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new System.Drawing.Size(340, 25);
            cboCliente.TabIndex = 1;
            cboCliente.SelectedIndexChanged += Input_TextChanged;

            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblSubTotal.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblSubTotal.Location = new System.Drawing.Point(20, 172);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new System.Drawing.Size(86, 15);
            lblSubTotal.TabIndex = 4;
            lblSubTotal.Text = "Subtotal ($) *";

            // 
            // txtSubTotal
            // 
            txtSubTotal.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtSubTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSubTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSubTotal.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtSubTotal.Location = new System.Drawing.Point(20, 191);
            txtSubTotal.MaxLength = 18;
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.Size = new System.Drawing.Size(160, 25);
            txtSubTotal.TabIndex = 2;
            txtSubTotal.Text = "0.00";
            txtSubTotal.TextChanged += TxtSubTotal_TextChanged;

            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblTotal.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblTotal.Location = new System.Drawing.Point(195, 172);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new System.Drawing.Size(117, 15);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total a Cobrar ($) *";

            // 
            // txtTotal
            // 
            txtTotal.BackColor = System.Drawing.Color.FromArgb(240, 253, 244);
            txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            txtTotal.ForeColor = System.Drawing.Color.FromArgb(21, 128, 61);
            txtTotal.Location = new System.Drawing.Point(195, 191);
            txtTotal.MaxLength = 18;
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new System.Drawing.Size(165, 25);
            txtTotal.TabIndex = 3;
            txtTotal.Text = "0.00";
            txtTotal.TextChanged += Input_TextChanged;

            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblMetodoPago.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblMetodoPago.Location = new System.Drawing.Point(20, 228);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new System.Drawing.Size(262, 15);
            lblMetodoPago.TabIndex = 6;
            lblMetodoPago.Text = "Método de Pago (Regla #1: Solo Efectivo)";

            // 
            // txtMetodoPago
            // 
            txtMetodoPago.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            txtMetodoPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtMetodoPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            txtMetodoPago.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            txtMetodoPago.Location = new System.Drawing.Point(20, 247);
            txtMetodoPago.Name = "txtMetodoPago";
            txtMetodoPago.ReadOnly = true;
            txtMetodoPago.Size = new System.Drawing.Size(340, 25);
            txtMetodoPago.TabIndex = 4;
            txtMetodoPago.Text = "Efectivo";

            // 
            // lblMensaje
            // 
            lblMensaje.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblMensaje.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblMensaje.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblMensaje.Location = new System.Drawing.Point(20, 282);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new System.Drawing.Size(340, 32);
            lblMensaje.TabIndex = 7;
            lblMensaje.Text = "";
            lblMensaje.Visible = false;

            // 
            // btnFacturarCobrar
            // 
            btnFacturarCobrar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnFacturarCobrar.BackColor = System.Drawing.Color.FromArgb(2, 132, 199);
            btnFacturarCobrar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnFacturarCobrar.FlatAppearance.BorderSize = 0;
            btnFacturarCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFacturarCobrar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnFacturarCobrar.ForeColor = System.Drawing.Color.White;
            btnFacturarCobrar.Location = new System.Drawing.Point(20, 325);
            btnFacturarCobrar.Name = "btnFacturarCobrar";
            btnFacturarCobrar.Size = new System.Drawing.Size(165, 42);
            btnFacturarCobrar.TabIndex = 5;
            btnFacturarCobrar.Text = "Facturar / Cobrar";
            btnFacturarCobrar.UseVisualStyleBackColor = false;
            btnFacturarCobrar.Click += btnFacturarCobrar_Click;

            // 
            // btnVerTicket
            // 
            btnVerTicket.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnVerTicket.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnVerTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            btnVerTicket.FlatAppearance.BorderSize = 0;
            btnVerTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnVerTicket.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnVerTicket.ForeColor = System.Drawing.Color.White;
            btnVerTicket.Location = new System.Drawing.Point(195, 325);
            btnVerTicket.Name = "btnVerTicket";
            btnVerTicket.Size = new System.Drawing.Size(165, 42);
            btnVerTicket.TabIndex = 6;
            btnVerTicket.Text = "Ver Comprobante";
            btnVerTicket.UseVisualStyleBackColor = false;
            btnVerTicket.Click += btnVerTicket_Click;

            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnLimpiar.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnLimpiar.ForeColor = System.Drawing.Color.White;
            btnLimpiar.Location = new System.Drawing.Point(20, 377);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new System.Drawing.Size(165, 42);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Nuevo / Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;

            // 
            // btnArqueo
            // 
            btnArqueo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnArqueo.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnArqueo.Cursor = System.Windows.Forms.Cursors.Hand;
            btnArqueo.FlatAppearance.BorderSize = 0;
            btnArqueo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnArqueo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnArqueo.ForeColor = System.Drawing.Color.White;
            btnArqueo.Location = new System.Drawing.Point(195, 377);
            btnArqueo.Name = "btnArqueo";
            btnArqueo.Size = new System.Drawing.Size(165, 42);
            btnArqueo.TabIndex = 8;
            btnArqueo.Text = "Arqueo de Caja";
            btnArqueo.UseVisualStyleBackColor = false;
            btnArqueo.Click += btnArqueo_Click;

            // 
            // pnlTableCard
            // 
            pnlTableCard.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlTableCard.BackColor = System.Drawing.Color.White;
            pnlTableCard.Controls.Add(tabControlFinanciero);
            pnlTableCard.Location = new System.Drawing.Point(415, 152);
            pnlTableCard.Name = "pnlTableCard";
            pnlTableCard.Size = new System.Drawing.Size(645, 508);
            pnlTableCard.TabIndex = 3;
            pnlTableCard.Paint += PnlCard_Paint;

            // 
            // tabControlFinanciero
            // 
            tabControlFinanciero.Controls.Add(tabFacturas);
            tabControlFinanciero.Controls.Add(tabHistorialCajas);
            tabControlFinanciero.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlFinanciero.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            tabControlFinanciero.Location = new System.Drawing.Point(0, 0);
            tabControlFinanciero.Name = "tabControlFinanciero";
            tabControlFinanciero.SelectedIndex = 0;
            tabControlFinanciero.Size = new System.Drawing.Size(645, 508);
            tabControlFinanciero.TabIndex = 0;

            // 
            // tabFacturas
            // 
            tabFacturas.BackColor = System.Drawing.Color.White;
            tabFacturas.Controls.Add(lblTableTitulo);
            tabFacturas.Controls.Add(lblBuscar);
            tabFacturas.Controls.Add(txtBuscar);
            tabFacturas.Controls.Add(btnRefrescar);
            tabFacturas.Controls.Add(lblTotalFacturas);
            tabFacturas.Controls.Add(lblTotalRecaudado);
            tabFacturas.Controls.Add(dgvFacturas);
            tabFacturas.Location = new System.Drawing.Point(4, 26);
            tabFacturas.Name = "tabFacturas";
            tabFacturas.Padding = new System.Windows.Forms.Padding(3);
            tabFacturas.Size = new System.Drawing.Size(637, 478);
            tabFacturas.TabIndex = 0;
            tabFacturas.Text = "📄 Facturas Emitidas";

            // 
            // tabHistorialCajas
            // 
            tabHistorialCajas.BackColor = System.Drawing.Color.White;
            tabHistorialCajas.Controls.Add(lblTableTituloCaja);
            tabHistorialCajas.Controls.Add(lblBuscarCaja);
            tabHistorialCajas.Controls.Add(txtBuscarCaja);
            tabHistorialCajas.Controls.Add(btnRefrescarHistorial);
            tabHistorialCajas.Controls.Add(lblTotalSesiones);
            tabHistorialCajas.Controls.Add(dgvHistorialCajas);
            tabHistorialCajas.Location = new System.Drawing.Point(4, 26);
            tabHistorialCajas.Name = "tabHistorialCajas";
            tabHistorialCajas.Padding = new System.Windows.Forms.Padding(3);
            tabHistorialCajas.Size = new System.Drawing.Size(637, 478);
            tabHistorialCajas.TabIndex = 1;
            tabHistorialCajas.Text = "📊 Historial de Cajas";

            // 
            // lblTableTitulo
            // 
            lblTableTitulo.AutoSize = true;
            lblTableTitulo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTableTitulo.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTableTitulo.Location = new System.Drawing.Point(15, 12);
            lblTableTitulo.Name = "lblTableTitulo";
            lblTableTitulo.Size = new System.Drawing.Size(262, 20);
            lblTableTitulo.TabIndex = 0;
            lblTableTitulo.Text = "Facturas y Comprobantes Emitidos";

            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblBuscar.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblBuscar.Location = new System.Drawing.Point(15, 44);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new System.Drawing.Size(47, 15);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar:";

            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtBuscar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtBuscar.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtBuscar.Location = new System.Drawing.Point(68, 40);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Filtrar por N° factura, N° orden, cliente o placa...";
            txtBuscar.Size = new System.Drawing.Size(430, 25);
            txtBuscar.TabIndex = 0;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;

            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRefrescar.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefrescar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btnRefrescar.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnRefrescar.Location = new System.Drawing.Point(510, 39);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new System.Drawing.Size(110, 27);
            btnRefrescar.TabIndex = 1;
            btnRefrescar.Text = "Refrescar";
            btnRefrescar.UseVisualStyleBackColor = false;
            btnRefrescar.Click += BtnRefrescar_Click;

            // 
            // lblTotalFacturas
            // 
            lblTotalFacturas.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalFacturas.AutoSize = true;
            lblTotalFacturas.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblTotalFacturas.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTotalFacturas.Location = new System.Drawing.Point(15, 450);
            lblTotalFacturas.Name = "lblTotalFacturas";
            lblTotalFacturas.Size = new System.Drawing.Size(155, 15);
            lblTotalFacturas.TabIndex = 2;
            lblTotalFacturas.Text = "Total facturas emitidas: 0";

            // 
            // lblTotalRecaudado
            // 
            lblTotalRecaudado.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblTotalRecaudado.AutoSize = true;
            lblTotalRecaudado.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblTotalRecaudado.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            lblTotalRecaudado.Location = new System.Drawing.Point(425, 448);
            lblTotalRecaudado.Name = "lblTotalRecaudado";
            lblTotalRecaudado.Size = new System.Drawing.Size(195, 17);
            lblTotalRecaudado.TabIndex = 3;
            lblTotalRecaudado.Text = "Total Recaudado: $ 0.00";

            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.AllowUserToResizeRows = false;
            dgvFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.BackgroundColor = System.Drawing.Color.White;
            dgvFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location = new System.Drawing.Point(15, 75);
            dgvFacturas.MultiSelect = false;
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new System.Drawing.Size(605, 365);
            dgvFacturas.TabIndex = 2;
            dgvFacturas.CellClick += DgvFacturas_CellClick;
            dgvFacturas.SelectionChanged += DgvFacturas_SelectionChanged;

            // 
            // lblTableTituloCaja
            // 
            lblTableTituloCaja.AutoSize = true;
            lblTableTituloCaja.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTableTituloCaja.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTableTituloCaja.Location = new System.Drawing.Point(15, 12);
            lblTableTituloCaja.Name = "lblTableTituloCaja";
            lblTableTituloCaja.Size = new System.Drawing.Size(320, 20);
            lblTableTituloCaja.TabIndex = 0;
            lblTableTituloCaja.Text = "Historial de Aperturas y Cierres de Caja";

            // 
            // lblBuscarCaja
            // 
            lblBuscarCaja.AutoSize = true;
            lblBuscarCaja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblBuscarCaja.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            lblBuscarCaja.Location = new System.Drawing.Point(15, 44);
            lblBuscarCaja.Name = "lblBuscarCaja";
            lblBuscarCaja.Size = new System.Drawing.Size(47, 15);
            lblBuscarCaja.TabIndex = 1;
            lblBuscarCaja.Text = "Buscar:";

            // 
            // txtBuscarCaja
            // 
            txtBuscarCaja.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtBuscarCaja.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            txtBuscarCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscarCaja.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtBuscarCaja.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtBuscarCaja.Location = new System.Drawing.Point(68, 40);
            txtBuscarCaja.Name = "txtBuscarCaja";
            txtBuscarCaja.PlaceholderText = "Filtrar por N° caja, fecha o estado (Abierta / Cerrada)...";
            txtBuscarCaja.Size = new System.Drawing.Size(430, 25);
            txtBuscarCaja.TabIndex = 2;
            txtBuscarCaja.TextChanged += TxtBuscarCaja_TextChanged;

            // 
            // btnRefrescarHistorial
            // 
            btnRefrescarHistorial.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRefrescarHistorial.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            btnRefrescarHistorial.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRefrescarHistorial.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            btnRefrescarHistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRefrescarHistorial.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            btnRefrescarHistorial.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnRefrescarHistorial.Location = new System.Drawing.Point(510, 39);
            btnRefrescarHistorial.Name = "btnRefrescarHistorial";
            btnRefrescarHistorial.Size = new System.Drawing.Size(110, 27);
            btnRefrescarHistorial.TabIndex = 3;
            btnRefrescarHistorial.Text = "Refrescar";
            btnRefrescarHistorial.UseVisualStyleBackColor = false;
            btnRefrescarHistorial.Click += BtnRefrescarHistorial_Click;

            // 
            // lblTotalSesiones
            // 
            lblTotalSesiones.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTotalSesiones.AutoSize = true;
            lblTotalSesiones.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            lblTotalSesiones.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTotalSesiones.Location = new System.Drawing.Point(15, 450);
            lblTotalSesiones.Name = "lblTotalSesiones";
            lblTotalSesiones.Size = new System.Drawing.Size(160, 15);
            lblTotalSesiones.TabIndex = 4;
            lblTotalSesiones.Text = "Total sesiones registradas: 0";

            // 
            // dgvHistorialCajas
            // 
            dgvHistorialCajas.AllowUserToAddRows = false;
            dgvHistorialCajas.AllowUserToDeleteRows = false;
            dgvHistorialCajas.AllowUserToResizeRows = false;
            dgvHistorialCajas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvHistorialCajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorialCajas.BackgroundColor = System.Drawing.Color.White;
            dgvHistorialCajas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHistorialCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorialCajas.Location = new System.Drawing.Point(15, 75);
            dgvHistorialCajas.MultiSelect = false;
            dgvHistorialCajas.Name = "dgvHistorialCajas";
            dgvHistorialCajas.ReadOnly = true;
            dgvHistorialCajas.RowHeadersVisible = false;
            dgvHistorialCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHistorialCajas.Size = new System.Drawing.Size(605, 365);
            dgvHistorialCajas.TabIndex = 5;

            // 
            // FrmCajaFacturacion
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            ClientSize = new System.Drawing.Size(1080, 680);
            Controls.Add(pnlTableCard);
            Controls.Add(pnlFormCard);
            Controls.Add(pnlStatusCard);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            MaximizeBox = true;
            MinimumSize = new System.Drawing.Size(1050, 650);
            Name = "FrmCajaFacturacion";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            Text = "Control de Caja y Facturación";
            Load += FrmCajaFacturacion_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogoHeader).EndInit();
            pnlStatusCard.ResumeLayout(false);
            pnlStatusCard.PerformLayout();
            pnlFormCard.ResumeLayout(false);
            pnlFormCard.PerformLayout();
            pnlTableCard.ResumeLayout(false);
            tabControlFinanciero.ResumeLayout(false);
            tabFacturas.ResumeLayout(false);
            tabFacturas.PerformLayout();
            tabHistorialCajas.ResumeLayout(false);
            tabHistorialCajas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvHistorialCajas).EndInit();
            ResumeLayout(false);
        }
    }
}
