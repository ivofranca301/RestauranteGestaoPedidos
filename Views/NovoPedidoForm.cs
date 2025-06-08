using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class NovoPedidoForm : Form
    {
        private readonly PedidoController _controller;
        private readonly ProdutoController _produtoController;
        private readonly Pedido _pedido;
        private readonly bool _isEdicao;

        public NovoPedidoForm(PedidoController controller, ProdutoController produtoController, Pedido pedido = null)
        {
            InitializeComponent();
            _controller = controller;
            _controller.Notificar += Controller_Notificar;
            _produtoController = produtoController;
            _pedido = pedido ?? new Pedido();
            _isEdicao = pedido != null;
            CarregarProdutos();

            if (_isEdicao)
            {
                PreencherCampos();
            }
        }

        private void Controller_Notificar(object sender, string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CarregarProdutos()
        {
            try
            {
                var produtos = _produtoController.ListarProdutos();
                comboBoxProduto.DataSource = produtos;
                comboBoxProduto.DisplayMember = "Nome";
                comboBoxProduto.ValueMember = "Id";
                comboBoxProduto.SelectedIndexChanged += ComboBoxProduto_SelectedIndexChanged;
                AtualizarPrecoProduto();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxProduto.Enabled = false;
            }
        }

        private void ComboBoxProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarPrecoProduto();
        }

        private void AtualizarPrecoProduto()
        {
            if (comboBoxProduto.SelectedItem is Produto produtoSelecionado)
            {
                lblPrecoProduto.Text = $"Preço: €{produtoSelecionado.Preco:F2}";
            }
            else
            {
                lblPrecoProduto.Text = "Preço: €0,00";
            }
        }

        private void PreencherCampos()
        {
            txtCliente.Text = _pedido.Cliente;
            dtpData.Value = _pedido.Data;
            comboBoxStatus.SelectedItem = _pedido.Status.ToString();
            if (_pedido.Itens.Any())
            {
                var item = _pedido.Itens[0];
                comboBoxProduto.SelectedValue = item.ProdutoId;
                numQuantidade.Value = item.Quantidade;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCliente.Text) || comboBoxProduto.SelectedItem == null)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _pedido.Cliente = txtCliente.Text;
                _pedido.Data = dtpData.Value;
                _pedido.Status = (StatusPedido)Enum.Parse(typeof(StatusPedido), comboBoxStatus.SelectedItem.ToString());

                if (!_isEdicao)
                {
                    _pedido.Id = _controller.ListarPedidos().Any() ? _controller.ListarPedidos().Max(p => p.Id) + 1 : 1;
                }

                var produtoSelecionado = (Produto)comboBoxProduto.SelectedItem;
                var item = new ItemPedido
                {
                    ProdutoId = produtoSelecionado.Id,
                    Nome = produtoSelecionado.Nome,
                    Quantidade = (int)numQuantidade.Value,
                    Preco = produtoSelecionado.Preco
                };

                if (_isEdicao)
                {
                    _pedido.Itens.Clear();
                }
                _pedido.Itens.Add(item);

                if (_isEdicao)
                {
                    _controller.AtualizarPedido(_pedido);
                }
                else
                {
                    _controller.CriarPedido(_pedido);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar pedido: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
