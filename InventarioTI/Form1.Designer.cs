namespace InventarioTI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.uctLoginCadastro = new InventarioTI.Views.uctLoginCadastro();
            this.uctSobre = new InventarioTI.Views.uctSobre();
            this.SuspendLayout();
            // 
            // uctLoginCadastro
            // 
            this.uctLoginCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.uctLoginCadastro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uctLoginCadastro.Location = new System.Drawing.Point(246, 9);
            this.uctLoginCadastro.Margin = new System.Windows.Forms.Padding(0);
            this.uctLoginCadastro.Name = "uctLoginCadastro";
            this.uctLoginCadastro.Size = new System.Drawing.Size(100, 100);
            this.uctLoginCadastro.TabIndex = 0;
            // 
            // uctSobre
            // 
            this.uctSobre.Location = new System.Drawing.Point(361, 9);
            this.uctSobre.Name = "uctSobre";
            this.uctSobre.Size = new System.Drawing.Size(100, 100);
            this.uctSobre.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 384);
            this.Controls.Add(this.uctSobre);
            this.Controls.Add(this.uctLoginCadastro);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "InventárioTI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.uctLoginCadastro uctLoginCadastro;
        private Views.uctSobre uctSobre;
    }
}