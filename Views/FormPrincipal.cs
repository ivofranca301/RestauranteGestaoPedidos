using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Models;
using RestauranteGestaoPedidos.Models.Repositorios;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormPrincipal : Form
    {
        private readonly PedidoController _pedidoController;
        private readonly ProdutoController _produtoController;
        private readonly string _papel;

        public FormPrincipal(string email, string papel, IProdutoRepository produtoRepo)
        {
            InitializeComponent();

            _pedidoController = new PedidoController();
            _produtoController = new ProdutoController(produtoRepo);

            _pedidoController.Notificar += PedidoController_Notificar;
            _papel = papel;

            try
            {
                CarregarPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pedidos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_papel != "Admin")
            {
                btnPermissoes.Visible = false;
            }
        }

        private void PedidoController_Notificar(object sender, string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CarregarPedidos()
        {
            try
            {
                var pedidos = _pedidoController.ListarPedidos();
                dataGridViewPedidos.DataSource = pedidos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao listar pedidos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovoPedido_Click(object sender, EventArgs e)
        {
            try
            {
                var novoPedidoForm = new NovoPedidoForm(_pedidoController, _produtoController);
                if (novoPedidoForm.ShowDialog() == DialogResult.OK)
                {
                    CarregarPedidos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarPedido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um pedido para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var pedidoSelecionado = (Pedido)dataGridViewPedidos.SelectedRows[0].DataBoundItem;
                var novoPedidoForm = new NovoPedidoForm(_pedidoController, _produtoController, pedidoSelecionado);
                if (novoPedidoForm.ShowDialog() == DialogResult.OK)
                {
                    CarregarPedidos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverPedido_Click(object sender, EventArgs e)
        {
            if (dataGridViewPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um pedido para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var pedidoSelecionado = (Pedido)dataGridViewPedidos.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Deseja remover o pedido #{pedidoSelecionado.Id} de {pedidoSelecionado.Cliente}?",
                    "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _pedidoController.RemoverPedido(pedidoSelecionado.Id);
                    CarregarPedidos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formHistorico = new FormHistorico(_pedidoController))
                {
                    formHistorico.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir histórico: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formGerenciarProdutos = new FormGerenciarProdutos(_produtoController.Repositorio))
                {
                    formGerenciarProdutos.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir gestão de produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formRelatorio = new FormRelatorio(_pedidoController))
                {
                    formRelatorio.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPermissoes_Click(object sender, EventArgs e)
        {
            if (_papel != "Admin")
            {
                MessageBox.Show("Apenas administradores podem gerenciar permissões.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var formGerenciarPermissoes = new FormGerenciarPermissoes(new ClienteController()))
                {
                    formGerenciarPermissoes.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir permissões: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar o programa?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

