﻿// <auto-generated />
using System;
using InventarioTI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventarioTI.Migrations
{
    [DbContext(typeof(InventarioContext))]
    partial class InventarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("InventarioTI.Entites.Cliente", b =>
                {
                    b.Property<int>("ID_C")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Matricula")
                        .HasMaxLength(10)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.HasKey("ID_C");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("InventarioTI.Entites.Equipamento", b =>
                {
                    b.Property<int>("ID_E")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteID_C")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Disco")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nomenclatura")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("Patrimonio")
                        .HasMaxLength(15)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Processador")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Ram")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<int>("UnidadeID_U")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID_E");

                    b.HasIndex("ClienteID_C");

                    b.HasIndex("UnidadeID_U");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("InventarioTI.Entites.Movimetacao", b =>
                {
                    b.Property<int>("ID_M")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Chamado")
                        .HasMaxLength(20)
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteID_C")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("DateTime");

                    b.Property<int>("EquipamentoID_E")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResponsavelID_R")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<int>("UnidadeID_U")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID_M");

                    b.HasIndex("ClienteID_C");

                    b.HasIndex("EquipamentoID_E");

                    b.HasIndex("ResponsavelID_R");

                    b.HasIndex("UnidadeID_U");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("InventarioTI.Entites.Responsavel", b =>
                {
                    b.Property<int>("ID_R")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CLienteID_C")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Nivel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefoneCOrporativo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefoneSecundario")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID_R");

                    b.HasIndex("CLienteID_C");

                    b.ToTable("Responsaveis");
                });

            modelBuilder.Entity("InventarioTI.Entites.ResponsavelUnidade", b =>
                {
                    b.Property<int>("ID_R")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ID_U")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ResponsavelID_R")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnidadeID_U")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID_R", "ID_U");

                    b.HasIndex("ResponsavelID_R");

                    b.HasIndex("UnidadeID_U");

                    b.ToTable("ResponsaveisUnidades");
                });

            modelBuilder.Entity("InventarioTI.Entites.Unidade", b =>
                {
                    b.Property<int>("ID_U")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("TEXT");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("TEXT");

                    b.HasKey("ID_U");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("InventarioTI.Entites.Equipamento", b =>
                {
                    b.HasOne("InventarioTI.Entites.Cliente", "Cliente")
                        .WithMany("Equipamentos")
                        .HasForeignKey("ClienteID_C")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventarioTI.Entites.Unidade", "Unidade")
                        .WithMany()
                        .HasForeignKey("UnidadeID_U")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("InventarioTI.Entites.Movimetacao", b =>
                {
                    b.HasOne("InventarioTI.Entites.Cliente", "Cliente")
                        .WithMany("Movimetacoes")
                        .HasForeignKey("ClienteID_C");

                    b.HasOne("InventarioTI.Entites.Equipamento", "Equipamento")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("EquipamentoID_E")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventarioTI.Entites.Responsavel", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelID_R")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventarioTI.Entites.Unidade", "Unidade")
                        .WithMany()
                        .HasForeignKey("UnidadeID_U")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Equipamento");

                    b.Navigation("Responsavel");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("InventarioTI.Entites.Responsavel", b =>
                {
                    b.HasOne("InventarioTI.Entites.Cliente", "CLiente")
                        .WithMany()
                        .HasForeignKey("CLienteID_C")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CLiente");
                });

            modelBuilder.Entity("InventarioTI.Entites.ResponsavelUnidade", b =>
                {
                    b.HasOne("InventarioTI.Entites.Responsavel", "Responsavel")
                        .WithMany("Unidades")
                        .HasForeignKey("ResponsavelID_R")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InventarioTI.Entites.Unidade", "Unidade")
                        .WithMany("Responsaveis")
                        .HasForeignKey("UnidadeID_U")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsavel");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("InventarioTI.Entites.Cliente", b =>
                {
                    b.Navigation("Equipamentos");

                    b.Navigation("Movimetacoes");
                });

            modelBuilder.Entity("InventarioTI.Entites.Equipamento", b =>
                {
                    b.Navigation("Movimentacoes");
                });

            modelBuilder.Entity("InventarioTI.Entites.Responsavel", b =>
                {
                    b.Navigation("Unidades");
                });

            modelBuilder.Entity("InventarioTI.Entites.Unidade", b =>
                {
                    b.Navigation("Responsaveis");
                });
#pragma warning restore 612, 618
        }
    }
}
