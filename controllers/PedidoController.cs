using RestauranteGestaoPedidos.Models;
using System.Collections.Generic;
using System;
using RestauranteGestaoPedidos.Models.Repositorios;
using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Data;
using System.Linq;
using RestauranteGestaoPedidos.Views;

public class PedidoController
{
    private readonly PedidoRepository _pedidoRepository;
    private NovoPedidoForm _view;


    public event EventHandler<string> Notificar;

    public PedidoController()
    {
        _pedidoRepository = new PedidoRepository();
    }

    public void AtribuirView(NovoPedidoForm view)
    {
        _view = view;
        _view.PedidoCriado += OnPedidoCriado;
    }


    public List<Pedido> ListarPedidos()
    {
        return _pedidoRepository.GetPedidos();
    }

    public void CriarPedido(Pedido pedido)
    {
        var pedidos = _pedidoRepository.GetPedidos();
        pedido.Id = pedidos.Any() ? pedidos.Max(p => p.Id) + 1 : 1;
        pedidos.Add(pedido);
        _pedidoRepository.SavePedidos(pedidos);
        Notificar?.Invoke(this, "Pedido criado");
    }

    public void AtualizarPedido(Pedido pedido)
    {
        var pedidos = _pedidoRepository.GetPedidos();
        var index = pedidos.FindIndex(p => p.Id == pedido.Id);
        if (index >= 0)
        {
            pedidos[index] = pedido;
            _pedidoRepository.SavePedidos(pedidos);
            Notificar?.Invoke(this, "Pedido editado");
        }
    }

    public void RemoverPedido(int id)
    {
        var pedidos = _pedidoRepository.GetPedidos();
        var pedido = pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido != null)
        {
            pedidos.Remove(pedido);
            _pedidoRepository.SavePedidos(pedidos);
            Notificar?.Invoke(this, "Pedido removido");
        }
    }

    private void OnPedidoCriado(Pedido pedido)
    {
        try
        {
            if (ValidarPedido(pedido, out string mensagemErro))
            {
                CriarPedido(pedido);
                Notificar?.Invoke(this, "Pedido criado com sucesso!");
            }
            else
            {
                Notificar?.Invoke(this, mensagemErro); // Mensagem prestável
            }
        }
        catch (Exception ex)
        {
            Notificar?.Invoke(this, $"Erro ao criar pedido: {ex.Message}");
        }
    }

    private bool ValidarPedido(Pedido pedido, out string mensagemErro)
    {
        mensagemErro = string.Empty;

        if (pedido == null)
        {
            mensagemErro = "Pedido nulo.";
            return false;
        }

        if (string.IsNullOrWhiteSpace(pedido.Cliente))
        {
            mensagemErro = "O nome do cliente é obrigatório.";
            return false;
        }

        if (pedido.Itens == null || !pedido.Itens.Any())
        {
            mensagemErro = "É necessário adicionar pelo menos um produto ao pedido.";
            return false;
        }

        var item = pedido.Itens.First();
        if (item.Quantidade <= 0)
        {
            mensagemErro = "A quantidade do produto deve ser superior a zero.";
            return false;
        }

        return true;
    }


}
