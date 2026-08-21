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
            }
            else if (rol == "Recepcionista")
            {
                btnEmpleados.Enabled = false;
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
