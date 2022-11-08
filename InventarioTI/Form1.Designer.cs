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
            this.pnlLateral = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlLateralTopo = new System.Windows.Forms.Panel();
            this.ptbLateralSolar = new System.Windows.Forms.PictureBox();
            this.ptbLateralLogo = new System.Windows.Forms.PictureBox();
            this.pnlLateralBack = new System.Windows.Forms.Panel();
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.pnlBaixo = new System.Windows.Forms.Panel();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlLateral.SuspendLayout();
            this.pnlLateralTopo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLateralSolar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLateralLogo)).BeginInit();
            this.pnlLateralBack.SuspendLayout();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pgnLoginCadastro
            // 
            this.pgnLoginCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.pgnLoginCadastro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pgnLoginCadastro.Location = new System.Drawing.Point(3, 3);
            this.pgnLoginCadastro.Margin = new System.Windows.Forms.Padding(0);
            this.pgnLoginCadastro.Name = "pgnLoginCadastro";
            this.pgnLoginCadastro.Size = new System.Drawing.Size(100, 100);
            this.pgnLoginCadastro.TabIndex = 0;
            this.pgnLoginCadastro.SizeChanged += new System.EventHandler(this.pgnLoginCadastro_SizeChanged);
            // 
            // pgnSobre
            // 
            this.pgnSobre.Location = new System.Drawing.Point(123, 3);
            this.pgnSobre.Name = "pgnSobre";
            this.pgnSobre.Size = new System.Drawing.Size(100, 100);
            this.pgnSobre.TabIndex = 1;
            // 
            // pgnDesconectado
            // 
            this.pgnDesconectado.Location = new System.Drawing.Point(243, 3);
            this.pgnDesconectado.Name = "pgnDesconectado";
            this.pgnDesconectado.Size = new System.Drawing.Size(100, 100);
            this.pgnDesconectado.TabIndex = 2;
            // 
            // pnlLateral
            // 
            this.pnlLateral.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLateral.Controls.Add(this.button4);
            this.pnlLateral.Controls.Add(this.button3);
            this.pnlLateral.Controls.Add(this.button2);
            this.pnlLateral.Controls.Add(this.button1);
            this.pnlLateral.Controls.Add(this.pnlLateralTopo);
            this.pnlLateral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlLateral.Name = "pnlLateral";
            this.pnlLateral.Size = new System.Drawing.Size(180, 384);
            this.pnlLateral.TabIndex = 4;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(39, 229);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "                Ajustes";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(39, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "                Sobre";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(39, 116);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "                Equipamento";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(39, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "                Home";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pnlLateralTopo
            // 
            this.pnlLateralTopo.BackColor = System.Drawing.SystemColors.Control;
            this.pnlLateralTopo.Controls.Add(this.ptbLateralSolar);
            this.pnlLateralTopo.Controls.Add(this.ptbLateralLogo);
            this.pnlLateralTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLateralTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlLateralTopo.Name = "pnlLateralTopo";
            this.pnlLateralTopo.Size = new System.Drawing.Size(180, 50);
            this.pnlLateralTopo.TabIndex = 3;
            // 
            // ptbLateralSolar
            // 
            this.ptbLateralSolar.BackgroundImage = global::InventarioTI.Properties.Resources.SolarCocaCola;
            this.ptbLateralSolar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbLateralSolar.Location = new System.Drawing.Point(64, 5);
            this.ptbLateralSolar.Name = "ptbLateralSolar";
            this.ptbLateralSolar.Size = new System.Drawing.Size(100, 40);
            this.ptbLateralSolar.TabIndex = 3;
            this.ptbLateralSolar.TabStop = false;
            // 
            // ptbLateralLogo
            // 
            this.ptbLateralLogo.BackgroundImage = global::InventarioTI.Properties.Resources.Logo;
            this.ptbLateralLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbLateralLogo.Location = new System.Drawing.Point(6, 3);
            this.ptbLateralLogo.Name = "ptbLateralLogo";
            this.ptbLateralLogo.Size = new System.Drawing.Size(45, 45);
            this.ptbLateralLogo.TabIndex = 3;
            this.ptbLateralLogo.TabStop = false;
            this.ptbLateralLogo.Click += new System.EventHandler(this.ptbLateralLogo_Click);
            // 
            // pnlLateralBack
            // 
            this.pnlLateralBack.Controls.Add(this.pnlLateral);
            this.pnlLateralBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLateralBack.Location = new System.Drawing.Point(0, 0);
            this.pnlLateralBack.Name = "pnlLateralBack";
            this.pnlLateralBack.Size = new System.Drawing.Size(180, 384);
            this.pnlLateralBack.TabIndex = 5;
            // 
            // pnlTopo
            // 
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(180, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(813, 50);
            this.pnlTopo.TabIndex = 6;
            // 
            // pnlBaixo
            // 
            this.pnlBaixo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBaixo.Location = new System.Drawing.Point(180, 359);
            this.pnlBaixo.Name = "pnlBaixo";
            this.pnlBaixo.Size = new System.Drawing.Size(813, 25);
            this.pnlBaixo.TabIndex = 7;
            // 
            // pnlBack
            // 
            this.pnlBack.Controls.Add(this.pgnLoginCadastro);
            this.pnlBack.Controls.Add(this.pgnDesconectado);
            this.pnlBack.Controls.Add(this.pgnSobre);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(180, 50);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(813, 309);
            this.pnlBack.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 384);
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.pnlBaixo);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.pnlLateralBack);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "InventárioTI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlLateral.ResumeLayout(false);
            this.pnlLateralTopo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLateralSolar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLateralLogo)).EndInit();
            this.pnlLateralBack.ResumeLayout(false);
            this.pnlBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Views.uctLoginCadastro pgnLoginCadastro;
        private Views.uctSobre pgnSobre;
        private Views.uctDesconectado pgnDesconectado;
        private Panel pnlLateral;
        private Panel pnlLateralTopo;
        private PictureBox ptbLateralSolar;
        private PictureBox ptbLateralLogo;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Panel pnlLateralBack;
        private Panel pnlTopo;
        private Panel pnlBaixo;
        private Panel pnlBack;
    }
}