using DocumentFormat.OpenXml.InkML;
using InventarioTI.Entites;
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
    public partial class uctHome : UserControl
    {
        List<Unidade> _unidades = new List<Unidade>();
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
            cbxUnidades.Visible = false;
            lblLocal.Text = "Regiao: " + _unidades.Where(u => u.Sigla == cbxUnidades.Text).SingleOrDefault().Regiao
                + "\nEstado: " + _unidades.Where(u => u.Sigla == cbxUnidades.Text).SingleOrDefault().Uf
                + "\nUnidade: " + _unidades.Where(u => u.Sigla == cbxUnidades.Text).SingleOrDefault().Nome;
            Properties.Settings.Default.UnidadePadrao = cbxUnidades.Text;
            Properties.Settings.Default.Save();
            Update();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Carregar()
        {
            using (var context = new InventarioContext())
            {
                string re = Properties.Settings.Default.Usuario;
                var resp = context.Responsaveis.Where(r => r.CLiente.UserId == re).SingleOrDefault();

                _unidades = context.ResponsaveisUnidades.Where(u => u.Responsavel.Equals(resp)).Select(u => u.Unidade).ToList();

                foreach (var u in _unidades)
                {
                    cbxUnidades.Items.Add(u.Sigla);
                }

                context.Entry(resp).Reference(r => r.CLiente).Load();

                lblinformacao.Text = "Responsável: " + resp.CLiente.Nome
                    + "\nCargo: " + resp.CLiente.Cargo
                    + "\nÁrea: " + resp.CLiente.Area;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.UnidadePadrao))
                {
                    cbxUnidades.Text = _unidades.Where(u => u.Sigla == Properties.Settings.Default.UnidadePadrao).Select(u => u.Sigla).SingleOrDefault();
                    lblLocal.Text = _unidades.Where(u => u.Sigla == Properties.Settings.Default.UnidadePadrao).Select(u => u.Regiao).SingleOrDefault()
                    + "\nEstado: " + _unidades.Where(u => u.Sigla == Properties.Settings.Default.UnidadePadrao).Select(u => u.Uf).SingleOrDefault()
                    + "\nUnidade: " + _unidades.Where(u => u.Sigla == Properties.Settings.Default.UnidadePadrao).Select(u => u.Nome).SingleOrDefault();
                }
                else
                {
                    cbxUnidades.Text = _unidades.First().Sigla;
                    lblLocal.Text = "Regiao: " + _unidades.First().Regiao
                    + "\nEstado: " + _unidades.First().Uf
                    + "\nUnidade: " + _unidades.First().Nome;
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
                                    comboBox.KeyDown += EnterCombobox;
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
                                _buttons[b] = button;
                                b++;
                            }
                        }
                    }
                }

                Update();

            }
        }



        private void Update(bool Informativos = true)
        {
            using (var context = new InventarioContext())
            {
                string[] s = new string[7];
                if (Informativos)
                {
                    _filtro = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text).ToArray();

                    var back = context.Equipamentos.Where(b => b.Cliente.Nome == "Backup").Where(b => b.Unidade.Sigla == cbxUnidades.Text).Count();
                    var total = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text).Count();
                    var totalNot = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text).Where(b => b.Tipo == "Notebook").Count();
                    var totalBackNot = context.Equipamentos.Where(b => b.Cliente.Nome == "Backup").Where(b => b.Unidade.Sigla == cbxUnidades.Text).Where(b => b.Tipo == "Notebook").Count();
                    var totalBackDesk = context.Equipamentos.Where(b => b.Cliente.Nome == "Backup").Where(b => b.Unidade.Sigla == cbxUnidades.Text).Where(b => b.Tipo == "Desktop").Count();
                    lblTotal.Text = "Equipamentos: " + total.ToString();
                    lblTotalNot.Text = "Notebooks: " + totalNot.ToString();
                    lblTotaBackup.Text = "Total Backups: " + back.ToString();
                    lblBackupNot.Text = "Backups Notebooks: " + totalBackNot.ToString();
                    lblBackupDesk.Text = "Backup Desktops: " + totalBackDesk.ToString();
                    int i = 0;
                    foreach (var c in _combos)
                    {
                        c.Text = null;
                        _buttons[i].Visible = false;
                        i++;
                    }
                }
                else
                {
                    int i = 0;
                    foreach (var c in _combos)
                    {
                        if (c.Name == "cbxPatrimonio")
                        {
                            s[i] = c.Text;
                            c.AutoCompleteCustomSource.Clear();
                            c.KeyDown -= EnterCombobox;
                        }
                        else
                        {
                            s[i] = c.Text;
                            c.Items.Clear();
                            c.SelectionChangeCommitted -= ComboBox_SelectionChangeCommitted;
                        }
                        i++;
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
                if (!Informativos)
                {
                    int i = 0;
                    foreach (var c in _combos)
                    {
                        if (c.Name == "cbxPatrimonio")
                        {
                            c.Text = s[i];
                            c.KeyDown += EnterCombobox;
                        }
                        else
                        {
                            c.Text = s[i];
                            c.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                        }
                        i++;
                    }
                }
            }

        }

        private void EnterCombobox(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (var c in _combos)
                {
                    if (!string.IsNullOrEmpty(c.Text))
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
            }
        }

        private void ComboBox_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            foreach (var c in _combos)
            {
                if (!string.IsNullOrEmpty(c.Text))
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
        }

        private void Filtro(ComboBox c)
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
                    int i = 0;
                    foreach (var iten in _combos)
                    {

                        iten.Enabled = false;
                        _buttons[i].Enabled = false;
                        i++;
                    }
                    cbxPatrimonio.Enabled= true;    
                    btnPatrimonio.Visible = true;

                }

            }
            else if (c.Name.Substring(3) == "Tipo")
            {
                _filtro = _filtro.Where(e => e.Tipo == c.Text).ToArray();
                btnTipo.Visible = true;
            }
            else if (c.Name.Substring(3) == "Marca")
            {
                _filtro = _filtro.Where(e => e.Marca == c.Text).ToArray();
                btnMarca.Visible = true;
            }
            else if (c.Name.Substring(3) == "Processador")
            {
                _filtro = _filtro.Where(e => e.Processador == c.Text).ToArray();
                btnProcessador.Visible = true;
            }
            else if (c.Name.Substring(3) == "Ram")
            {
                _filtro = _filtro.Where(e => e.Ram == c.Text).ToArray();
                btnRam.Visible = true;
            }
            else if (c.Name.Substring(3) == "Modelo")
            {
                _filtro = _filtro.Where(e => e.Modelo == c.Text).ToArray();
                btnModelo.Visible = true;
            }
            else if (c.Name.Substring(3) == "Status")
            {
                _filtro = _filtro.Where(e => e.Status == c.Text).ToArray();
                btnStatus.Visible = true;
            }
        }
    }
}
