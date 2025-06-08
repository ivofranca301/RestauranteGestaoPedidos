using Newtonsoft.Json;
using RestauranteGestaoPedidos.Models;
using RestauranteGestaoPedidos.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RestauranteGestaoPedidos.Models.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _filePath;

        public ProdutoRepository()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "produtos.json");
        }

        public List<Produto> ObterTodos()
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
                throw new IOException($"Erro ao carregar produtos: {ex.Message}", ex);
            }
        }

        public Produto ObterPorId(int id)
        {
            return ObterTodos().FirstOrDefault(p => p.Id == id);
        }

        public void Adicionar(Produto produto)
        {
            try
            {
                var produtos = ObterTodos();
                produto.Id = produtos.Any() ? produtos.Max(p => p.Id) + 1 : 1;
                produtos.Add(produto);
                SaveProdutos(produtos);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao adicionar o produto.", ex);
            }
        }

        public void Atualizar(Produto produto)
        {
            try
            {
                var produtos = ObterTodos();
                var index = produtos.FindIndex(p => p.Id == produto.Id);
                if (index >= 0)
                {
                    produtos[index] = produto;
                    SaveProdutos(produtos);
                }
                else
                {
                    throw new KeyNotFoundException("Produto não encontrado para atualização.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao atualizar o produto.", ex);
            }
        }

        public void Remover(int id)
        {
            try
            {
                var produtos = ObterTodos();
                var produto = produtos.FirstOrDefault(p => p.Id == id);
                if (produto != null)
                {
                    produtos.Remove(produto);
                    SaveProdutos(produtos);
                }
                else
                {
                    throw new KeyNotFoundException("Produto não encontrado para remoção.");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao remover o produto.", ex);
            }
        }

        private void SaveProdutos(List<Produto> produtos)
        {
            try
            {
                var json = JsonConvert.SerializeObject(produtos, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                throw new IOException($"Erro ao guardar os produtos: {ex.Message}", ex);
            }
        }
    }
}
