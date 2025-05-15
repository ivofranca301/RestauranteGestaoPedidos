using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Models;
using System;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormGerenciarPermissoes : Form
    {
        private readonly ClienteController _controller;

        public FormGerenciarPermissoes(ClienteController controller)
        {
            InitializeComponent();
            _controller = controller;
            CarregarUsuarios();
        }

        private void CarregarUsuarios()
        {
            var usuarios = _controller.GetUtilizadores();
            dataGridViewUsuarios.DataSource = usuarios;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um usuário para atualizar.", "Aviso");
                return;
            }

            var usuarioSelecionado = (Utilizador)dataGridViewUsuarios.SelectedRows[0].DataBoundItem;
            usuarioSelecionado.Papel = comboBoxPapel.SelectedItem.ToString();
            _controller.AtualizarUtilizador(usuarioSelecionado);
            MessageBox.Show("Permissões atualizadas com sucesso.", "Sucesso");
            CarregarUsuarios();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}