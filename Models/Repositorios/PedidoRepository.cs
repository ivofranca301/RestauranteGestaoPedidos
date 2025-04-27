using Newtonsoft.Json;
using RestauranteGestaoPedidos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                var pedidosIniciais = new List<Pedido>();
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

        public void AdicionarPedido(Pedido pedido)
        {
            var pedidos = GetPedidos();
            pedido.Id = pedidos.Any() ? pedidos.Max(p => p.Id) + 1 : 1;
            pedidos.Add(pedido);
            SavePedidos(pedidos);
        }

        public void AtualizarStatus(int pedidoId, StatusPedido novoStatus)
        {
            var pedidos = GetPedidos();
            var pedido = pedidos.FirstOrDefault(p => p.Id == pedidoId);
            if (pedido != null)
            {
                pedido.Status = novoStatus; // Aqui deve ser StatusPedido, não string
                SavePedidos(pedidos);
            }
        }
    }
}