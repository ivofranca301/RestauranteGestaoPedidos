using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Views;
using RestauranteGestaoPedidos.Models.Repositorios;
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
                IProdutoRepository produtoRepository = new ProdutoRepository();
                Application.Run(new FormPrincipal(formLogin.EmailLogado, formLogin.PapelLogado, produtoRepository));
            }
        }
    }
}
