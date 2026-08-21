using System;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEN usuario = _usuarioBL.IniciarSesion(txtUsuario.Text.Trim(), txtClave.Text.Trim());

                // Guardar datos en sesión global
                SesionSistema.UsuarioID = usuario.UsuarioID;
                SesionSistema.NombreUsuario = usuario.NombreUsuario;
                SesionSistema.Rol = usuario.Rol;

                MessageBox.Show($"Bienvenido {usuario.NombreUsuario} ({usuario.Rol})", "Taller Mecánico Toluca", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                FrmMenuPrincipal menu = new FrmMenuPrincipal();
                menu.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}