using RestauranteGestaoPedidos.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteGestaoPedidos.Repositories
{
    public class CardapioRepository
    {
        private List<ItemCardapio> _itens = new List<ItemCardapio>();
        private int _nextId = 1;

        public void Adicionar(ItemCardapio item)
        {
            item.Id = _nextId++;
            _itens.Add(item);
        }

        public List<ItemCardapio> Listar()
        {
            return _itens;
        }

        public ItemCardapio BuscarPorId(int id)
        {
            return _itens.FirstOrDefault(i => i.Id == id);
        }

        public void Atualizar(ItemCardapio item)
        {
            var existente = BuscarPorId(item.Id);
            if (existente != null)
            {
                existente.Nome = item.Nome;
                existente.Preco = item.Preco;
                existente.Categoria = item.Categoria;
            }
        }

        public void Remover(int id)
        {
            var item = BuscarPorId(id);
            if (item != null)
                _itens.Remove(item);
        }
    }
}