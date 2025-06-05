using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Models;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormAdicionarProduto : Form
    {
        private readonly ProdutoController _controller;
        private readonly Produto _produto;
        private readonly bool _isEdicao;

        public FormAdicionarProduto(ProdutoController controller, Produto produto = null)
        {
            InitializeComponent();
            txtPreco.Minimum = 0.01M;           // impede valores a 0
            txtPreco.DecimalPlaces = 2;        // para permitir casas decimais
            txtPreco.Increment = 0.10M;        // valor ao clicar nas setas
            _controller = controller;
            _controller.Notificar += Controller_Notificar;
            _produto = produto ?? new Produto();
            _isEdicao = produto != null;
            if (_isEdicao)
            {
                PreencherCampos();
                this.Text = "Editar Produto";
            }
        }

        private void Controller_Notificar(object sender, string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso");
        }

        private void PreencherCampos()
        {
            txtNome.Text = _produto.Nome;
            txtPreco.Value = _produto.Preco;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || txtPreco.Value <= 0)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Erro");
                return;
            }

            _produto.Nome = txtNome.Text;
            _produto.Preco = txtPreco.Value;

            if (_isEdicao)
            {
                _controller.AtualizarProduto(_produto);
            }
            else
            {
                _controller.AdicionarProduto(_produto);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}