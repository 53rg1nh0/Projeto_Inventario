using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Vml;
using InventarioTI.Entites;
using InventarioTI.Extencions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    public partial class uctHome : UserControl
    {
        Unidade[] _unidades;
        Equipamento[] _filtro;
        ComboBox[] _combos = new ComboBox[7];
        Button[] _buttons = new Button[7];
        public uctHome()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Senha = null;
            Properties.Settings.Default.Usuario = null;
            Properties.Settings.Default.UnidadePadrao = null;
            Properties.Settings.Default.Save();
            Application.Restart();
        }


        private void ptbLocal_Click(object sender, EventArgs e)
        {
            cbxUnidades.Visible = true;
        }

        private void cbxUnidades_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Update();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public void Carregar()
        {
            using (var context = new InventarioContext())
            {
                var resp = context.Responsaveis.Where(r => r.CLiente.UserId == Properties.Settings.Default.Usuario).SingleOrDefault();
                context.Entry(resp).Reference(r => r.CLiente).Load();

                lblinformacao.Text = "Responsável: " + resp.CLiente.Nome
                    + "\nCargo: " + resp.CLiente.Cargo
                    + "\nÁrea: " + resp.CLiente.Area;

                _unidades = context.ResponsaveisUnidades.Where(u => u.Responsavel.Equals(resp)).Select(u => u.Unidade).ToArray();

                cbxUnidades.Items.AddRange(_unidades.Select(u => u.Sigla).ToArray());


                if (!string.IsNullOrEmpty(Properties.Settings.Default.UnidadePadrao))
                {
                    cbxUnidades.Text = _unidades.Where(u => u.Sigla == Properties.Settings.Default.UnidadePadrao).First().Sigla;
                }
                else
                {
                    cbxUnidades.Text = _unidades.First().Sigla;
                }

                int b = 0, c = 0;
                foreach (Control control in tlpFiltro.Controls)
                {
                    if (control is Panel)
                    {
                        foreach (Control c2 in control.Controls)
                        {
                            if (c2 is ComboBox)
                            {
                                ComboBox comboBox = c2 as ComboBox;
                                _combos[c] = comboBox;
                                if (comboBox.Name == "cbxPatrimonio")
                                {
                                    comboBox.KeyDown += EnterComboBox;
                                }
                                else
                                {
                                    comboBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                                }
                                c++;
                            }
                            if (c2 is Button)
                            {
                                Button button = c2 as Button;
                                button.Click += Button_Click;
                                _buttons[b] = button;
                                b++;
                            }
                        }
                    }
                }
                Update();
                TabelaEquipe(context);
            }
        }

        
        private void Update(bool informativos = true)
        {
            using (var context = new InventarioContext())
            {
                if (informativos)
                {
                    var b = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text);
                    _filtro = b.ToArray();

                    lblTotal.Text = "Equipamentos: " + b.Count().ToString();
                    lblTotalNot.Text = "Notebooks: " + b.Where(b => b.Tipo == "Notebook").Count().ToString();
                    lblTotaBackup.Text = "Total Backups: " + b.Where(b => b.Cliente.Nome == "Backup").Count().ToString();
                    lblBackupNot.Text = "Nackups Notebooks: " + b.Where(b => b.Cliente.Nome == "Backup").Where(b => b.Tipo == "Notebook").Count().ToString();
                    lblBackupDesk.Text = "Backup Desktops: " + b.Where(b => b.Cliente.Nome == "Backup").Where(b => b.Tipo == "Desktop").Count().ToString();

                    lblLocal.Text = "Regiao: " + _unidades.Where(u => u.Sigla == cbxUnidades.Text).First().Regiao
                            + "\nEstado: " + _unidades.Where(u => u.Sigla == cbxUnidades.Text).First().Uf
                            + "\nUnidade: " + _unidades.Where(u => u.Sigla == cbxUnidades.Text).First().Nome;

                    Properties.Settings.Default.UnidadePadrao = cbxUnidades.Text;
                    Properties.Settings.Default.Save();

                    for (int i = 0; i < 7; i++)
                    {

                        _combos[i].Enabled = true;
                        _buttons[i].Enabled = true;
                    }

                    cbxUnidades.Visible = false;
                }

                string[] s = new string[7];

                for (int i = 0; i < 7; i++)
                {

                    s[i] = _combos[i].Text;
                    if (_combos[i].Name == "cbxPatrimonio")
                    {
                        if (!string.IsNullOrEmpty(_combos[i].Text))
                        {
                            _combos[i].KeyDown -= EnterComboBox;
                            _combos[i].Text = null;
                            _buttons[i].Visible = false;
                        }
                        _combos[i].AutoCompleteCustomSource.Clear();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(_combos[i].Text))
                        {
                            _combos[i].SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted;
                            _combos[i].Text = null;
                            _buttons[i].Visible = false;
                        }
                        _combos[i].Items.Clear();
                    }


                }

                dgvBackups.Estilo(_filtro);

                cbxPatrimonio.AutoCompleteCustomSource.AddRange(_filtro.Select(e => e.Patrimonio.ToString()).ToArray());
                cbxPatrimonio.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cbxPatrimonio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                cbxTipo.Items.AddRange(_filtro.Select(e => e.Tipo).Distinct().ToArray());

                cbxMarca.Items.AddRange(_filtro.Select(e => e.Marca).Distinct().ToArray());

                cbxProcessador.Items.AddRange(_filtro.Select(e => e.Processador).Distinct().ToArray());

                cbxRam.Items.AddRange(_filtro.Select(e => e.Ram).Distinct().ToArray());

                cbxModelo.Items.AddRange(_filtro.Select(e => e.Modelo).Distinct().ToArray());

                cbxStatus.Items.AddRange(_filtro.Select(e => e.Status).Distinct().ToArray());

                cbxStatus.Items.AddRange(_filtro.Select(e => e.Status).Distinct().ToArray());

                for (int i = 0; i < 7; i++)
                {
                    if (!string.IsNullOrEmpty(s[i]))
                    {
                        if (_combos[i].Name == "cbxPatrimonio")
                        {
                            _combos[i].KeyDown += EnterComboBox;

                        }
                        else
                        {
                            _combos[i].SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                        }
                        if (!informativos)
                        {
                            _combos[i].Text = s[i];
                            _buttons[i].Visible = true;
                        }
                    }
                }
            }
        }

        private void EnterComboBox(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboBox_SelectionChangeCommitted(sender, e);
            }
        }

        private void ComboBox_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            foreach (var c in _combos)
            {
                ComboBox comboBox = (ComboBox)sender;
                if (comboBox.Name.Substring(3) == c.Name.Substring(3))
                {
                    Filtro(comboBox);
                    Update(false);
                    return;
                }
            }
        }

        private void Filtro(ComboBox c)
        {
            if (string.IsNullOrEmpty(c.Text))
            {
                using (var context = new InventarioContext())
                {
                    _filtro = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text).ToArray();
                }
                foreach (var combo in _combos)
                {
                    if (!string.IsNullOrEmpty(combo.Text))
                    {
                        Filtro(combo);
                    }
                }
            }
            else
            {
                if (c.Name.Substring(3) == "Patrimonio")
                {
                    if (_filtro.Where(e => e.Patrimonio == int.Parse(cbxPatrimonio.Text)).Count() == 0)
                    {
                        MessageBox.Show("Equimamento não existe na uindade.");
                    }
                    else
                    {
                        _filtro = _filtro.Where(e => e.Patrimonio == int.Parse(cbxPatrimonio.Text)).ToArray();
                        for (int i = 0; i < 7; i++)
                        {

                            _combos[i].Enabled = false;
                            _buttons[i].Enabled = false;
                        }
                        cbxPatrimonio.Enabled = true;
                        btnPatrimonio.Enabled = true;

                    }

                }
                else if (c.Name.Substring(3) == "Tipo")
                {
                    _filtro = _filtro.Where(e => e.Tipo == c.Text).ToArray();
                }
                else if (c.Name.Substring(3) == "Marca")
                {
                    _filtro = _filtro.Where(e => e.Marca == c.Text).ToArray();
                }
                else if (c.Name.Substring(3) == "Processador")
                {
                    _filtro = _filtro.Where(e => e.Processador == c.Text).ToArray();
                }
                else if (c.Name.Substring(3) == "Ram")
                {
                    _filtro = _filtro.Where(e => e.Ram == c.Text).ToArray();
                }
                else if (c.Name.Substring(3) == "Modelo")
                {
                    _filtro = _filtro.Where(e => e.Modelo == c.Text).ToArray();
                }
                else if (c.Name.Substring(3) == "Status")
                {
                    _filtro = _filtro.Where(e => e.Status == c.Text).ToArray();
                }
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {

            Button b = sender as Button;
            if (b.Name == "btnPatrimonio")
            {
                for (int i = 0; i < 7; i++)
                {

                    _combos[i].Enabled = true;
                    _buttons[i].Enabled = true;
                }
            }
            b.Visible = false;
            ButtonToCombo(b).Text = null;

            ComboBox_SelectionChangeCommitted(ButtonToCombo(b), e);


        }

        private ComboBox ButtonToCombo(Button b)
        {
            for (int i = 0; i < 7; i++)
            {
                if (b.Equals(_buttons[i]))
                {
                    return _combos[i];
                }
            }
            return null;
        }

        private void TabelaEquipe(InventarioContext context)
        {
            Responsavel[] r = context.Responsaveis.Include(r => r.CLiente).ToArray();
            Unidade[] u;
            List<string> lista = new List<string>();
            string unidades = "";
            foreach (Responsavel responsavel in r)
            {
                context.Entry(responsavel).Collection(r => r.Unidades).Load();
                u = responsavel.Unidades.Where(u => u.Responsavel.Equals(responsavel)).Select(u => u.Unidade).ToArray();
                foreach (Unidade unidade in u)
                {
                    unidades += unidade.Sigla + ", ";
                }
                lista.Add(unidades);
                unidades = "";
            }

            var dados = from responsavel in r
                        select new
                        {
                            Nome = responsavel.CLiente.Nome,
                            Area = responsavel.CLiente.Area,
                            Cargo = responsavel.CLiente.Cargo,
                            Tel_Corporativo = responsavel.TelefoneCorporativo,
                            Tel_Secundario = responsavel.TelefoneSecundario,
                            Email = responsavel.Email,
                        };
            dgvEquipe.Estilo(dados.ToArray());
        }
    }
}
