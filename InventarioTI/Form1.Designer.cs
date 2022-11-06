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
            this.SuspendLayout();
            // 
            // pgnLoginCadastro
            // 
            this.pgnLoginCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.pgnLoginCadastro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pgnLoginCadastro.Location = new System.Drawing.Point(246, 12);
            this.pgnLoginCadastro.Margin = new System.Windows.Forms.Padding(0);
            this.pgnLoginCadastro.Name = "pgnLoginCadastro";
            this.pgnLoginCadastro.Size = new System.Drawing.Size(100, 100);
            this.pgnLoginCadastro.TabIndex = 0;
            this.pgnLoginCadastro.SizeChanged += new System.EventHandler(this.pgnLoginCadastro_SizeChanged);
            // 
            // pgnSobre
            // 
            this.pgnSobre.Location = new System.Drawing.Point(366, 12);
            this.pgnSobre.Name = "pgnSobre";
            this.pgnSobre.Size = new System.Drawing.Size(100, 100);
            this.pgnSobre.TabIndex = 1;
            // 
            // pgnDesconectado
            // 
            this.pgnDesconectado.Location = new System.Drawing.Point(486, 12);
            this.pgnDesconectado.Name = "pgnDesconectado";
            this.pgnDesconectado.Size = new System.Drawing.Size(100, 100);
            this.pgnDesconectado.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(865, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 63);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 384);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pgnDesconectado);
            this.Controls.Add(this.pgnSobre);
            this.Controls.Add(this.pgnLoginCadastro);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "InventárioTI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.uctLoginCadastro pgnLoginCadastro;
        private Views.uctSobre pgnSobre;
        private Views.uctDesconectado pgnDesconectado;
        private Button button1;
    }
}