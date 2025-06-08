using System.Collections.Generic;

namespace RestauranteGestaoPedidos.Models.Repositorios
{
    public interface IProdutoRepository
    {
        List<Produto> ObterTodos();
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(int id);
        Produto ObterPorId(int id);
    }
}
