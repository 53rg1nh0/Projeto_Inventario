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

                    Cliente c = context.Clientes.Where(c => c.Nome == "Backup").FirstOrDefault();
                    Unidade u = context.Unidades.Where(u => u.Sigla == "CVF").FirstOrDefault();

                    Equipamento equi = new Equipamento
                    {
                        Tipo = "Desktop",
                        Patrimonio = 81841,
                        Nomenclatura = "CVF00081841D",
                        Serie = "BRJ429FG3",
                        Marca = "HP",
                        Modelo = "800 G1",
                        Processador = "Core I5",
                        Ram = "8GB",
                        Status = "Ativo",
                        Cliente = c,
                        Unidade=u
                    };

                    context.Add(equi);
                    context.SaveChanges();

                    var responsavel =
                        from responsaveis in context.Responsaveis
                        join clientes in context.Clientes on responsaveis.ID_R equals clientes.ID_C
                        where Properties.Settings.Default.Usuario == clientes.UserId
                        select new
                        {
                            clientes.UserId,
                            responsaveis.Senha
                        };


                    if (Properties.Settings.Default.Senha == responsavel.Select(x => x.Senha).SingleOrDefault() &&
                        Properties.Settings.Default.Usuario == responsavel.Select(x => x.UserId).SingleOrDefault())
                    {
                        this.IrParaPagina(pgnSobre);
                    }
                    else
                    {
                        this.IrParaPagina(pgnLoginCadastro);
                        this.Arrastar();
                    }
                }
            }
            catch (Microsoft.Data.Sqlite.SqliteException ex)
            {
                this.IrParaPagina(pgnDesconectado);
                pgnDesconectado.lblMensagem.Text = "Erro na operação com BD. Verifique conexão!";
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logoff();
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