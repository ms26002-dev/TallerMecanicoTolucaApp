using System;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmClienteDetalle : Form
    {
        public enum ModoFormulario { Nuevo, Editar, Consultar }

        private readonly ClienteBL _clienteBL = new ClienteBL();
        private readonly ModoFormulario _modo;
        private readonly ClienteEN _clienteOriginal;

        public FrmClienteDetalle(ModoFormulario modo, ClienteEN cliente)
        {
            InitializeComponent();
            _modo = modo;
            _clienteOriginal = cliente;
            ConfigurarSegunModo();
        }

        private void ConfigurarSegunModo()
        {
            if (_clienteOriginal != null)
            {
                txtNombre.Text = _clienteOriginal.NombreCompleto;
                txtTelefono.Text = _clienteOriginal.Telefono;
                txtCorreo.Text = _clienteOriginal.Correo;
                txtDireccion.Text = _clienteOriginal.Direccion;
                cboEstado.SelectedItem = _clienteOriginal.Estado;
            }

            switch (_modo)
            {
                case ModoFormulario.Nuevo:
                    lblTitulo.Text = "Nuevo Registro";
                    Text = "Nuevo Cliente";
                    cboEstado.Enabled = false;
                    break;

                case ModoFormulario.Editar:
                    lblTitulo.Text = "Editar Cliente";
                    Text = "Editar Cliente";
                    break;

                case ModoFormulario.Consultar:
                    lblTitulo.Text = "Consultar Cliente";
                    Text = "Consultar Cliente";
                    txtNombre.ReadOnly = true;
                    txtTelefono.ReadOnly = true;
                    txtCorreo.ReadOnly = true;
                    txtDireccion.ReadOnly = true;
                    cboEstado.Enabled = false;
                    btnGuardar.Visible = false;
                    btnCancelar.Text = "Cerrar";
                    break;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new ClienteEN
                {
                    ClienteID = _clienteOriginal?.ClienteID ?? 0,
                    NombreCompleto = txtNombre.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Estado = cboEstado.SelectedItem?.ToString() ?? "Activo"
                };

                if (_modo == ModoFormulario.Nuevo)
                {
                    _clienteBL.RegistrarCliente(cliente);
                    MessageBox.Show("Cliente registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (_modo == ModoFormulario.Editar)
                {
                    _clienteBL.ModificarCliente(cliente);
                    MessageBox.Show("Cliente actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
