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

        private void btnRegistrarRepuesto_Click(object sender, EventArgs e)
        {
            try
            {
                RepuestoEN repuesto = new RepuestoEN
                {
                    Codigo = txtCodigo.Text.Trim(),
                    NombreRepuesto = txtNombreRepuesto.Text.Trim(),
                    PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text),
                    Existencia = Convert.ToInt32(txtStockInicial.Text)
                };

                _inventarioBL.RegistrarRepuesto(repuesto);
                MessageBox.Show("Nuevo repuesto registrado en el catálogo.", "Taller Mecánico Toluca", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnRegistrarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                MovimientoInventarioEN mov = new MovimientoInventarioEN
                {
                    RepuestoID = Convert.ToInt32(txtRepuestoID.Text),
                    TipoMovimiento = cboTipoMovimiento.SelectedItem?.ToString(), // "Entrada" o "Salida"
                    Cantidad = Convert.ToInt32(txtCantidadMovimiento.Text),
                    Motivo = txtMotivoMovimiento.Text.Trim()
                };

                _inventarioBL.RegistrarMovimiento(mov);
                MessageBox.Show("Movimiento de inventario registrado y stock actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
