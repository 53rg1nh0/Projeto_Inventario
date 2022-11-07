using InventarioTI.Entites;
using InventarioTI.Extencions;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
                        this.pnlBack.IrParaPagina(pgnSobre);
                    }
                    else
                    {
                        this.pnlBack.IrParaPagina(pgnLoginCadastro);
                        this.Arrastar();
                    }
                }
            }
            catch (Microsoft.Data.Sqlite.SqliteException ex)
            {
                this.pnlBack.IrParaPagina(pgnDesconectado);
                pgnDesconectado.lblMensagem.Text = "Erro na operação com BD. Verifique conexão!";
            }
            catch(DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logoff();
        }

        private void pgnLoginCadastro_SizeChanged(object sender, EventArgs e)
        {
            this.Size = pgnLoginCadastro.Size;
            pnlBaixo.Visible = false;
            pnlTopo.Visible = false;
            pnlLateral.Visible = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////


        private void Logoff()
        {
            Properties.Settings.Default.Senha = null;
            Properties.Settings.Default.Usuario = null;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

    }

}