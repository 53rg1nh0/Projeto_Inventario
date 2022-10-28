namespace InventarioTI.Views
{
    partial class uctDesconectado
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctDesconectado));
            this.lblMensagem = new System.Windows.Forms.Label();
            this.ptbDesconectado = new System.Windows.Forms.PictureBox();
            this.tlpDivisor = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ptbDesconectado)).BeginInit();
            this.tlpDivisor.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMensagem.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMensagem.Location = new System.Drawing.Point(0, 0);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(86, 30);
            this.lblMensagem.TabIndex = 0;
            this.lblMensagem.Text = "label1";
            // 
            // ptbDesconectado
            // 
            this.ptbDesconectado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbDesconectado.BackgroundImage")));
            this.ptbDesconectado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbDesconectado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptbDesconectado.Location = new System.Drawing.Point(248, 0);
            this.ptbDesconectado.Margin = new System.Windows.Forms.Padding(0);
            this.ptbDesconectado.Name = "ptbDesconectado";
            this.ptbDesconectado.Size = new System.Drawing.Size(414, 352);
            this.ptbDesconectado.TabIndex = 1;
            this.ptbDesconectado.TabStop = false;
            // 
            // tlpDivisor
            // 
            this.tlpDivisor.ColumnCount = 3;
            this.tlpDivisor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tlpDivisor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tlpDivisor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tlpDivisor.Controls.Add(this.ptbDesconectado, 1, 0);
            this.tlpDivisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDivisor.Location = new System.Drawing.Point(0, 30);
            this.tlpDivisor.Margin = new System.Windows.Forms.Padding(0);
            this.tlpDivisor.Name = "tlpDivisor";
            this.tlpDivisor.RowCount = 1;
            this.tlpDivisor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDivisor.Size = new System.Drawing.Size(911, 352);
            this.tlpDivisor.TabIndex = 2;
            // 
            // uctDesconectado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpDivisor);
            this.Controls.Add(this.lblMensagem);
            this.Name = "uctDesconectado";
            this.Size = new System.Drawing.Size(911, 382);
            ((System.ComponentModel.ISupportInitialize)(this.ptbDesconectado)).EndInit();
            this.tlpDivisor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox ptbDesconectado;
        private TableLayoutPanel tlpDivisor;
        public Label lblMensagem;
    }
}
