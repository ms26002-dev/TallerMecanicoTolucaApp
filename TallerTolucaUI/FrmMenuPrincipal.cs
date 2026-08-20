using System;
using System.Drawing;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmMenuPrincipal : Form
    {
        private readonly CitaBL _citaBL = new CitaBL();
        private Form? _formularioActivo = null;
        private Button? _botonNavActivo = null;

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            ConfigurarEventosNav();
            AplicarSeguridadSegunRol();
            ProcesarCitasVencidas();

            // Cargar por defecto la pantalla de Inicio / Clientes
            btnNavInicio_Click(btnNavInicio, EventArgs.Empty);
        }

        private void ConfigurarEventosNav()
        {
            btnNavInicio.Click += btnNavInicio_Click;
            btnNavEmpleados.Click += btnNavEmpleados_Click;
            btnNavClientes.Click += btnNavClientes_Click;
            btnNavInventario.Click += btnNavInventario_Click;
            btnNavVehiculos.Click += btnNavVehiculos_Click;
            btnNavOrdenes.Click += btnNavOrdenes_Click;
            btnNavCaja.Click += btnNavCaja_Click;
            btnNavFacturacion.Click += btnNavFacturacion_Click;
            btnNavCitas.Click += btnNavCitas_Click;
        }

        private void AplicarSeguridadSegunRol()
        {
            string rol = SesionSistema.Rol ?? "Administrador";
            lblUserName.Text = string.IsNullOrWhiteSpace(SesionSistema.NombreUsuario) ? "Admin Taller" : SesionSistema.NombreUsuario;
            lblUserRole.Text = rol;

            // Restricción de permisos según el Rol
            if (rol == "Mecánico")
            {
                btnNavClientes.Enabled = false;
                btnNavCaja.Enabled = false;
                btnNavFacturacion.Enabled = false;
                btnNavEmpleados.Enabled = false;
                btnNavClientes.ForeColor = Color.FromArgb(71, 85, 105);
                btnNavCaja.ForeColor = Color.FromArgb(71, 85, 105);
                btnNavFacturacion.ForeColor = Color.FromArgb(71, 85, 105);
                btnNavEmpleados.ForeColor = Color.FromArgb(71, 85, 105);
            }
            else if (rol == "Recepcionista")
            {
                btnNavEmpleados.Enabled = false;
                btnNavEmpleados.ForeColor = Color.FromArgb(71, 85, 105);
            }
        }

        private void ProcesarCitasVencidas()
        {
            try
            {
                _citaBL.ProcesarCitasVencidas(30);
            }
            catch { }
        }

        private void ActivarBotonNav(Button boton)
        {
            if (_botonNavActivo != null)
            {
                _botonNavActivo.BackColor = Color.Transparent;
                _botonNavActivo.ForeColor = Color.FromArgb(203, 213, 225);
                _botonNavActivo.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            }

            _botonNavActivo = boton;
            _botonNavActivo.BackColor = Color.FromArgb(30, 41, 59); // #1E293B
            _botonNavActivo.ForeColor = Color.FromArgb(0, 191, 255); // #00BFFF
            _botonNavActivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        public void AbrirFormularioEnPanel(Form formularioHijo, Button botonNav)
        {
            ActivarBotonNav(botonNav);

            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
            }

            _formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            pnlContenedorPrincipal.Controls.Clear();
            pnlContenedorPrincipal.Controls.Add(formularioHijo);
            pnlContenedorPrincipal.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        // ============================================
        // Vistas y Navegación
        // ============================================

        private void btnNavInicio_Click(object? sender, EventArgs e)
        {
            ActivarBotonNav(btnNavInicio);
            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
                _formularioActivo.Dispose();
                _formularioActivo = null;
            }
            pnlContenedorPrincipal.Controls.Clear();
            MostrarDashboardInicio();
        }

        private void MostrarDashboardInicio()
        {
            Panel pnlDash = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(240, 248, 255),
                Padding = new Padding(30, 30, 30, 30)
            };

            // Titulo
            Label lblTitulo = new Label
            {
                Text = "Panel de Control Principal",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(30, 25),
                AutoSize = true
            };

            Label lblSub = new Label
            {
                Text = "Bienvenido al Sistema de Gestión de Taller Mecánico Toluca.",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(32, 65),
                AutoSize = true
            };

            // KPI Cards Container
            FlowLayoutPanel flpKpis = new FlowLayoutPanel
            {
                Location = new Point(30, 110),
                Size = new Size(1100, 130),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = false
            };

            flpKpis.Controls.Add(CrearTarjetaKpi("CLIENTES REGISTRADOS", "Activos en sistema", "👤", Color.FromArgb(2, 132, 199)));
            flpKpis.Controls.Add(CrearTarjetaKpi("ÓRDENES ACTIVAS", "En diagnóstico o taller", "🛠️", Color.FromArgb(217, 119, 6)));
            flpKpis.Controls.Add(CrearTarjetaKpi("VEHÍCULOS", "Parque registrado", "🚗", Color.FromArgb(16, 185, 129)));
            flpKpis.Controls.Add(CrearTarjetaKpi("CITAS PROGRAMADAS", "Próximos servicios", "📅", Color.FromArgb(139, 92, 246)));

            // Accesos Rápidos
            Label lblAccesos = new Label
            {
                Text = "Módulos de Gestión Rápida",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(30, 260),
                AutoSize = true
            };

            FlowLayoutPanel flpAccesos = new FlowLayoutPanel
            {
                Location = new Point(30, 300),
                Size = new Size(1100, 280),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };

            flpAccesos.Controls.Add(CrearTarjetaModulo("👥 Empleados", "Administración del personal técnico y mecánico.", () => btnNavEmpleados_Click(this, EventArgs.Empty)));
            flpAccesos.Controls.Add(CrearTarjetaModulo("👤 Clientes", "Directorio y perfiles de clientes y propietarios.", () => btnNavClientes_Click(this, EventArgs.Empty)));
            flpAccesos.Controls.Add(CrearTarjetaModulo("🚗 Vehículos", "Gestión de vehículos asociados y tipos de automóvil.", () => btnNavVehiculos_Click(this, EventArgs.Empty)));
            flpAccesos.Controls.Add(CrearTarjetaModulo("🛠️ Órdenes de Trabajo", "Crear y finalizar órdenes de diagnóstico y reparación.", () => btnNavOrdenes_Click(this, EventArgs.Empty)));
            flpAccesos.Controls.Add(CrearTarjetaModulo("💵 Caja y Facturación", "Apertura de caja diaria y procesamiento de cobros.", () => btnNavCaja_Click(this, EventArgs.Empty)));
            flpAccesos.Controls.Add(CrearTarjetaModulo("📦 Inventario", "Catálogo de repuestos y movimientos de almacén.", () => btnNavInventario_Click(this, EventArgs.Empty)));

            pnlDash.Controls.AddRange(new Control[] { lblTitulo, lblSub, flpKpis, lblAccesos, flpAccesos });
            pnlContenedorPrincipal.Controls.Add(pnlDash);
        }

        private Panel CrearTarjetaKpi(string titulo, string subtitulo, string icono, Color colorAcento)
        {
            Panel card = new Panel
            {
                Size = new Size(240, 110),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 20, 0),
                Padding = new Padding(15)
            };

            Label lblIco = new Label
            {
                Text = icono,
                Font = new Font("Segoe UI Emoji", 16F),
                Location = new Point(180, 15),
                Size = new Size(45, 45),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblTit = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(15, 15),
                Size = new Size(160, 20)
            };

            Label lblVal = new Label
            {
                Text = "Operativo",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = colorAcento,
                Location = new Point(15, 40),
                Size = new Size(160, 30)
            };

            Label lblSub = new Label
            {
                Text = subtitulo,
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.FromArgb(148, 163, 184),
                Location = new Point(15, 75),
                Size = new Size(200, 20)
            };

            card.Controls.AddRange(new Control[] { lblIco, lblTit, lblVal, lblSub });
            return card;
        }

        private Panel CrearTarjetaModulo(string titulo, string descripcion, Action onClick)
        {
            Panel card = new Panel
            {
                Size = new Size(320, 115),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 20, 20),
                Cursor = Cursors.Hand,
                Padding = new Padding(18)
            };

            Label lblTit = new Label
            {
                Text = titulo,
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 23, 42),
                Location = new Point(15, 12),
                Size = new Size(280, 26),
                Cursor = Cursors.Hand
            };

            Label lblDesc = new Label
            {
                Text = descripcion,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(15, 42),
                Size = new Size(280, 40),
                Cursor = Cursors.Hand
            };

            Label lblAction = new Label
            {
                Text = "Abrir módulo ➔",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 191, 255),
                Location = new Point(15, 85),
                Size = new Size(280, 20),
                Cursor = Cursors.Hand
            };

            EventHandler clickHandler = (s, e) => onClick();
            card.Click += clickHandler;
            lblTit.Click += clickHandler;
            lblDesc.Click += clickHandler;
            lblAction.Click += clickHandler;

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(245, 250, 255);
            card.MouseLeave += (s, e) => card.BackColor = Color.White;

            card.Controls.AddRange(new Control[] { lblTit, lblDesc, lblAction });
            return card;
        }

        private void btnNavClientes_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmClientes(), btnNavClientes);
        }

        private void btnNavEmpleados_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmEmpleados(), btnNavEmpleados);
        }

        private void btnNavVehiculos_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmVehiculos(), btnNavVehiculos);
        }

        private void btnNavOrdenes_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmOrdenesTrabajo(), btnNavOrdenes);
        }

        private void btnNavCaja_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmCajaFacturacion(), btnNavCaja);
        }

        private void btnNavFacturacion_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmCajaFacturacion(), btnNavFacturacion);
        }

        private void btnNavInventario_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmInventario(), btnNavInventario);
        }

        private void btnNavCitas_Click(object? sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FrmCitas(), btnNavCitas);
        }

        private void btnCerrarSesion_Click(object? sender, EventArgs e)
        {
            var r = MessageBox.Show("¿Está seguro de que desea cerrar la sesión actual?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                SesionSistema.UsuarioID = 0;
                SesionSistema.NombreUsuario = string.Empty;
                SesionSistema.Rol = string.Empty;
                this.Close();
            }
        }
    }
}
