using RestauranteGestaoPedidos.Models;
using RestauranteGestaoPedidos.Repositories;
using System;

namespace RestauranteGestaoPedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testar CardapioRepository
            var cardapioRepo = new CardapioRepository();
            var item1 = new ItemCardapio { Nome = "Hamburguer", Preco = 15.00m, Categoria = "Prato Principal" };
            var item2 = new ItemCardapio { Nome = "Sumo", Preco = 5.00m, Categoria = "Bebida" };
            cardapioRepo.Adicionar(item1);
            cardapioRepo.Adicionar(item2);
            Console.WriteLine("Itens no cardápio:");
            foreach (var item in cardapioRepo.Listar())
            {
                Console.WriteLine($"{item.Id}: {item.Nome} - €{item.Preco}");
            }

            // Testar PedidosRepository
            var pedidosRepo = new PedidosRepository();
            var pedido = new Pedido
            {
                ClienteId = 1, // Simula um usuário da fase 1
                Data = DateTime.Now
            };
            pedido.Itens.Add(item1);
            pedido.Itens.Add(item2);
            pedidosRepo.Adicionar(pedido);
            Console.WriteLine("\nPedidos:");
            foreach (var p in pedidosRepo.Listar())
            {
                Console.WriteLine($"Pedido {p.Id}: Total €{p.Total}, Status: {p.Status}");
            }
        }
    }
}