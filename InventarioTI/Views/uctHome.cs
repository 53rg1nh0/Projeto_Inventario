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

                Update();
            }

        }

        private void Update()
        {
            using (var context = new InventarioContext())
            {
                var back = context.Equipamentos.Where(b => b.Cliente.Nome == "Backup").Where(b => b.Unidade.Sigla == cbxUnidades.Text).ToArray();
                var total = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text).Count();
                var totalNot = context.Equipamentos.Where(b => b.Unidade.Sigla == cbxUnidades.Text).Where(b => b.Tipo == "Notebook").Count();
                var totalBackNot = context.Equipamentos.Where(b => b.Cliente.Nome == "Backup").Where(b => b.Unidade.Sigla == cbxUnidades.Text).Where(b => b.Tipo == "Notebook").Count();
                var totalBackDesk = context.Equipamentos.Where(b => b.Cliente.Nome == "Backup").Where(b => b.Unidade.Sigla == cbxUnidades.Text).Where(b => b.Tipo == "Desktop").Count();

                lblTotal.Text = "Equipamentos: " + total.ToString();
                lblTotalNot.Text = "Notebooks: " + totalNot.ToString();
                lblTotaBackup.Text = "Total Backups: " + back.Count().ToString();
                lblBackupNot.Text = "Backups Notebooks: " + totalBackNot.ToString();
                lblBackupDesk.Text = "Backup Desktops: " + totalBackDesk.ToString();

                dgvBackups.Estilo(back);


            }
        }

    }
}
