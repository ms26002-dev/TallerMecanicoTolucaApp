using System;
using TallerToluca.DAL;
using TallerToluca.EN;

namespace TallerToluca.BL
{
    public class ClienteBL
    {
        private readonly ClienteDAL _clienteDAL = new ClienteDAL();

        public int RegistrarCliente(ClienteEN cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.NombreCompleto))
                throw new ArgumentException("El nombre completo del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Telefono))
                throw new ArgumentException("El teléfono del cliente es obligatorio.");

            return _clienteDAL.Registrar(cliente);
        }

        public int ModificarCliente(ClienteEN cliente)
        {
            if (cliente.ClienteID <= 0)
                throw new ArgumentException("ID de cliente no válido.");

            if (string.IsNullOrWhiteSpace(cliente.NombreCompleto))
                throw new ArgumentException("El nombre completo del cliente es obligatorio.");

            return _clienteDAL.Modificar(cliente);
        }

        public int EliminarCliente(int clienteID)
        {
            if (clienteID <= 0)
                throw new ArgumentException("ID de cliente no válido.");

            return _clienteDAL.EliminarLogico(clienteID);
        }

        public List<ClienteEN> ObtenerClientesActivos()
        {
            return _clienteDAL.ConsultarActivos();
        }

        public List<ClienteEN> ObtenerTodosLosClientes()
        {
            return _clienteDAL.ConsultarTodos();
        }
    }
}