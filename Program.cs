using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Views;
using System;
using System.Windows.Forms;
using RestauranteGestaoPedidos.Models;

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
                Application.Run(new FormPrincipal(formLogin.EmailLogado, formLogin.PapelLogado));
            }
        }
    }
}