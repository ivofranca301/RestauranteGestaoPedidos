namespace RestauranteGestaoPedidos.Views
{
    partial class FormHistorico
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
            this.dataGridViewHistorico = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitulo.Location = new System.Drawing.Point(10, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(183, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Histórico de Pedidos";
            // 
            // dataGridViewHistorico
            // 
            this.dataGridViewHistorico.AllowUserToAddRows = false;
            this.dataGridViewHistorico.AllowUserToDeleteRows = false;
            this.dataGridViewHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistorico.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridViewHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorico.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewHistorico.Location = new System.Drawing.Point(10, 50);
            this.dataGridViewHistorico.Name = "dataGridViewHistorico";
            this.dataGridViewHistorico.ReadOnly = true;
            this.dataGridViewHistorico.RowHeadersWidth = 51;
            this.dataGridViewHistorico.RowTemplate.Height = 29;
            this.dataGridViewHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistorico.Size = new System.Drawing.Size(760, 350);
            this.dataGridViewHistorico.TabIndex = 1;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(650, 410);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 30);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormHistorico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(780, 450);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.dataGridViewHistorico);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormHistorico";
            this.Text = "Histórico de Pedidos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dataGridViewHistorico;
        private System.Windows.Forms.Button btnFechar;
    }
}