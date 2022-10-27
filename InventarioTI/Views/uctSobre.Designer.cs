namespace InventarioTI.Views
{
    partial class uctSobre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctSobre));
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pnlInferior = new System.Windows.Forms.Panel();
            this.ptbSolarCocaCola = new System.Windows.Forms.PictureBox();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSolarCocaCola)).BeginInit();
            this.pnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // ptbLogo
            // 
            this.ptbLogo.BackgroundImage = global::InventarioTI.Properties.Resources.Logo;
            this.ptbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbLogo.Location = new System.Drawing.Point(7, 7);
            this.ptbLogo.Margin = new System.Windows.Forms.Padding(10);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(150, 100);
            this.ptbLogo.TabIndex = 0;
            this.ptbLogo.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.richTextBox1.Location = new System.Drawing.Point(170, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0, 10, 10, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(779, 347);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.ptbSolarCocaCola);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(170, 347);
            this.pnlInferior.Margin = new System.Windows.Forms.Padding(10);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(10);
            this.pnlInferior.Size = new System.Drawing.Size(779, 100);
            this.pnlInferior.TabIndex = 4;
            // 
            // ptbSolarCocaCola
            // 
            this.ptbSolarCocaCola.BackgroundImage = global::InventarioTI.Properties.Resources.SolarCocaCola;
            this.ptbSolarCocaCola.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbSolarCocaCola.Dock = System.Windows.Forms.DockStyle.Right;
            this.ptbSolarCocaCola.Location = new System.Drawing.Point(495, 10);
            this.ptbSolarCocaCola.Margin = new System.Windows.Forms.Padding(10);
            this.ptbSolarCocaCola.Name = "ptbSolarCocaCola";
            this.ptbSolarCocaCola.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.ptbSolarCocaCola.Size = new System.Drawing.Size(274, 80);
            this.ptbSolarCocaCola.TabIndex = 1;
            this.ptbSolarCocaCola.TabStop = false;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.Controls.Add(this.ptbLogo);
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlSuperior.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(170, 447);
            this.pnlSuperior.TabIndex = 3;
            // 
            // uctSobre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.pnlSuperior);
            this.Name = "uctSobre";
            this.Size = new System.Drawing.Size(949, 447);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbSolarCocaCola)).EndInit();
            this.pnlSuperior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox ptbLogo;
        private RichTextBox richTextBox1;
        private PictureBox ptbSolarCocaCola;
        private Panel pnlInferior;
        private Panel pnlSuperior;
    }
}
