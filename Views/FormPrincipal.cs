using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Models;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormPrincipal : Form
    {
        private readonly PedidoController _pedidoController;
        private readonly string _papel;

        public FormPrincipal(string email, string papel)
        {
            InitializeComponent();
            _pedidoController = new PedidoController();
            _pedidoController.Notificar += PedidoController_Notificar;
            _papel = papel;
            CarregarPedidos();
            if (_papel != "Admin")
            {
                btnPermissoes.Visible = false;
            }
        }

        private void PedidoController_Notificar(object sender, string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso");
        }

        private void CarregarPedidos()
        {
            var pedidos = _pedidoController.ListarPedidos();
            dataGridViewPedidos.DataSource = pedidos;
        }

        private void btnNovoPedido_Click(object sender, EventArgs e)
        {
            var novoPedidoForm = new NovoPedidoForm(_pedidoController, new ProdutoController());
            if (novoPedidoForm.ShowDialog() == DialogResult.OK)
            {
                CarregarPedidos();
            }
        }

        private void btnEditarPedido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um pedido para editar.", "Aviso");
                return;
            }

            var pedidoSelecionado = (Pedido)dataGridViewPedidos.SelectedRows[0].DataBoundItem;
            var novoPedidoForm = new NovoPedidoForm(_pedidoController, new ProdutoController(), pedidoSelecionado);
            if (novoPedidoForm.ShowDialog() == DialogResult.OK)
            {
                CarregarPedidos();
            }
        }

        private void btnRemoverPedido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um pedido para remover.", "Aviso");
                return;
            }

            var pedidoSelecionado = (Pedido)dataGridViewPedidos.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Deseja remover o pedido #{pedidoSelecionado.Id} de {pedidoSelecionado.Cliente}?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _pedidoController.RemoverPedido(pedidoSelecionado.Id);
                CarregarPedidos();
            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            using (var formHistorico = new FormHistorico(_pedidoController))
            {
                formHistorico.ShowDialog();
            }
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            using (var formGerenciarProdutos = new FormGerenciarProdutos(new ProdutoController()))
            {
                formGerenciarProdutos.ShowDialog();
            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            using (var formRelatorio = new FormRelatorio(_pedidoController))
            {
                formRelatorio.ShowDialog();
            }
        }

        private void btnPermissoes_Click(object sender, EventArgs e)
        {
            if (_papel != "Admin")
            {
                MessageBox.Show("Apenas administradores podem gerenciar permissões.", "Aviso");
                return;
            }

            using (var formGerenciarPermissoes = new FormGerenciarPermissoes(new ClienteController()))
            {
                formGerenciarPermissoes.ShowDialog();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar o programa?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}