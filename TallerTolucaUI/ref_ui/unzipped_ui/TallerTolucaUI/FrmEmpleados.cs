using System;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmEmpleados : Form
    {
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();

        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadoEN empleado = new EmpleadoEN
                {
                    NombreCompleto = txtNombre.Text.Trim(),
                    Cargo = txtCargo.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim()
                };

                _empleadoBL.RegistrarEmpleado(empleado);
                MessageBox.Show("Empleado registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNombre.Clear();
                txtCargo.Clear();
                txtTelefono.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Registrar Empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
