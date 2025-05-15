using Newtonsoft.Json;
using RestauranteGestaoPedidos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Data
{
    public class ProdutoRepository
    {
        private readonly string _filePath;

        public ProdutoRepository()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "produtos.json");
        }

        public List<Produto> GetProdutos()
        {
            if (!File.Exists(_filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
                var produtosIniciais = new List<Produto>
                {
                    new Produto { Id = 1, Nome = "Pizza Margherita", Preco = 30.00m },
                    new Produto { Id = 2, Nome = "Refrigerante", Preco = 5.00m }
                };
                SaveProdutos(produtosIniciais);
                return produtosIniciais;
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                var produtos = JsonConvert.DeserializeObject<List<Produto>>(json);
                return produtos ?? new List<Produto>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro");
                return new List<Produto>();
            }
        }

        public void SaveProdutos(List<Produto> produtos)
        {
            try
            {
                var json = JsonConvert.SerializeObject(produtos, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar produtos: {ex.Message}", "Erro");
            }
        }
    }
}