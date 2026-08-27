using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
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

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            CentrarTarjeta();
            CargarLogotipo();
            VerificarCapsLock();
            txtUsuario.Focus();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            CentrarTarjeta();
        }

        private void CentrarTarjeta()
        {
            if (pnlCard != null)
            {
                pnlCard.Left = Math.Max(10, (this.ClientSize.Width - pnlCard.Width) / 2);
                pnlCard.Top = Math.Max(10, (this.ClientSize.Height - pnlCard.Height) / 2);
            }
        }

        private void CargarLogotipo()
        {
            try
            {
                // Intentar cargar logotipo del proyecto si existe en el directorio
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string[] possiblePaths = new string[]
                {
                    Path.Combine(basePath, "Assets", "logo.png"),
                    Path.Combine(basePath, "image1.png"),
                    Path.Combine(basePath, "..", "..", "..", "doc_extracted", "image1.png"),
                    Path.Combine(basePath, "..", "..", "..", "ref_ui", "screenshot_downloads.png")
                };

                foreach (string path in possiblePaths)
                {
                    if (File.Exists(path))
                    {
                        using (var img = Image.FromFile(path))
                        {
                            picLogo.Image = new Bitmap(img);
                        }
                        return;
                    }
                }

                // Si no hay imagen física, generar un ícono vectorial estilizado
                Bitmap iconBmp = new Bitmap(50, 45);
                using (Graphics g = Graphics.FromImage(iconBmp))
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Brush bgBrush = new SolidBrush(Color.FromArgb(224, 242, 254)))
                    {
                        g.FillEllipse(bgBrush, 2, 2, 44, 40);
                    }
                    using (Pen pen = new Pen(Color.FromArgb(2, 132, 199), 2))
                    {
                        g.DrawEllipse(pen, 2, 2, 44, 40);
                        // Símbolo de llave / tuerca
                        g.DrawLine(pen, 16, 16, 32, 28);
                        g.DrawLine(pen, 32, 16, 16, 28);
                    }
                }
                picLogo.Image = iconBmp;
            }
            catch
            {
                // Manejo silencioso si no se puede cargar la imagen
            }
        }

        private void PnlCard_Paint(object sender, PaintEventArgs e)
        {
            // Borde sutil y profesional para la tarjeta
            using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                Rectangle rect = new Rectangle(0, 0, pnlCard.Width - 1, pnlCard.Height - 1);
                e.Graphics.DrawRectangle(borderPen, rect);
            }
        }

        private void ChkMostrarClave_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.UseSystemPasswordChar = !chkMostrarClave.Checked;
        }

        private void TxtClave_KeyDown(object sender, KeyEventArgs e)
        {
            VerificarCapsLock();
        }

        private void Campos_TextChanged(object sender, EventArgs e)
        {
            if (lblMensajeError.Visible)
            {
                lblMensajeError.Visible = false;
                lblMensajeError.Text = string.Empty;
                txtUsuario.BackColor = Color.FromArgb(248, 250, 252);
                txtClave.BackColor = Color.FromArgb(248, 250, 252);
            }
            VerificarCapsLock();
        }

        private void VerificarCapsLock()
        {
            lblCapsLock.Visible = Control.IsKeyLocked(Keys.CapsLock);
        }

        private void MostrarError(string mensaje, Control? controlObjetivo = null)
        {
            lblMensajeError.Text = $"⚠️ {mensaje}";
            lblMensajeError.Visible = true;

            if (controlObjetivo != null)
            {
                controlObjetivo.BackColor = Color.FromArgb(254, 242, 242);
                controlObjetivo.Focus();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtClave.Text.Trim();

            // Validaciones visuales y de entrada en capa UI
            if (string.IsNullOrWhiteSpace(usuario))
            {
                MostrarError("Debe ingresar el nombre de usuario.", txtUsuario);
                return;
            }

            if (string.IsNullOrWhiteSpace(clave))
            {
                MostrarError("Debe ingresar la contraseña.", txtClave);
                return;
            }

            try
            {
                btnIngresar.Enabled = false;
                btnIngresar.Text = "Verificando...";
                Cursor = Cursors.WaitCursor;

                UsuarioEN usuarioAutenticado = _usuarioBL.IniciarSesion(usuario, clave);

                // Guardar datos en sesión global
                SesionSistema.UsuarioID = usuarioAutenticado.UsuarioID;
                SesionSistema.NombreUsuario = usuarioAutenticado.NombreUsuario;
                SesionSistema.Rol = usuarioAutenticado.Rol;

                Cursor = Cursors.Default;
                btnIngresar.Enabled = true;
                btnIngresar.Text = "Iniciar Sesión";

                // Ocultar formulario de login y abrir menú principal
                this.Hide();

                using (FrmMenuPrincipal menu = new FrmMenuPrincipal())
                {
                    menu.ShowDialog();
                }

                // Al regresar del menú (cierre de sesión), limpiar campos
                txtClave.Clear();
                txtUsuario.Focus();
                lblMensajeError.Visible = false;
                this.Show();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                btnIngresar.Enabled = true;
                btnIngresar.Text = "Iniciar Sesión";

                MostrarError(ex.Message, txtClave);
                txtClave.SelectAll();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea salir del sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}