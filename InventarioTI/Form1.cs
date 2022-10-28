using InventarioTI.Entites;
using InventarioTI.Extencions;
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
                    context.ChangeTracker.AutoDetectChangesEnabled=true;
                    context.ChangeTracker.StateChanged += teste;
                    //EXEMPLO DE CONSULTA NO BANCO

                    var query =
                        from person in context.Clientes
                        join unit in context.Unidades on person.ID_FK_U equals unit.ID_U
                        join equi in context.Equipamentos on person.ID_C equals equi.FK_ID_C
                        //where person.Area == "TI"
                        orderby person.Nome ascending
                        select new
                        {
                            person.UserId,
                            person.Nome,
                            person.Area,
                            person.Cargo,
                            equi.Tipo,
                            Unidade = unit.Nome
                        };
                    var array=query.ToArray();
                    dataGridView1.Estilo(array);
                    dataGridView1.ToExcel(@"C:\Users\sesousa\OneDrive - SOLAR BR PARTICIPAÇÕES S.A\Desktop\teste.xlsx");

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
        }

        private void teste(object sender, EventArgs e)
        {
            MessageBox.Show("Aew!");
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