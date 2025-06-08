namespace RestauranteGestaoPedidos.Views
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNovoPedido = new System.Windows.Forms.Button();
            this.btnEditarPedido = new System.Windows.Forms.Button();
            this.btnRemoverPedido = new System.Windows.Forms.Button();
            this.btnHistorico = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnPermissoes = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.dataGridViewPedidos = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitulo.Location = new System.Drawing.Point(10, 8);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(233, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Lista de Pedidos";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNovoPedido);
            this.flowLayoutPanel1.Controls.Add(this.btnEditarPedido);
            this.flowLayoutPanel1.Controls.Add(this.btnRemoverPedido);
            this.flowLayoutPanel1.Controls.Add(this.btnHistorico);
            this.flowLayoutPanel1.Controls.Add(this.btnProdutos);
            this.flowLayoutPanel1.Controls.Add(this.btnRelatorio);
            this.flowLayoutPanel1.Controls.Add(this.btnPermissoes);
            this.flowLayoutPanel1.Controls.Add(this.btnSair);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 40);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(990, 50);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnNovoPedido
            // 
            this.btnNovoPedido.BackColor = System.Drawing.Color.SeaGreen;
            this.btnNovoPedido.Font = new System.Drawing.Font("Arial", 10F);
            this.btnNovoPedido.ForeColor = System.Drawing.Color.White;
            this.btnNovoPedido.Location = new System.Drawing.Point(3, 2);
            this.btnNovoPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNovoPedido.Name = "btnNovoPedido";
            this.btnNovoPedido.Size = new System.Drawing.Size(78, 34);
            this.btnNovoPedido.TabIndex = 0;
            this.btnNovoPedido.Text = "Novo Pedido";
            this.btnNovoPedido.UseVisualStyleBackColor = false;
            this.btnNovoPedido.Click += new System.EventHandler(this.btnNovoPedido_Click);
            // 
            // btnEditarPedido
            // 
            this.btnEditarPedido.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEditarPedido.Font = new System.Drawing.Font("Arial", 10F);
            this.btnEditarPedido.ForeColor = System.Drawing.Color.White;
            this.btnEditarPedido.Location = new System.Drawing.Point(87, 2);
            this.btnEditarPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditarPedido.Name = "btnEditarPedido";
            this.btnEditarPedido.Size = new System.Drawing.Size(97, 34);
            this.btnEditarPedido.TabIndex = 1;
            this.btnEditarPedido.Text = "Editar Pedido";
            this.btnEditarPedido.UseVisualStyleBackColor = false;
            this.btnEditarPedido.Click += new System.EventHandler(this.btnEditarPedido_Click);
            // 
            // btnRemoverPedido
            // 
            this.btnRemoverPedido.BackColor = System.Drawing.Color.IndianRed;
            this.btnRemoverPedido.Font = new System.Drawing.Font("Arial", 10F);
            this.btnRemoverPedido.ForeColor = System.Drawing.Color.White;
            this.btnRemoverPedido.Location = new System.Drawing.Point(190, 2);
            this.btnRemoverPedido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoverPedido.Name = "btnRemoverPedido";
            this.btnRemoverPedido.Size = new System.Drawing.Size(112, 34);
            this.btnRemoverPedido.TabIndex = 2;
            this.btnRemoverPedido.Text = "Remover Pedido";
            this.btnRemoverPedido.UseVisualStyleBackColor = false;
            this.btnRemoverPedido.Click += new System.EventHandler(this.btnRemoverPedido_Click);
            // 
            // btnHistorico
            // 
            this.btnHistorico.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnHistorico.Font = new System.Drawing.Font("Arial", 10F);
            this.btnHistorico.ForeColor = System.Drawing.Color.White;
            this.btnHistorico.Location = new System.Drawing.Point(308, 2);
            this.btnHistorico.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHistorico.Name = "btnHistorico";
            this.btnHistorico.Size = new System.Drawing.Size(111, 34);
            this.btnHistorico.TabIndex = 3;
            this.btnHistorico.Text = "Histórico";
            this.btnHistorico.UseVisualStyleBackColor = false;
            this.btnHistorico.Click += new System.EventHandler(this.btnHistorico_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnProdutos.Font = new System.Drawing.Font("Arial", 10F);
            this.btnProdutos.ForeColor = System.Drawing.Color.White;
            this.btnProdutos.Location = new System.Drawing.Point(425, 2);
            this.btnProdutos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(134, 34);
            this.btnProdutos.TabIndex = 4;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.UseVisualStyleBackColor = false;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.BackColor = System.Drawing.Color.DarkCyan;
            this.btnRelatorio.Font = new System.Drawing.Font("Arial", 10F);
            this.btnRelatorio.ForeColor = System.Drawing.Color.White;
            this.btnRelatorio.Location = new System.Drawing.Point(565, 2);
            this.btnRelatorio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(149, 34);
            this.btnRelatorio.TabIndex = 5;
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.UseVisualStyleBackColor = false;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnPermissoes
            // 
            this.btnPermissoes.BackColor = System.Drawing.Color.DarkMagenta;
            this.btnPermissoes.Font = new System.Drawing.Font("Arial", 10F);
            this.btnPermissoes.ForeColor = System.Drawing.Color.White;
            this.btnPermissoes.Location = new System.Drawing.Point(720, 2);
            this.btnPermissoes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPermissoes.Name = "btnPermissoes";
            this.btnPermissoes.Size = new System.Drawing.Size(138, 34);
            this.btnPermissoes.TabIndex = 6;
            this.btnPermissoes.Text = "Permissões";
            this.btnPermissoes.UseVisualStyleBackColor = false;
            this.btnPermissoes.Click += new System.EventHandler(this.btnPermissoes_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Gray;
            this.btnSair.Font = new System.Drawing.Font("Arial", 10F);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(864, 2);
            this.btnSair.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(108, 34);
            this.btnSair.TabIndex = 7;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // dataGridViewPedidos
            // 
            this.dataGridViewPedidos.AllowUserToAddRows = false;
            this.dataGridViewPedidos.AllowUserToDeleteRows = false;
            this.dataGridViewPedidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPedidos.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewPedidos.Location = new System.Drawing.Point(12, 94);
            this.dataGridViewPedidos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewPedidos.Name = "dataGridViewPedidos";
            this.dataGridViewPedidos.ReadOnly = true;
            this.dataGridViewPedidos.RowHeadersWidth = 51;
            this.dataGridViewPedidos.RowTemplate.Height = 29;
            this.dataGridViewPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPedidos.Size = new System.Drawing.Size(958, 263);
            this.dataGridViewPedidos.TabIndex = 2;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1011, 434);
            this.Controls.Add(this.dataGridViewPedidos);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormPrincipal";
            this.Text = "Sistema de Pedidos - Restaurante";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNovoPedido;
        private System.Windows.Forms.Button btnEditarPedido;
        private System.Windows.Forms.Button btnRemoverPedido;
        private System.Windows.Forms.Button btnHistorico;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.Button btnPermissoes;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.DataGridView dataGridViewPedidos;
    }
}