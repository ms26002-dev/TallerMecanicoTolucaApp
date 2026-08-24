using System;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmCitas : Form
    {
        private readonly CitaBL _citaBL = new CitaBL();

        public FrmCitas()
        {
            InitializeComponent();
        }

        private void btnProgramarCita_Click(object sender, EventArgs e)
        {
            try
            {
                CitaEN cita = new CitaEN
                {
                    ClienteID = Convert.ToInt32(txtClienteID.Text),
                    VehiculoID = Convert.ToInt32(txtVehiculoID.Text),
                    FechaHora = dtpFechaHora.Value,
                    Motivo = txtMotivo.Text.Trim()
                };

                _citaBL.ProgramarCita(cita);
                MessageBox.Show("Cita programada con éxito.", "Taller Mecánico Toluca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                // Captura si la fecha seleccionada ya pasó o si faltan datos
                MessageBox.Show(ex.Message, "Error al Programar Cita", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                int citaID = Convert.ToInt32(txtCitaID.Text);
                string nuevoEstado = cboEstadoCita.SelectedItem?.ToString();

                if (string.IsNullOrEmpty(nuevoEstado))
                {
                    MessageBox.Show("Seleccione un estado válido para la cita.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _citaBL.ActualizarEstadoCita(citaID, nuevoEstado);
                MessageBox.Show($"Estado de la cita actualizado a '{nuevoEstado}'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Actualizar Estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            txtClienteID.Clear();
            txtVehiculoID.Clear();
            txtMotivo.Clear();
            dtpFechaHora.Value = DateTime.Now;
        }
    }
}
