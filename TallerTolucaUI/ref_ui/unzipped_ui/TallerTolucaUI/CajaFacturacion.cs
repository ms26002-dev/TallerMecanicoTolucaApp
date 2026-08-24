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

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            try
            {
                decimal montoInicial = Convert.ToDecimal(txtMontoApertura.Text);
                _cajaBL.AbrirCaja(montoInicial);
                MessageBox.Show("Apertura de caja realizada con éxito.", "Caja Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFacturarCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                FacturaEN factura = new FacturaEN
                {
                    OrdenID = Convert.ToInt32(txtOrdenID.Text),
                    ClienteID = Convert.ToInt32(txtClienteID.Text),
                    SubTotal = Convert.ToDecimal(txtSubTotal.Text),
                    Total = Convert.ToDecimal(txtTotal.Text)
                };

                _facturaBL.GenerarFacturaEfectivo(factura);
                MessageBox.Show("Factura generada y cobro registrado en Efectivo.", "Facturación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cobrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
