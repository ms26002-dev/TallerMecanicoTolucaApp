using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmCajaFacturacion : Form
    {
        private readonly CajaBL _cajaBL = new CajaBL();
        private readonly FacturaBL _facturaBL = new FacturaBL();
        private readonly OrdenTrabajoBL _ordenBL = new OrdenTrabajoBL();
        private readonly ClienteBL _clienteBL = new ClienteBL();

        private ControlCajaEN? _cajaActiva;
        private List<FacturaEN> _listaFacturas = new List<FacturaEN>();
        private List<OrdenTrabajoEN> _listaOrdenes = new List<OrdenTrabajoEN>();
        private List<ClienteEN> _listaClientes = new List<ClienteEN>();
        private List<ControlCajaEN> _listaHistorialCajas = new List<ControlCajaEN>();

        private FacturaEN? _facturaSeleccionada;

        private class ComboItem<T>
        {
            public T Value { get; set; }
            public string Text { get; set; } = string.Empty;

            public ComboItem(T value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString() => Text;
        }

        public FrmCajaFacturacion()
        {
            InitializeComponent();
        }

        private void FrmCajaFacturacion_Load(object sender, EventArgs e)
        {
            CargarLogotipo();
            EstilizarGrid();
            EstilizarGridHistorial();
            CargarCombos();
            CargarEstadoCaja();
            CargarFacturas();
            CargarHistorialCajas();
        }

        private void CargarLogotipo()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string[] possiblePaths = new string[]
                {
                    Path.Combine(basePath, "image1.png"),
                    Path.Combine(basePath, "..", "..", "..", "doc_extracted", "image1.png")
                };

                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        using (var img = Image.FromFile(path))
                        {
                            picLogoHeader.Image = new Bitmap(img);
                        }
                        return;
                    }
                }

                Bitmap bmp = new Bitmap(46, 44);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Brush b = new SolidBrush(Color.FromArgb(224, 242, 254)))
                    {
                        g.FillEllipse(b, 2, 2, 40, 40);
                    }
                    using (Pen p = new Pen(Color.FromArgb(2, 132, 199), 2))
                    {
                        g.DrawEllipse(p, 2, 2, 40, 40);
                        g.DrawString("💵", new Font("Segoe UI", 12F), Brushes.DarkBlue, 8, 8);
                    }
                }
                picLogoHeader.Image = bmp;
            }
            catch { }
        }

        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            Panel? pnl = sender as Panel;
            if (pnl == null) return;

            using (Pen pen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1));
            }
        }

        private void EstilizarGrid()
        {
            dgvFacturas.BackgroundColor = Color.White;
            dgvFacturas.BorderStyle = BorderStyle.None;
            dgvFacturas.GridColor = Color.FromArgb(241, 245, 249);
            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.EnableHeadersVisualStyles = false;
            dgvFacturas.ColumnHeadersHeight = 36;
            dgvFacturas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvFacturas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvFacturas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvFacturas.DefaultCellStyle.BackColor = Color.White;
            dgvFacturas.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvFacturas.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvFacturas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvFacturas.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvFacturas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvFacturas.RowTemplate.Height = 34;

            dgvFacturas.AutoGenerateColumns = false;
            dgvFacturas.Columns.Clear();

            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FacturaID",
                HeaderText = "N° Factura",
                Width = 85,
                FillWeight = 30
            });

            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrdenID",
                HeaderText = "N° Orden",
                Width = 75,
                FillWeight = 25
            });

            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaFormateada",
                HeaderText = "Fecha / Hora",
                Width = 135,
                FillWeight = 55
            });

            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCliente",
                HeaderText = "Cliente",
                FillWeight = 95
            });

            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PlacaVehiculo",
                HeaderText = "Placa",
                Width = 80,
                FillWeight = 30
            });

            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalFormateado",
                HeaderText = "Total Cobrado",
                Width = 100,
                FillWeight = 40
            });

            dgvFacturas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MetodoPago",
                HeaderText = "Método",
                Width = 85,
                FillWeight = 30
            });
        }

        private void EstilizarGridHistorial()
        {
            dgvHistorialCajas.BackgroundColor = Color.White;
            dgvHistorialCajas.BorderStyle = BorderStyle.None;
            dgvHistorialCajas.GridColor = Color.FromArgb(241, 245, 249);
            dgvHistorialCajas.RowHeadersVisible = false;
            dgvHistorialCajas.EnableHeadersVisualStyles = false;
            dgvHistorialCajas.ColumnHeadersHeight = 36;
            dgvHistorialCajas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvHistorialCajas.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvHistorialCajas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvHistorialCajas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvHistorialCajas.DefaultCellStyle.BackColor = Color.White;
            dgvHistorialCajas.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvHistorialCajas.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvHistorialCajas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvHistorialCajas.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);
            dgvHistorialCajas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvHistorialCajas.RowTemplate.Height = 34;

            dgvHistorialCajas.AutoGenerateColumns = false;
            dgvHistorialCajas.Columns.Clear();

            dgvHistorialCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CajaID",
                HeaderText = "N° Caja",
                Width = 70,
                FillWeight = 25
            });

            dgvHistorialCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EstadoBadge",
                HeaderText = "Estado",
                Width = 90,
                FillWeight = 30
            });

            dgvHistorialCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaAperturaFormateada",
                HeaderText = "Fecha Apertura",
                Width = 135,
                FillWeight = 50
            });

            dgvHistorialCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FechaCierreFormateada",
                HeaderText = "Fecha Cierre",
                Width = 135,
                FillWeight = 50
            });

            dgvHistorialCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MontoAperturaFormateado",
                HeaderText = "Monto Inicial",
                Width = 95,
                FillWeight = 35
            });

            dgvHistorialCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MontoIngresosFormateado",
                HeaderText = "Cobros",
                Width = 95,
                FillWeight = 35
            });

            dgvHistorialCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "MontoEgresosFormateado",
                HeaderText = "Egresos",
                Width = 85,
                FillWeight = 30
            });

            dgvHistorialCajas.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "SaldoTotalFormateado",
                HeaderText = "Saldo Final",
                Width = 100,
                FillWeight = 40
            });
        }

        private void CargarHistorialCajas()
        {
            try
            {
                _listaHistorialCajas = _cajaBL.ObtenerHistorialCajas() ?? new List<ControlCajaEN>();
                AplicarFiltroHistorial();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar historial de cajas: {ex.Message}", true);
            }
        }

        private void AplicarFiltroHistorial()
        {
            string filtro = txtBuscarCaja.Text.Trim().ToLower();

            List<ControlCajaEN> filtrados;
            if (string.IsNullOrEmpty(filtro))
            {
                filtrados = _listaHistorialCajas;
            }
            else
            {
                filtrados = _listaHistorialCajas.Where(c =>
                    c.CajaID.ToString().Contains(filtro) ||
                    (c.Estado != null && c.Estado.ToLower().Contains(filtro)) ||
                    c.FechaAperturaFormateada.ToLower().Contains(filtro) ||
                    c.FechaCierreFormateada.ToLower().Contains(filtro) ||
                    c.MontoAperturaFormateado.Contains(filtro) ||
                    c.SaldoTotalFormateado.Contains(filtro)
                ).ToList();
            }

            dgvHistorialCajas.DataSource = null;
            dgvHistorialCajas.DataSource = filtrados;
            lblTotalSesiones.Text = $"Total sesiones registradas: {filtrados.Count}";
        }

        private void TxtBuscarCaja_TextChanged(object? sender, EventArgs e)
        {
            AplicarFiltroHistorial();
        }

        private void BtnRefrescarHistorial_Click(object? sender, EventArgs e)
        {
            txtBuscarCaja.Clear();
            CargarHistorialCajas();
            MostrarMensaje("Historial de cajas actualizado.", false);
        }

        private void BtnHistorialCajas_Click(object? sender, EventArgs e)
        {
            tabControlFinanciero.SelectedTab = tabHistorialCajas;
            CargarHistorialCajas();
        }

        private void CargarEstadoCaja()
        {
            try
            {
                _cajaActiva = _cajaBL.ObtenerCajaActiva();

                if (_cajaActiva != null)
                {
                    decimal saldoActual = _cajaActiva.MontoApertura + _cajaActiva.MontoIngresos - _cajaActiva.MontoEgresos;
                    lblEstadoCajaBadge.Text = $"🟢 CAJA ABIERTA (N° {_cajaActiva.CajaID})";
                    lblEstadoCajaBadge.ForeColor = Color.FromArgb(16, 185, 129);

                    lblMontoAperturaInfo.Text = $"Apertura: {_cajaActiva.MontoApertura:C2}";
                    lblIngresosInfo.Text = $"Cobros: {_cajaActiva.MontoIngresos:C2}";
                    lblSaldoTotalInfo.Text = $"Total en Caja: {saldoActual:C2}";

                    btnAbrirCaja.Enabled = false;
                    btnAbrirCaja.BackColor = Color.FromArgb(148, 163, 184);

                    btnCerrarCaja.Enabled = true;
                    btnCerrarCaja.BackColor = Color.FromArgb(217, 119, 6);

                    btnFacturarCobrar.Enabled = true;
                    btnFacturarCobrar.BackColor = Color.FromArgb(2, 132, 199);
                }
                else
                {
                    lblEstadoCajaBadge.Text = "🔴 CAJA CERRADA";
                    lblEstadoCajaBadge.ForeColor = Color.FromArgb(220, 38, 38);

                    lblMontoAperturaInfo.Text = "Apertura: $0.00";
                    lblIngresosInfo.Text = "Cobros: $0.00";
                    lblSaldoTotalInfo.Text = "Total en Caja: $0.00";

                    btnAbrirCaja.Enabled = true;
                    btnAbrirCaja.BackColor = Color.FromArgb(2, 132, 199);

                    btnCerrarCaja.Enabled = false;
                    btnCerrarCaja.BackColor = Color.FromArgb(148, 163, 184);

                    btnFacturarCobrar.Enabled = false;
                    btnFacturarCobrar.BackColor = Color.FromArgb(148, 163, 184);

                    MostrarMensaje("La caja se encuentra cerrada. Debe abrir la caja para poder cobrar y facturar.", true);
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al consultar estado de caja: {ex.Message}", true);
            }
        }

        private void CargarCombos()
        {
            try
            {
                // 1. Clientes
                _listaClientes = _clienteBL.ObtenerClientesActivos() ?? new List<ClienteEN>();
                cboCliente.Items.Clear();
                cboCliente.Items.Add(new ComboItem<int>(0, "-- Seleccione un Cliente --"));
                foreach (var c in _listaClientes)
                {
                    cboCliente.Items.Add(new ComboItem<int>(c.ClienteID, $"#{c.ClienteID} - {c.NombreCompleto}"));
                }
                cboCliente.SelectedIndex = 0;

                // 2. Órdenes de Trabajo
                _listaOrdenes = _ordenBL.ObtenerTodasOrdenes() ?? new List<OrdenTrabajoEN>();
                cboOrden.Items.Clear();
                cboOrden.Items.Add(new ComboItem<int>(0, "-- Seleccione Orden de Trabajo a Facturar --"));
                foreach (var o in _listaOrdenes)
                {
                    string info = $"Orden #{o.OrdenID} | {o.NombreCliente} | Placa: {o.PlacaVehiculo} ({o.Estado})";
                    cboOrden.Items.Add(new ComboItem<int>(o.OrdenID, info));
                }
                cboOrden.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar listas: {ex.Message}", true);
            }
        }

        private void CboOrden_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboOrden.SelectedItem is ComboItem<int> item && item.Value > 0)
            {
                var orden = _listaOrdenes.FirstOrDefault(o => o.OrdenID == item.Value);
                if (orden != null)
                {
                    // Seleccionar cliente asociado
                    for (int i = 0; i < cboCliente.Items.Count; i++)
                    {
                        if (cboCliente.Items[i] is ComboItem<int> cItem && cItem.Value == orden.ClienteID)
                        {
                            cboCliente.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            Input_TextChanged(sender, e);
        }

        private void TxtSubTotal_TextChanged(object? sender, EventArgs e)
        {
            if (decimal.TryParse(txtSubTotal.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal subtotal))
            {
                txtTotal.Text = subtotal.ToString("F2", CultureInfo.InvariantCulture);
            }
            Input_TextChanged(sender, e);
        }

        private void CargarFacturas()
        {
            try
            {
                _listaFacturas = _facturaBL.ObtenerTodasFacturas() ?? new List<FacturaEN>();
                AplicarFiltro();
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar facturas: {ex.Message}", true);
            }
        }

        private void AplicarFiltro()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            List<FacturaEN> filtrados;
            if (string.IsNullOrEmpty(filtro))
            {
                filtrados = _listaFacturas;
            }
            else
            {
                filtrados = _listaFacturas.Where(f =>
                    f.FacturaID.ToString().Contains(filtro) ||
                    f.OrdenID.ToString().Contains(filtro) ||
                    (f.NombreCliente != null && f.NombreCliente.ToLower().Contains(filtro)) ||
                    (f.PlacaVehiculo != null && f.PlacaVehiculo.ToLower().Contains(filtro)) ||
                    f.Total.ToString().Contains(filtro)
                ).ToList();
            }

            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = filtrados;
            lblTotalFacturas.Text = $"Total facturas emitidas: {filtrados.Count}";

            decimal totalRecaudado = filtrados.Sum(f => f.Total);
            lblTotalRecaudado.Text = $"Total Recaudado: {totalRecaudado:C2}";
        }

        private void TxtBuscar_TextChanged(object? sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void BtnRefrescar_Click(object? sender, EventArgs e)
        {
            txtBuscar.Clear();
            CargarCombos();
            CargarEstadoCaja();
            CargarFacturas();
            MostrarMensaje("Información de caja y facturación actualizada.", false);
        }

        private void Input_TextChanged(object? sender, EventArgs? e)
        {
            if (lblMensaje.Visible)
            {
                lblMensaje.Visible = false;
                lblMensaje.Text = string.Empty;
                txtSubTotal.BackColor = Color.FromArgb(248, 250, 252);
                txtTotal.BackColor = Color.FromArgb(240, 253, 244);
                cboOrden.BackColor = Color.FromArgb(248, 250, 252);
                cboCliente.BackColor = Color.FromArgb(248, 250, 252);
            }
        }

        private void MostrarMensaje(string mensaje, bool esError, Control? controlObjetivo = null)
        {
            lblMensaje.Text = (esError ? "⚠️ " : "✅ ") + mensaje;
            lblMensaje.ForeColor = esError ? Color.FromArgb(220, 38, 38) : Color.FromArgb(16, 185, 129);
            lblMensaje.Visible = true;

            if (controlObjetivo != null)
            {
                controlObjetivo.BackColor = esError ? Color.FromArgb(254, 242, 242) : Color.FromArgb(240, 253, 244);
                controlObjetivo.Focus();
            }
        }

        private void btnAbrirCaja_Click(object? sender, EventArgs e)
        {
            string promptValue = Microsoft.VisualBasic.Interaction.InputBox(
                "Ingrese el monto inicial de apertura de caja en efectivo ($):",
                "Apertura de Caja Diaria - Taller Toluca",
                "500.00"
            );

            if (string.IsNullOrWhiteSpace(promptValue)) return;

            if (!decimal.TryParse(promptValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal montoApertura) &&
                !decimal.TryParse(promptValue, out montoApertura) || montoApertura < 0)
            {
                MessageBox.Show("Por favor ingrese un monto numérico válido y no negativo.", "Monto Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int nuevaCajaID = _cajaBL.AbrirCaja(montoApertura);
                MessageBox.Show($"Caja #{nuevaCajaID} abierta con éxito.\nMonto inicial: {montoApertura:C2}", "Apertura Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEstadoCaja();
                CargarHistorialCajas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Abrir Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrarCaja_Click(object? sender, EventArgs e)
        {
            if (_cajaActiva == null)
            {
                MostrarMensaje("No hay ninguna caja abierta para cerrar.", true);
                return;
            }

            decimal saldoEsperado = _cajaActiva.MontoApertura + _cajaActiva.MontoIngresos - _cajaActiva.MontoEgresos;

            string resumen = $"Resumen de Cierre de Caja #{_cajaActiva.CajaID}:\n\n" +
                             $"• Fecha Apertura: {_cajaActiva.FechaApertura:dd/MM/yyyy hh:mm tt}\n" +
                             $"• Monto Apertura: {_cajaActiva.MontoApertura:C2}\n" +
                             $"• Cobros en Efectivo: {_cajaActiva.MontoIngresos:C2}\n" +
                             $"----------------------------------------\n" +
                             $"TOTAL EN CAJA: {saldoEsperado:C2}\n\n" +
                             $"¿Desea confirmar el CIERRE DIARIO de la caja?";

            DialogResult confirm = MessageBox.Show(resumen, "Confirmar Cierre Diario / Arqueo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _cajaBL.CerrarCaja(_cajaActiva.CajaID);
                    MessageBox.Show("El cierre diario de caja ha sido registrado exitosamente.", "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarEstadoCaja();
                    CargarHistorialCajas();
                    LimpiarFormulario();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al Cerrar Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFacturarCobrar_Click(object? sender, EventArgs e)
        {
            if (_cajaActiva == null)
            {
                MostrarMensaje("Debe abrir la caja antes de facturar o recibir cobros.", true);
                MessageBox.Show("Debe realizar la apertura de caja antes de registrar cobros.", "Caja Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!(cboOrden.SelectedItem is ComboItem<int> ordenItem) || ordenItem.Value <= 0)
            {
                MostrarMensaje("Seleccione la orden de trabajo a facturar.", true, cboOrden);
                return;
            }

            if (!(cboCliente.SelectedItem is ComboItem<int> clienteItem) || clienteItem.Value <= 0)
            {
                MostrarMensaje("Seleccione un cliente.", true, cboCliente);
                return;
            }

            if (!decimal.TryParse(txtTotal.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal total) &&
                !decimal.TryParse(txtTotal.Text.Trim(), out total) || total <= 0)
            {
                MostrarMensaje("Ingrese un monto total a cobrar válido y mayor a cero.", true, txtTotal);
                return;
            }

            decimal.TryParse(txtSubTotal.Text.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal subtotal);
            if (subtotal <= 0) subtotal = total;

            try
            {
                FacturaEN nuevaFactura = new FacturaEN
                {
                    OrdenID = ordenItem.Value,
                    ClienteID = clienteItem.Value,
                    SubTotal = subtotal,
                    Total = total,
                    MetodoPago = "Efectivo"
                };

                int nuevaFacturaID = _facturaBL.GenerarFacturaEfectivo(nuevaFactura);
                nuevaFactura.FacturaID = nuevaFacturaID;
                _facturaSeleccionada = nuevaFactura;

                MostrarMensaje($"Factura #{nuevaFacturaID} generada y cobrada con éxito (Solo Efectivo - Regla #1).", false);

                string msgTicket = $"========================================\n" +
                                   $"       TALLER MECÁNICO TOLUCA\n" +
                                   $"            Taller Toluca\n" +
                                   $"========================================\n" +
                                   $"Factura N°: #{nuevaFacturaID}\n" +
                                   $"Orden N°:   #{ordenItem.Value}\n" +
                                   $"Fecha:      {DateTime.Now:dd/MM/yyyy hh:mm tt}\n" +
                                   $"Cliente:    {cboCliente.Text}\n" +
                                   $"Método:     Efectivo (Regla #1)\n" +
                                   $"----------------------------------------\n" +
                                   $"Subtotal:   {subtotal:C2}\n" +
                                   $"TOTAL:      {total:C2}\n" +
                                   $"========================================\n" +
                                   $"¡Gracias por su preferencia!\n" +
                                   $"(Comprobante Fiscal Emitido - Regla #5)";

                MessageBox.Show(msgTicket, "Comprobante Fiscal / Factura Emitida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarEstadoCaja();
                CargarFacturas();
                CargarHistorialCajas();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message, true);
                MessageBox.Show(ex.Message, "Error al Facturar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVerTicket_Click(object? sender, EventArgs e)
        {
            if (_facturaSeleccionada == null)
            {
                MostrarMensaje("Seleccione una factura del listado para ver su comprobante.", true);
                return;
            }

            string ticket = $"========================================\n" +
                            $"       TALLER MECÁNICO TOLUCA\n" +
                            $"            Taller Toluca\n" +
                            $"========================================\n" +
                            $"Factura N°: #{_facturaSeleccionada.FacturaID}\n" +
                            $"Orden N°:   #{_facturaSeleccionada.OrdenID}\n" +
                            $"Fecha:      {_facturaSeleccionada.FechaFormateada}\n" +
                            $"Cliente:    {_facturaSeleccionada.NombreCliente}\n" +
                            $"Vehículo:   Placa {_facturaSeleccionada.PlacaVehiculo}\n" +
                            $"Método:     {_facturaSeleccionada.MetodoPago}\n" +
                            $"----------------------------------------\n" +
                            $"Subtotal:   {_facturaSeleccionada.SubTotalFormateado}\n" +
                            $"TOTAL:      {_facturaSeleccionada.TotalFormateado}\n" +
                            $"========================================\n" +
                            $"Comprobante Inmutable (Regla #7 - Auditoría)";

            MessageBox.Show(ticket, $"Comprobante Factura #{_facturaSeleccionada.FacturaID}", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnArqueo_Click(object? sender, EventArgs e)
        {
            if (_cajaActiva == null)
            {
                MessageBox.Show("La caja se encuentra cerrada actualmente. No hay arqueo activo.", "Arqueo de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal saldoEsperado = _cajaActiva.MontoApertura + _cajaActiva.MontoIngresos - _cajaActiva.MontoEgresos;

            string info = $"ARQUEO DE CAJA ACTIVA (N° {_cajaActiva.CajaID})\n\n" +
                          $"• Fecha Apertura:    {_cajaActiva.FechaApertura:dd/MM/yyyy hh:mm tt}\n" +
                          $"• Monto Inicial:     {_cajaActiva.MontoApertura:C2}\n" +
                          $"• Ingresos (Cobros): {_cajaActiva.MontoIngresos:C2}\n" +
                          $"• Egresos / Retiros: {_cajaActiva.MontoEgresos:C2}\n" +
                          $"----------------------------------------\n" +
                          $"EFECTIVO ESPERADO EN CAJA: {saldoEsperado:C2}";

            MessageBox.Show(info, "Arqueo de Caja en Tiempo Real", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _facturaSeleccionada = null;
            if (cboOrden.Items.Count > 0) cboOrden.SelectedIndex = 0;
            if (cboCliente.Items.Count > 0) cboCliente.SelectedIndex = 0;
            txtSubTotal.Text = "0.00";
            txtTotal.Text = "0.00";
            lblMensaje.Visible = false;
            lblMensaje.Text = string.Empty;

            txtSubTotal.BackColor = Color.FromArgb(248, 250, 252);
            txtTotal.BackColor = Color.FromArgb(240, 253, 244);
            cboOrden.BackColor = Color.FromArgb(248, 250, 252);
            cboCliente.BackColor = Color.FromArgb(248, 250, 252);

            dgvFacturas.ClearSelection();
        }

        private void DgvFacturas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            CargarFacturaSeleccionada();
        }

        private void DgvFacturas_SelectionChanged(object? sender, EventArgs e)
        {
            CargarFacturaSeleccionada();
        }

        private void CargarFacturaSeleccionada()
        {
            if (dgvFacturas.CurrentRow != null && dgvFacturas.CurrentRow.DataBoundItem is FacturaEN factura)
            {
                _facturaSeleccionada = factura;

                // Seleccionar orden
                for (int i = 0; i < cboOrden.Items.Count; i++)
                {
                    if (cboOrden.Items[i] is ComboItem<int> item && item.Value == factura.OrdenID)
                    {
                        cboOrden.SelectedIndex = i;
                        break;
                    }
                }

                // Seleccionar cliente
                for (int i = 0; i < cboCliente.Items.Count; i++)
                {
                    if (cboCliente.Items[i] is ComboItem<int> item && item.Value == factura.ClienteID)
                    {
                        cboCliente.SelectedIndex = i;
                        break;
                    }
                }

                txtSubTotal.Text = factura.SubTotal.ToString("F2", CultureInfo.InvariantCulture);
                txtTotal.Text = factura.Total.ToString("F2", CultureInfo.InvariantCulture);
                txtMetodoPago.Text = factura.MetodoPago;
            }
        }
    }
}
