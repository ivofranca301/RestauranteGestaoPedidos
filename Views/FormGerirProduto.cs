using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Models;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormGerenciarProdutos : Form
    {
        private readonly ProdutoController _produtoController;

        public FormGerenciarProdutos(ProdutoController produtoController)
        {
            InitializeComponent();
            _produtoController = produtoController;
            _produtoController.Notificar += ProdutoController_Notificar;
            CarregarProdutos();
        }

        private void ProdutoController_Notificar(object sender, string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso");
            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            dataGridViewProdutos.DataSource = null; // Limpar o DataSource para evitar duplicatas
            dataGridViewProdutos.DataSource = _produtoController.ListarProdutos();
            if (dataGridViewProdutos.Columns["Preco"] != null)
            {
                dataGridViewProdutos.Columns["Preco"].DefaultCellStyle.Format = "€0.00";
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var formAdicionarProduto = new FormAdicionarProduto(_produtoController))
            {
                formAdicionarProduto.ShowDialog();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para editar.", "Aviso");
                return;
            }

            var produtoSelecionado = (Produto)dataGridViewProdutos.SelectedRows[0].DataBoundItem;
            using (var formAdicionarProduto = new FormAdicionarProduto(_produtoController, produtoSelecionado))
            {
                formAdicionarProduto.ShowDialog();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (dataGridViewProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para remover.", "Aviso");
                return;
            }

            var produtoSelecionado = (Produto)dataGridViewProdutos.SelectedRows[0].DataBoundItem;
            if (MessageBox.Show($"Deseja remover o produto {produtoSelecionado.Nome}?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _produtoController.RemoverProduto(produtoSelecionado.Id);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}