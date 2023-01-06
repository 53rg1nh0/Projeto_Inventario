using InventarioTI.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTI
{
    public class InventarioContext : DbContext
    {
        private string _pathDB = @"C:\Users\sesousa\OneDrive - SOLAR BR PARTICIPAÇÕES S.A\Desktop\DBInvenTI.db";

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Movimetacao> Movimentacoes { get; set; }
        public DbSet<Responsavel> Responsaveis { get; set; }
        public DbSet<ResponsavelUnidade> ResponsaveisUnidades { get; set; }
        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<AprovacaoTransferencia> AprovacaoTransferencias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + _pathDB);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //////////////////////////////////CLIENTE//////////////////////////////

            modelBuilder.Entity<Cliente>()
                .Property(c => c.UserId)
                    .HasMaxLength(25)
                        .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Nome)
                    .HasMaxLength(100)
                        .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Matricula)
                    .HasMaxLength(10)
                        .IsRequired(false);

            modelBuilder.Entity<Cliente>()
                .Property(c => c.Area)
                    .IsRequired();

            modelBuilder.Entity<Cliente>()
              .Property(c => c.Cargo)
                .IsRequired();

            //modelBuilder.Entity<Cliente>()
            //    .Property(c => c.Unidade)
            //        .IsRequired();

            //modelBuilder.Entity<Cliente>()
            //    .HasOne(c => c.Unidade)
            //        .WithMany(u => u.Clientes);


            //////////////////////////////////EQUIPAMENTO//////////////////////////////
            ///

            modelBuilder.Entity<Equipamento>()
               .Property(e => e.Patrimonio)
                   .HasMaxLength(15)
                       .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Nomenclatura)
                    .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Serie)
                    .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Modelo)
                    .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Tipo)
                    .HasMaxLength(15)
                        .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Marca)
                    .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Processador)
                    .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Ram)
                    .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Disco)
                    .HasMaxLength(20)
                        .IsRequired(false);

            modelBuilder.Entity<Equipamento>()
                .Property(e => e.Status)
                    .HasMaxLength(10)
                        .IsRequired();

            //modelBuilder.Entity<Equipamento>()
            //    .Property(e => e.Cliente)
            //        .IsRequired(false);


            modelBuilder.Entity<Equipamento>()
                .HasOne(e => e.Cliente)
                    .WithMany(c => c.Equipamentos);



            //////////////////////////////////RESPONSAVEL//////////////////////////////
            ///

            //modelBuilder.Entity<Responsavel>()
            //    .Property(r => r.AprovacaoTransferencias)
            //            .IsRequired(false);


            //////////////////////////////////UNIDADE//////////////////////////////
            ///

            modelBuilder.Entity<Unidade>()
                .Property(u => u.Regiao)
                    .HasMaxLength(20)
                        .IsRequired();

            modelBuilder.Entity<Unidade>()
                .Property(u => u.Uf)
                    .HasMaxLength(2)
                        .IsRequired();

            modelBuilder.Entity<Unidade>()
                .Property(u => u.Nome)
                    .HasMaxLength(50)
                        .IsRequired();

            modelBuilder.Entity<Unidade>()
                .Property(u => u.Sigla)
                    .HasMaxLength(4)
                        .IsRequired();

            //////////////////////////////////MOVIMENTACAO//////////////////////////////
            ///
            modelBuilder.Entity<Movimetacao>()
                .Property(m => m.Data)
                    .HasColumnType("DateTime")
                        .IsRequired();

            modelBuilder.Entity<Movimetacao>()
                .Property(m => m.Status)
                    .HasMaxLength(10)
                        .IsRequired();

            modelBuilder.Entity<Movimetacao>()
                .Property(m => m.Observacao)
                    .HasMaxLength(50)
                        .IsRequired(false);

            modelBuilder.Entity<Movimetacao>()
                .HasOne(m => m.Equipamento)
                    .WithMany(e => e.Movimentacoes)
                        .IsRequired();

            modelBuilder.Entity<Movimetacao>()
                .HasOne(m => m.Cliente)
                    .WithMany(c => c.Movimetacoes)
                        .IsRequired(false);

            //////////////////////////////////RESPONSAVELUNIDADE//////////////////////////////
            ///
            modelBuilder.Entity<ResponsavelUnidade>()
                .HasKey(c => new { c.ID_R, c.ID_U });


            //////////////////////////////////APROVACOES//////////////////////////////
            ///

            modelBuilder.Entity<AprovacaoTransferencia>()
              .Property(a => a.UnidadeDestino)
                      .IsRequired();

            modelBuilder.Entity<AprovacaoTransferencia>()
               .Property(a => a.DataInicio)
                   .HasColumnType("DateTime")
                       .IsRequired();

            modelBuilder.Entity<AprovacaoTransferencia>()
                .Property(a => a.DataAprovacao)
                    .HasColumnType("DateTime");

            modelBuilder.Entity<AprovacaoTransferencia>()
                .Property(a => a.ResponsavelAprovacao)
                    .IsRequired(false);

            modelBuilder.Entity<AprovacaoTransferencia>()
              .HasOne(a => a.Responsavel)
                  .WithMany(r => r.AprovacaoTransferencias)
                       .IsRequired(false);
        }


    }
}
