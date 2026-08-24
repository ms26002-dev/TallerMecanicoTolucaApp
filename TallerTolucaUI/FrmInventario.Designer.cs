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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();

            pnlHeader = new System.Windows.Forms.Panel();
            lblTitulo = new System.Windows.Forms.Label();
            lblSubtitulo = new System.Windows.Forms.Label();
            tabControlInventario = new System.Windows.Forms.TabControl();
            tabRepuestos = new System.Windows.Forms.TabPage();
            pnlTopRepuestos = new System.Windows.Forms.Panel();
            btnNuevoRepuesto = new System.Windows.Forms.Button();
            pnlFiltroRepuestos = new System.Windows.Forms.Panel();
            txtBuscarRepuesto = new System.Windows.Forms.TextBox();
            cboFiltroStock = new System.Windows.Forms.ComboBox();
            dgvRepuestos = new System.Windows.Forms.DataGridView();
            lblConteoRepuestos = new System.Windows.Forms.Label();

            tabMovimientos = new System.Windows.Forms.TabPage();
            pnlTopMovimientos = new System.Windows.Forms.Panel();
            btnNuevoMovimiento = new System.Windows.Forms.Button();
            pnlFiltroMovimientos = new System.Windows.Forms.Panel();
            txtBuscarMovimiento = new System.Windows.Forms.TextBox();
            cboFiltroTipoMov = new System.Windows.Forms.ComboBox();
            dgvMovimientos = new System.Windows.Forms.DataGridView();
            lblConteoMovimientos = new System.Windows.Forms.Label();

            pnlHeader.SuspendLayout();
            tabControlInventario.SuspendLayout();
            tabRepuestos.SuspendLayout();
            pnlTopRepuestos.SuspendLayout();
            pnlFiltroRepuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).BeginInit();
            tabMovimientos.SuspendLayout();
            pnlTopMovimientos.SuspendLayout();
            pnlFiltroMovimientos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();

            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.White;
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1040, 75);
            pnlHeader.TabIndex = 0;

            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            lblTitulo.ForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            lblTitulo.Location = new System.Drawing.Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new System.Drawing.Size(325, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Inventario";

            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(92, 122, 144);
            lblSubtitulo.Location = new System.Drawing.Point(22, 44);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new System.Drawing.Size(430, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Catálogo de repuestos y registro de entradas y salidas de almacén";

            // 
            // tabControlInventario
            // 
            tabControlInventario.Controls.Add(tabRepuestos);
            tabControlInventario.Controls.Add(tabMovimientos);
            tabControlInventario.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControlInventario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            tabControlInventario.Location = new System.Drawing.Point(0, 75);
            tabControlInventario.Name = "tabControlInventario";
            tabControlInventario.SelectedIndex = 0;
            tabControlInventario.Size = new System.Drawing.Size(1040, 585);
            tabControlInventario.TabIndex = 1;

            // 
            // tabRepuestos
            // 
            tabRepuestos.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            tabRepuestos.Controls.Add(dgvRepuestos);
            tabRepuestos.Controls.Add(pnlFiltroRepuestos);
            tabRepuestos.Controls.Add(pnlTopRepuestos);
            tabRepuestos.Controls.Add(lblConteoRepuestos);
            tabRepuestos.Location = new System.Drawing.Point(4, 30);
            tabRepuestos.Name = "tabRepuestos";
            tabRepuestos.Padding = new System.Windows.Forms.Padding(15);
            tabRepuestos.Size = new System.Drawing.Size(1032, 551);
            tabRepuestos.TabIndex = 0;
            tabRepuestos.Text = "  Catálogo de Repuestos  ";

            // 
            // pnlTopRepuestos
            // 
            pnlTopRepuestos.Controls.Add(btnNuevoRepuesto);
            pnlTopRepuestos.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTopRepuestos.Location = new System.Drawing.Point(15, 15);
            pnlTopRepuestos.Name = "pnlTopRepuestos";
            pnlTopRepuestos.Size = new System.Drawing.Size(1002, 50);
            pnlTopRepuestos.TabIndex = 0;

            // 
            // btnNuevoRepuesto
            // 
            btnNuevoRepuesto.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNuevoRepuesto.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnNuevoRepuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNuevoRepuesto.FlatAppearance.BorderSize = 0;
            btnNuevoRepuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNuevoRepuesto.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnNuevoRepuesto.ForeColor = System.Drawing.Color.White;
            btnNuevoRepuesto.Location = new System.Drawing.Point(822, 5);
            btnNuevoRepuesto.Name = "btnNuevoRepuesto";
            btnNuevoRepuesto.Size = new System.Drawing.Size(175, 40);
            btnNuevoRepuesto.TabIndex = 0;
            btnNuevoRepuesto.Text = "+ Nuevo Repuesto";
            btnNuevoRepuesto.UseVisualStyleBackColor = false;
            btnNuevoRepuesto.Click += btnNuevoRepuesto_Click;

            // 
            // pnlFiltroRepuestos
            // 
            pnlFiltroRepuestos.Controls.Add(cboFiltroStock);
            pnlFiltroRepuestos.Controls.Add(txtBuscarRepuesto);
            pnlFiltroRepuestos.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFiltroRepuestos.Location = new System.Drawing.Point(15, 65);
            pnlFiltroRepuestos.Name = "pnlFiltroRepuestos";
            pnlFiltroRepuestos.Size = new System.Drawing.Size(1002, 45);
            pnlFiltroRepuestos.TabIndex = 1;

            // 
            // txtBuscarRepuesto
            // 
            txtBuscarRepuesto.BackColor = System.Drawing.Color.White;
            txtBuscarRepuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscarRepuesto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtBuscarRepuesto.ForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            txtBuscarRepuesto.Location = new System.Drawing.Point(0, 8);
            txtBuscarRepuesto.Name = "txtBuscarRepuesto";
            txtBuscarRepuesto.Size = new System.Drawing.Size(420, 25);
            txtBuscarRepuesto.TabIndex = 0;
            txtBuscarRepuesto.Text = "🔍 Buscar por nombre o código...";
            txtBuscarRepuesto.Enter += txtBuscarRepuesto_Enter;
            txtBuscarRepuesto.Leave += txtBuscarRepuesto_Leave;
            txtBuscarRepuesto.TextChanged += txtBuscarRepuesto_TextChanged;

            // 
            // cboFiltroStock
            // 
            cboFiltroStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFiltroStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboFiltroStock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFiltroStock.FormattingEnabled = true;
            cboFiltroStock.Items.AddRange(new object[] { "Todos los stocks", "Disponible", "Bajo stock", "Sin stock" });
            cboFiltroStock.Location = new System.Drawing.Point(435, 8);
            cboFiltroStock.Name = "cboFiltroStock";
            cboFiltroStock.Size = new System.Drawing.Size(200, 25);
            cboFiltroStock.TabIndex = 1;
            cboFiltroStock.SelectedIndexChanged += cboFiltroStock_SelectedIndexChanged;

            // 
            // dgvRepuestos
            // 
            dgvRepuestos.AllowUserToAddRows = false;
            dgvRepuestos.AllowUserToDeleteRows = false;
            dgvRepuestos.AllowUserToResizeRows = false;
            dgvRepuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvRepuestos.BackgroundColor = System.Drawing.Color.White;
            dgvRepuestos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvRepuestos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRepuestos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvRepuestos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvRepuestos.ColumnHeadersHeight = 40;
            dgvRepuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(224, 245, 255);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvRepuestos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvRepuestos.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvRepuestos.EnableHeadersVisualStyles = false;
            dgvRepuestos.GridColor = System.Drawing.Color.FromArgb(232, 244, 252);
            dgvRepuestos.Location = new System.Drawing.Point(15, 110);
            dgvRepuestos.MultiSelect = false;
            dgvRepuestos.Name = "dgvRepuestos";
            dgvRepuestos.ReadOnly = true;
            dgvRepuestos.RowHeadersVisible = false;
            dgvRepuestos.RowTemplate.Height = 42;
            dgvRepuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvRepuestos.Size = new System.Drawing.Size(1002, 405);
            dgvRepuestos.TabIndex = 2;
            dgvRepuestos.CellContentClick += dgvRepuestos_CellContentClick;

            // 
            // lblConteoRepuestos
            // 
            lblConteoRepuestos.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblConteoRepuestos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblConteoRepuestos.ForeColor = System.Drawing.Color.FromArgb(92, 122, 144);
            lblConteoRepuestos.Location = new System.Drawing.Point(15, 515);
            lblConteoRepuestos.Name = "lblConteoRepuestos";
            lblConteoRepuestos.Size = new System.Drawing.Size(1002, 21);
            lblConteoRepuestos.TabIndex = 3;
            lblConteoRepuestos.Text = "Mostrando 0 registros";
            lblConteoRepuestos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // tabMovimientos
            // 
            tabMovimientos.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            tabMovimientos.Controls.Add(dgvMovimientos);
            tabMovimientos.Controls.Add(pnlFiltroMovimientos);
            tabMovimientos.Controls.Add(pnlTopMovimientos);
            tabMovimientos.Controls.Add(lblConteoMovimientos);
            tabMovimientos.Location = new System.Drawing.Point(4, 30);
            tabMovimientos.Name = "tabMovimientos";
            tabMovimientos.Padding = new System.Windows.Forms.Padding(15);
            tabMovimientos.Size = new System.Drawing.Size(1032, 551);
            tabMovimientos.TabIndex = 1;
            tabMovimientos.Text = "  Entradas y Salidas de Inventario  ";

            // 
            // pnlTopMovimientos
            // 
            pnlTopMovimientos.Controls.Add(btnNuevoMovimiento);
            pnlTopMovimientos.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTopMovimientos.Location = new System.Drawing.Point(15, 15);
            pnlTopMovimientos.Name = "pnlTopMovimientos";
            pnlTopMovimientos.Size = new System.Drawing.Size(1002, 50);
            pnlTopMovimientos.TabIndex = 0;

            // 
            // btnNuevoMovimiento
            // 
            btnNuevoMovimiento.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNuevoMovimiento.BackColor = System.Drawing.Color.FromArgb(0, 191, 255);
            btnNuevoMovimiento.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNuevoMovimiento.FlatAppearance.BorderSize = 0;
            btnNuevoMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNuevoMovimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnNuevoMovimiento.ForeColor = System.Drawing.Color.White;
            btnNuevoMovimiento.Location = new System.Drawing.Point(802, 5);
            btnNuevoMovimiento.Name = "btnNuevoMovimiento";
            btnNuevoMovimiento.Size = new System.Drawing.Size(195, 40);
            btnNuevoMovimiento.TabIndex = 0;
            btnNuevoMovimiento.Text = "+ Registrar Movimiento";
            btnNuevoMovimiento.UseVisualStyleBackColor = false;
            btnNuevoMovimiento.Click += btnNuevoMovimiento_Click;

            // 
            // pnlFiltroMovimientos
            // 
            pnlFiltroMovimientos.Controls.Add(cboFiltroTipoMov);
            pnlFiltroMovimientos.Controls.Add(txtBuscarMovimiento);
            pnlFiltroMovimientos.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFiltroMovimientos.Location = new System.Drawing.Point(15, 65);
            pnlFiltroMovimientos.Name = "pnlFiltroMovimientos";
            pnlFiltroMovimientos.Size = new System.Drawing.Size(1002, 45);
            pnlFiltroMovimientos.TabIndex = 1;

            // 
            // txtBuscarMovimiento
            // 
            txtBuscarMovimiento.BackColor = System.Drawing.Color.White;
            txtBuscarMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtBuscarMovimiento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtBuscarMovimiento.ForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            txtBuscarMovimiento.Location = new System.Drawing.Point(0, 8);
            txtBuscarMovimiento.Name = "txtBuscarMovimiento";
            txtBuscarMovimiento.Size = new System.Drawing.Size(420, 25);
            txtBuscarMovimiento.TabIndex = 0;
            txtBuscarMovimiento.Text = "🔍 Buscar por repuesto o motivo...";
            txtBuscarMovimiento.Enter += txtBuscarMovimiento_Enter;
            txtBuscarMovimiento.Leave += txtBuscarMovimiento_Leave;
            txtBuscarMovimiento.TextChanged += txtBuscarMovimiento_TextChanged;

            // 
            // cboFiltroTipoMov
            // 
            cboFiltroTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboFiltroTipoMov.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboFiltroTipoMov.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            cboFiltroTipoMov.FormattingEnabled = true;
            cboFiltroTipoMov.Items.AddRange(new object[] { "Tipo de movimiento", "Entrada", "Salida" });
            cboFiltroTipoMov.Location = new System.Drawing.Point(435, 8);
            cboFiltroTipoMov.Name = "cboFiltroTipoMov";
            cboFiltroTipoMov.Size = new System.Drawing.Size(200, 25);
            cboFiltroTipoMov.TabIndex = 1;
            cboFiltroTipoMov.SelectedIndexChanged += cboFiltroTipoMov_SelectedIndexChanged;

            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AllowUserToAddRows = false;
            dgvMovimientos.AllowUserToDeleteRows = false;
            dgvMovimientos.AllowUserToResizeRows = false;
            dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.BackgroundColor = System.Drawing.Color.White;
            dgvMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvMovimientos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMovimientos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvMovimientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvMovimientos.ColumnHeadersHeight = 40;
            dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(224, 245, 255);
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(10, 22, 40);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvMovimientos.DefaultCellStyle = dataGridViewCellStyle4;
            dgvMovimientos.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvMovimientos.EnableHeadersVisualStyles = false;
            dgvMovimientos.GridColor = System.Drawing.Color.FromArgb(232, 244, 252);
            dgvMovimientos.Location = new System.Drawing.Point(15, 110);
            dgvMovimientos.MultiSelect = false;
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.ReadOnly = true;
            dgvMovimientos.RowHeadersVisible = false;
            dgvMovimientos.RowTemplate.Height = 42;
            dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvMovimientos.Size = new System.Drawing.Size(1002, 405);
            dgvMovimientos.TabIndex = 2;
            dgvMovimientos.CellContentClick += dgvMovimientos_CellContentClick;

            // 
            // lblConteoMovimientos
            // 
            lblConteoMovimientos.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblConteoMovimientos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblConteoMovimientos.ForeColor = System.Drawing.Color.FromArgb(92, 122, 144);
            lblConteoMovimientos.Location = new System.Drawing.Point(15, 515);
            lblConteoMovimientos.Name = "lblConteoMovimientos";
            lblConteoMovimientos.Size = new System.Drawing.Size(1002, 21);
            lblConteoMovimientos.TabIndex = 3;
            lblConteoMovimientos.Text = "Mostrando 0 registros";
            lblConteoMovimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // FrmInventario
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            ClientSize = new System.Drawing.Size(1040, 660);
            Controls.Add(tabControlInventario);
            Controls.Add(pnlHeader);
            Name = "FrmInventario";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Gestión de Inventario - Taller Radiador Springs";
            Load += FrmInventario_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tabControlInventario.ResumeLayout(false);
            tabRepuestos.ResumeLayout(false);
            pnlTopRepuestos.ResumeLayout(false);
            pnlFiltroRepuestos.ResumeLayout(false);
            pnlFiltroRepuestos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRepuestos).EndInit();
            tabMovimientos.ResumeLayout(false);
            pnlTopMovimientos.ResumeLayout(false);
            pnlFiltroMovimientos.ResumeLayout(false);
            pnlFiltroMovimientos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
        }
    }
}
