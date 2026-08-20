using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TallerToluca.BL;
using TallerToluca.EN;

namespace TallerTolucaUI
{
    public partial class FrmClientes : Form
    {
        private readonly ClienteBL _clienteBL = new ClienteBL();

        private List<ClienteEN> _todosLosClientes = new List<ClienteEN>();
        private List<ClienteEN> _clientesFiltrados = new List<ClienteEN>();

        private const int TamanoPagina = 5;
        private int _paginaActual = 1;

        public FrmClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        // ---------- Carga y filtrado ----------

        private void CargarClientes()
        {
            try
            {
                _todosLosClientes = _clienteBL.ObtenerTodosLosClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _todosLosClientes = new List<ClienteEN>();
            }

            _paginaActual = 1;
            AplicarFiltros();
        }

        private void FiltrosCambiaron(object sender, EventArgs e)
        {
            _paginaActual = 1;
            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            string texto = txtBuscar.Text.Trim();
            string estado = cboEstadoFiltro.SelectedItem?.ToString() ?? "Todos los estados";

            IEnumerable<ClienteEN> consulta = _todosLosClientes;

            if (!string.IsNullOrWhiteSpace(texto))
            {
                consulta = consulta.Where(c =>
                    (c.NombreCompleto ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    (c.Telefono ?? "").Contains(texto, StringComparison.OrdinalIgnoreCase) ||
                    c.ClienteID.ToString().Contains(texto));
            }

            if (estado != "Todos los estados")
            {
                consulta = consulta.Where(c => c.Estado == estado);
            }

            _clientesFiltrados = consulta.ToList();
            MostrarPagina();
        }

        // ---------- Paginación ----------

        private int TotalPaginas => Math.Max(1, (int)Math.Ceiling(_clientesFiltrados.Count / (double)TamanoPagina));

        private void MostrarPagina()
        {
            if (_paginaActual > TotalPaginas) _paginaActual = TotalPaginas;
            if (_paginaActual < 1) _paginaActual = 1;

            var pagina = _clientesFiltrados
                .Skip((_paginaActual - 1) * TamanoPagina)
                .Take(TamanoPagina)
                .ToList();

            dgvClientes.Rows.Clear();
            foreach (var c in pagina)
            {
                int fila = dgvClientes.Rows.Add(
                    $"CLI-{c.ClienteID:000}",
                    c.NombreCompleto,
                    c.Telefono,
                    c.VehiculosAsociados,
                    c.Estado,
                    "Consultar",
                    "Editar",
                    "Eliminar");
                dgvClientes.Rows[fila].Tag = c.ClienteID;
            }

            ActualizarResumenYPaginador();
        }

        private void ActualizarResumenYPaginador()
        {
            int total = _clientesFiltrados.Count;
            int desde = total == 0 ? 0 : ((_paginaActual - 1) * TamanoPagina) + 1;
            int hasta = Math.Min(_paginaActual * TamanoPagina, total);
            lblResumenRegistros.Text = total == 0
                ? "No se encontraron registros"
                : $"Mostrando {desde}–{hasta} de {total} registros";

            flpPaginas.Controls.Clear();

            var btnAnterior = CrearBotonPagina("‹", false);
            btnAnterior.Enabled = _paginaActual > 1;
            btnAnterior.Click += (s, e) => { _paginaActual--; MostrarPagina(); };
            flpPaginas.Controls.Add(btnAnterior);

            for (int i = 1; i <= TotalPaginas; i++)
            {
                int numeroPagina = i;
                var btnPagina = CrearBotonPagina(i.ToString(), i == _paginaActual);
                btnPagina.Click += (s, e) => { _paginaActual = numeroPagina; MostrarPagina(); };
                flpPaginas.Controls.Add(btnPagina);
            }

            var btnSiguiente = CrearBotonPagina("›", false);
            btnSiguiente.Enabled = _paginaActual < TotalPaginas;
            btnSiguiente.Click += (s, e) => { _paginaActual++; MostrarPagina(); };
            flpPaginas.Controls.Add(btnSiguiente);
        }

        private Button CrearBotonPagina(string texto, bool activa)
        {
            var btn = new Button
            {
                Text = texto,
                Size = new Size(32, 32),
                Font = new Font("Segoe UI", 9.5F, activa ? FontStyle.Bold : FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Margin = new Padding(3, 0, 0, 0)
            };
            btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btn.FlatAppearance.BorderSize = 1;
            if (activa)
            {
                btn.BackColor = Color.FromArgb(0, 191, 255);
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderSize = 0;
            }
            else
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(51, 65, 85);
            }
            return btn;
        }

        // ---------- Presentación de la columna Estado como "badge" ----------

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvClientes.Columns[e.ColumnIndex].Name != "Estado" || e.Value == null) return;

            bool activo = e.Value.ToString() == "Activo";
            var celda = dgvClientes.Rows[e.RowIndex].Cells[e.ColumnIndex];
            celda.Style.BackColor = activo ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
            celda.Style.ForeColor = activo ? Color.FromArgb(21, 128, 61) : Color.FromArgb(185, 28, 28);
            celda.Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            celda.Style.SelectionBackColor = celda.Style.BackColor;
            celda.Style.SelectionForeColor = celda.Style.ForeColor;
        }

        // ---------- Acciones por fila ----------

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columna = dgvClientes.Columns[e.ColumnIndex].Name;
            if (columna != "Consultar" && columna != "Editar" && columna != "Eliminar") return;

            int clienteId = (int)dgvClientes.Rows[e.RowIndex].Tag;
            var cliente = _todosLosClientes.FirstOrDefault(c => c.ClienteID == clienteId);
            if (cliente == null) return;

            switch (columna)
            {
                case "Consultar":
                    using (var frm = new FrmClienteDetalle(FrmClienteDetalle.ModoFormulario.Consultar, cliente))
                        frm.ShowDialog();
                    break;

                case "Editar":
                    using (var frm = new FrmClienteDetalle(FrmClienteDetalle.ModoFormulario.Editar, cliente))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                            CargarClientes();
                    }
                    break;

                case "Eliminar":
                    var confirmacion = MessageBox.Show(
                        $"¿Desea eliminar al cliente \"{cliente.NombreCompleto}\"?",
                        "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmacion == DialogResult.Yes)
                    {
                        try
                        {
                            _clienteBL.EliminarCliente(clienteId);
                            MessageBox.Show("Cliente eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarClientes();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }

        private void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmClienteDetalle(FrmClienteDetalle.ModoFormulario.Nuevo, null))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    CargarClientes();
            }
        }

        // ---------- Exportar / Importar CSV ----------

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using var sfd = new SaveFileDialog
            {
                Filter = "Archivo CSV (*.csv)|*.csv",
                FileName = "Clientes.csv"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var lineas = new List<string> { "ClienteID,NombreCompleto,Telefono,Correo,Direccion,Estado" };
                lineas.AddRange(_clientesFiltrados.Select(c =>
                    $"{c.ClienteID},{c.NombreCompleto},{c.Telefono},{c.Correo},{c.Direccion},{c.Estado}"));
                File.WriteAllLines(sfd.FileName, lineas);
                MessageBox.Show("Clientes exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportarCSV_Click(object sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog { Filter = "Archivo CSV (*.csv)|*.csv" };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var lineas = File.ReadAllLines(ofd.FileName);
                int importados = 0;
                foreach (var linea in lineas.Skip(1))
                {
                    if (string.IsNullOrWhiteSpace(linea)) continue;
                    var campos = linea.Split(',');
                    if (campos.Length < 3) continue;

                    var cliente = new ClienteEN
                    {
                        NombreCompleto = campos[1].Trim(),
                        Telefono = campos[2].Trim(),
                        Correo = campos.Length > 3 ? campos[3].Trim() : null,
                        Direccion = campos.Length > 4 ? campos[4].Trim() : null
                    };

                    _clienteBL.RegistrarCliente(cliente);
                    importados++;
                }

                MessageBox.Show($"{importados} cliente(s) importado(s) correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Importar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
