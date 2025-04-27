using Newtonsoft.Json;

namespace RestauranteGestaoPedidos.Models
{
    public class ItemPedido
    {
        [JsonProperty("produtoId")]
        public int ProdutoId { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }

        [JsonProperty("preco")]
        public decimal Preco { get; set; }

        [JsonProperty("notas")]
        public string Notas { get; set; } // Novo campo para observações por exemplo "sem cebola"
    }
}