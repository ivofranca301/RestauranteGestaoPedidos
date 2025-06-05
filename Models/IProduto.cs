namespace RestauranteGestaoPedidos.Models
{
    public interface IProduto
    {
        int Id { get; }
        string Nome { get; }
        decimal Preco { get; }
    }
}
