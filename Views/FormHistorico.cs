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
            try
            {
                dataGridViewHistorico.DataSource = null;
                dataGridViewHistorico.DataSource = _pedidoController.ListarPedidos();
                if (dataGridViewHistorico.Columns["Preco"] != null)
                {
                    dataGridViewHistorico.Columns["Preco"].DefaultCellStyle.Format = "€0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar histórico de pedidos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewHistorico.Enabled = false;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
