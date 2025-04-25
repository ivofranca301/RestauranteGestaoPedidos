using RestauranteGestaoPedidos.Models;
using System.Collections.Generic;
using System;
using RestauranteGestaoPedidos.Models.Repositorios;
using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Data;
using System.Linq;

public class PedidoController
{
    private readonly PedidoRepository _pedidoRepository;

    public event EventHandler<string> Notificar;

    public PedidoController()
    {
        _pedidoRepository = new PedidoRepository();
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
}
