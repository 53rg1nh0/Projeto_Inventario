using InventarioTI.Extencions;
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
    public partial class uctLoginCadastro : UserControl
    {
        public uctLoginCadastro()
        {
            InitializeComponent();
        }

        private void lblCadastrar_MouseHover(object sender, EventArgs e)
        {
            lblCadastrar.ForeColor = Color.FromArgb(255, 65, 81);
        }

        private void lblCadastrar_MouseEnter(object sender, EventArgs e)
        {
            lblCadastrar.ForeColor = Color.FromArgb(255, 65, 81);
        }

        private void lblCadastrar_MouseLeave(object sender, EventArgs e)
        {
            lblCadastrar.ForeColor = Color.White;
        }

        private void lblEditarCadastro_MouseHover(object sender, EventArgs e)
        {
            lblEditarCadastro.ForeColor = Color.FromArgb(255, 65, 81);
        }

        private void lblEditarCadastro_MouseEnter(object sender, EventArgs e)
        {
            lblEditarCadastro.ForeColor = Color.FromArgb(255, 65, 81);
        }

        private void lblEditarCadastro_MouseLeave(object sender, EventArgs e)
        {
            lblEditarCadastro.ForeColor = Color.White;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void lblCadastrar_Click(object sender, EventArgs e)
        {
            lblCadastrar.Visible = false;
            lblEditarCadastro.Visible = false;
            lblSenha_Email.Text = "Email";
            lblLogin.Text = "Cadastro";

            txbUsuario.Text = "";
            txbSenha_Email.Text = "";
            txbSenha_Email.PasswordChar = '\0';

            btnBack.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            lblCadastrar.Visible = true;
            lblEditarCadastro.Visible = true;
            lblSenha_Email.Text = "Senha";
            lblLogin.Text = "Login";
            txbUsuario.Text = "";
            txbSenha_Email.Text = "";
            lblSenha_Email.Visible = true;
            txbSenha_Email.Visible = true;
            txbSenha_Email.PasswordChar = '*';

            btnBack.Visible = false;
        }

        private void lblEditarCadastro_Click(object sender, EventArgs e)
        {
            lblCadastrar.Visible = false;
            lblEditarCadastro.Visible = false;
            lblSenha_Email.Visible = false;
            txbSenha_Email.Visible = false;
            txbUsuario.Text = "";
            txbSenha_Email.Text = "";
            lblLogin.Text = "Editar\nCadastro";

            btnBack.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (lblLogin.Text == "Login")
            {

            }
            else if (lblLogin.Text == "Cadastro")
            {

            }
            else if (lblLogin.Text == "Editar\nCadastro")
            {

            }
        }
    }
}
