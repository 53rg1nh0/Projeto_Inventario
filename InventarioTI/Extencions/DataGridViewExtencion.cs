using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI.Extencions
{
    static class DataGridViewExtencion
    {
        public static void Estilo<T>(this DataGridView DG, T[] dados)
        {
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
                if (column.HeaderText == "Uf")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 25;
                }
                if (column.HeaderText == "Disco" || column.HeaderText == "Ram" || column.HeaderText == "Sigla")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 40;
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
                    column.Width = 300;
                }
                if (column.HeaderText == "ID_C" || column.HeaderText == "ID_U" || column.HeaderText == "ID_FK_C" 
                    || column.HeaderText == "ID_FK_U" || column.HeaderText == "Nivel" || column.HeaderText == "Senha"
                    || column.HeaderText == "ID_E" || column.HeaderText == "Cliente" || column.HeaderText == "Unidade"
                    || column.HeaderText == "Movimentacoes" || column.HeaderText == "Disco" || column.HeaderText == "Status")
                {
                    column.Visible = false;
                }
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
    }
}
