using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmInventario : Form
    {
        private readonly InventarioBL _inventarioBL = new InventarioBL();
        private List<RepuestoEN> _listaRepuestos = new List<RepuestoEN>();
        private List<MovimientoInventarioEN> _listaMovimientos = new List<MovimientoInventarioEN>();

        private const string PLACEHOLDER_BUSCAR_REP = "🔍 Buscar por nombre o código...";
        private const string PLACEHOLDER_BUSCAR_MOV = "🔍 Buscar por repuesto o motivo...";

        public FrmInventario()
        {
            InitializeComponent();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasGrids();
            cboFiltroStock.SelectedIndex = 0;
            cboFiltroTipoMov.SelectedIndex = 0;
            CargarDatos();
        }

        private void ConfigurarColumnasGrids()
        {
            // ---------------- DataGridView Repuestos ----------------
            dgvRepuestos.Columns.Clear();
            dgvRepuestos.AutoGenerateColumns = false;

            dgvRepuestos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RepuestoID",
                DataPropertyName = "RepuestoID",
                Visible = false
            });

            dgvRepuestos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Codigo",
                HeaderText = "Código",
                DataPropertyName = "Codigo",
                FillWeight = 85
            });

            dgvRepuestos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreRepuesto",
                HeaderText = "Nombre del Repuesto",
                DataPropertyName = "NombreRepuesto",
                FillWeight = 200
            });

            dgvRepuestos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                DataPropertyName = "PrecioUnitario",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "$0.00" },
                FillWeight = 90
            });

            dgvRepuestos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Existencia",
                HeaderText = "Existencia",
                DataPropertyName = "Existencia",
                FillWeight = 80
            });

            dgvRepuestos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EstadoStock",
                HeaderText = "Estado Stock",
                FillWeight = 110
            });

            // Action Buttons in standard order: Consultar, Editar, Eliminar
            DataGridViewButtonColumn btnConsultarRep = new DataGridViewButtonColumn
            {
                Name = "btnConsultar",
                HeaderText = "Acción",
                Text = "Consultar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                FillWeight = 85
            };
            btnConsultarRep.DefaultCellStyle.BackColor = Color.FromArgb(224, 245, 255);
            btnConsultarRep.DefaultCellStyle.ForeColor = Color.FromArgb(0, 153, 204);
            btnConsultarRep.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 245, 255);
            btnConsultarRep.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 153, 204);
            dgvRepuestos.Columns.Add(btnConsultarRep);

            DataGridViewButtonColumn btnEditarRep = new DataGridViewButtonColumn
            {
                Name = "btnEditar",
                HeaderText = "",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                FillWeight = 75
            };
            btnEditarRep.DefaultCellStyle.BackColor = Color.FromArgb(254, 243, 199);
            btnEditarRep.DefaultCellStyle.ForeColor = Color.FromArgb(180, 83, 9);
            btnEditarRep.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 243, 199);
            btnEditarRep.DefaultCellStyle.SelectionForeColor = Color.FromArgb(180, 83, 9);
            dgvRepuestos.Columns.Add(btnEditarRep);

            DataGridViewButtonColumn btnEliminarRep = new DataGridViewButtonColumn
            {
                Name = "btnEliminar",
                HeaderText = "",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                FillWeight = 75
            };
            btnEliminarRep.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
            btnEliminarRep.DefaultCellStyle.ForeColor = Color.FromArgb(220, 38, 38);
            btnEliminarRep.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 226);
            btnEliminarRep.DefaultCellStyle.SelectionForeColor = Color.FromArgb(220, 38, 38);
            dgvRepuestos.Columns.Add(btnEliminarRep);


            // ---------------- DataGridView Movimientos ----------------
            dgvMovimientos.Columns.Clear();
            dgvMovimientos.AutoGenerateColumns = false;

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "MovimientoID",
                HeaderText = "MovID",
                DataPropertyName = "MovimientoID",
                FillWeight = 70
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                HeaderText = "Fecha",
                DataPropertyName = "Fecha",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" },
                FillWeight = 110
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreRepuesto",
                HeaderText = "Repuesto",
                DataPropertyName = "NombreRepuesto",
                FillWeight = 190
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TipoMovimiento",
                HeaderText = "Tipo",
                DataPropertyName = "TipoMovimiento",
                FillWeight = 85
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                FillWeight = 75
            });

            dgvMovimientos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Motivo",
                HeaderText = "N° Orden Ref. / Motivo",
                DataPropertyName = "Motivo",
                FillWeight = 170
            });

            DataGridViewButtonColumn btnConsultarMov = new DataGridViewButtonColumn
            {
                Name = "btnConsultarMov",
                HeaderText = "Acción",
                Text = "Consultar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                FillWeight = 85
            };
            btnConsultarMov.DefaultCellStyle.BackColor = Color.FromArgb(224, 245, 255);
            btnConsultarMov.DefaultCellStyle.ForeColor = Color.FromArgb(0, 153, 204);
            btnConsultarMov.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 245, 255);
            btnConsultarMov.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 153, 204);
            dgvMovimientos.Columns.Add(btnConsultarMov);

            DataGridViewButtonColumn btnEliminarMov = new DataGridViewButtonColumn
            {
                Name = "btnEliminarMov",
                HeaderText = "",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                FillWeight = 75
            };
            btnEliminarMov.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226);
            btnEliminarMov.DefaultCellStyle.ForeColor = Color.FromArgb(220, 38, 38);
            btnEliminarMov.DefaultCellStyle.SelectionBackColor = Color.FromArgb(254, 226, 226);
            btnEliminarMov.DefaultCellStyle.SelectionForeColor = Color.FromArgb(220, 38, 38);
            dgvMovimientos.Columns.Add(btnEliminarMov);
        }

        private void CargarDatos()
        {
            try
            {
                _listaRepuestos = _inventarioBL.ObtenerRepuestos();
                _listaMovimientos = _inventarioBL.ObtenerMovimientos();

                FiltrarRepuestos();
                FiltrarMovimientos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de inventario: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarRepuestos()
        {
            string texto = txtBuscarRepuesto.Text.Trim();
            if (texto == PLACEHOLDER_BUSCAR_REP) texto = "";

            var query = _listaRepuestos.AsEnumerable();

            if (!string.IsNullOrEmpty(texto))
            {
                query = query.Where(r => (r.Codigo != null && r.Codigo.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                         (r.NombreRepuesto != null && r.NombreRepuesto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            string filtroStock = cboFiltroStock.SelectedItem?.ToString() ?? "";
            if (filtroStock == "Disponible")
                query = query.Where(r => r.Existencia > 5);
            else if (filtroStock == "Bajo stock")
                query = query.Where(r => r.Existencia > 0 && r.Existencia <= 5);
            else if (filtroStock == "Sin stock")
                query = query.Where(r => r.Existencia == 0);

            var resultado = query.ToList();
            dgvRepuestos.DataSource = resultado;

            // Formatear Estado Stock badge cell
            for (int i = 0; i < resultado.Count; i++)
            {
                var r = resultado[i];
                string estado = r.Existencia > 5 ? "Disponible" : (r.Existencia > 0 ? "Bajo stock" : "Sin stock");
                dgvRepuestos.Rows[i].Cells["EstadoStock"].Value = estado;
                if (estado == "Disponible")
                {
                    dgvRepuestos.Rows[i].Cells["EstadoStock"].Style.ForeColor = Color.FromArgb(0, 168, 120);
                    dgvRepuestos.Rows[i].Cells["EstadoStock"].Style.SelectionForeColor = Color.FromArgb(0, 168, 120);
                }
                else if (estado == "Bajo stock")
                {
                    dgvRepuestos.Rows[i].Cells["EstadoStock"].Style.ForeColor = Color.FromArgb(244, 162, 97);
                    dgvRepuestos.Rows[i].Cells["EstadoStock"].Style.SelectionForeColor = Color.FromArgb(244, 162, 97);
                }
                else
                {
                    dgvRepuestos.Rows[i].Cells["EstadoStock"].Style.ForeColor = Color.FromArgb(230, 57, 70);
                    dgvRepuestos.Rows[i].Cells["EstadoStock"].Style.SelectionForeColor = Color.FromArgb(230, 57, 70);
                }
            }

            lblConteoRepuestos.Text = $"Mostrando 1-{resultado.Count} de {resultado.Count} repuestos registrados";
        }

        private void FiltrarMovimientos()
        {
            string texto = txtBuscarMovimiento.Text.Trim();
            if (texto == PLACEHOLDER_BUSCAR_MOV) texto = "";

            var query = _listaMovimientos.AsEnumerable();

            if (!string.IsNullOrEmpty(texto))
            {
                query = query.Where(m => (m.NombreRepuesto != null && m.NombreRepuesto.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                         (m.Motivo != null && m.Motivo.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            string tipoMov = cboFiltroTipoMov.SelectedItem?.ToString() ?? "";
            if (tipoMov == "Entrada" || tipoMov == "Salida")
            {
                query = query.Where(m => m.TipoMovimiento == tipoMov);
            }

            var resultado = query.ToList();
            dgvMovimientos.DataSource = resultado;

            lblConteoMovimientos.Text = $"Mostrando 1-{resultado.Count} de {resultado.Count} movimientos registrados";
        }

        // Placeholders logic
        private void txtBuscarRepuesto_Enter(object sender, EventArgs e)
        {
            if (txtBuscarRepuesto.Text == PLACEHOLDER_BUSCAR_REP)
            {
                txtBuscarRepuesto.Text = "";
                txtBuscarRepuesto.ForeColor = Color.FromArgb(10, 22, 40);
            }
        }

        private void txtBuscarRepuesto_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarRepuesto.Text))
            {
                txtBuscarRepuesto.Text = PLACEHOLDER_BUSCAR_REP;
                txtBuscarRepuesto.ForeColor = Color.Gray;
            }
        }

        private void txtBuscarRepuesto_TextChanged(object sender, EventArgs e)
        {
            FiltrarRepuestos();
        }

        private void cboFiltroStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarRepuestos();
        }

        private void txtBuscarMovimiento_Enter(object sender, EventArgs e)
        {
            if (txtBuscarMovimiento.Text == PLACEHOLDER_BUSCAR_MOV)
            {
                txtBuscarMovimiento.Text = "";
                txtBuscarMovimiento.ForeColor = Color.FromArgb(10, 22, 40);
            }
        }

        private void txtBuscarMovimiento_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarMovimiento.Text))
            {
                txtBuscarMovimiento.Text = PLACEHOLDER_BUSCAR_MOV;
                txtBuscarMovimiento.ForeColor = Color.Gray;
            }
        }

        private void txtBuscarMovimiento_TextChanged(object sender, EventArgs e)
        {
            FiltrarMovimientos();
        }

        private void cboFiltroTipoMov_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarMovimientos();
        }

        // ---------------- BOTONES PRINCIPALES ----------------
        private void btnNuevoRepuesto_Click(object sender, EventArgs e)
        {
            MostrarDialogoRepuesto(null);
        }

        private void btnNuevoMovimiento_Click(object sender, EventArgs e)
        {
            MostrarDialogoMovimiento();
        }

        // ---------------- ACCIONES EN FILAS DE REPUESTOS ----------------
        private void dgvRepuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvRepuestos.Columns[e.ColumnIndex].Name;
            var repuesto = dgvRepuestos.Rows[e.RowIndex].DataBoundItem as RepuestoEN;
            if (repuesto == null) return;

            if (colName == "btnConsultar")
            {
                MostrarDetalleRepuesto(repuesto);
            }
            else if (colName == "btnEditar")
            {
                MostrarDialogoRepuesto(repuesto);
            }
            else if (colName == "btnEliminar")
            {
                if (MessageBox.Show($"¿Está seguro de eliminar el repuesto '{repuesto.NombreRepuesto}' ({repuesto.Codigo})?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _inventarioBL.EliminarRepuesto(repuesto.RepuestoID);
                        MessageBox.Show("Repuesto eliminado correctamente.", "Taller Radiador Springs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo eliminar el repuesto: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        // ---------------- ACCIONES EN FILAS DE MOVIMIENTOS ----------------
        private void dgvMovimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvMovimientos.Columns[e.ColumnIndex].Name;
            var mov = dgvMovimientos.Rows[e.RowIndex].DataBoundItem as MovimientoInventarioEN;
            if (mov == null) return;

            if (colName == "btnConsultarMov")
            {
                MostrarDetalleMovimiento(mov);
            }
            else if (colName == "btnEliminarMov")
            {
                if (MessageBox.Show($"¿Está seguro de eliminar el movimiento ID #{mov.MovimientoID}?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _inventarioBL.EliminarMovimiento(mov.MovimientoID);
                        MessageBox.Show("Movimiento eliminado correctamente.", "Taller Radiador Springs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo eliminar el movimiento: " + ex.Message, "Error de Eliminación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        // ---------------- DIÁLOGOS Y MODALES COMPONENTES ----------------
        private void MostrarDialogoRepuesto(RepuestoEN repuestoExistente)
        {
            bool esEdicion = repuestoExistente != null;
            using (Form modal = new Form())
            {
                modal.Text = esEdicion ? "Editar Repuesto" : "Nuevo Repuesto";
                modal.Size = new Size(460, 360);
                modal.StartPosition = FormStartPosition.CenterParent;
                modal.FormBorderStyle = FormBorderStyle.FixedDialog;
                modal.MaximizeBox = false;
                modal.MinimizeBox = false;
                modal.BackColor = Color.FromArgb(240, 248, 255);

                Label lblCode = new Label { Text = "Código del Repuesto:", Location = new Point(25, 20), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                TextBox txtCode = new TextBox { Location = new Point(25, 42), Size = new Size(390, 26), Font = new Font("Segoe UI", 10F), Text = esEdicion ? repuestoExistente.Codigo : $"REP-{Guid.NewGuid().ToString().Substring(0, 4).ToUpper()}" };

                Label lblName = new Label { Text = "Nombre del Repuesto:", Location = new Point(25, 80), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                TextBox txtName = new TextBox { Location = new Point(25, 102), Size = new Size(390, 26), Font = new Font("Segoe UI", 10F), Text = esEdicion ? repuestoExistente.NombreRepuesto : "" };

                Label lblPrecio = new Label { Text = "Precio Unitario ($):", Location = new Point(25, 140), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                TextBox txtPrecio = new TextBox { Location = new Point(25, 162), Size = new Size(185, 26), Font = new Font("Segoe UI", 10F), Text = esEdicion ? repuestoExistente.PrecioUnitario.ToString("0.00") : "0.00" };

                Label lblStock = new Label { Text = "Existencia Actual / Stock:", Location = new Point(230, 140), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                TextBox txtStock = new TextBox { Location = new Point(230, 162), Size = new Size(185, 26), Font = new Font("Segoe UI", 10F), Text = esEdicion ? repuestoExistente.Existencia.ToString() : "0" };

                Button btnGuardar = new Button
                {
                    Text = esEdicion ? "Actualizar Repuesto" : "Guardar Repuesto",
                    Location = new Point(230, 235),
                    Size = new Size(185, 40),
                    BackColor = Color.FromArgb(0, 191, 255),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnGuardar.FlatAppearance.BorderSize = 0;

                Button btnCancelar = new Button
                {
                    Text = "Cancelar",
                    Location = new Point(25, 235),
                    Size = new Size(185, 40),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(10, 22, 40),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(192, 216, 236);

                btnGuardar.Click += (s, ev) =>
                {
                    try
                    {
                        if (string.IsNullOrWhiteSpace(txtCode.Text) || string.IsNullOrWhiteSpace(txtName.Text))
                        {
                            MessageBox.Show("El código y el nombre del repuesto son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
                        {
                            MessageBox.Show("Ingrese un precio unitario válido mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
                        {
                            MessageBox.Show("Ingrese una cantidad de existencia válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        RepuestoEN rep = esEdicion ? repuestoExistente : new RepuestoEN();
                        rep.Codigo = txtCode.Text.Trim();
                        rep.NombreRepuesto = txtName.Text.Trim();
                        rep.PrecioUnitario = precio;
                        rep.Existencia = stock;

                        if (esEdicion)
                        {
                            _inventarioBL.ActualizarRepuesto(rep);
                            MessageBox.Show("Repuesto actualizado con éxito.", "Taller Radiador Springs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            _inventarioBL.RegistrarRepuesto(rep);
                            MessageBox.Show("Nuevo repuesto registrado en el catálogo.", "Taller Radiador Springs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        modal.DialogResult = DialogResult.OK;
                        modal.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                btnCancelar.Click += (s, ev) => { modal.Close(); };

                modal.Controls.AddRange(new Control[] { lblCode, txtCode, lblName, txtName, lblPrecio, txtPrecio, lblStock, txtStock, btnGuardar, btnCancelar });
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void MostrarDialogoMovimiento()
        {
            if (_listaRepuestos == null || _listaRepuestos.Count == 0)
            {
                MessageBox.Show("Primero debe registrar repuestos en el catálogo antes de poder hacer movimientos de inventario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form modal = new Form())
            {
                modal.Text = "Registrar Movimiento de Inventario";
                modal.Size = new Size(460, 390);
                modal.StartPosition = FormStartPosition.CenterParent;
                modal.FormBorderStyle = FormBorderStyle.FixedDialog;
                modal.MaximizeBox = false;
                modal.MinimizeBox = false;
                modal.BackColor = Color.FromArgb(240, 248, 255);

                Label lblTipo = new Label { Text = "Tipo de Movimiento:", Location = new Point(25, 20), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                ComboBox cboTipo = new ComboBox { Location = new Point(25, 42), Size = new Size(390, 26), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
                cboTipo.Items.AddRange(new object[] { "Entrada", "Salida" });
                cboTipo.SelectedIndex = 0;

                Label lblRep = new Label { Text = "Seleccionar Repuesto:", Location = new Point(25, 80), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                ComboBox cboRep = new ComboBox { Location = new Point(25, 102), Size = new Size(390, 26), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F) };
                cboRep.DataSource = _listaRepuestos;
                cboRep.DisplayMember = "NombreRepuesto";
                cboRep.ValueMember = "RepuestoID";

                Label lblCant = new Label { Text = "Cantidad:", Location = new Point(25, 140), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                NumericUpDown numCant = new NumericUpDown { Location = new Point(25, 162), Size = new Size(390, 26), Minimum = 1, Maximum = 1000, Value = 1, Font = new Font("Segoe UI", 10F) };

                Label lblMotivo = new Label { Text = "Motivo / N° Orden Referencia:", Location = new Point(25, 200), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                TextBox txtMotivo = new TextBox { Location = new Point(25, 222), Size = new Size(390, 26), Font = new Font("Segoe UI", 10F), PlaceholderText = "Ej. Orden de trabajo OT-0045 o Compra proveedor" };

                Button btnGuardar = new Button
                {
                    Text = "Guardar Movimiento",
                    Location = new Point(230, 280),
                    Size = new Size(185, 40),
                    BackColor = Color.FromArgb(0, 191, 255),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnGuardar.FlatAppearance.BorderSize = 0;

                Button btnCancelar = new Button
                {
                    Text = "Cancelar",
                    Location = new Point(25, 280),
                    Size = new Size(185, 40),
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(10, 22, 40),
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(192, 216, 236);

                btnGuardar.Click += (s, ev) =>
                {
                    try
                    {
                        if (cboRep.SelectedValue == null)
                        {
                            MessageBox.Show("Seleccione un repuesto de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int repuestoId = Convert.ToInt32(cboRep.SelectedValue);
                        string tipo = cboTipo.SelectedItem?.ToString() ?? "Entrada";
                        int cant = Convert.ToInt32(numCant.Value);
                        string motivo = txtMotivo.Text.Trim();

                        MovimientoInventarioEN mov = new MovimientoInventarioEN
                        {
                            RepuestoID = repuestoId,
                            TipoMovimiento = tipo,
                            Cantidad = cant,
                            Fecha = DateTime.Now,
                            Motivo = motivo
                        };

                        _inventarioBL.RegistrarMovimiento(mov);
                        MessageBox.Show("Movimiento de inventario registrado y existencia actualizada con éxito.", "Taller Radiador Springs", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        modal.DialogResult = DialogResult.OK;
                        modal.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Restricción de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                };

                btnCancelar.Click += (s, ev) => { modal.Close(); };

                modal.Controls.AddRange(new Control[] { lblTipo, cboTipo, lblRep, cboRep, lblCant, numCant, lblMotivo, txtMotivo, btnGuardar, btnCancelar });
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    CargarDatos();
                }
            }
        }

        private void MostrarDetalleRepuesto(RepuestoEN r)
        {
            string estado = r.Existencia > 5 ? "Disponible" : (r.Existencia > 0 ? "Bajo stock" : "Sin stock");
            string mensaje = $"--- DETALLES DEL REPUESTO ---\n\n" +
                             $"ID: {r.RepuestoID}\n" +
                             $"Código: {r.Codigo}\n" +
                             $"Nombre: {r.NombreRepuesto}\n" +
                             $"Precio Unitario: ${r.PrecioUnitario:0.00}\n" +
                             $"Existencia Actual: {r.Existencia} unidades\n" +
                             $"Estado del Stock: {estado}";

            MessageBox.Show(mensaje, "Consulta de Repuesto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarDetalleMovimiento(MovimientoInventarioEN m)
        {
            string mensaje = $"--- DETALLES DEL MOVIMIENTO DE INVENTARIO ---\n\n" +
                             $"MovID: MOV-{m.MovimientoID:D3}\n" +
                             $"Fecha: {m.Fecha:dd/MM/yyyy HH:mm}\n" +
                             $"Repuesto: {m.NombreRepuesto}\n" +
                             $"Tipo de Movimiento: {m.TipoMovimiento}\n" +
                             $"Cantidad: {m.Cantidad}\n" +
                             $"Motivo / N° Orden Ref: {(string.IsNullOrEmpty(m.Motivo) ? "N/A" : m.Motivo)}";

            MessageBox.Show(mensaje, "Consulta de Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
