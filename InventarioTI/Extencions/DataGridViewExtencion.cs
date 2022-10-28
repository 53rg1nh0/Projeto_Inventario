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
                if (column.HeaderText == "ID_C" || column.HeaderText == "ID_U" || column.HeaderText == "ID_FK_C" || column.HeaderText == "ID_FK_U" || column.HeaderText == "Nivel" || column.HeaderText == "Senha")
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
                int i = 1, j = 1;
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible)
                        {
                            if (i == 1)
                            {
                                worksheet.Column(j).Cell(i).Value = column.HeaderText.ToUpper();
                                Celulas(worksheet.Column(j).Cell(i), true, true);
                            }
                            else
                            {
                                worksheet.Column(j).Cell(i).Value = dgv.Rows[i-1].Cells[j-1].Value;
                                Celulas(worksheet.Column(j).Cell(i));
                            }
                            j++;
                        }
                    }
                    i++;
                    j = 1;
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
