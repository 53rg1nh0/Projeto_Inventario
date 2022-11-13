using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Extencions
{
    static class ControlExtencion
    {
        static int intMouse_x, intMouse_y;
        static Point pointNovo;
        static bool booMouseDown = false;
        private static void MouseDown(Object sender, MouseEventArgs e)
        {

            booMouseDown = true;
            intMouse_x = Control.MousePosition.X - Form1.ActiveForm.Location.X;
            intMouse_y = Control.MousePosition.Y - Form1.ActiveForm.Location.Y;
        }

        private static void MouseUp(Object sender, MouseEventArgs e)
        {
            booMouseDown = false;
        }

        private static void MouseMove(Object sender, MouseEventArgs e)
        {

            if (booMouseDown)
            {
                pointNovo = Control.MousePosition;
                pointNovo.X -= intMouse_x;
                pointNovo.Y -= intMouse_y;
                Form1.ActiveForm.Location = pointNovo;
                Application.DoEvents();
            }
        }

        public static void Arrastar(this Control conteiner)
        {
            foreach (Control c in conteiner.Controls)
            {
                Type tipo = c.GetType();
                if (tipo != typeof(Button) && tipo != typeof(TextBox) && tipo != typeof(Label) && tipo != typeof(ComboBox))
                {
                    c.MouseDown += MouseDown;
                    c.MouseUp += MouseUp;
                    c.MouseMove += MouseMove;
                }
                if (c.Controls.Count != 0)
                {
                    Arrastar(c);
                }
                if (conteiner is Form1)
                {
                    var form = (Form1)conteiner;
                    form.Size = new Size(330, 262);
                    form.FormBorderStyle = FormBorderStyle.None;

                }
            }
        }

        public static void IrParaPagina(this Control form, Control control,Panel p, Image[] imagem)
        {
            foreach (var uct in form.Controls)
            {
                if (uct is UserControl)
                {
                    var user = (UserControl)uct;
                    user.Visible = false;
                    user.Dock = DockStyle.None;
                    if (user.Name == control.Name)
                    {
                        user.Visible = true;
                        user.Dock = DockStyle.Fill;
                    }

                }
                if (uct is Panel && control.Name == "pgnLoginCadastro")
                {
                    control.Size = new Size(330, 262);
                    var panel = (Panel)uct;
                    panel.Visible = false;
                }
            }
            if (!(control.Name == "pgnLoginCadastro" || control.Name == "pgnDesconectado"))
            {
                int i = 0;
                foreach (Control c in p.Controls)
                {
                    if (c is Button)
                    {
                        if (control.Name.Substring(3) == c.Name.Substring(3))
                        {
                            var btn = (Button)c;
                            btn.BackColor = SystemColors.Control;
                            btn.ForeColor = Color.Black;
                            btn.Image = imagem[p.Controls.Count/2+i-1];
                        }
                        i++;
                    }
                }
            }
        }
    }
}
