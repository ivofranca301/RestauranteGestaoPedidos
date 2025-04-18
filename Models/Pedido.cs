using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteGestaoPedidos.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } // Conecta ao Utilizador da fase 1
        public List<ItemCardapio> Itens { get; set; } = new List<ItemCardapio>();
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; } = "Pendente"; // Valor padrão

        // Calcula o total com base nos itens
        public void CalcularTotal()
        {
            Total = Itens.Sum(item => item.Preco);
        }
    }
}