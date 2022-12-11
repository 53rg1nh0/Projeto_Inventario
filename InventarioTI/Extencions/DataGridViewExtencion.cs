using Accessibility;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using InventarioTI.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Zuby.ADGV;

namespace InventarioTI.Extencions
{
    static class DataGridViewExtencion
    {
        private static string[] _arrayFiltros;
        private static Dictionary<string, string[]> _arrayFiltro = new Dictionary<string, string[]>();

        private static string _orderBy, teste;
        private static Dictionary<string, string> _ordenar = new Dictionary<string, string>();
        private static int _count;
        public static void Estilo<T>(this DataGridView DG, T[] dados)
        {

            _arrayFiltro.Clear();
            _ordenar.Clear();
            DG.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            DG.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DG.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 65, 81);
            DG.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DG.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DG.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            DG.Dock = DockStyle.Fill;
            DG.RowHeadersVisible = false;
            DG.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DG.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DG.DataSource = dados;
            DG.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DG.EnableHeadersVisualStyles = false;
            DG.AllowUserToResizeRows = false;


            foreach (DataGridViewColumn column in DG.Columns)
            {
                try
                {
                    if (column.HeaderText == "Uf")
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.Width = 25;
                    }
                    if (column.HeaderText == "Disco" || column.HeaderText == "Ram" || column.HeaderText == "Sigla" || column.HeaderText == "Status")
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.Width = 60;
                    }
                    if (column.HeaderText == "UserID" || column.HeaderText == "Matricula")
                    {
                        column.Width = 65;
                    }
                    if (column.HeaderText == "Regiao" || column.HeaderText == "Processador" || column.HeaderText == "Tipo")
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        column.Width = 110;
                    }
                    if (column.HeaderText == "Nome" || column.HeaderText == "Email")
                    {
                        if (DG.Name != "dgvEquipe")
                        {
                            column.Width = 300;
                        }
                    }
                    if (column.HeaderText == "ID_C" || column.HeaderText == "ID_U" || column.HeaderText == "ID_FK_C"
                        || column.HeaderText == "ID_FK_U" || column.HeaderText == "Nivel" || column.HeaderText == "Senha"
                        || column.HeaderText == "ID_E" || column.HeaderText == "Cliente" || column.HeaderText == "Unidade"
                        || column.HeaderText == "Movimentacoes" || column.HeaderText == "Disco")
                    {
                        column.Visible = false;
                    }
                }
                catch (NullReferenceException) { }
            }

        }

        public static void ToExcel(this DataGridView dgv, string path)
        {
            using (var workbook = new XLWorkbook())
            {

                var worksheet = workbook.AddWorksheet("Inventário");

                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column.Visible)
                    {
                        worksheet.Column(column.Index + 1).Cell(1).Value = column.HeaderText.ToUpper();
                        Celulas(worksheet.Column(column.Index + 1).Cell(1), true, true);
                    }
                }

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible)
                        {
                            worksheet.Column(column.Index + 1).Cell(row.Index + 2).Value = dgv.Rows[row.Index].Cells[column.Index].Value;
                            Celulas(worksheet.Column(column.Index + 1).Cell(row.Index + 2));
                        }
                    }
                }
                workbook.SaveAs(path);
            }
        }

        private static void Celulas(IXLCell celula, bool fontBold = false, bool cor = false)
        {
            celula.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            celula.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            celula.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            celula.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            celula.Style.Border.TopBorder = XLBorderStyleValues.Thin;

            celula.Style.Font.Bold = fontBold;

            if (cor)
            {
                celula.Style.Fill.BackgroundColor = XLColor.Yellow;
            }
        }

        public static void FilterString(this DataGridView dgv, string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                _arrayFiltros = s.Split(" AND ");
                foreach (string str in _arrayFiltros)
                {
                    _arrayFiltro[str.Substring(str.IndexOf('[') + 1, str.IndexOf(']') - str.IndexOf('[') - 1)] =
                        str.Substring(str.LastIndexOf('(')).Trim(')').Trim('(').Split(", ");
                }
            }
        }

        public static bool Filtro(this DataGridView dgv, Object e)
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

        public static void SortString(this DataGridView dgv, string s)
        {
            _count = s.Split(", ").Length;
            if (!string.IsNullOrEmpty(s) /*&& s.Split(", ").Length == 1*/)
            {
                _orderBy= s.Split(", ").Last().Substring(s.Split(", ").Last().LastIndexOf(' ')).Trim(' ');
                teste = s.Split(", ").Last().Substring(s.Split(", ").Last().IndexOf('[') + 1, s.Split(", ").Last().IndexOf(']') - s.Split(", ").Last().IndexOf('[') - 1);

                _ordenar[s.Split(", ").Last().Substring(s.Split(", ").Last().IndexOf('[') + 1, s.Split(", ").Last().IndexOf(']') - s.Split(", ").Last().IndexOf('[') - 1)] =
                 _orderBy;
            }
        }

        public static int Count(this DataGridView dgv)
        {
            return _count;
        }
        public static string OrderBy(this DataGridView dgv)
        {
            return _orderBy;
        }

        public static string Campo(this DataGridView dgv)
        {
            return teste;
        }
        public static string OrdenarString(this DataGridView dgv, Object e)
        {
            var p = e.GetType().GetProperties();
            if (_ordenar.Count == 0)
            {
                return "";
            }
            else
            {
                foreach (var pr in p)
                {
                    if (pr.Name == _ordenar.First().Key)
                    {
                        return pr.GetValue(e).ToString();
                    }
                }
            }
            return "";

        }
        public static int OrdenarInt(this DataGridView dgv, Object e)
        {
            var p = e.GetType().GetProperties();
            if (_ordenar.Count == 0)
            {
                return 0;
            }
            else
            {
                foreach (var pr in p)
                {
                    if (pr.Name == _ordenar.First().Key)
                    {
                        return int.Parse(pr.GetValue(e).ToString());
                    }
                }
            }
            return 0;

        }
    }
}
