using Newtonsoft.Json;

namespace RestauranteGestaoPedidos.Models
{
    public class Produto : IProduto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("preco")]
        public decimal Preco { get; set; }

        [JsonIgnore]
        public string PrecoFormatado => $"€{Preco:F2}";
    }
}