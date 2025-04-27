using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteGestaoPedidos.Models
{
    public class Pedido
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cliente")]
        public string Cliente { get; set; }

        [JsonProperty("itens")]
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

        [JsonProperty("data")]
        public DateTime Data { get; set; }

        [JsonProperty("status")]
        public StatusPedido Status { get; set; } // Deve ser StatusPedido, não string

        [JsonProperty("total")]
        public decimal Total => Itens.Sum(i => i.Preco * i.Quantidade);
    }
}