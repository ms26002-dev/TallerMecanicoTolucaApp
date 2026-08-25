namespace TallerTolucaUI
{
    partial class FrmInventario
    {
        private System.ComponentModel.IContainer components = null;

        // UI Layout Controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.TabControl tabControlInventario;
        private System.Windows.Forms.TabPage tabRepuestos;
        private System.Windows.Forms.TabPage tabMovimientos;

        // Tab Repuestos Controls
        private System.Windows.Forms.Panel pnlTopRepuestos;
        private System.Windows.Forms.Button btnNuevoRepuesto;
        private System.Windows.Forms.Panel pnlFiltroRepuestos;
        private System.Windows.Forms.TextBox txtBuscarRepuesto;
        private System.Windows.Forms.ComboBox cboFiltroStock;
        private System.Windows.Forms.DataGridView dgvRepuestos;
        private System.Windows.Forms.Label lblConteoRepuestos;

        // Tab Movimientos Controls
        private System.Windows.Forms.Panel pnlTopMovimientos;
        private System.Windows.Forms.Button btnNuevoMovimiento;
        private System.Windows.Forms.Panel pnlFiltroMovimientos;
        private System.Windows.Forms.TextBox txtBuscarMovimiento;
        private System.Windows.Forms.ComboBox cboFiltroTipoMov;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.Label lblConteoMovimientos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            tabControlInventario = new TabControl();
            tabRepuestos = new TabPage();
            dgvRepuestos = new DataGridView();
            pnlFiltroRepuestos = new Panel();
            cboFiltroStock = new ComboBox();
            txtBuscarRepuesto = new TextBox();
            pnlTopRepuestos = new Panel();
            btnNuevoRepuesto = new Button();
            lblConteoRepuestos = new Label();
            tabMovimientos = new TabPage();
            dgvMovimientos = new DataGridView();
            pnlFiltroMovimientos = new Panel();
            cboFiltroTipoMov = new ComboBox();
            txtBuscarMovimiento = new TextBox();
            pnlTopMovimientos = new Panel();
            btnNuevoMovimiento = new Button();
            lblConteoMovimientos = new Label();
            pnlHeader.SuspendLayout();
            tabControlInventario.SuspendLayout();
            tabRepuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            pnlFiltroRepuestos.SuspendLayout();
            pnlTopRepuestos.SuspendLayout();
            tabMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            pnlFiltroMovimientos.SuspendLayout();
            pnlTopMovimientos.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1040, 75);
            pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F);
            lblSubtitulo.ForeColor = Color.FromArgb(92, 122, 144);
            lblSubtitulo.Location = new Point(22, 44);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(401, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Catálogo de repuestos y registro de entradas y salidas de almacén";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(10, 22, 40);
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(236, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Inventario";
            // 
            // tabControlInventario
            // 
            tabControlInventario.Controls.Add(tabRepuestos);
            tabControlInventario.Controls.Add(tabMovimientos);
            tabControlInventario.Dock = DockStyle.Fill;
            tabControlInventario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabControlInventario.Location = new Point(0, 75);
            tabControlInventario.Name = "tabControlInventario";
            tabControlInventario.SelectedIndex = 0;
            tabControlInventario.Size = new Size(1040, 585);
            tabControlInventario.TabIndex = 1;
            // 
            // tabRepuestos
            // 
            tabRepuestos.BackColor = Color.FromArgb(240, 248, 255);
            tabRepuestos.Controls.Add(dgvRepuestos);
            tabRepuestos.Controls.Add(pnlFiltroRepuestos);
            tabRepuestos.Controls.Add(pnlTopRepuestos);
            tabRepuestos.Controls.Add(lblConteoRepuestos);
            tabRepuestos.Location = new Point(4, 26);
            tabRepuestos.Name = "tabRepuestos";
            tabRepuestos.Padding = new Padding(15);
            tabRepuestos.Size = new Size(1032, 555);
            tabRepuestos.TabIndex = 0;
            tabRepuestos.Text = "  Catálogo de Repuestos  ";
            // 
            // dgvRepuestos
            // 
            dgvRepuestos.AllowUserToAddRows = false;
            dgvRepuestos.AllowUserToDeleteRows = false;
            dgvRepuestos.AllowUserToResizeRows = false;
            dgvRepuestos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRepuestos.BackgroundColor = Color.White;
            dgvRepuestos.BorderStyle = BorderStyle.None;
            dgvRepuestos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRepuestos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(240, 248, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(240, 248, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvRepuestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRepuestos.ColumnHeadersHeight = 40;
            dgvRepuestos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvRepuestos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRepuestos.Dock = DockStyle.Fill;
            dgvRepuestos.EnableHeadersVisualStyles = false;
            dgvRepuestos.GridColor = Color.FromArgb(232, 244, 252);
            dgvRepuestos.Location = new Point(15, 110);
            dgvRepuestos.MultiSelect = false;
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.ReadOnly = true;
            dgvRepuestos.RowHeadersVisible = false;
            dgvRepuestos.RowTemplate.Height = 42;
            dgvRepuestos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRepuestos.Size = new Size(1002, 409);
            dgvRepuestos.TabIndex = 2;
            dgvRepuestos.CellContentClick += dgvRepuestos_CellContentClick;
            // 
            // pnlFiltroRepuestos
            // 
            pnlFiltroRepuestos.Controls.Add(cboFiltroStock);
            pnlFiltroRepuestos.Controls.Add(txtBuscarRepuesto);
            pnlFiltroRepuestos.Dock = DockStyle.Top;
            pnlFiltroRepuestos.Location = new Point(15, 65);
            pnlFiltroRepuestos.Name = "pnlFiltroRepuestos";
            pnlFiltroRepuestos.Size = new Size(1002, 45);
            pnlFiltroRepuestos.TabIndex = 1;
            // 
            // cboFiltroStock
            // 
            cboFiltroStock.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroStock.FlatStyle = FlatStyle.Flat;
            cboFiltroStock.Font = new Font("Segoe UI", 9.5F);
            cboFiltroStock.FormattingEnabled = true;
            cboFiltroStock.Items.AddRange(new object[] { "Todos los stocks", "Disponible", "Bajo stock", "Sin stock" });
            cboFiltroStock.Location = new Point(435, 8);
            cboFiltroStock.Name = "cboFiltroStock";
            cboFiltroStock.Size = new Size(200, 25);
            cboFiltroStock.TabIndex = 1;
            cboFiltroStock.SelectedIndexChanged += cboFiltroStock_SelectedIndexChanged;
            // 
            // txtBuscarRepuesto
            // 
            txtBuscarRepuesto.BackColor = Color.White;
            txtBuscarRepuesto.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarRepuesto.Font = new Font("Segoe UI", 10F);
            txtBuscarRepuesto.ForeColor = Color.FromArgb(10, 22, 40);
            txtBuscarRepuesto.Location = new Point(0, 8);
            txtBuscarRepuesto.Name = "txtBuscarRepuesto";
            txtBuscarRepuesto.Size = new Size(420, 25);
            txtBuscarRepuesto.TabIndex = 0;
            txtBuscarRepuesto.Text = "🔍 Buscar por nombre o código...";
            txtBuscarRepuesto.TextChanged += txtBuscarRepuesto_TextChanged;
            txtBuscarRepuesto.Enter += txtBuscarRepuesto_Enter;
            txtBuscarRepuesto.Leave += txtBuscarRepuesto_Leave;
            // 
            // pnlTopRepuestos
            // 
            pnlTopRepuestos.Controls.Add(btnNuevoRepuesto);
            pnlTopRepuestos.Dock = DockStyle.Top;
            pnlTopRepuestos.Location = new Point(15, 15);
            pnlTopRepuestos.Name = "pnlTopRepuestos";
            pnlTopRepuestos.Size = new Size(1002, 50);
            pnlTopRepuestos.TabIndex = 0;
            // 
            // btnNuevoRepuesto
            // 
            btnNuevoRepuesto.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoRepuesto.BackColor = Color.FromArgb(2, 132, 199);
            btnNuevoRepuesto.Cursor = Cursors.Hand;
            btnNuevoRepuesto.FlatAppearance.BorderSize = 0;
            btnNuevoRepuesto.FlatStyle = FlatStyle.Flat;
            btnNuevoRepuesto.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNuevoRepuesto.ForeColor = Color.White;
            btnNuevoRepuesto.Location = new Point(822, 5);
            btnNuevoRepuesto.Name = "btnNuevoRepuesto";
            btnNuevoRepuesto.Size = new Size(175, 40);
            btnNuevoRepuesto.TabIndex = 0;
            btnNuevoRepuesto.Text = "+ Nuevo Repuesto";
            btnNuevoRepuesto.UseVisualStyleBackColor = false;
            btnNuevoRepuesto.Click += btnNuevoRepuesto_Click;
            // 
            // lblConteoRepuestos
            // 
            lblConteoRepuestos.Dock = DockStyle.Bottom;
            lblConteoRepuestos.Font = new Font("Segoe UI", 9F);
            lblConteoRepuestos.ForeColor = Color.FromArgb(92, 122, 144);
            lblConteoRepuestos.Location = new Point(15, 519);
            lblConteoRepuestos.Name = "lblConteoRepuestos";
            lblConteoRepuestos.Size = new Size(1002, 21);
            lblConteoRepuestos.TabIndex = 3;
            lblConteoRepuestos.Text = "Mostrando 0 registros";
            lblConteoRepuestos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabMovimientos
            // 
            tabMovimientos.BackColor = Color.FromArgb(240, 248, 255);
            tabMovimientos.Controls.Add(dgvMovimientos);
            tabMovimientos.Controls.Add(pnlFiltroMovimientos);
            tabMovimientos.Controls.Add(pnlTopMovimientos);
            tabMovimientos.Controls.Add(lblConteoMovimientos);
            tabMovimientos.Location = new Point(4, 26);
            tabMovimientos.Name = "tabMovimientos";
            tabMovimientos.Padding = new Padding(15);
            tabMovimientos.Size = new Size(1032, 555);
            tabMovimientos.TabIndex = 1;
            tabMovimientos.Text = "  Entradas y Salidas de Inventario  ";
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AllowUserToResizeRows = false;
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = Color.White;
            dgvMovimientos.BorderStyle = BorderStyle.None;
            dgvMovimientos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMovimientos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(240, 248, 255);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(240, 248, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMovimientos.ColumnHeadersHeight = 40;
            dgvMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(224, 245, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle4;
            dgvMovimientos.Dock = DockStyle.Fill;
            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.GridColor = Color.FromArgb(232, 244, 252);
            dgvMovimientos.Location = new Point(15, 110);
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.RowTemplate.Height = 42;
            dgvMovimientos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new Size(1002, 409);
            dgvMovimientos.TabIndex = 2;
            dgvMovimientos.CellContentClick += dgvMovimientos_CellContentClick;
            // 
            // pnlFiltroMovimientos
            // 
            pnlFiltroMovimientos.Controls.Add(cboFiltroTipoMov);
            pnlFiltroMovimientos.Controls.Add(txtBuscarMovimiento);
            pnlFiltroMovimientos.Dock = DockStyle.Top;
            pnlFiltroMovimientos.Location = new Point(15, 65);
            pnlFiltroMovimientos.Name = "pnlFiltroMovimientos";
            pnlFiltroMovimientos.Size = new Size(1002, 45);
            pnlFiltroMovimientos.TabIndex = 1;
            // 
            // cboFiltroTipoMov
            // 
            cboFiltroTipoMov.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroTipoMov.FlatStyle = FlatStyle.Flat;
            cboFiltroTipoMov.Font = new Font("Segoe UI", 9.5F);
            cboFiltroTipoMov.FormattingEnabled = true;
            cboFiltroTipoMov.Items.AddRange(new object[] { "Tipo de movimiento", "Entrada", "Salida" });
            cboFiltroTipoMov.Location = new Point(435, 8);
            cboFiltroTipoMov.Name = "cboFiltroTipoMov";
            cboFiltroTipoMov.Size = new Size(200, 25);
            cboFiltroTipoMov.TabIndex = 1;
            cboFiltroTipoMov.SelectedIndexChanged += cboFiltroTipoMov_SelectedIndexChanged;
            // 
            // txtBuscarMovimiento
            // 
            txtBuscarMovimiento.BackColor = Color.White;
            txtBuscarMovimiento.BorderStyle = BorderStyle.FixedSingle;
            txtBuscarMovimiento.Font = new Font("Segoe UI", 10F);
            txtBuscarMovimiento.ForeColor = Color.FromArgb(10, 22, 40);
            txtBuscarMovimiento.Location = new Point(0, 8);
            txtBuscarMovimiento.Name = "txtBuscarMovimiento";
            txtBuscarMovimiento.Size = new Size(420, 25);
            txtBuscarMovimiento.TabIndex = 0;
            txtBuscarMovimiento.Text = "🔍 Buscar por repuesto o motivo...";
            txtBuscarMovimiento.TextChanged += txtBuscarMovimiento_TextChanged;
            txtBuscarMovimiento.Enter += txtBuscarMovimiento_Enter;
            txtBuscarMovimiento.Leave += txtBuscarMovimiento_Leave;
            // 
            // pnlTopMovimientos
            // 
            pnlTopMovimientos.Controls.Add(btnNuevoMovimiento);
            pnlTopMovimientos.Dock = DockStyle.Top;
            pnlTopMovimientos.Location = new Point(15, 15);
            pnlTopMovimientos.Name = "pnlTopMovimientos";
            pnlTopMovimientos.Size = new Size(1002, 50);
            pnlTopMovimientos.TabIndex = 0;
            // 
            // btnNuevoMovimiento
            // 
            btnNuevoMovimiento.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNuevoMovimiento.BackColor = Color.FromArgb(0, 191, 255);
            btnNuevoMovimiento.Cursor = Cursors.Hand;
            btnNuevoMovimiento.FlatAppearance.BorderSize = 0;
            btnNuevoMovimiento.FlatStyle = FlatStyle.Flat;
            btnNuevoMovimiento.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNuevoMovimiento.ForeColor = Color.White;
            btnNuevoMovimiento.Location = new Point(802, 5);
            btnNuevoMovimiento.Name = "btnNuevoMovimiento";
            btnNuevoMovimiento.Size = new Size(195, 40);
            btnNuevoMovimiento.TabIndex = 0;
            btnNuevoMovimiento.Text = "+ Registrar Movimiento";
            btnNuevoMovimiento.UseVisualStyleBackColor = false;
            btnNuevoMovimiento.Click += btnNuevoMovimiento_Click;
            // 
            // lblConteoMovimientos
            // 
            lblConteoMovimientos.Dock = DockStyle.Bottom;
            lblConteoMovimientos.Font = new Font("Segoe UI", 9F);
            lblConteoMovimientos.ForeColor = Color.FromArgb(92, 122, 144);
            lblConteoMovimientos.Location = new Point(15, 519);
            lblConteoMovimientos.Name = "lblConteoMovimientos";
            lblConteoMovimientos.Size = new Size(1002, 21);
            lblConteoMovimientos.TabIndex = 3;
            lblConteoMovimientos.Text = "Mostrando 0 registros";
            lblConteoMovimientos.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // FrmInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 248, 255);
            ClientSize = new Size(1040, 660);
            Controls.Add(tabControlInventario);
            Controls.Add(pnlHeader);
            Name = "FrmInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Inventario - Taller Radiador Springs";
            Load += FrmInventario_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tabControlInventario.ResumeLayout(false);
            tabRepuestos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            pnlFiltroRepuestos.ResumeLayout(false);
            pnlFiltroRepuestos.PerformLayout();
            pnlTopRepuestos.ResumeLayout(false);
            tabMovimientos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            pnlFiltroMovimientos.ResumeLayout(false);
            pnlFiltroMovimientos.PerformLayout();
            pnlTopMovimientos.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
