using RestauranteGestaoPedidos.Controllers;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormLogin : Form
    {
        private readonly ClienteController _controller;

        public string EmailLogado { get; private set; }
        public string PapelLogado { get; private set; }

        public FormLogin(ClienteController controller)
        {
            InitializeComponent();
            _controller = controller;
            _controller.ResponderLogin += Controller_ResponderLogin;
        }

        private void Controller_ResponderLogin(object sender, (bool Sucesso, string Mensagem, string Papel) e)
        {
            if (e.Sucesso)
            {
                EmailLogado = txtEmail.Text.Trim().ToLower();
                PapelLogado = e.Papel;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(e.Mensagem, "Erro");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim().ToLower();
            var senha = txtSenha.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha todos os campos.", "Erro");
                return;
            }

            _controller.Login(email, senha);
        }

        private void btnNovaConta_Click(object sender, EventArgs e)
        {
            using (var formNovaConta = new FormNovaConta(_controller))
            {
                if (formNovaConta.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Por favor, faça login com sua nova conta.", "Sucesso");
                }
            }
        }
    }
}