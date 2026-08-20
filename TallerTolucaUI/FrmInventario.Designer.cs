using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class FrmInventario
    {
        private System.ComponentModel.IContainer components = null;

        // Encabezado
        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnNuevoRepuesto;
        private Button btnRegistrarMovimiento;

        // Filtros y Búsqueda
        private Panel pnlFiltros;
        private TextBox txtBuscar;

        // Tabla
        private DataGridView dgvRepuestos;

        // Paginación / Resumen
        private Panel pnlPaginacion;
        private Label lblResumenRegistros;

        // Panel Modal Nuevo Repuesto
        private Panel pnlModalRepuesto;
        private Label lblTituloModalRepuesto;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblStock;
        private TextBox txtStock;
        private Button btnCancelarRepuesto;
        private Button btnGuardarRepuesto;

        // Panel Modal Movimiento Inventario
        private Panel pnlModalMovimiento;
        private Label lblTituloModalMov;
        private Label lblMovRepuestoID;
        private TextBox txtMovRepuestoID;
        private Label lblMovTipo;
        private ComboBox cboMovTipo;
        private Label lblMovCantidad;
        private TextBox txtMovCantidad;
        private Label lblMovMotivo;
        private TextBox txtMovMotivo;
        private Button btnCancelarMov;
        private Button btnGuardarMov;

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
            btnNuevoRepuesto = new Button();
            btnRegistrarMovimiento = new Button();

            pnlFiltros = new Panel();
            txtBuscar = new TextBox();

            dgvRepuestos = new DataGridView();
            pnlPaginacion = new Panel();
            lblResumenRegistros = new Label();

            pnlModalRepuesto = new Panel();
            lblTituloModalRepuesto = new Label();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPrecio = new Label();
            txtPrecio = new TextBox();
            lblStock = new Label();
            txtStock = new TextBox();
            btnCancelarRepuesto = new Button();
            btnGuardarRepuesto = new Button();

            pnlModalMovimiento = new Panel();
            lblTituloModalMov = new Label();
            lblMovRepuestoID = new Label();
            txtMovRepuestoID = new TextBox();
            lblMovTipo = new Label();
            cboMovTipo = new ComboBox();
            lblMovCantidad = new Label();
            txtMovCantidad = new TextBox();
            lblMovMotivo = new Label();
            txtMovMotivo = new TextBox();
            btnCancelarMov = new Button();
            btnGuardarMov = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            pnlHeader.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlPaginacion.SuspendLayout();
            pnlModalRepuesto.SuspendLayout();
            pnlModalMovimiento.SuspendLayout();
            SuspendLayout();

            // ============================================
            // pnlHeader (Encabezado Superior)
            // ============================================
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 75;
            pnlHeader.BackColor = Color.FromArgb(240, 248, 255);
            pnlHeader.Controls.Add(btnRegistrarMovimiento);
            pnlHeader.Controls.Add(btnNuevoRepuesto);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);

            lblTitulo.Text = "Control de Inventario y Repuestos";
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Catálogo de piezas de repuesto, control de stock y entradas/salidas justificadas.";
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitulo.Location = new Point(27, 47);
            lblSubtitulo.AutoSize = true;

            btnRegistrarMovimiento.Text = "📦 Entrada / Salida";
            btnRegistrarMovimiento.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRegistrarMovimiento.BackColor = Color.White;
            btnRegistrarMovimiento.ForeColor = Color.FromArgb(51, 65, 85);
            btnRegistrarMovimiento.FlatStyle = FlatStyle.Flat;
            btnRegistrarMovimiento.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnRegistrarMovimiento.Size = new Size(160, 40);
            btnRegistrarMovimiento.Location = new Point(605, 18);
            btnRegistrarMovimiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegistrarMovimiento.Cursor = Cursors.Hand;
            btnRegistrarMovimiento.Click += btnRegistrarMovimiento_Click;

            btnNuevoRepuesto.Text = "+ Nuevo Repuesto";
            btnNuevoRepuesto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoRepuesto.BackColor = Color.FromArgb(0, 191, 255); // #00BFFF
            btnNuevoRepuesto.ForeColor = Color.White;
            btnNuevoRepuesto.FlatStyle = FlatStyle.Flat;
            btnNuevoRepuesto.FlatAppearance.BorderSize = 0;
            btnNuevoRepuesto.Size = new Size(175, 40);
            btnNuevoRepuesto.Location = new Point(775, 18);
            btnNuevoRepuesto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoRepuesto.Cursor = Cursors.Hand;
            btnNuevoRepuesto.Click += btnNuevoRepuesto_Click;

            // ============================================
            // pnlFiltros (Barra de Búsqueda)
            // ============================================
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Height = 55;
            pnlFiltros.BackColor = Color.FromArgb(240, 248, 255);
            pnlFiltros.Controls.Add(txtBuscar);

            txtBuscar.Location = new Point(25, 8);
            txtBuscar.Size = new Size(925, 33);
            txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.BackColor = Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            txtBuscar.PlaceholderText = "🔍  Buscar repuesto por código o descripción...";
            txtBuscar.TextChanged += (s, e) => AplicarFiltros();

            // ============================================
            // dgvRepuestos (Tabla)
            // ============================================
            dgvRepuestos.Dock = DockStyle.Fill;
            dgvRepuestos.BackgroundColor = Color.White;
            dgvRepuestos.BorderStyle = BorderStyle.None;
            dgvRepuestos.GridColor = Color.FromArgb(226, 232, 240);
            dgvRepuestos.RowHeadersVisible = false;
            dgvRepuestos.EnableHeadersVisualStyles = false;
            dgvRepuestos.ColumnHeadersHeight = 42;
            dgvRepuestos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvRepuestos.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvRepuestos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvRepuestos.DefaultCellStyle.BackColor = Color.White;
            dgvRepuestos.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvRepuestos.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRepuestos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 245, 255);
            dgvRepuestos.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvRepuestos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
            dgvRepuestos.RowTemplate.Height = 44;
            dgvRepuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRepuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRepuestos.MultiSelect = false;
            dgvRepuestos.AllowUserToAddRows = false;
            dgvRepuestos.AllowUserToDeleteRows = false;
            dgvRepuestos.ReadOnly = true;
            ConfigurarColumnasRepuestos(dgvRepuestos);
            dgvRepuestos.CellFormatting += dgvRepuestos_CellFormatting;

            // ============================================
            // pnlPaginacion (Pie de página)
            // ============================================
            pnlPaginacion.Dock = DockStyle.Bottom;
            pnlPaginacion.Height = 45;
            pnlPaginacion.BackColor = Color.FromArgb(240, 248, 255);
            pnlPaginacion.Controls.Add(lblResumenRegistros);

            lblResumenRegistros.AutoSize = true;
            lblResumenRegistros.Font = new Font("Segoe UI", 9.5F);
            lblResumenRegistros.ForeColor = Color.FromArgb(100, 116, 139);
            lblResumenRegistros.Location = new Point(25, 12);

            // ============================================
            // pnlModalRepuesto (Modal Nuevo Repuesto)
            // ============================================
            pnlModalRepuesto.Visible = false;
            pnlModalRepuesto.Size = new Size(740, 360);
            pnlModalRepuesto.BackColor = Color.White;
            pnlModalRepuesto.Location = new Point(120, 90);
            pnlModalRepuesto.Anchor = AnchorStyles.None;
            pnlModalRepuesto.BorderStyle = BorderStyle.FixedSingle;

            lblTituloModalRepuesto.Text = "📦 Registro de Nuevo Repuesto";
            lblTituloModalRepuesto.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloModalRepuesto.ForeColor = Color.FromArgb(15, 23, 42);
            lblTituloModalRepuesto.Location = new Point(30, 20);
            lblTituloModalRepuesto.AutoSize = true;

            ConfigurarEtiqueta(lblCodigo, "Código Único de Repuesto *", 30, 65);
            ConfigurarInput(txtCodigo, "Ej. REP-ACE-01", 30, 90, 320);

            ConfigurarEtiqueta(lblNombre, "Nombre / Descripción de la Pieza *", 380, 65);
            ConfigurarInput(txtNombre, "Ej. Filtro de Aceite Sintético", 380, 90, 320);

            ConfigurarEtiqueta(lblPrecio, "Precio Unitario ($) *", 30, 135);
            ConfigurarInput(txtPrecio, "Ej. 25.50", 30, 160, 320);

            ConfigurarEtiqueta(lblStock, "Existencia Inicial (Stock)", 380, 135);
            ConfigurarInput(txtStock, "Ej. 10", 380, 160, 320);

            btnCancelarRepuesto.Text = "CANCELAR";
            btnCancelarRepuesto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancelarRepuesto.BackColor = Color.White;
            btnCancelarRepuesto.ForeColor = Color.FromArgb(71, 85, 105);
            btnCancelarRepuesto.FlatStyle = FlatStyle.Flat;
            btnCancelarRepuesto.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancelarRepuesto.Size = new Size(140, 42);
            btnCancelarRepuesto.Location = new Point(370, 280);
            btnCancelarRepuesto.Cursor = Cursors.Hand;
            btnCancelarRepuesto.Click += (s, e) => pnlModalRepuesto.Visible = false;

            btnGuardarRepuesto.Text = "💾 GUARDAR PIEZA";
            btnGuardarRepuesto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardarRepuesto.BackColor = Color.FromArgb(0, 191, 255);
            btnGuardarRepuesto.ForeColor = Color.White;
            btnGuardarRepuesto.FlatStyle = FlatStyle.Flat;
            btnGuardarRepuesto.FlatAppearance.BorderSize = 0;
            btnGuardarRepuesto.Size = new Size(190, 42);
            btnGuardarRepuesto.Location = new Point(520, 280);
            btnGuardarRepuesto.Cursor = Cursors.Hand;
            btnGuardarRepuesto.Click += btnGuardarRepuesto_Click;

            pnlModalRepuesto.Controls.AddRange(new Control[] {
                lblTituloModalRepuesto, lblCodigo, txtCodigo, lblNombre, txtNombre,
                lblPrecio, txtPrecio, lblStock, txtStock,
                btnCancelarRepuesto, btnGuardarRepuesto
            });

            // ============================================
            // pnlModalMovimiento (Modal Entrada / Salida)
            // ============================================
            pnlModalMovimiento.Visible = false;
            pnlModalMovimiento.Size = new Size(740, 360);
            pnlModalMovimiento.BackColor = Color.White;
            pnlModalMovimiento.Location = new Point(120, 90);
            pnlModalMovimiento.Anchor = AnchorStyles.None;
            pnlModalMovimiento.BorderStyle = BorderStyle.FixedSingle;

            lblTituloModalMov.Text = "🔄 Registro de Entrada / Salida de Inventario";
            lblTituloModalMov.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTituloModalMov.ForeColor = Color.FromArgb(15, 23, 42);
            lblTituloModalMov.Location = new Point(30, 20);
            lblTituloModalMov.AutoSize = true;

            ConfigurarEtiqueta(lblMovRepuestoID, "ID del Repuesto *", 30, 65);
            ConfigurarInput(txtMovRepuestoID, "Ej. 1", 30, 90, 320);

            ConfigurarEtiqueta(lblMovTipo, "Tipo de Movimiento *", 380, 65);
            cboMovTipo.Location = new Point(380, 90);
            cboMovTipo.Size = new Size(320, 33);
            cboMovTipo.Font = new Font("Segoe UI", 10F);
            cboMovTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMovTipo.FlatStyle = FlatStyle.Flat;
            cboMovTipo.BackColor = Color.FromArgb(248, 250, 252);
            cboMovTipo.Items.AddRange(new object[] { "Entrada", "Salida" });
            cboMovTipo.SelectedIndex = 0;

            ConfigurarEtiqueta(lblMovCantidad, "Cantidad de Unidades *", 30, 135);
            ConfigurarInput(txtMovCantidad, "Ej. 5", 30, 160, 320);

            ConfigurarEtiqueta(lblMovMotivo, "Motivo o Justificación de Uso * (Req. 7)", 380, 135);
            ConfigurarInput(txtMovMotivo, "Ej. Uso en Orden de Trabajo ORD-001", 380, 160, 320);

            btnCancelarMov.Text = "CANCELAR";
            btnCancelarMov.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancelarMov.BackColor = Color.White;
            btnCancelarMov.ForeColor = Color.FromArgb(71, 85, 105);
            btnCancelarMov.FlatStyle = FlatStyle.Flat;
            btnCancelarMov.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnCancelarMov.Size = new Size(140, 42);
            btnCancelarMov.Location = new Point(370, 280);
            btnCancelarMov.Cursor = Cursors.Hand;
            btnCancelarMov.Click += (s, e) => pnlModalMovimiento.Visible = false;

            btnGuardarMov.Text = "💾 APLICAR MOVIMIENTO";
            btnGuardarMov.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGuardarMov.BackColor = Color.FromArgb(2, 132, 199);
            btnGuardarMov.ForeColor = Color.White;
            btnGuardarMov.FlatStyle = FlatStyle.Flat;
            btnGuardarMov.FlatAppearance.BorderSize = 0;
            btnGuardarMov.Size = new Size(200, 42);
            btnGuardarMov.Location = new Point(520, 280);
            btnGuardarMov.Cursor = Cursors.Hand;
            btnGuardarMov.Click += btnGuardarMov_Click;

            pnlModalMovimiento.Controls.AddRange(new Control[] {
                lblTituloModalMov, lblMovRepuestoID, txtMovRepuestoID, lblMovTipo, cboMovTipo,
                lblMovCantidad, txtMovCantidad, lblMovMotivo, txtMovMotivo,
                btnCancelarMov, btnGuardarMov
            });

            // ============================================
            // FrmInventario (Formulario)
            // ============================================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(980, 600);
            Controls.Add(pnlModalMovimiento);
            Controls.Add(pnlModalRepuesto);
            Controls.Add(dgvRepuestos);
            Controls.Add(pnlPaginacion);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Control de Inventario";
            Padding = new Padding(20, 10, 20, 15);

            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlPaginacion.ResumeLayout(false);
            pnlPaginacion.PerformLayout();
            pnlModalRepuesto.ResumeLayout(false);
            pnlModalRepuesto.PerformLayout();
            pnlModalMovimiento.ResumeLayout(false);
            pnlModalMovimiento.PerformLayout();
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

        private void ConfigurarColumnasRepuestos(DataGridView grid)
        {
            grid.Columns.Add("RepuestoID", "ID");
            grid.Columns.Add("Codigo", "CÓDIGO");
            grid.Columns.Add("Nombre", "DESCRIPCIÓN DE LA PIEZA");
            grid.Columns.Add("Precio", "PRECIO UNIT.");
            grid.Columns.Add("Existencia", "STOCK DISPONIBLE");
            grid.Columns.Add("EstadoStock", "ESTADO DE STOCK");

            grid.Columns["RepuestoID"].FillWeight = 50;
            grid.Columns["Codigo"].FillWeight = 90;
            grid.Columns["Nombre"].FillWeight = 220;
            grid.Columns["Precio"].FillWeight = 85;
            grid.Columns["Existencia"].FillWeight = 85;
            grid.Columns["EstadoStock"].FillWeight = 90;

            grid.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grid.Columns["Existencia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns["EstadoStock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
