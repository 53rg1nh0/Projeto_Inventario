using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Vml;
using InventarioTI.Entites;
using InventarioTI.Extencions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioTI.Views
{
    public partial class uctHome : UserControl
    {
        Unidade[] _unidades;
        Equipamento[] _filtro;//, _dados,_unidade;
        private static Dictionary<string, string> _ordenar = new Dictionary<string, string>();
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

            Atualizar();
        }

        private void dgvBackups_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            SortAndFilter();
        }

        private void dgvBackups_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            SortAndFilter();
        }

        private void dgvBackups_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Preencher(dgvBackups.Rows[e.RowIndex].Cells[1].Value.ToString());

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


                Atualizar();
                TabelaEquipe(context);
            }
        }


        private void Atualizar()
        {
            dgvBackups.CleanFilterAndSort();
            using (var context = new InventarioContext())
            {
                //_dados = context.Equipamentos.Where(b => b.Status != "obsoleto").Include(e => e.Cliente).Include(e => e.Unidade).ToArray();
                var b = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text).Where(b=>b.Status!="obsoleto");
                Equipamento[] dadosCompletos = DadosCompleto();
                //_unidade = b.ToArray();
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
                Preencher("");

                dgvBackups.Estilo(_filtro);

                txbPatrimonio.AutoCompleteCustomSource.Clear();
                txbNomenclatura.AutoCompleteCustomSource.Clear();
                txbSerie.AutoCompleteCustomSource.Clear();

                cbxTipo.Items.Clear();
                cbxMarca.Items.Clear();
                cbxProcessador.Items.Clear();
                cbxRam.Items.Clear();
                cbxModelo.Items.Clear();

                txbPatrimonio.AutoCompleteCustomSource.AddRange(dadosCompletos.Select(e => e.Patrimonio.ToString()).ToArray());
                txbPatrimonio.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txbPatrimonio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                txbNomenclatura.AutoCompleteCustomSource.AddRange(dadosCompletos.Select(e => e.Nomenclatura.ToString()).ToArray());
                txbNomenclatura.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txbNomenclatura.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                txbSerie.AutoCompleteCustomSource.AddRange(dadosCompletos.Select(e => e.Serie.ToString()).ToArray());
                txbSerie.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txbSerie.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                cbxTipo.Items.AddRange(dadosCompletos.Select(e => e.Tipo).Distinct().ToArray());

                cbxMarca.Items.AddRange(dadosCompletos.Select(e => e.Marca).Distinct().ToArray());

                cbxProcessador.Items.AddRange(dadosCompletos.Select(e => e.Processador).Distinct().ToArray());

                cbxRam.Items.AddRange(dadosCompletos.Select(e => e.Ram).Distinct().ToArray());

                cbxModelo.Items.AddRange(dadosCompletos.Select(e => e.Modelo).Distinct().ToArray());


            }
        }

        private void Preencher(string s, bool tudo = true)
        {
            Equipamento[] dadosCompletos = DadosCompleto();
            if (tudo)
            {
                txbPatrimonio.Text = s == "" ? "" : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Patrimonio.ToString();
                cbxTipo.Text = s == "" ? null : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Tipo;
                cbxMarca.Text = s == "" ? null : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Marca;
                cbxProcessador.Text = s == "" ? null : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Processador;
                cbxRam.Text = s == "" ? null : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Ram;
                cbxTipo.Text = s == "" ? null : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Tipo;
                cbxModelo.Text = s == "" ? null : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Modelo;
                txbNomenclatura.Text = s == "" ? "" : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Nomenclatura;
                txbSerie.Text = s == "" ? "" : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Serie;
                cbxDisco.Text = s == "" ? null : dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Disco;
                lblInfoCliente.Text = "";
            }
            if (s != "")
            {
                if (dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Status == "backup")
                {
                    lblInfoCliente.Text = "Equipamento backup TI \nUnidade: " + dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Unidade.Nome;
                }
                else if (dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Status == "unidade")
                {
                    lblInfoCliente.Text = "Equipamento pertencente a unidade: " + dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Unidade.Nome;
                }
                else
                {
                    lblInfoCliente.Text = "Equipamento pertencente a cliente " + dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Cliente.Nome +
                        "(" + dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Cliente.UserId + ")"
                        + "\nUnidade: " + dadosCompletos.Where(e => e.Patrimonio.ToString() == s).SingleOrDefault().Unidade.Nome;
                }
            }
        }

        private void SortAndFilter()
        {
            Equipamento[] sort;

            dgvBackups.FilterString(dgvBackups.FilterString);
            dgvBackups.SortString(dgvBackups.SortString);


            using (var context = new InventarioContext())
            {
                var b = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text);
                _filtro = b.ToArray();
            }

            _filtro = _filtro.Where(e => dgvBackups.Filtro(e)).ToArray();

            sort = _filtro;

            if (dgvBackups.Count() == 0)
            {
                sort = _filtro;
            }
            else if (dgvBackups.Count() == 1)
            {
                if (dgvBackups.OrderBy() == "ASC")
                {
                    if (dgvBackups.Campo() == "Patrimonio")
                    {
                        sort = sort.OrderBy(e => dgvBackups.OrdenarInt(e)).ToArray();
                    }
                    else
                    {
                        sort = sort.OrderBy(e => dgvBackups.OrdenarString(e)).ToArray();
                    }
                }
                else if (dgvBackups.OrderBy() == "DESC")
                {
                    if (dgvBackups.Campo() == "Patrimonio")
                    {
                        sort = sort.OrderByDescending(e => dgvBackups.OrdenarInt(e)).ToArray();
                    }
                    else
                    {
                        sort = sort.OrderByDescending(e => dgvBackups.OrdenarString(e)).ToArray();
                    }
                }
            }
            else
            {
                dgvBackups.CleanSort();


            }
            dgvBackups.Estilo(sort);
        }
        private void TabelaEquipe(InventarioContext context)
        {
            Responsavel[] r = context.Responsaveis.Include(r => r.CLiente).ToArray();

            var dados = from responsavel in r
                        select new
                        {
                            Nome = responsavel.CLiente.Nome,
                            Area = responsavel.CLiente.Area,
                            Cargo = responsavel.CLiente.Cargo,
                            Tel_Corporativo = responsavel.TelefoneCorporativo,
                            Tel_Secundario = responsavel.TelefoneSecundario,
                            Email = responsavel.Email,
                            Unidades = Unidades(context, responsavel)
                        };
            //MessageBox.Show(dados.GetType().ToString());

            dgvEquipe.Estilo(dados.ToArray());

        }

        private string Unidades(InventarioContext context, Responsavel responsavel)
        {
            string unidades = "";


            foreach (Unidade unidade in context.ResponsaveisUnidades.Where(ru => ru.Responsavel.Equals(responsavel)).Select(ru => ru.Unidade))
            {

                unidades += unidade.Sigla + ", ";

            }

            return unidades;
        }

        private void txbNomenclatura_KeyDown(object sender, KeyEventArgs e)
        {
            Equipamento[] dadosCompletos = DadosCompleto();
            string temp = "";
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txbNomenclatura.Text))
            {
                if (dadosCompletos.Select(a => a.Nomenclatura).Contains(txbNomenclatura.Text.ToUpper()))
                {
                    Preencher(dadosCompletos.Where(a => a.Nomenclatura == txbNomenclatura.Text.ToUpper()).Select(a => a.Patrimonio).SingleOrDefault().ToString());
                }
                else
                {
                    temp = txbNomenclatura.Text;
                    MessageBox.Show("Equipamento não existente!");
                    Preencher("");
                    txbNomenclatura.Text = temp;
                }
            }
        }

        private void txbSerie_KeyDown(object sender, KeyEventArgs e)
        {
            Equipamento[] dadosCompletos = DadosCompleto();
            string temp = "";
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txbSerie.Text))
            {
                if (dadosCompletos.Select(a => a.Serie).Contains(txbSerie.Text.ToUpper()))
                {
                    Preencher(dadosCompletos.Where(a => a.Serie == txbSerie.Text.ToUpper()).Select(a => a.Patrimonio).SingleOrDefault().ToString());
                }
                else
                {
                    temp=txbSerie.Text;
                    MessageBox.Show("Equipamento não existente!");
                    Preencher("");
                    txbSerie.Text = temp;
                }
            }
        }



        private void txbPatrimonio_KeyDown(object sender, KeyEventArgs e)
        {
            Equipamento[] dadosCompletos = DadosCompleto();
            string temp = "";
            if (e.KeyCode == Keys.Enter && !string.IsNullOrEmpty(txbPatrimonio.Text))
            {
                if (dadosCompletos.Select(a => a.Patrimonio).Contains(int.Parse(txbPatrimonio.Text)))
                {
                    Preencher(txbPatrimonio.Text);
                }
                else
                {
                    temp = txbPatrimonio.Text;
                    MessageBox.Show("Equipamento não existente!");
                    Preencher("");
                    txbPatrimonio.Text= temp;
                }
            }
        }


        private Equipamento[] DadosCompleto()
        {
            using (var context = new InventarioContext())
            {
                return context.Equipamentos.Where(b => b.Status != "obsoleto").Include(e => e.Cliente).Include(e => e.Unidade).ToArray();
            }
        }

        private Equipamento[] DadosUnidade()
        {
            using (var context = new InventarioContext())
            {
                return context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text).Where(b=>b.Status!="obsoleto").ToArray();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ptbBorracha_Click(object sender, EventArgs e)
        {
            Preencher("");
        }

        private void ptbAdd_Click(object sender, EventArgs e)
        {
            Equipamento[] dadosCompletos = DadosCompleto();
            using (var context = new InventarioContext())
            {
                var unidade = context.Unidades;
                var cliente = context.Clientes;
                var responsavel = context.Responsaveis;

                if (!(dadosCompletos.Select(a => a.Patrimonio).Contains(int.Parse(txbPatrimonio.Text)) || dadosCompletos.Select(a => a.Nomenclatura).Contains(txbNomenclatura.Text.ToUpper()) ||
                    dadosCompletos.Select(a => a.Serie).Contains(txbSerie.Text.ToUpper())))
                {
                    Equipamento eq = new Equipamento();
                    Movimetacao m = new Movimetacao();

                    eq.Patrimonio = int.Parse(txbPatrimonio.Text);
                    eq.Nomenclatura = txbNomenclatura.Text.ToUpper();
                    eq.Serie = txbSerie.Text.ToUpper();
                    eq.Tipo = cbxTipo.Text;
                    eq.Marca = cbxMarca.Text;
                    eq.Modelo = cbxModelo.Text;
                    eq.Processador = cbxProcessador.Text;
                    eq.Ram = cbxRam.Text;
                    eq.Status = "backup";
                    eq.Unidade = unidade.Where(u => u.Sigla == Properties.Settings.Default.UnidadePadrao).SingleOrDefault();
                    eq.Cliente = cliente.Where(c => c.UserId == "bck").SingleOrDefault();
                    eq.Disco = cbxDisco.Text == null ? null : cbxDisco.Text;
                    context.Add(eq);
                    context.SaveChanges();
                    Atualizar();
                    Preencher(DadosCompleto().Where(a=>a.Patrimonio==eq.Patrimonio).Select(a=>a.Patrimonio).SingleOrDefault().ToString());
                    MessageBox.Show("Equipamento cadastrado com sucesso!");

                    m.Data=DateTime.Now;
                    m.Status = "adicionado";
                    m.Cliente=cliente.Where(c => c.UserId == "bck").SingleOrDefault();
                    m.Equipamento = eq;
                    m.Unidade= unidade.Where(u => u.Sigla == Properties.Settings.Default.UnidadePadrao).SingleOrDefault();
                    m.Responsavel = responsavel.Where(r => r.CLiente.Equals(cliente.Where(c => c.UserId == Properties.Settings.Default.Usuario).SingleOrDefault())).SingleOrDefault();
                    context.Add(m);
                    context.SaveChanges();
                }
                else
                {
                    if (dadosCompletos.Select(a => a.Patrimonio).Contains(int.Parse(txbPatrimonio.Text)))
                    {
                        Preencher(txbPatrimonio.Text, false);
                        MessageBox.Show("Computador com PATRIMONIO já cadastrado!\n" + lblInfoCliente.Text);
                    }
                    else if (dadosCompletos.Select(a => a.Nomenclatura).Contains(txbNomenclatura.Text.ToUpper()))
                    {
                        Preencher(dadosCompletos.Where(a => a.Nomenclatura == txbNomenclatura.Text.ToUpper()).Select(a => a.Patrimonio).SingleOrDefault().ToString(), false);
                        MessageBox.Show("Computador com NOMENCLATURA já cadastrado!\n" + lblInfoCliente.Text);
                    }
                    else if (dadosCompletos.Select(a => a.Serie).Contains(txbSerie.Text.ToUpper()))
                    {
                        Preencher(dadosCompletos.Where(a => a.Serie == txbSerie.Text.ToUpper()).Select(a => a.Patrimonio).SingleOrDefault().ToString(), false);
                        MessageBox.Show("Computador com número de SÉRIE já cadastrado!\n" + lblInfoCliente.Text);
                    }
                }
            }
        }

        private void ptbRemover_Click(object sender, EventArgs e)
        {
            Equipamento[] dadosUnidade = DadosUnidade();
            Movimetacao m = new Movimetacao();

            using (var context = new InventarioContext())
            {
                if (dadosUnidade.Select(a => a.Patrimonio).Contains(int.Parse(txbPatrimonio.Text)))
                {
                    var unidade = context.Unidades;
                    var cliente = context.Clientes;
                    var responsavel = context.Responsaveis;

                    if (dadosUnidade.Where(a => a.Patrimonio == int.Parse(txbPatrimonio.Text)).SingleOrDefault().Status == "backup")
                    {
                        Equipamento eq = new Equipamento();
                        Cliente c = new Cliente();
                        eq = DadosCompleto().Where(a => a.Patrimonio == int.Parse(txbPatrimonio.Text)).SingleOrDefault();
                        eq.Status = "obsoleto";
                        context.Update(eq);
                        context.SaveChanges();
                        Atualizar();
                        MessageBox.Show("Equipamento removido com sucesso!");

                        m.Data = DateTime.Now;
                        m.Status = "Removido";
                        m.Cliente = cliente.Where(c => c.UserId == "bck").SingleOrDefault();
                        m.Equipamento = eq;
                        m.Unidade = unidade.Where(u => u.Sigla == Properties.Settings.Default.UnidadePadrao).SingleOrDefault();
                        m.Responsavel = responsavel.Where(r => r.CLiente.Equals(cliente.Where(c => c.UserId == Properties.Settings.Default.Usuario).SingleOrDefault())).SingleOrDefault();
                        context.Add(m);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Somente equipamentos Backup TI podem ser removidos!");
                    }
                }
                else
                {
                    MessageBox.Show("Apenas o PATRIMONIO é considerado para remossão do equipamento.\n\t\tEquipamento não existe em sua unidade!");
                }
            }
        }
    }

}