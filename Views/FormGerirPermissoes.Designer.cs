namespace RestauranteGestaoPedidos.Views
{
    partial class FormGerenciarPermissoes
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
            this.labelPapel = new System.Windows.Forms.Label();
            this.comboBoxPapel = new System.Windows.Forms.ComboBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitulo.Location = new System.Drawing.Point(11, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(358, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gerenciar Permissões";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelPapel);
            this.flowLayoutPanel1.Controls.Add(this.comboBoxPapel);
            this.flowLayoutPanel1.Controls.Add(this.btnAtualizar);
            this.flowLayoutPanel1.Controls.Add(this.btnFechar);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(855, 55);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // labelPapel
            // 
            this.labelPapel.AutoSize = true;
            this.labelPapel.Font = new System.Drawing.Font("Arial", 10F);
            this.labelPapel.Location = new System.Drawing.Point(3, 0);
            this.labelPapel.Name = "labelPapel";
            this.labelPapel.Size = new System.Drawing.Size(66, 23);
            this.labelPapel.TabIndex = 2;
            this.labelPapel.Text = "Papel:";
            // 
            // comboBoxPapel
            // 
            this.comboBoxPapel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPapel.FormattingEnabled = true;
            this.comboBoxPapel.Items.AddRange(new object[] {
            "Admin",
            "Utilizador"});
            this.comboBoxPapel.Location = new System.Drawing.Point(75, 3);
            this.comboBoxPapel.Name = "comboBoxPapel";
            this.comboBoxPapel.Size = new System.Drawing.Size(224, 28);
            this.comboBoxPapel.TabIndex = 3;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAtualizar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(305, 3);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(155, 43);
            this.btnAtualizar.TabIndex = 0;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.Font = new System.Drawing.Font("Arial", 10F);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(466, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(135, 43);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(11, 122);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.RowHeadersWidth = 51;
            this.dataGridViewUsuarios.RowTemplate.Height = 29;
            this.dataGridViewUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(855, 350);
            this.dataGridViewUsuarios.TabIndex = 2;
            // 
            // FormGerenciarPermissoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(879, 493);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormGerenciarPermissoes";
            this.Text = "Gerenciar Permissões";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.Label labelPapel;
        private System.Windows.Forms.ComboBox comboBoxPapel;
    }
}