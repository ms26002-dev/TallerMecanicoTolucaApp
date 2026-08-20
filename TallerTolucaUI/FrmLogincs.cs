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
            CentrarTarjeta();
            this.Resize += (s, e) => CentrarTarjeta();
            this.Load += (s, e) => CentrarTarjeta();

            txtClave.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnIngresar_Click(this, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                }
            };
            txtUsuario.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtClave.Focus();
                    e.SuppressKeyPress = true;
                }
            };
        }

        private void CentrarTarjeta()
        {
            if (pnlCard != null)
            {
                pnlCard.Left = Math.Max(20, (this.ClientSize.Width - pnlCard.Width) / 2);
                pnlCard.Top = Math.Max(20, (this.ClientSize.Height - pnlCard.Height) / 2 - 20);

                if (lblFooter != null)
                {
                    lblFooter.Left = (this.ClientSize.Width - lblFooter.Width) / 2;
                    lblFooter.Top = pnlCard.Bottom + 15;
                }
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuarioTexto = txtUsuario.Text.Trim();
                string claveTexto = txtClave.Text.Trim();

                if (string.IsNullOrWhiteSpace(usuarioTexto) || string.IsNullOrWhiteSpace(claveTexto))
                {
                    MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                UsuarioEN usuario = _usuarioBL.IniciarSesion(usuarioTexto, claveTexto);

                // Guardar datos en sesión global
                SesionSistema.UsuarioID = usuario.UsuarioID;
                SesionSistema.NombreUsuario = usuario.NombreUsuario;
                SesionSistema.Rol = usuario.Rol;

                this.Hide();
                txtClave.Clear();

                using (FrmMenuPrincipal menu = new FrmMenuPrincipal())
                {
                    menu.ShowDialog();
                }

                this.Show();
                txtUsuario.Focus();
                CentrarTarjeta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}