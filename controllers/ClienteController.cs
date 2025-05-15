using RestauranteGestaoPedidos.Data;
using RestauranteGestaoPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestauranteGestaoPedidos.Controllers
{
    public class ClienteController
    {
        private readonly UtilizadorRepository _utilizadorRepository;

        public event EventHandler<(bool Sucesso, string Mensagem, string Papel)> ResponderLogin;

        public ClienteController()
        {
            _utilizadorRepository = new UtilizadorRepository();
        }

        public void Login(string email, string senha)
        {
            var utilizadores = _utilizadorRepository.GetUtilizadores();
            var utilizador = utilizadores.Find(u => u.Email.ToLower() == email.ToLower() && u.Senha == senha);
            if (utilizador == null)
            {
                ResponderLogin?.Invoke(this, (false, "Credenciais inválidas.", null));
            }
            else
            {
                ResponderLogin?.Invoke(this, (true, "Login bem-sucedido.", utilizador.Papel));
            }
        }

        public string GetPermissoes(string email)
        {
            var utilizadores = _utilizadorRepository.GetUtilizadores();
            var utilizador = utilizadores.Find(u => u.Email.ToLower() == email.ToLower());
            return utilizador?.Papel ?? "Utilizador";
        }

        public List<Utilizador> GetUtilizadores()
        {
            return _utilizadorRepository.GetUtilizadores();
        }

        public void CriarConta(Utilizador novoUtilizador)
        {
            var utilizadores = _utilizadorRepository.GetUtilizadores();
            novoUtilizador.Id = utilizadores.Any() ? utilizadores.Max(u => u.Id) + 1 : 1;
            utilizadores.Add(novoUtilizador);
            _utilizadorRepository.SaveUtilizadores(utilizadores);
        }

        public void AtualizarUtilizador(Utilizador usuario)
        {
            var utilizadores = _utilizadorRepository.GetUtilizadores();
            var index = utilizadores.FindIndex(u => u.Id == usuario.Id);
            if (index >= 0)
            {
                utilizadores[index] = usuario;
                _utilizadorRepository.SaveUtilizadores(utilizadores);
            }
        }
    }
}

