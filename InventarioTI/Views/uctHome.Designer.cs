namespace InventarioTI.Views
{
    partial class uctHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uctHome));
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.tlpTopo = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTopoUni = new System.Windows.Forms.Panel();
            this.cbxUnidades = new System.Windows.Forms.ComboBox();
            this.ptbLocal = new System.Windows.Forms.PictureBox();
            this.tlpTopo2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblLogoff = new System.Windows.Forms.Label();
            this.ptbresponsavel = new System.Windows.Forms.PictureBox();
            this.lblLocal = new System.Windows.Forms.Label();
            this.lblinformacao = new System.Windows.Forms.Label();
            this.pnlBaixo = new System.Windows.Forms.Panel();
            this.tlpBotton = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotaBackup = new System.Windows.Forms.Label();
            this.lblBackupDesk = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblBackupNot = new System.Windows.Forms.Label();
            this.lblTotalNot = new System.Windows.Forms.Label();
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.tlpHome = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTopo.SuspendLayout();
            this.tlpTopo.SuspendLayout();
            this.pnlTopoUni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLocal)).BeginInit();
            this.tlpTopo2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbresponsavel)).BeginInit();
            this.pnlBaixo.SuspendLayout();
            this.tlpBotton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.tlpHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.pnlTopo.Controls.Add(this.tlpTopo);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(1016, 53);
            this.pnlTopo.TabIndex = 0;
            // 
            // tlpTopo
            // 
            this.tlpTopo.ColumnCount = 5;
            this.tlpTopo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tlpTopo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTopo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpTopo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTopo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tlpTopo.Controls.Add(this.pnlTopoUni, 2, 0);
            this.tlpTopo.Controls.Add(this.tlpTopo2, 4, 0);
            this.tlpTopo.Controls.Add(this.ptbresponsavel, 0, 0);
            this.tlpTopo.Controls.Add(this.lblLocal, 3, 0);
            this.tlpTopo.Controls.Add(this.lblinformacao, 1, 0);
            this.tlpTopo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTopo.Location = new System.Drawing.Point(0, 0);
            this.tlpTopo.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTopo.Name = "tlpTopo";
            this.tlpTopo.RowCount = 1;
            this.tlpTopo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopo.Size = new System.Drawing.Size(1016, 53);
            this.tlpTopo.TabIndex = 9;
            // 
            // pnlTopoUni
            // 
            this.pnlTopoUni.Controls.Add(this.cbxUnidades);
            this.pnlTopoUni.Controls.Add(this.ptbLocal);
            this.pnlTopoUni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopoUni.Location = new System.Drawing.Point(484, 0);
            this.pnlTopoUni.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTopoUni.Name = "pnlTopoUni";
            this.pnlTopoUni.Size = new System.Drawing.Size(50, 53);
            this.pnlTopoUni.TabIndex = 9;
            // 
            // cbxUnidades
            // 
            this.cbxUnidades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxUnidades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.cbxUnidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUnidades.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxUnidades.ForeColor = System.Drawing.Color.White;
            this.cbxUnidades.FormattingEnabled = true;
            this.cbxUnidades.Location = new System.Drawing.Point(3, 28);
            this.cbxUnidades.Name = "cbxUnidades";
            this.cbxUnidades.Size = new System.Drawing.Size(45, 24);
            this.cbxUnidades.TabIndex = 8;
            this.cbxUnidades.Visible = false;
            this.cbxUnidades.SelectionChangeCommitted += new System.EventHandler(this.cbxUnidades_SelectionChangeCommitted);
            // 
            // ptbLocal
            // 
            this.ptbLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbLocal.BackgroundImage = global::InventarioTI.Properties.Resources.LocalizacaoClaro50;
            this.ptbLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbLocal.Location = new System.Drawing.Point(4, 1);
            this.ptbLocal.Name = "ptbLocal";
            this.ptbLocal.Size = new System.Drawing.Size(44, 45);
            this.ptbLocal.TabIndex = 6;
            this.ptbLocal.TabStop = false;
            this.ptbLocal.Click += new System.EventHandler(this.ptbLocal_Click);
            // 
            // tlpTopo2
            // 
            this.tlpTopo2.ColumnCount = 1;
            this.tlpTopo2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopo2.Controls.Add(this.btnExit, 0, 0);
            this.tlpTopo2.Controls.Add(this.lblLogoff, 0, 1);
            this.tlpTopo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTopo2.Location = new System.Drawing.Point(963, 0);
            this.tlpTopo2.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTopo2.Name = "tlpTopo2";
            this.tlpTopo2.RowCount = 2;
            this.tlpTopo2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopo2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTopo2.Size = new System.Drawing.Size(53, 53);
            this.tlpTopo2.TabIndex = 10;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackgroundImage = global::InventarioTI.Properties.Resources.Exit50;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(14, 6);
            this.btnExit.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(27, 27);
            this.btnExit.TabIndex = 2;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblLogoff
            // 
            this.lblLogoff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogoff.AutoSize = true;
            this.lblLogoff.ForeColor = System.Drawing.Color.White;
            this.lblLogoff.Location = new System.Drawing.Point(4, 33);
            this.lblLogoff.Name = "lblLogoff";
            this.lblLogoff.Size = new System.Drawing.Size(46, 17);
            this.lblLogoff.TabIndex = 4;
            this.lblLogoff.Text = "Logoff";
            // 
            // ptbresponsavel
            // 
            this.ptbresponsavel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptbresponsavel.BackgroundImage")));
            this.ptbresponsavel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptbresponsavel.Location = new System.Drawing.Point(3, 3);
            this.ptbresponsavel.Name = "ptbresponsavel";
            this.ptbresponsavel.Size = new System.Drawing.Size(49, 47);
            this.ptbresponsavel.TabIndex = 2;
            this.ptbresponsavel.TabStop = false;
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.ForeColor = System.Drawing.Color.White;
            this.lblLocal.Location = new System.Drawing.Point(537, 0);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(46, 17);
            this.lblLocal.TabIndex = 7;
            this.lblLocal.Text = "Logoff\r\n";
            // 
            // lblinformacao
            // 
            this.lblinformacao.AutoSize = true;
            this.lblinformacao.ForeColor = System.Drawing.Color.White;
            this.lblinformacao.Location = new System.Drawing.Point(58, 0);
            this.lblinformacao.Name = "lblinformacao";
            this.lblinformacao.Size = new System.Drawing.Size(46, 17);
            this.lblinformacao.TabIndex = 5;
            this.lblinformacao.Text = "Logoff\r\n";
            // 
            // pnlBaixo
            // 
            this.pnlBaixo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.pnlBaixo.Controls.Add(this.tlpBotton);
            this.pnlBaixo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBaixo.Location = new System.Drawing.Point(0, 459);
            this.pnlBaixo.Name = "pnlBaixo";
            this.pnlBaixo.Size = new System.Drawing.Size(1016, 29);
            this.pnlBaixo.TabIndex = 1;
            // 
            // tlpBotton
            // 
            this.tlpBotton.ColumnCount = 5;
            this.tlpBotton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBotton.Controls.Add(this.lblTotaBackup, 2, 0);
            this.tlpBotton.Controls.Add(this.lblBackupDesk, 4, 0);
            this.tlpBotton.Controls.Add(this.lblTotal, 0, 0);
            this.tlpBotton.Controls.Add(this.lblBackupNot, 3, 0);
            this.tlpBotton.Controls.Add(this.lblTotalNot, 1, 0);
            this.tlpBotton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBotton.Location = new System.Drawing.Point(0, 0);
            this.tlpBotton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBotton.Name = "tlpBotton";
            this.tlpBotton.RowCount = 1;
            this.tlpBotton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBotton.Size = new System.Drawing.Size(1016, 29);
            this.tlpBotton.TabIndex = 11;
            // 
            // lblTotaBackup
            // 
            this.lblTotaBackup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotaBackup.AutoSize = true;
            this.lblTotaBackup.ForeColor = System.Drawing.Color.White;
            this.lblTotaBackup.Location = new System.Drawing.Point(409, 6);
            this.lblTotaBackup.Name = "lblTotaBackup";
            this.lblTotaBackup.Size = new System.Drawing.Size(46, 17);
            this.lblTotaBackup.TabIndex = 10;
            this.lblTotaBackup.Text = "Logoff\r\n";
            // 
            // lblBackupDesk
            // 
            this.lblBackupDesk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBackupDesk.AutoSize = true;
            this.lblBackupDesk.ForeColor = System.Drawing.Color.White;
            this.lblBackupDesk.Location = new System.Drawing.Point(815, 6);
            this.lblBackupDesk.Name = "lblBackupDesk";
            this.lblBackupDesk.Size = new System.Drawing.Size(46, 17);
            this.lblBackupDesk.TabIndex = 8;
            this.lblBackupDesk.Text = "Logoff\r\n";
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotal.AutoSize = true;
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(3, 6);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(46, 17);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Logoff\r\n";
            // 
            // lblBackupNot
            // 
            this.lblBackupNot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBackupNot.AutoSize = true;
            this.lblBackupNot.ForeColor = System.Drawing.Color.White;
            this.lblBackupNot.Location = new System.Drawing.Point(612, 6);
            this.lblBackupNot.Name = "lblBackupNot";
            this.lblBackupNot.Size = new System.Drawing.Size(46, 17);
            this.lblBackupNot.TabIndex = 7;
            this.lblBackupNot.Text = "Logoff\r\n";
            // 
            // lblTotalNot
            // 
            this.lblTotalNot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTotalNot.AutoSize = true;
            this.lblTotalNot.ForeColor = System.Drawing.Color.White;
            this.lblTotalNot.Location = new System.Drawing.Point(206, 6);
            this.lblTotalNot.Name = "lblTotalNot";
            this.lblTotalNot.Size = new System.Drawing.Size(46, 17);
            this.lblTotalNot.TabIndex = 9;
            this.lblTotalNot.Text = "Logoff\r\n";
            // 
            // dgvBackups
            // 
            this.dgvBackups.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackups.Location = new System.Drawing.Point(3, 33);
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.RowTemplate.Height = 25;
            this.dgvBackups.Size = new System.Drawing.Size(93, 44);
            this.dgvBackups.TabIndex = 0;
            // 
            // tlpHome
            // 
            this.tlpHome.ColumnCount = 1;
            this.tlpHome.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHome.Controls.Add(this.dgvBackups, 0, 1);
            this.tlpHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHome.Location = new System.Drawing.Point(0, 53);
            this.tlpHome.Name = "tlpHome";
            this.tlpHome.RowCount = 4;
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpHome.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpHome.Size = new System.Drawing.Size(1016, 406);
            this.tlpHome.TabIndex = 2;
            // 
            // uctHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpHome);
            this.Controls.Add(this.pnlBaixo);
            this.Controls.Add(this.pnlTopo);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "uctHome";
            this.Size = new System.Drawing.Size(1016, 488);
            this.pnlTopo.ResumeLayout(false);
            this.tlpTopo.ResumeLayout(false);
            this.tlpTopo.PerformLayout();
            this.pnlTopoUni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLocal)).EndInit();
            this.tlpTopo2.ResumeLayout(false);
            this.tlpTopo2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbresponsavel)).EndInit();
            this.pnlBaixo.ResumeLayout(false);
            this.tlpBotton.ResumeLayout(false);
            this.tlpBotton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.tlpHome.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlTopo;
        private Panel pnlBaixo;
        private PictureBox ptbresponsavel;
        private Button btnExit;
        private Label lblLogoff;
        private Label lblinformacao;
        private Label lblTotal;
        private Label lblBackupDesk;
        private Label lblBackupNot;
        private Label lblTotaBackup;
        private Label lblTotalNot;
        private Label lblLocal;
        private PictureBox ptbLocal;
        private ComboBox cbxUnidades;
        private DataGridView dgvBackups;
        private TableLayoutPanel tlpTopo;
        private Panel pnlTopoUni;
        private TableLayoutPanel tlpTopo2;
        private TableLayoutPanel tlpBotton;
        private TableLayoutPanel tlpHome;
    }
}
