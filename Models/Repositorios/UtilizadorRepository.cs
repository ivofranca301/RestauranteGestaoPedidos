using Newtonsoft.Json;
using RestauranteGestaoPedidos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Data
{
    public class UtilizadorRepository
    {
        private readonly string _filePath;

        public UtilizadorRepository()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "utilizadores.json");
        }

        public List<Utilizador> GetUtilizadores()
        {
            if (!File.Exists(_filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_filePath));
                var utilizadoresIniciais = new List<Utilizador>
                {
                    new Utilizador { Id = 1, Nome = "Admin", Email = "admin@restaurante.com", Papel = "Admin", Senha = "admin123" },
                    new Utilizador { Id = 2, Nome = "Utilizador", Email = "user@restaurante.com", Papel = "Utilizador", Senha = "user123" }
                };
                SaveUtilizadores(utilizadoresIniciais);
                return utilizadoresIniciais;
            }

            try
            {
                var json = File.ReadAllText(_filePath);
                var utilizadores = JsonConvert.DeserializeObject<List<Utilizador>>(json);
                return utilizadores ?? new List<Utilizador>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar utilizadores: {ex.Message}", "Erro");
                return new List<Utilizador>();
            }
        }

        public void SaveUtilizadores(List<Utilizador> utilizadores)
        {
            try
            {
                var json = JsonConvert.SerializeObject(utilizadores, Formatting.Indented);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar utilizadores: {ex.Message}", "Erro");
            }
        }
    }
}