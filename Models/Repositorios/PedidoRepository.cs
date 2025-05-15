using Newtonsoft.Json;
using RestauranteGestaoPedidos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Data
{
    public class PedidoRepository
    {
        private readonly string _filePath;

        public PedidoRepository()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "pedidos.json");
        }

        public List<Pedido> GetPedidos()
        {
            if (!File.Exists(_filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
                var pedidosIniciais = new List<Pedido>
                {
                    new Pedido
                    {
                        Id = 1,
                        Cliente = "João Silva",
                        Itens = new List<ItemPedido>
                        {
                            new ItemPedido { ProdutoId = 1, Nome = "Pizza Margherita", Quantidade = 2, Preco = 30.00m },
                            new ItemPedido { ProdutoId = 2, Nome = "Refrigerante", Quantidade = 1, Preco = 5.00m }
                        },
                        Data = DateTime.Now,
                        Status = StatusPedido.Pendente
                    }
                };
                SavePedidos(pedidosIniciais);
                return pedidosIniciais;
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                var pedidos = JsonConvert.DeserializeObject<List<Pedido>>(json);
                return pedidos ?? new List<Pedido>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pedidos: {ex.Message}", "Erro");
                return new List<Pedido>();
            }
        }

        public void SavePedidos(List<Pedido> pedidos)
        {
            try
            {
                var json = JsonConvert.SerializeObject(pedidos, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar pedidos: {ex.Message}", "Erro");
            }
        }
    }
}