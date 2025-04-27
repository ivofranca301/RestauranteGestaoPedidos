using RestauranteGestaoPedidos.Controllers;
using RestauranteGestaoPedidos.Models;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RestauranteGestaoPedidos.Views
{
    public partial class NovoPedidoForm : Form
    {
        private readonly PedidoController _controller;
        private readonly ProdutoController _produtoController;
        private readonly Pedido _pedido;
        private readonly bool _isEdicao;

        public delegate void PedidoCriadoHandler(Pedido pedido);
        public event PedidoCriadoHandler PedidoCriado;

        public NovoPedidoForm(PedidoController controller, ProdutoController produtoController, Pedido pedido = null)
        {
            InitializeComponent();
            _controller = controller;
            _controller.Notificar += Controller_Notificar;
            _produtoController = produtoController;
            _pedido = pedido ?? new Pedido();
            _isEdicao = pedido != null;
            CarregarProdutos();
            CarregarStatus(); // <-- NOVO
            if (_isEdicao)
            {
                PreencherCampos();
            }
        }

        private void Controller_Notificar(object sender, string mensagem)
        {
            var resultado = MessageBox.Show(mensagem + "\nDeseja corrigir?", "Aviso do Sistema", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Cancel)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            // Se for Retry, não faz nada — o utilizador pode corrigir os campos manualmente
        }

        private void CarregarProdutos()
        {
            var produtos = _produtoController.ListarProdutos();
            comboBoxProduto.DataSource = produtos;
            comboBoxProduto.DisplayMember = "Nome";
            comboBoxProduto.ValueMember = "Id";
            comboBoxProduto.SelectedIndexChanged += ComboBoxProduto_SelectedIndexChanged;
            AtualizarPrecoProduto();
        }

        private void CarregarStatus() // <-- NOVO MÉTODO
        {
            comboBoxStatus.DataSource = Enum.GetValues(typeof(StatusPedido));
            comboBoxStatus.SelectedItem = StatusPedido.Pendente; // Opcional: pré-selecionar
        }

        private void ComboBoxProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarPrecoProduto();
        }

        private void AtualizarPrecoProduto()
        {
            if (comboBoxProduto.SelectedItem != null)
            {
                var produtoSelecionado = (Produto)comboBoxProduto.SelectedItem;
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
            comboBoxStatus.SelectedItem = _pedido.Status.ToString(); // Aqui não mexemos
            if (_pedido.Itens.Any())
            {
                var item = _pedido.Itens[0];
                comboBoxProduto.SelectedValue = item.ProdutoId;
                numQuantidade.Value = item.Quantidade;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                PedidoCriado?.Invoke(_pedido);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
