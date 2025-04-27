using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Views;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var clienteController = new ClienteController();
            var formLogin = new FormLogin(clienteController);

            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                // NOVO: criar os controladores e formulários
                var produtoController = new ProdutoController();

                // Primeiro criamos um "Form Novo Pedido" vazio
                NovoPedidoForm formNovoPedido = null;

                // Depois criamos o controller e ligamos a view
                var pedidoController = new PedidoController();

                formNovoPedido = new NovoPedidoForm(pedidoController, produtoController);

                // Agora associamos no controller
                pedidoController.AtribuirView(formNovoPedido);

                // Finalmente, abrimos o form
                formNovoPedido.ShowDialog();
            }
        }
    }
}
