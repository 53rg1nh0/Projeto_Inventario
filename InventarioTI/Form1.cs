using InventarioTI.Entites;
using InventarioTI.Extencions;
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
                    //    join equi in context.Equipamentos on person.ID_C equals equi.FK_ID_C
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
                    ////    };
                    //uctTeste1.dgvEsquerda.Estilo(array);
                    //this.IrParaPagina(uctTeste1);
                    //this.IrParaPagina(uctSobre);
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
                pgnDesconectado.lblMensagem.Text = "Verifique se está conectado a rede da Solar!";
            }
        }

        
    }
}