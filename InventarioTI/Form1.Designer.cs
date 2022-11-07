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
            this.pgnLoginCadastro = new InventarioTI.Views.uctLoginCadastro();
            this.pgnSobre = new InventarioTI.Views.uctSobre();
            this.pgnDesconectado = new InventarioTI.Views.uctDesconectado();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.pnlBaixo = new System.Windows.Forms.Panel();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlLateral.SuspendLayout();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgnLoginCadastro
            // 
            this.pgnLoginCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.pgnLoginCadastro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pgnLoginCadastro.Location = new System.Drawing.Point(22, 18);
            this.pgnLoginCadastro.Margin = new System.Windows.Forms.Padding(0);
            this.pgnLoginCadastro.Name = "pgnLoginCadastro";
            this.pgnLoginCadastro.Size = new System.Drawing.Size(100, 100);
            this.pgnLoginCadastro.TabIndex = 0;
            this.pgnLoginCadastro.SizeChanged += new System.EventHandler(this.pgnLoginCadastro_SizeChanged);
            // 
            // pgnSobre
            // 
            this.pgnSobre.Location = new System.Drawing.Point(142, 18);
            this.pgnSobre.Name = "pgnSobre";
            this.pgnSobre.Size = new System.Drawing.Size(100, 100);
            this.pgnSobre.TabIndex = 1;
            // 
            // pgnDesconectado
            // 
            this.pgnDesconectado.Location = new System.Drawing.Point(262, 18);
            this.pgnDesconectado.Name = "pgnDesconectado";
            this.pgnDesconectado.Size = new System.Drawing.Size(100, 100);
            this.pgnDesconectado.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 63);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlLateral
            // 
            this.pnlLateral.Controls.Add(this.button1);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(161, 384);
            this.pnlLateral.TabIndex = 4;
            // 
            // pnlTopo
            // 
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(161, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(832, 23);
            this.pnlTopo.TabIndex = 5;
            // 
            // pnlBaixo
            // 
            this.pnlBaixo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBaixo.Location = new System.Drawing.Point(161, 361);
            this.pnlBaixo.Name = "pnlBaixo";
            this.pnlBaixo.Size = new System.Drawing.Size(832, 23);
            this.pnlBaixo.TabIndex = 6;
            // 
            // pnlBack
            // 
            this.pnlBack.Controls.Add(this.pgnLoginCadastro);
            this.pnlBack.Controls.Add(this.pgnSobre);
            this.pnlBack.Controls.Add(this.pgnDesconectado);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(161, 23);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(832, 338);
            this.pnlBack.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 384);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.pnlBaixo);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.pnlLateral);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "InventárioTI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlLateral.ResumeLayout(false);
            this.pnlBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.uctLoginCadastro pgnLoginCadastro;
        private Views.uctSobre pgnSobre;
        private Views.uctDesconectado pgnDesconectado;
        private Button button1;
        private Panel pnlLateral;
        private Panel pnlTopo;
        private Panel pnlBaixo;
        private Panel pnlBack;
    }
}