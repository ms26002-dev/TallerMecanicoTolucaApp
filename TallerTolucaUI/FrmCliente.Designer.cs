using System.Drawing;
using System.Windows.Forms;

namespace TallerTolucaUI
{
    partial class FrmClientes
    {
        private System.ComponentModel.IContainer components = null;

        // Encabezado
        private Panel pnlHeader;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnExportar;
        private Button btnImportarCSV;
        private Button btnNuevoRegistro;

        // KPI Cards Panel
        private FlowLayoutPanel flpKpis;
        private Panel pnlKpiTotal;
        private Panel pnlKpiNuevos;
        private Panel pnlKpiFrecuentes;
        private Panel pnlKpiRetorno;

        // Filtros y Búsqueda
        private Panel pnlFiltros;
        private TextBox txtBuscar;
        private ComboBox cboEstadoFiltro;

        // Tabla
        private DataGridView dgvClientes;

        // Paginación
        private Panel pnlPaginacion;
        private Label lblResumenRegistros;
        private FlowLayoutPanel flpPaginas;

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
            btnExportar = new Button();
            btnImportarCSV = new Button();
            btnNuevoRegistro = new Button();

            flpKpis = new FlowLayoutPanel();
            pnlKpiTotal = new Panel();
            pnlKpiNuevos = new Panel();
            pnlKpiFrecuentes = new Panel();
            pnlKpiRetorno = new Panel();

            pnlFiltros = new Panel();
            txtBuscar = new TextBox();
            cboEstadoFiltro = new ComboBox();

            dgvClientes = new DataGridView();
            pnlPaginacion = new Panel();
            lblResumenRegistros = new Label();
            flpPaginas = new FlowLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            pnlHeader.SuspendLayout();
            flpKpis.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlPaginacion.SuspendLayout();
            SuspendLayout();

            // ============================================
            // pnlHeader (Encabezado Superior)
            // ============================================
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Height = 75;
            pnlHeader.BackColor = Color.FromArgb(240, 248, 255);
            pnlHeader.Controls.Add(btnNuevoRegistro);
            pnlHeader.Controls.Add(btnImportarCSV);
            pnlHeader.Controls.Add(btnExportar);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);

            lblTitulo.Text = "Gestión de Clientes";
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitulo.Location = new Point(25, 12);
            lblTitulo.AutoSize = true;

            lblSubtitulo.Text = "Administre la base de datos de propietarios y sus perfiles de servicio.";
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitulo.Location = new Point(27, 47);
            lblSubtitulo.AutoSize = true;

            ConfigurarBotonSecundario(btnExportar, "↓ Exportar CSV", 520, 18, 125);
            btnExportar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExportar.Click += btnExportar_Click;

            ConfigurarBotonSecundario(btnImportarCSV, "📄 Importar CSV", 655, 18, 135);
            btnImportarCSV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImportarCSV.Click += btnImportarCSV_Click;

            btnNuevoRegistro.Text = "+ Nuevo Registro";
            btnNuevoRegistro.Location = new Point(800, 18);
            btnNuevoRegistro.Size = new Size(155, 40);
            btnNuevoRegistro.BackColor = Color.FromArgb(0, 191, 255); // #00BFFF
            btnNuevoRegistro.ForeColor = Color.White;
            btnNuevoRegistro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoRegistro.FlatStyle = FlatStyle.Flat;
            btnNuevoRegistro.FlatAppearance.BorderSize = 0;
            btnNuevoRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoRegistro.Cursor = Cursors.Hand;
            btnNuevoRegistro.Click += btnNuevoRegistro_Click;

            // ============================================
            // flpKpis (Tarjetas de Métricas según Imagen 5)
            // ============================================
            flpKpis.Dock = DockStyle.Top;
            flpKpis.Height = 100;
            flpKpis.BackColor = Color.FromArgb(240, 248, 255);
            flpKpis.FlowDirection = FlowDirection.LeftToRight;
            flpKpis.WrapContents = false;
            flpKpis.Padding = new Padding(25, 5, 20, 5);

            pnlKpiTotal = CrearKpiCard("Total Clientes", "En base de datos", "👥", Color.FromArgb(2, 132, 199));
            pnlKpiNuevos = CrearKpiCard("Nuevos (Mes)", "+32 registrados", "👤+", Color.FromArgb(217, 119, 6));
            pnlKpiFrecuentes = CrearKpiCard("Frecuentes", "Con múltiples visitas", "⭐", Color.FromArgb(16, 185, 129));
            pnlKpiRetorno = CrearKpiCard("Tasa de Retorno", "84% satisfacción", "📈", Color.FromArgb(139, 92, 246));

            flpKpis.Controls.AddRange(new Control[] { pnlKpiTotal, pnlKpiNuevos, pnlKpiFrecuentes, pnlKpiRetorno });

            // ============================================
            // pnlFiltros (Barra de Búsqueda y Filtros)
            // ============================================
            pnlFiltros.Dock = DockStyle.Top;
            pnlFiltros.Height = 55;
            pnlFiltros.BackColor = Color.FromArgb(240, 248, 255);
            pnlFiltros.Controls.Add(txtBuscar);
            pnlFiltros.Controls.Add(cboEstadoFiltro);

            txtBuscar.Location = new Point(25, 8);
            txtBuscar.Size = new Size(680, 33);
            txtBuscar.Font = new Font("Segoe UI", 10F);
            txtBuscar.BackColor = Color.FromArgb(248, 250, 252);
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.ForeColor = Color.FromArgb(30, 41, 59);
            txtBuscar.PlaceholderText = "🔍  Buscar clientes por nombre, teléfono o ID...";
            txtBuscar.TextChanged += FiltrosCambiaron;

            cboEstadoFiltro.Location = new Point(720, 8);
            cboEstadoFiltro.Size = new Size(235, 33);
            cboEstadoFiltro.Font = new Font("Segoe UI", 10F);
            cboEstadoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstadoFiltro.FlatStyle = FlatStyle.Flat;
            cboEstadoFiltro.BackColor = Color.FromArgb(248, 250, 252);
            cboEstadoFiltro.Items.AddRange(new object[] { "Todos los estados", "Activo", "Inactivo" });
            cboEstadoFiltro.SelectedIndex = 0;
            cboEstadoFiltro.SelectedIndexChanged += FiltrosCambiaron;

            // ============================================
            // dgvClientes (Tabla)
            // ============================================
            dgvClientes.Dock = DockStyle.Fill;
            dgvClientes.BackgroundColor = Color.White;
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.GridColor = Color.FromArgb(226, 232, 240);
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.EnableHeadersVisualStyles = false;
            dgvClientes.ColumnHeadersHeight = 42;
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvClientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvClientes.DefaultCellStyle.BackColor = Color.White;
            dgvClientes.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvClientes.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 245, 255);
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 255);
            dgvClientes.RowTemplate.Height = 44;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.ReadOnly = true;
            ConfigurarColumnas(dgvClientes);
            dgvClientes.CellFormatting += dgvClientes_CellFormatting;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;

            // ============================================
            // pnlPaginacion (Pie de página)
            // ============================================
            pnlPaginacion.Dock = DockStyle.Bottom;
            pnlPaginacion.Height = 50;
            pnlPaginacion.BackColor = Color.FromArgb(240, 248, 255);
            pnlPaginacion.Controls.Add(lblResumenRegistros);
            pnlPaginacion.Controls.Add(flpPaginas);

            lblResumenRegistros.AutoSize = true;
            lblResumenRegistros.Font = new Font("Segoe UI", 9.5F);
            lblResumenRegistros.ForeColor = Color.FromArgb(100, 116, 139);
            lblResumenRegistros.Location = new Point(25, 15);

            flpPaginas.FlowDirection = FlowDirection.LeftToRight;
            flpPaginas.Location = new Point(620, 8);
            flpPaginas.Size = new Size(335, 36);
            flpPaginas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            flpPaginas.WrapContents = false;

            // ============================================
            // FrmClientes (Formulario)
            // ============================================
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(980, 600);
            Controls.Add(dgvClientes);
            Controls.Add(pnlPaginacion);
            Controls.Add(pnlFiltros);
            Controls.Add(flpKpis);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes";
            Padding = new Padding(20, 10, 20, 15);

            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            flpKpis.ResumeLayout(false);
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlPaginacion.ResumeLayout(false);
            pnlPaginacion.PerformLayout();
            ResumeLayout(false);
        }

        private Panel CrearKpiCard(string titulo, string subtitulo, string icono, Color colorAcento)
        {
            Panel card = new Panel
            {
                Size = new Size(220, 80),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 15, 0),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblIco = new Label
            {
                Text = icono,
                Font = new Font("Segoe UI Emoji", 14F),
                Location = new Point(165, 10),
                Size = new Size(40, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblTit = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(12, 10),
                Size = new Size(150, 18)
            };

            Label lblSub = new Label
            {
                Text = subtitulo,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = colorAcento,
                Location = new Point(12, 32),
                Size = new Size(150, 20)
            };

            card.Controls.AddRange(new Control[] { lblIco, lblTit, lblSub });
            return card;
        }

        private void ConfigurarBotonSecundario(Button btn, string texto, int x, int y, int ancho)
        {
            btn.Text = texto;
            btn.Location = new Point(x, y);
            btn.Size = new Size(ancho, 40);
            btn.BackColor = Color.White;
            btn.ForeColor = Color.FromArgb(51, 65, 85);
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btn.FlatAppearance.BorderSize = 1;
            btn.Cursor = Cursors.Hand;
        }

        private void ConfigurarColumnas(DataGridView grid)
        {
            grid.Columns.Add("ClienteID", "CLIENTEID");
            grid.Columns.Add("NombreCompleto", "NOMBRE COMPLETO");
            grid.Columns.Add("Telefono", "TELÉFONO");
            grid.Columns.Add("VehiculosAsociados", "VEHÍCULOS");
            grid.Columns.Add("Estado", "ESTADO");

            var colConsultar = new DataGridViewButtonColumn
            {
                Name = "Consultar",
                HeaderText = "",
                Text = "Consultar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            colConsultar.DefaultCellStyle.BackColor = Color.FromArgb(224, 245, 255);
            colConsultar.DefaultCellStyle.ForeColor = Color.FromArgb(2, 132, 199);
            colConsultar.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colConsultar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 245, 255);
            colConsultar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(2, 132, 199);

            var colEditar = new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            colEditar.DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199);
            colEditar.DefaultCellStyle.ForeColor = Color.FromArgb(146, 64, 14);
            colEditar.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colEditar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 243, 199);
            colEditar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(146, 64, 14);

            var colEliminar = new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                HeaderText = "ACCIONES",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            colEliminar.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
            colEliminar.DefaultCellStyle.ForeColor = Color.FromArgb(185, 28, 28);
            colEliminar.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            colEliminar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 226);
            colEliminar.DefaultCellStyle.SelectionForeColor = Color.FromArgb(185, 28, 28);

            grid.Columns.Add(colConsultar);
            grid.Columns.Add(colEditar);
            grid.Columns.Add(colEliminar);

            grid.Columns["ClienteID"].FillWeight = 80;
            grid.Columns["NombreCompleto"].FillWeight = 190;
            grid.Columns["Telefono"].FillWeight = 110;
            grid.Columns["VehiculosAsociados"].FillWeight = 90;
            grid.Columns["Estado"].FillWeight = 85;
            grid.Columns["Consultar"].FillWeight = 85;
            grid.Columns["Editar"].FillWeight = 75;
            grid.Columns["Eliminar"].FillWeight = 85;

            grid.Columns["VehiculosAsociados"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.Columns["Estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
