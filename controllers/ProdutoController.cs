using RestauranteGestaoPedidos.Models;
using RestauranteGestaoPedidos.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteGestaoPedidos.Controllers
{
    public class ProdutoController
    {
        private readonly IProdutoRepository _produtoRepository;

        public event EventHandler<string> Notificar;

        // Construtor modificado para injeção da interface
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public List<Produto> ListarProdutos()
        {
            return _produtoRepository.ObterTodos();
        }

        public void AdicionarProduto(Produto produto)
        {
            _produtoRepository.Adicionar(produto);
            Notificar?.Invoke(this, "Produto adicionado");
        }

        public void AtualizarProduto(Produto produto)
        {
            _produtoRepository.Atualizar(produto);
            Notificar?.Invoke(this, "Produto editado");
        }

        public void RemoverProduto(int id)
        {
            _produtoRepository.Remover(id);
            Notificar?.Invoke(this, "Produto removido");
        }
        public IProdutoRepository Repositorio => _produtoRepository;
    }
}
