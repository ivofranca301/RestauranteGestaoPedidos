using Newtonsoft.Json;

namespace RestauranteGestaoPedidos.Models
{
    public class Produto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("preço")]
        public decimal Preco { get; set; }

        [JsonProperty("disponível")]
        public bool Disponivel { get; set; }
    }
}