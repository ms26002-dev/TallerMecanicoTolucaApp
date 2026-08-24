using System;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmOrdenesTrabajo : Form
    {
        private readonly OrdenTrabajoBL _ordenBL = new OrdenTrabajoBL();

        public FrmOrdenesTrabajo()
        {
            InitializeComponent();
        }

        private void btnCrearOrden_Click(object sender, EventArgs e)
        {
            try
            {
                OrdenTrabajoEN orden = new OrdenTrabajoEN
                {
                    ClienteID = Convert.ToInt32(txtClienteID.Text),
                    VehiculoID = Convert.ToInt32(txtVehiculoID.Text),
                    EmpleadoID = Convert.ToInt32(txtMecanicoID.Text),
                    KilometrajeEntrada = Convert.ToInt32(txtKilometraje.Text),
                    DescripcionDiagnostico = txtDiagnostico.Text.Trim(),
                    UbicacionTaller = "Taller Mecánico Toluca"
                };

                _ordenBL.CrearOrden(orden);
                MessageBox.Show("Orden de trabajo creada y mecánico asignado con éxito.", "Taller Mecánico Toluca", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Captura si el mecánico ya tiene una orden activa
                MessageBox.Show(ex.Message, "Validación de Asignación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFinalizarOrden_Click(object sender, EventArgs e)
        {
            try
            {
                int ordenID = Convert.ToInt32(txtOrdenID.Text);
                _ordenBL.CambiarEstadoOrden(ordenID, "Finalizada");
                MessageBox.Show("La orden fue marcada como Finalizada. Ya no podrá modificarse.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Bloquea cambios si la orden ya estaba finalizada
                MessageBox.Show(ex.Message, "Orden Inmutable", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
