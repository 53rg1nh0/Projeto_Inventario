using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Extencions
{
    static class PanelExtencion
    {
        private static List<Control> _list = new List<Control>();
        private static int _countButtons = 0;
        private static Color _cor;
        private static Image[] _imagens = new Image[20];
        private static Panel _panel = new Panel();

        public static void Estilo(this Panel panel, Color cor, int alturaBotoes, int larguraMenu, Image[] imagens)
        {
            _imagens = imagens;
            _panel = panel;
            _cor = cor;
            panel.Dock = DockStyle.Left;
            panel.BackColor = cor;
            panel.Width = larguraMenu;
            List<Control> controls = new List<Control>();


            foreach (Control item in panel.Controls)
            {
                _list.Add(item);
            }
            while (_list.Count > 0)
            {
                controls.Add(_list.Where(x => x.Location.Y == _list.Max(x => x.Location.Y)).SingleOrDefault());
                _list.Remove(_list.Where(x => x.Location.Y == _list.Max(x => x.Location.Y)).SingleOrDefault());
            }
            _countButtons = controls.Count(x => x is Button);

            panel.Controls.Clear();

            int i = 0;
            foreach (Control item in controls)
            {
                panel.Controls.Add(item);
                if (item is Button)
                {

                    Button b = (Button)item;

                    b.Padding = new Padding(0, 0, 0, 0);
                    if (i < 2)
                    {
                        Separacao(DockStyle.Bottom);
                        b.Dock = DockStyle.Bottom;
                    }
                    else
                    {
                        Separacao(DockStyle.Top);
                        b.Dock = DockStyle.Top;
                    }

                    b.Image = _imagens[i];
                    b.ImageAlign = ContentAlignment.MiddleLeft;

                    b.BackColor = cor;
                    b.ForeColor = Color.White;
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.Cursor = Cursors.Hand;
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(cor.R + 20, cor.G + 20, cor.B + 20);
                    b.Font = new Font("century gothic", 12f, FontStyle.Regular, GraphicsUnit.World);
                    b.Height = alturaBotoes;

                    panel.Controls.Add(b);
                    i++;
                    b.Click += ApertaBotao;
                    _list.Add(b);
                }

                if (item is Panel)
                {
                    Separacao(DockStyle.Top);

                    Panel p = (Panel)item;
                    p.Dock = DockStyle.Top;

                    panel.Controls.Add(p);

                }
            }
        }

        private static void ApertaBotao(object sender, EventArgs e)
        {
            int i = 0;
            var botao = (Button)sender;
            foreach (var item in _list)
            {
                Button b = (Button)item;
                b.BackColor = _cor;
                b.ImageAlign = ContentAlignment.MiddleLeft;
                b.ForeColor = Color.White;
                if (_imagens.Count(x => !(x is null)) == 2 * _countButtons)
                {
                    b.Image = _imagens[i];
                    i++;
                }
            }
            botao.BackColor = SystemColors.Control;
            botao.ForeColor = Color.Black;
            if (_imagens.Count(x => !(x is null)) == 2 * _countButtons)
            {
                botao.Image = _imagens[_list.IndexOf(botao) + _countButtons];
            }
        }

        private static void Separacao(DockStyle stily)
        {
            Panel p = new Panel();
            _panel.Controls.Add(p);
            p.Dock = stily;
            p.Height = 10;
            _panel.Controls.Add(p);
        }
    }
}
