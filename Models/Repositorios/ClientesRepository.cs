using System.Collections.Generic;
using System.Linq;
using RestauranteGestaoPedidos.Models;

namespace RestauranteGestaoPedidos.Models.Repositorios
{
    public class ClientesRepository
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public void Adicionar(Cliente cliente)
        {
            cliente.Id = _clientes.Count + 1;
            _clientes.Add(cliente);
        }

        public Cliente ObterPorEmail(string email)
        {
            return _clientes.FirstOrDefault(c => c.Email == email);
        }

        public List<Cliente> Listar()
        {
            return _clientes;
        }
    }
}