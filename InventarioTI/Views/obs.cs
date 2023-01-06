using InventarioTI.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioTI.Views
{
    public partial class obs : Form
    {
        Movimetacao _movimetacao = new Movimetacao();
        public obs(Movimetacao m)
        {
            InitializeComponent();
            _movimetacao = m;
        }

        private void btnIncerir_Click(object sender, EventArgs e)
        {
            _movimetacao.Observacao = txbMovimentacao.Text;
            this.Close();
        }
    }
}
