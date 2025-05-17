using RestauranteGestaoPedidos.Models.repositorios;
using RestauranteGestaoPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RestauranteGestaoPedidos.Controllers
{
    public class ProdutoController
    {
        private readonly ProdutoRepository _produtoRepository;

        public event EventHandler<string> Notificar;

        public ProdutoController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        public List<Produto> ListarProdutos()
        {
            return _produtoRepository.GetProdutos();
        }

        public void AdicionarProduto(Produto produto)
        {
            var produtos = _produtoRepository.GetProdutos();
            produto.Id = produtos.Any() ? produtos.Max(p => p.Id) + 1 : 1;
            produtos.Add(produto);
            _produtoRepository.SaveProdutos(produtos);
            Notificar?.Invoke(this, "Produto adicionado");
        }

        public void AtualizarProduto(Produto produto)
        {
            var produtos = _produtoRepository.GetProdutos();
            var index = produtos.FindIndex(p => p.Id == produto.Id);
            if (index >= 0)
            {
                produtos[index] = produto;
                _produtoRepository.SaveProdutos(produtos);
                Notificar?.Invoke(this, "Produto editado");
            }
        }

        public void RemoverProduto(int id)
        {
            var produtos = _produtoRepository.GetProdutos();
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            if (produto != null)
            {
                produtos.Remove(produto);
                _produtoRepository.SaveProdutos(produtos);
                Notificar?.Invoke(this, "Produto removido");
            }
        }
    }
}