using System;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmMenuPrincipal : Form
    {
        private readonly CitaBL _citaBL = new CitaBL();

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            AplicarSeguridadSegunRol();
            ProcesarCitasVencidas();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            CargarLogotipo();
            CentrarDashboard();
        }

        private void FrmMenuPrincipal_Resize(object sender, EventArgs e)
        {
            CentrarDashboard();
        }

        private void CentrarDashboard()
        {
            if (pnlCardsContainer != null && pnlDashboardArea != null)
            {
                int left = Math.Max(20, (pnlDashboardArea.ClientSize.Width - pnlCardsContainer.Width) / 2);
                int top = Math.Max(20, (pnlDashboardArea.ClientSize.Height - pnlCardsContainer.Height) / 2);
                pnlCardsContainer.Location = new System.Drawing.Point(left, top);
            }
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        }

        private void CargarLogotipo()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string[] possiblePaths = new string[]
                {
                    System.IO.Path.Combine(basePath, "Assets", "logo.png"),
                    System.IO.Path.Combine(basePath, "image1.png"),
                    System.IO.Path.Combine(basePath, "..", "..", "..", "doc_extracted", "image1.png"),
                    System.IO.Path.Combine(basePath, "..", "..", "..", "ref_ui", "screenshot_downloads.png")
                };

                foreach (string path in possiblePaths)
                {
                    if (System.IO.File.Exists(path))
                    {
                        using (var img = System.Drawing.Image.FromFile(path))
                        {
                            picLogoHeader.Image = new System.Drawing.Bitmap(img);
                        }
                        return;
                    }
                }

                // Generar icono estilizado
                var iconBmp = new System.Drawing.Bitmap(48, 46);
                using (var g = System.Drawing.Graphics.FromImage(iconBmp))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var bgBrush = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(224, 242, 254)))
                    {
                        g.FillEllipse(bgBrush, 2, 2, 44, 42);
                    }
                    using (var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(2, 132, 199), 2))
                    {
                        g.DrawEllipse(pen, 2, 2, 44, 42);
                        g.DrawLine(pen, 16, 16, 32, 30);
                        g.DrawLine(pen, 32, 16, 16, 30);
                    }
                }
                picLogoHeader.Image = iconBmp;
            }
            catch { }
        }

        private void AplicarSeguridadSegunRol()
        {
            string rol = SesionSistema.Rol;
            lblUsuarioActivo.Text = $"Usuario: {SesionSistema.NombreUsuario} | Rol: {rol}";

            // Restricción de permisos según el Rol (Punto 25)
            if (rol == "Mecánico")
            {
                btnClientes.Enabled = false;
                btnCaja.Enabled = false;
                btnFacturacion.Enabled = false;
                btnEmpleados.Enabled = false;
                btnUsuarios.Enabled = false;
            }
            else if (rol == "Recepcionista")
            {
                btnEmpleados.Enabled = false;
                btnUsuarios.Enabled = false;
            }
            else if (rol != "Administrador")
            {
                btnUsuarios.Enabled = false;
            }
        }

        private void ProcesarCitasVencidas()
        {
            try
            {
                // Regla Fuera de Alcance #3: Marcar citas vencidas automáticamente como "No Recibida"
                _citaBL.ProcesarCitasVencidas(30);
            }
            catch { }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmClientes())
            {
                frm.ShowDialog();
            }
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmCajaFacturacion())
            {
                frm.ShowDialog();
            }
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmCajaFacturacion())
            {
                frm.ShowDialog();
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmEmpleados())
            {
                frm.ShowDialog();
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmUsuarios())
            {
                frm.ShowDialog();
            }
        }

        private void btnVehiculos_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmVehiculos())
            {
                frm.ShowDialog();
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmInventario())
            {
                frm.ShowDialog();
            }
        }

        private void btnOrdenesTrabajo_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmOrdenesTrabajo())
            {
                frm.ShowDialog();
            }
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmCitas())
            {
                frm.ShowDialog();
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            SesionSistema.UsuarioID = 0;
            SesionSistema.Rol = null;
            this.Close();
        }
    }
} 
