using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioTI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID_C = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(type: "INTEGER", maxLength: 10, nullable: true),
                    Area = table.Column<string>(type: "TEXT", nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID_C);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    ID_U = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Regiao = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Uf = table.Column<string>(type: "TEXT", maxLength: 2, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "TEXT", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.ID_U);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    ID_R = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TelefoneCOrporativo = table.Column<string>(type: "TEXT", nullable: false),
                    TelefoneSecundario = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Nivel = table.Column<int>(type: "INTEGER", nullable: false),
                    Senha = table.Column<string>(type: "TEXT", nullable: false),
                    Codigo = table.Column<string>(type: "TEXT", nullable: false),
                    CLienteID_C = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.ID_R);
                    table.ForeignKey(
                        name: "FK_Responsaveis_Clientes_CLienteID_C",
                        column: x => x.CLienteID_C,
                        principalTable: "Clientes",
                        principalColumn: "ID_C",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    ID_E = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Patrimonio = table.Column<int>(type: "INTEGER", maxLength: 15, nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Marca = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Processador = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Ram = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Disco = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ClienteID_C = table.Column<int>(type: "INTEGER", nullable: false),
                    UnidadeID_U = table.Column<int>(type: "INTEGER", nullable: false),
                    Nomenclatura = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Serie = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamentos", x => x.ID_E);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Clientes_ClienteID_C",
                        column: x => x.ClienteID_C,
                        principalTable: "Clientes",
                        principalColumn: "ID_C",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipamentos_Unidades_UnidadeID_U",
                        column: x => x.UnidadeID_U,
                        principalTable: "Unidades",
                        principalColumn: "ID_U",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResponsaveisUnidades",
                columns: table => new
                {
                    ID_R = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_U = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsavelID_R = table.Column<int>(type: "INTEGER", nullable: false),
                    UnidadeID_U = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsaveisUnidades", x => new { x.ID_R, x.ID_U });
                    table.ForeignKey(
                        name: "FK_ResponsaveisUnidades_Responsaveis_ResponsavelID_R",
                        column: x => x.ResponsavelID_R,
                        principalTable: "Responsaveis",
                        principalColumn: "ID_R",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponsaveisUnidades_Unidades_UnidadeID_U",
                        column: x => x.UnidadeID_U,
                        principalTable: "Unidades",
                        principalColumn: "ID_U",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    ID_M = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ClienteID_C = table.Column<int>(type: "INTEGER", nullable: false),
                    EquipamentoID_E = table.Column<int>(type: "INTEGER", nullable: false),
                    UnidadeID_U = table.Column<int>(type: "INTEGER", nullable: false),
                    ResponsavelID_R = table.Column<int>(type: "INTEGER", nullable: false),
                    Chamado = table.Column<int>(type: "INTEGER", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.ID_M);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Clientes_ClienteID_C",
                        column: x => x.ClienteID_C,
                        principalTable: "Clientes",
                        principalColumn: "ID_C");
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Equipamentos_EquipamentoID_E",
                        column: x => x.EquipamentoID_E,
                        principalTable: "Equipamentos",
                        principalColumn: "ID_E",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Responsaveis_ResponsavelID_R",
                        column: x => x.ResponsavelID_R,
                        principalTable: "Responsaveis",
                        principalColumn: "ID_R",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Unidades_UnidadeID_U",
                        column: x => x.UnidadeID_U,
                        principalTable: "Unidades",
                        principalColumn: "ID_U",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_ClienteID_C",
                table: "Equipamentos",
                column: "ClienteID_C");

            migrationBuilder.CreateIndex(
                name: "IX_Equipamentos_UnidadeID_U",
                table: "Equipamentos",
                column: "UnidadeID_U");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ClienteID_C",
                table: "Movimentacoes",
                column: "ClienteID_C");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_EquipamentoID_E",
                table: "Movimentacoes",
                column: "EquipamentoID_E");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ResponsavelID_R",
                table: "Movimentacoes",
                column: "ResponsavelID_R");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_UnidadeID_U",
                table: "Movimentacoes",
                column: "UnidadeID_U");

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_CLienteID_C",
                table: "Responsaveis",
                column: "CLienteID_C");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisUnidades_ResponsavelID_R",
                table: "ResponsaveisUnidades",
                column: "ResponsavelID_R");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsaveisUnidades_UnidadeID_U",
                table: "ResponsaveisUnidades",
                column: "UnidadeID_U");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "ResponsaveisUnidades");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Unidades");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
