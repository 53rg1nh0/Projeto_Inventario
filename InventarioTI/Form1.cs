using InventarioTI.Extencions;

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
            this.IrParaPagina(uctSobre);
            if (true)//condição só irá acontecer se usuário não tiver logado
            {
                Size = new Size(345, 302);
                FormBorderStyle = FormBorderStyle.None;

                uctLoginCadastro.Dock = DockStyle.Fill;
                this.IrParaPagina(uctLoginCadastro);
                this.Arrastar();

            }
           
        }

        
    }
}