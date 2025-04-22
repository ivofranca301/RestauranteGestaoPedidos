using RestauranteGestaoPedidos.Data;
using RestauranteGestaoPedidos.Models;
using RestauranteGestaoPedidos.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace RestauranteGestaoPedidos.Controllers
{
    public class ClienteController
    {
        private readonly ClientesRepository _ClientesRepository;

        public event EventHandler<(bool Sucesso, string Mensagem, string Papel)> ResponderLogin;

        public ClienteController()
        {
            _ClientesRepository = new ClientesRepository();
        }

        public void Login(string email, string senha)
        {
            var cliente = _ClientesRepository.ObterPorEmail(email);
            if (cliente == null)
            {
                ResponderLogin?.Invoke(this, (false, "Email não encontrado.", null));
                return;
            }
            if (cliente.Senha != senha)
            {
                ResponderLogin?.Invoke(this, (false, "Senha incorreta.", null));
                return;       
            }
            else
            {
                ResponderLogin?.Invoke(this, (true, "Login bem-sucedido.", cliente.Papel));
            }
        }


        public void CriarConta(string nome, string email, string senha, string papel)
        {
            var cliente = new Cliente
            {
                Nome = nome,
                Email = email,
                Senha = senha,
                Papel = papel
            };
            _ClientesRepository.Adicionar(cliente);
        }
    }
}


