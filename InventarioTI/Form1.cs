using InventarioTI.Entites;
using InventarioTI.Extencions;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

namespace InventarioTI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Image[] imagem = new Image[20];
            imagem[7] = Properties.Resources.HomeEscuro45;
            imagem[6] = Properties.Resources.ComputadorEscuro45;
            imagem[5] = Properties.Resources.SobreEscuro45;
            imagem[4] = Properties.Resources.AjusteEscuro45;
            imagem[3] = Properties.Resources.HomeClaro45;
            imagem[2] = Properties.Resources.ComputadorClaro45;
            imagem[1] = Properties.Resources.SobreClaro45;
            imagem[0] = Properties.Resources.AjusteClaro45;

            if (!Properties.Settings.Default.Lateral && !string.IsNullOrEmpty(Properties.Settings.Default.Usuario))
            {
                pnlLateralBack.Width = 55;
            }
            if (Properties.Settings.Default.Maximizado && !string.IsNullOrEmpty(Properties.Settings.Default.Usuario))
            {
                this.WindowState = FormWindowState.Maximized;
            }

            try
            {
                using (var context = new InventarioContext())
                {
                    //EXEMPLO DE CONSULTA NO BANCO

                    //var query =
                    //    from person in context.Clientes
                    //    join unit in context.Unidades on person.ID_FK_U equals unit.ID_U
                    //    join equi in context.Equipamentos on person.ID_C equals equi.FK_ID_C // ATENÇÂO QUE A CHAVE ESTRANGEIRA MUDOU
                    //    where person.Area == "TI"
                    //    orderby person.Nome ascending
                    //    select new
                    //    {
                    //        person.UserId,
                    //        person.Nome,
                    //        person.Area,
                    //        person.Cargo,
                    //        equi.Tipo,
                    //        Unidade = unit.Nome
                    //    };

                    // EXEMPLO DE EXPORTAR PARA DGV QUANDO EXISTEM NULOS

                    //var query1 =
                    //    from person in context.Clientes
                    //    join equi in context.Equipamentos on person.ID_C equals equi.FK_ID_C
                    //    select new
                    //    {
                    //        Tipo = equi.Tipo,
                    //        Patrimonio = equi.Patrimonio,
                    //        Modelo = equi.Modelo,
                    //        Nome = person.Nome
                    //    };

                    //var query2 =
                    //    from equi in context.Equipamentos
                    //    where equi.FK_ID_C.Equals(null)
                    //    select new
                    //    {
                    //        Tipo = equi.Tipo,
                    //        Patrimonio = equi.Patrimonio,
                    //        Modelo = equi.Modelo,
                    //        Nome = ""
                    //    };
                    //var query = query1.Concat(query2);


                    //var array = query.ToArray();
                    //dataGridView1.Estilo(array);
                    //dataGridView1.ToExcel(@"C:\Users\sesousa\OneDrive - SOLAR BR PARTICIPAÇÕES S.A\Desktop\teste.xlsx");

                    //EXEMPLO DE COMO INCLUIR DADOS 

                    //Cliente c = context.Clientes.Where(c => c.Nome == "Backup").FirstOrDefault();
                    //Unidade u = context.Unidades.Where(u => u.Sigla == "CVF").FirstOrDefault();

                    //Equipamento equi = new Equipamento
                    //{
                    //    Tipo = "Desktop",
                    //    Patrimonio = 81841,
                    //    Nomenclatura = "CVF00081841D",
                    //    Serie = "BRJ429FG3",
                    //    Marca = "HP",
                    //    Modelo = "800 G1",
                    //    Processador = "Core I5",
                    //    Ram = "8GB",
                    //    Status = "Ativo",
                    //    Cliente = c,
                    //    Unidade=u
                    //};

                    //context.Add(equi);
                    //context.SaveChanges();

                    //Unidade u = context.Unidades.Where(u => u.Sigla == "CVF").FirstOrDefault();


                    //var query = from equi in context.Equipamentos
                    //            where equi.Cliente.Area == "RH"
                    //            select new
                    //            {
                    //                equi.Tipo,
                    //                equi.Modelo,
                    //                equi.Patrimonio,
                    //                Funcionario = equi.Cliente.Nome,
                    //                User = equi.Cliente.UserId,
                    //                Cargo = equi.Cliente.Cargo,
                    //            };





                    //dataGridView1.Estilo(query.ToArray());
                    foreach (Control b in pnlLateral.Controls)
                    {
                        if (b is Button)
                        {
                            b.Click += Navegacao;
                        }
                    }

                    pnlLateral.Estilo(Color.FromArgb(50, 65, 81), 55, 180, imagem);



                    var responsavel =
                        from resp in context.Responsaveis
                        where Properties.Settings.Default.Usuario == resp.CLiente.UserId
                        select new
                        {
                            resp.CLiente.UserId,
                            resp.Senha
                        };


                    if (Properties.Settings.Default.Senha == responsavel.Select(x => x.Senha).SingleOrDefault() &&
                        Properties.Settings.Default.Usuario == responsavel.Select(x => x.UserId).SingleOrDefault())
                    {
                        this.pnlBack.IrParaPagina(pgnHome, pnlLateral, imagem);
                        pgnHome.Carregar();
                    }
                    else
                    {
                        pnlBack.IrParaPagina(pgnLoginCadastro, pnlLateral, imagem);
                        this.Arrastar();
                    }
                }
            }
            catch (Microsoft.Data.Sqlite.SqliteException ex)
            {
                this.pnlBack.IrParaPagina(pgnDesconectado, pnlLateral, imagem);
                pgnDesconectado.lblMensagem.Text = "Erro na operação com BD. Verifique conexão!";
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void pgnLoginCadastro_SizeChanged(object sender, EventArgs e)
        {
            this.Size = pgnLoginCadastro.Size;
            pnlLateralBack.Visible = false;
        }

        private void Navegacao(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            foreach (Control b in pnlLateral.Controls)
            {
                if (b is Button)
                {
                    if (btn.Name == b.Name)
                    {
                        foreach (Control p in pnlBack.Controls)
                        {
                            p.Visible = false;
                            if (p.Name.Substring(3) == b.Name.Substring(3))
                            {
                                p.Visible = true;
                                p.Dock = DockStyle.Fill;
                            }
                        }
                    }
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////


        private void ptbLateralLogo_Click(object sender, EventArgs e)
        {
            if (pnlLateralBack.Width == 180)
            {
                pnlLateralBack.Width = 55;
                Properties.Settings.Default.Lateral = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                pnlLateralBack.Width = 180;
                Properties.Settings.Default.Lateral = true;
                Properties.Settings.Default.Save();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Usuario))
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    Properties.Settings.Default.Maximizado = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Maximizado = false;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }

}