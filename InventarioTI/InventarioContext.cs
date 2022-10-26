using InventarioTI.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI
{
    public class InventarioContext:DbContext
    {
        private string _pathDB = @"C:\Users\sesousa\OneDrive - SOLAR BR PARTICIPAÇÕES S.A\Desktop\DBInvenTI.db";

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Movimetacao> Movimentacoes { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<ResponsavelUnidade> ResponsaveisUnidades { get; set; }
        public DbSet<Unidade> Unidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source="+_pathDB);
        }

    }
}
