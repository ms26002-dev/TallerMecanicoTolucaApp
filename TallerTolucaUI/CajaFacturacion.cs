using System;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmCajaFacturacion : Form
    {
        private readonly CajaBL _cajaBL = new CajaBL();
        private readonly FacturaBL _facturaBL = new FacturaBL();

        public FrmCajaFacturacion()
        {
            InitializeComponent();
        }

        private void btnAbrirCaja_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtMontoApertura.Text.Trim(), out decimal montoInicial) || montoInicial <= 0)
                {
                    MessageBox.Show("Por favor, ingrese un monto inicial válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMontoApertura.Focus();
                    return;
                }

                _cajaBL.AbrirCaja(montoInicial);
                MessageBox.Show($"Apertura de caja realizada con éxito con un monto de ${montoInicial:F2}.", "Caja Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMontoApertura.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFacturarCobrar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtOrdenID.Text.Trim(), out int ordenId) || ordenId <= 0)
                {
                    MessageBox.Show("Ingrese un ID de orden válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOrdenID.Focus();
                    return;
                }

                if (!int.TryParse(txtClienteID.Text.Trim(), out int clienteId) || clienteId <= 0)
                {
                    MessageBox.Show("Ingrese un ID de cliente válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtClienteID.Focus();
                    return;
                }

                if (!decimal.TryParse(txtSubTotal.Text.Trim(), out decimal subTotal) || subTotal < 0)
                {
                    MessageBox.Show("Ingrese un subtotal válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSubTotal.Focus();
                    return;
                }

                if (!decimal.TryParse(txtTotal.Text.Trim(), out decimal total) || total <= 0)
                {
                    MessageBox.Show("Ingrese un monto total válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTotal.Focus();
                    return;
                }

                FacturaEN factura = new FacturaEN
                {
                    OrdenID = ordenId,
                    ClienteID = clienteId,
                    SubTotal = subTotal,
                    Total = total
                };

                _facturaBL.GenerarFacturaEfectivo(factura);
                MessageBox.Show($"Factura generada con éxito por un total de ${total:F2}.\nCobro registrado en Efectivo e ingresado a Caja.", "Facturación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOrdenID.Clear();
                txtClienteID.Clear();
                txtSubTotal.Clear();
                txtTotal.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
