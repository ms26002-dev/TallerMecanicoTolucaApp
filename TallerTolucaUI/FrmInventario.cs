using System;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmInventario : Form
    {
        private readonly InventarioBL _inventarioBL = new InventarioBL();

        public FrmInventario()
        {
            InitializeComponent();
        }

        private void btnRegistrarRepuesto_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigo.Text))
                {
                    MessageBox.Show("El código de repuesto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNombreRepuesto.Text))
                {
                    MessageBox.Show("El nombre del repuesto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreRepuesto.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrecioUnitario.Text.Trim(), out decimal precio) || precio < 0)
                {
                    MessageBox.Show("Ingrese un precio unitario válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrecioUnitario.Focus();
                    return;
                }

                if (!int.TryParse(txtStockInicial.Text.Trim(), out int stock) || stock < 0)
                {
                    MessageBox.Show("Ingrese una cantidad inicial de stock válida.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtStockInicial.Focus();
                    return;
                }

                RepuestoEN repuesto = new RepuestoEN
                {
                    Codigo = txtCodigo.Text.Trim().ToUpper(),
                    NombreRepuesto = txtNombreRepuesto.Text.Trim(),
                    PrecioUnitario = precio,
                    Existencia = stock
                };

                _inventarioBL.RegistrarRepuesto(repuesto);
                MessageBox.Show("Nuevo repuesto registrado exitosamente en el catálogo.", "Taller Mecánico Toluca", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtCodigo.Clear();
                txtNombreRepuesto.Clear();
                txtPrecioUnitario.Clear();
                txtStockInicial.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Registrar Repuesto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRegistrarMovimiento_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtRepuestoID.Text.Trim(), out int repuestoId) || repuestoId <= 0)
                {
                    MessageBox.Show("Ingrese un ID de repuesto válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRepuestoID.Focus();
                    return;
                }

                if (!int.TryParse(txtCantidadMovimiento.Text.Trim(), out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCantidadMovimiento.Focus();
                    return;
                }

                string tipoMov = cboTipoMovimiento.SelectedItem?.ToString() ?? "Entrada";

                if (string.IsNullOrWhiteSpace(txtMotivoMovimiento.Text))
                {
                    MessageBox.Show("El motivo del movimiento es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMotivoMovimiento.Focus();
                    return;
                }

                MovimientoInventarioEN mov = new MovimientoInventarioEN
                {
                    RepuestoID = repuestoId,
                    TipoMovimiento = tipoMov,
                    Cantidad = cantidad,
                    Motivo = txtMotivoMovimiento.Text.Trim()
                };

                _inventarioBL.RegistrarMovimiento(mov);
                MessageBox.Show($"Movimiento de {tipoMov} por {cantidad} pieza(s) registrado y stock actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtRepuestoID.Clear();
                txtCantidadMovimiento.Clear();
                txtMotivoMovimiento.Clear();
            }
            catch (Exception ex)
            {
                // Muestra la alerta si se intenta hacer una salida sin especificar el motivo/orden
                MessageBox.Show(ex.Message, "Restricción de Inventario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
