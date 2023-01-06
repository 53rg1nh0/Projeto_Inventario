namespace InventarioTI.Views
{
    partial class obs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblObs = new System.Windows.Forms.Label();
            this.txbMovimentacao = new System.Windows.Forms.TextBox();
            this.btnIncerir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(12, 9);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(38, 15);
            this.lblObs.TabIndex = 0;
            this.lblObs.Text = "label1";
            // 
            // txbMovimentacao
            // 
            this.txbMovimentacao.Location = new System.Drawing.Point(12, 27);
            this.txbMovimentacao.Name = "txbMovimentacao";
            this.txbMovimentacao.Size = new System.Drawing.Size(427, 23);
            this.txbMovimentacao.TabIndex = 1;
            // 
            // btnIncerir
            // 
            this.btnIncerir.Location = new System.Drawing.Point(364, 56);
            this.btnIncerir.Name = "btnIncerir";
            this.btnIncerir.Size = new System.Drawing.Size(75, 23);
            this.btnIncerir.TabIndex = 2;
            this.btnIncerir.Text = "Incerir";
            this.btnIncerir.UseVisualStyleBackColor = true;
            this.btnIncerir.Click += new System.EventHandler(this.btnIncerir_Click);
            // 
            // obs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 87);
            this.Controls.Add(this.btnIncerir);
            this.Controls.Add(this.txbMovimentacao);
            this.Controls.Add(this.lblObs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "obs";
            this.Text = "Movimentação";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txbMovimentacao;
        private Button btnIncerir;
        public Label lblObs;
    }
}