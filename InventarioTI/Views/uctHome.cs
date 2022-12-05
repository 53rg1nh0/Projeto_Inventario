using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Math;
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
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioTI.Views
{
    public partial class uctHome : UserControl
    {
        Unidade[] _unidades;
        Equipamento[] _filtro;
        string[] _arrayFiltros;
        Dictionary<string, string[]> _arrayFiltro = new Dictionary<string, string[]>();
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


                Update();
                TabelaEquipe(context);
            }
        }


        private void Update()
        {
            using (var context = new InventarioContext())
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

                dgvBackups.Estilo(_filtro);


                cbxPatrimonio.AutoCompleteCustomSource.AddRange(_filtro.Select(e => e.Patrimonio.ToString()).ToArray());
                cbxPatrimonio.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cbxPatrimonio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                cbxNomenclatura.AutoCompleteCustomSource.AddRange(_filtro.Select(e => e.Nomenclatura.ToString()).ToArray());
                cbxNomenclatura.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cbxNomenclatura.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                cbxSerie.AutoCompleteCustomSource.AddRange(_filtro.Select(e => e.Serie.ToString()).ToArray());
                cbxSerie.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cbxSerie.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                cbxTipo.Items.AddRange(_filtro.Select(e => e.Tipo).Distinct().ToArray());

                cbxMarca.Items.AddRange(_filtro.Select(e => e.Marca).Distinct().ToArray());

                cbxProcessador.Items.AddRange(_filtro.Select(e => e.Processador).Distinct().ToArray());

                cbxRam.Items.AddRange(_filtro.Select(e => e.Ram).Distinct().ToArray());

                cbxModelo.Items.AddRange(_filtro.Select(e => e.Modelo).Distinct().ToArray());

                cbxStatus.Items.AddRange(_filtro.Select(e => e.Status).Distinct().ToArray());

            }
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

        private void dgvBackups_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {

            
            string s = dgvBackups.FilterString;
            if (!string.IsNullOrEmpty(s))
            {
                _arrayFiltros = s.Split(" AND ");
                foreach (string str in _arrayFiltros)
                {
                    _arrayFiltro[str.Substring(str.IndexOf('[') + 1, str.IndexOf(']') - str.IndexOf('[') - 1)] =
                        str.Substring(str.LastIndexOf('(')).Trim(')').Trim('(').Split(", ");
                }
               
                _filtro = _filtro.Where(e => Filtro(e)).ToArray();
            }
            
            dgvBackups.Estilo(_filtro);
            


            s = "";
            _arrayFiltro.Clear();
            using (var context = new InventarioContext())
            {
                var b = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text);
                _filtro = b.ToArray();
            }

        }

        private bool Filtro(Equipamento e)
        {
            var p = e.GetType().GetProperties();
            bool bi = false, be = true;

            foreach (var a in _arrayFiltro)
            {

                foreach (var v in a.Value)
                {
                    bi |= p.Where(p => p.Name == a.Key).SingleOrDefault().GetValue(e).ToString() == v.Trim('\'');
                }
                be &= (bi);
                bi = false;
            }      
            return be;
        }
    }
}