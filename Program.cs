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
                MessageBox.Show("Login bem-sucedido! A funcionalidade será implementada nas próximas fases.", "Sucesso");
            }
        }
    }
}