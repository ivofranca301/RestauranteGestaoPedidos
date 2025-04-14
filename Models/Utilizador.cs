using Newtonsoft.Json;

namespace RestauranteGestaoPedidos.Models
{
    public class Utilizador
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("papel")]
        public string Papel { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }
    }
}