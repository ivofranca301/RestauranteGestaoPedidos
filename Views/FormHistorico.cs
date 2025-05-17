using RestauranteGestaoPedidos.Controllers;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormHistorico : Form
    {
        private readonly PedidoController _pedidoController;

        public FormHistorico(PedidoController pedidoController)
        {
            InitializeComponent();
            _pedidoController = pedidoController;
            CarregarHistorico();
        }

        private void CarregarHistorico()
        {
            dataGridViewHistorico.DataSource = _pedidoController.ListarPedidos();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}