using RestauranteGestaoPedidos.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteGestaoPedidos.Repositories
{
    public class PedidosRepository
    {
        private List<Pedido> _pedidos = new List<Pedido>();
        private int _nextId = 1;

        public void Adicionar(Pedido pedido)
        {
            pedido.Id = _nextId++;
            pedido.CalcularTotal(); // Garante que o total está correto
            _pedidos.Add(pedido);
        }

        public List<Pedido> Listar()
        {
            return _pedidos;
        }

        public Pedido BuscarPorId(int id)
        {
            return _pedidos.FirstOrDefault(p => p.Id == id);
        }

        public void Atualizar(Pedido pedido)
        {
            var existente = BuscarPorId(pedido.Id);
            if (existente != null)
            {
                existente.ClienteId = pedido.ClienteId;
                existente.Itens = pedido.Itens;
                existente.Data = pedido.Data;
                existente.Status = pedido.Status;
                existente.CalcularTotal();
            }
        }

        public void Remover(int id)
        {
            var pedido = BuscarPorId(id);
            if (pedido != null)
                _pedidos.Remove(pedido);
        }
    }
}