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
    }
}
