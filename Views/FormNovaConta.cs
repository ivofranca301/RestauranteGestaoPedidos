using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Models;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormNovaConta : Form
    {
        private readonly ClienteController _controller;

        public FormNovaConta(ClienteController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Erro");
                return;
            }

            var novoUtilizador = new Utilizador
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                Papel = "Utilizador"
            };

            _controller.CriarConta(novoUtilizador);
            MessageBox.Show("Conta criada com sucesso.", "Sucesso");
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