using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.InkML;
using InventarioTI.Entites;
using InventarioTI.Exceptions;
using InventarioTI.Extencions;
using InventarioTI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace InventarioTI.Views
{
    public partial class uctLoginCadastro : UserControl
    {
        private List<string> _responsavelUnidade = new List<string>();
        private byte _pgn = 1;
        private string _codigo = "";
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
            btnVisualizarSenha1.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            switch (_pgn)
            {
                case 1:
                    lblCadastrar.Visible = true;
                    lblEditarCadastro.Visible = true;
                    lblSenha_Email.Text = "Senha";
                    lblLogin.Text = "Login";
                    txbUsuario.Text = "";
                    txbSenha_Email.Text = "";
                    lblSenha_Email.Visible = true;
                    txbSenha_Email.Visible = true;
                    txbSenha_Email.PasswordChar = '*';
                    txbSenha_Email.PlaceholderText = "";

                    btnBack.Visible = false;
                    btnVisualizarSenha1.Visible = true;
                    lblCodigo.Text = "Código";
                    break;
                case 2:
                    _pgn--;
                    if (lblLogin.Text != "Editar\nCadastro")
                    {
                        VoltarPagina();
                    }
                    else
                    {
                        lblSenha_Email.Visible = false;
                        txbSenha_Email.Visible = false;
                        txbUsuario.ReadOnly = false;
                    }
                    break;
                case 3:
                    _pgn--;
                    VoltarPagina();
                    this.Size = new Size(330, 262);
                    break;
            }
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
            btnVisualizarSenha1.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {

                if (lblLogin.Text == "Login")
                {
                    Login();
                }
                else if (lblLogin.Text == "Cadastro")
                {
                    btnVisualizarSenha1.Visible = false;
                    switch (_pgn)
                    {
                        case 1:

                            PrimeraEtapaCadastro();
                            break;
                        case 2:
                            SegundaEtapaCadastro();
                            break;
                        case 3:
                            TerceiraEtapaCadastro();
                            btnVisualizarSenha1.Visible = true;
                            break;
                    }
                }
                else if (lblLogin.Text == "Editar\nCadastro")
                {
                    btnVisualizarSenha1.Visible = false;
                    switch (_pgn)
                    {
                        case 1:
                            PrimeiraEtapaEditarCadastro();
                            break;
                        case 2:
                            SegundaEtapaEditarCadastro();
                            break;
                    }
                }
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void uctLoginCadastro_Load(object sender, EventArgs e)
        {
            try
            {
                using (var context = new InventarioContext())
                {
                    var unidades =
                            from uni in context.Unidades
                            select uni.Sigla;

                    cbxIncluir.DataSource = unidades.ToArray();
                }
            }
            catch { }
        }

        private void btnAdd_Remove_Click(object sender, EventArgs e)
        {
            if (!_responsavelUnidade.Contains(cbxIncluir.SelectedValue.ToString()))
            {
                _responsavelUnidade.Add(cbxIncluir.SelectedValue.ToString());
                btnAdd_Remove.BackgroundImage = Properties.Resources.LixeiraClaro25;
                string aux = "";
                foreach (string unidade in _responsavelUnidade)
                {
                    aux += unidade + ",";
                }
                txbUnidadeAtua.Text = aux;
            }
            else
            {
                _responsavelUnidade.Remove(cbxIncluir.SelectedValue.ToString());
                btnAdd_Remove.BackgroundImage = Properties.Resources.AddClaro25;
                string aux = "";
                foreach (string unidade in _responsavelUnidade)
                {
                    aux += unidade + ",";
                }
                txbUnidadeAtua.Text = aux;
            }
        }

        private void cbxIncluir_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_responsavelUnidade.Contains(cbxIncluir.SelectedValue.ToString()))
            {
                btnAdd_Remove.BackgroundImage = Properties.Resources.AddClaro25;
            }
            else
            {
                btnAdd_Remove.BackgroundImage = Properties.Resources.LixeiraClaro25;
            }
        }

        private void btnVisualizarSenha1_MouseDown(object sender, MouseEventArgs e)
        {
            btnVisualizarSenha1.BackgroundImage = Properties.Resources.OlhoAbertoEscuro22;
            txbSenha_Email.PasswordChar = '\0';
        }

        private void btnVisualizarSenha1_MouseUp(object sender, MouseEventArgs e)
        {
            btnVisualizarSenha1.BackgroundImage = Properties.Resources.OlhoFechadoEscuro22;
            txbSenha_Email.PasswordChar = '*';
        }

        private void btnVisualizarSenha2_MouseDown(object sender, MouseEventArgs e)
        {
            btnVisualizarSenha2.BackgroundImage = Properties.Resources.OlhoAbertoEscuro22;
            txbSenha.PasswordChar = '\0';
        }

        private void btnVisualizarSenha2_MouseUp(object sender, MouseEventArgs e)
        {
            btnVisualizarSenha2.BackgroundImage = Properties.Resources.OlhoFechadoEscuro22;
            txbSenha.PasswordChar = '*';
        }

        private void btnVisualizarSenha3_MouseDown(object sender, MouseEventArgs e)
        {
            btnVisualizarSenha3.BackgroundImage = Properties.Resources.OlhoAbertoEscuro22;
            txbConfirmarSenha.PasswordChar = '\0';
        }

        private void btnVisualizarSenha3_MouseUp(object sender, MouseEventArgs e)
        {
            btnVisualizarSenha3.BackgroundImage = Properties.Resources.OlhoFechadoEscuro22;
            txbConfirmarSenha.PasswordChar = '*';
        }

        /////////////////////////////////////////////////////////////////////////////////////


        private void Login()
        {
            using (var context = new InventarioContext())
            {
                var responsavel =
                            from resp in context.Responsaveis
                            where txbUsuario.Text == resp.CLiente.UserId
                            select new
                            {
                                resp.CLiente.UserId,
                                resp.Senha
                            };
                if (string.IsNullOrEmpty(txbSenha_Email.Text) || string.IsNullOrEmpty(txbUsuario.Text))
                {
                    throw new DomainException("Não pode haver campos em branco!");
                }
                else if (!(txbSenha_Email.Text == responsavel.Select(x => x.Senha).SingleOrDefault() &&
                    txbUsuario.Text.ToLower() == responsavel.Select(x => x.UserId).SingleOrDefault()))
                {
                    throw new DomainException("Usuário não está cadastrado!");
                }
                else
                {
                    Properties.Settings.Default.Usuario = txbUsuario.Text;
                    Properties.Settings.Default.Senha = txbSenha_Email.Text;
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
            }
        }

        private void PrimeraEtapaCadastro()
        {
            using (var context = new InventarioContext())
            {
                string exp = @"^(\w+.)?\w+@solarbr.com.br$";
                Regex re = new Regex(exp);
                var r = context.Responsaveis.Where(r => r.CLiente.UserId.ToLower() == txbUsuario.Text.ToLower()).SingleOrDefault();
                if (txbSenha_Email.Text == "" || txbUsuario.Text == "")
                {
                    throw new DomainException("Usuário ou e-mail não podem está em branco!");
                }
                else if (string.IsNullOrEmpty(context.Clientes.Where(c => c.UserId.ToLower() == txbUsuario.Text.ToLower()).Select(c => c.UserId).SingleOrDefault()))
                {
                    throw new DomainException("Usuário não existe no Banco de Dados do Sistema!");
                }
                else if (!(r is null))
                {
                    throw new DomainException("Usuário já cadastrado no Sistema!");
                }
                else if (!re.IsMatch(txbSenha_Email.Text))
                {
                    throw new DomainException("Email deve conter o domínio @solarbr.com.br");
                }
                else
                {
                    _codigo = Servico.GerarCodigo();
                    Task.Factory.StartNew(() => { Servico.EnviarEmail(txbSenha_Email.Text, _codigo); });
                    txbCodigo.PlaceholderText = "Verifique em seu e-mail o código enviado!";

                    _pgn++;
                    PassarPagina();
                    btnVisualizarSenha1.Visible = true;
                }
            }
        }

        private void SegundaEtapaCadastro()
        {
            if (txbCodigo.Text == "" || txbMatricula.Text == "" || txbSenha.Text == "" || txbConfirmarSenha.Text == "")
            {
                throw new DomainException("Não pode haver campos em branco!");
            }
            else if (txbCodigo.Text != _codigo)
            {
                throw new DomainException("O código fornecido não conrresponde ao enviado por e-mail!");
            }
            else if (txbSenha.Text != txbConfirmarSenha.Text)
            {
                throw new DomainException("As senhas não coencidem!");
            }
            else
            {
                _pgn++;
                PassarPagina();
            }
        }
        private void TerceiraEtapaCadastro()
        {
            string tel = @"^[(][0-9]{2}[)][ ]([0-9][ ])?[0-9]{4}[-][0-9]{4}$";
            Regex re = new Regex(tel);
            if (txbNome.Text == "" || txbUnidadeAtua.Text == "" || mtbTelCorp.Text == "(  )     -")
            {
                throw new DomainException("Campos obrigatórios não podem está em branco!");
            }
            else if (!re.IsMatch(mtbTelCorp.Text) || (mtbTelSec.Text != "" && !re.IsMatch(mtbTelSec.Text)))
            {
                throw new DomainException("Telefone inválido!");
            }
            else
            {
                using (var context = new InventarioContext())
                {
                    Cliente c = new Cliente();
                    Responsavel r = new Responsavel();
                    ResponsavelUnidade un = new ResponsavelUnidade();
                    ICollection<ResponsavelUnidade> ru = new List<ResponsavelUnidade>();

                    c = context.Clientes.Where(c => c.UserId == txbUsuario.Text).SingleOrDefault();
                    
                    
                    r.TelefoneCorporativo = mtbTelCorp.Text;
                    r.TelefoneSecundario = mtbTelCorp.Text;
                    r.Email = txbSenha_Email.Text;
                    r.Nivel = 1;
                    r.Senha = txbSenha.Text;
                    r.Codigo = txbCodigo.Text;
                    r.CLiente = c;
                    context.Add(r);
                    context.SaveChanges();
                    c.Matricula = int.Parse(txbMatricula.Text);
                    context.Update(c);

                    foreach (var unidade in _responsavelUnidade)
                    {
                        
                        un.Unidade = context.Unidades.Where(u => u.Sigla == unidade).SingleOrDefault();
                        un.ID_U = context.Unidades.Where(u => u.Sigla == unidade).SingleOrDefault().ID_U;
                        un.Responsavel = r;
                        un.ID_R = r.ID_R;
                        context.Add(un);
                        context.SaveChanges();
                    }
                    
                    Properties.Settings.Default.Usuario = txbUsuario.Text;
                    Properties.Settings.Default.Senha = txbSenha.Text;
                    Properties.Settings.Default.Save();
                    
                    Application.Restart();      
                }
            }
        }

        private void PrimeiraEtapaEditarCadastro()
        {
            using (var context = new InventarioContext())
            {
                txbCodigo.PlaceholderText = "";
                var r = context.Responsaveis.Where(r => r.CLiente.UserId.ToLower() == txbUsuario.Text.ToLower()).SingleOrDefault();
                if (txbUsuario.Text == "")
                {
                    throw new DomainException("Campo não pode está em branco!");
                }
                else if (string.IsNullOrEmpty(context.Clientes.Where(c => c.UserId.ToLower() == txbUsuario.Text.ToLower()).Select(c => c.UserId).SingleOrDefault()))
                {
                    throw new DomainException("Usuário não existe no Banco de Dados do Sistema!");
                }
                else if (r is null)
                {
                    throw new DomainException("Usuário não está cadastrado no sistema!");
                }
                else
                {
                    txbUsuario.ReadOnly = true;
                    _codigo = Servico.GerarCodigo();
                    txbSenha_Email.Visible = true;
                    lblSenha_Email.Visible = true;
                    lblSenha_Email.Text = "Código";
                    txbSenha_Email.PasswordChar = '\0';
                    txbSenha_Email.PlaceholderText = "Verifique em seu e-mail o código enviado!";
                    Task.Factory.StartNew(() => { Servico.EnviarEmail(txbSenha_Email.Text, _codigo); });
                    _pgn++;
                }
            }
        }

        private void SegundaEtapaEditarCadastro()
        {
            if (txbSenha_Email.Text == "")
            {
                throw new DomainException("Campo não pode está vazio!");
            }
            else if (txbSenha_Email.Text != _codigo)
            {
                throw new DomainException("O código fornecido não conrresponde ao enviado por e-mail!");
            }
            else
            {
                txbUsuario.ReadOnly = false;
                lblCodigo.Text = "Usuário";
                _pgn++;
                PassarPagina();
                this.Size = new Size(660, 262);

                using(var context = new InventarioContext())
                {
                    var r = context.Responsaveis.Where(r => r.CLiente.UserId == txbUsuario.Text).SingleOrDefault();
                    var unidades = context.ResponsaveisUnidades.Where(u => u.Responsavel.Equals(r)).Select(u => u.Unidade);
                    context.Entry(r).Reference(r => r.CLiente).Load();
                    string Unidades="";
                    txbCodigo.Text = r.CLiente.UserId;
                    txbMatricula.Text = r.CLiente.Matricula.ToString();
                    txbSenha.Text = r.Senha;
                    txbConfirmarSenha.Text = r.Senha;
                    txbNome.Text = r.CLiente.Nome;
                    context.Entry(r).Collection(r=>r.Unidades).Load();

                    foreach(var u in unidades)
                    {
                        Unidades += u.Sigla + ", ";
                        _responsavelUnidade.Add(u.Sigla);
                    }
                    txbUnidadeAtua.Text = Unidades;
                    mtbTelCorp.Text = r.TelefoneCorporativo;
                    mtbTelSec.Text = r.TelefoneSecundario;
                    if (_responsavelUnidade.Contains(cbxIncluir.SelectedValue.ToString()))
                    {
                        btnAdd_Remove.BackgroundImage = Properties.Resources.LixeiraClaro25;
                    }
                }
            }
        }

        private void TerceiraEtapaEditarCadastro()
        {
           
        }
        private void PassarPagina()
        {
            foreach (Control control in this.Controls)
            {
                if (!(control.Name == "btnFechar" || control.Name == "btnNext" || control.Name == "btnBack"))
                {
                    Point p = control.Location;
                    p.Offset(-330, 0);
                    control.Location = p;
                }
            }
        }

        private void VoltarPagina()
        {
            foreach (Control control in this.Controls)
            {
                if (!(control.Name == "btnFechar" || control.Name == "btnNext" || control.Name == "btnBack"))
                {
                    Point p = control.Location;
                    p.Offset(330, 0);
                    control.Location = p;
                }
            }
        }
    }
}
