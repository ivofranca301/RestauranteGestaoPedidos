using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Models;
using RestauranteGestaoPedidos.Models.Repositorios;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormGerenciarProdutos : Form
    {
        private readonly ProdutoController _produtoController;

        public FormGerenciarProdutos(IProdutoRepository produtoRepository)
        {
            InitializeComponent();
            _produtoController = new ProdutoController(produtoRepository);
            _produtoController.Notificar += ProdutoController_Notificar;

            try
            {
                CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProdutoController_Notificar(object sender, string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar lista de produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarProdutos()
        {
            dataGridViewProdutos.DataSource = null;
            dataGridViewProdutos.DataSource = _produtoController.ListarProdutos();
            if (dataGridViewProdutos.Columns["Preco"] != null)
            {
                dataGridViewProdutos.Columns["Preco"].DefaultCellStyle.Format = "€0.00";
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formAdicionarProduto = new FormAdicionarProduto(_produtoController))
                {
                    formAdicionarProduto.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var produtoSelecionado = (Produto)dataGridViewProdutos.SelectedRows[0].DataBoundItem;
                using (var formAdicionarProduto = new FormAdicionarProduto(_produtoController, produtoSelecionado))
                {
                    formAdicionarProduto.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridViewProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var produtoSelecionado = (Produto)dataGridViewProdutos.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"Deseja remover o produto {produtoSelecionado.Nome}?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _produtoController.RemoverProduto(produtoSelecionado.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover produto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
