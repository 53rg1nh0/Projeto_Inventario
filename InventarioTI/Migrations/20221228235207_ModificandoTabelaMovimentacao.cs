using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioTI.Migrations
{
    /// <inheritdoc />
    public partial class ModificandoTabelaMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chamado",
                table: "Movimentacoes");

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Movimentacoes",
                type: "TEXT",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Movimentacoes");

            migrationBuilder.AddColumn<int>(
                name: "Chamado",
                table: "Movimentacoes",
                type: "INTEGER",
                maxLength: 20,
                nullable: true);
        }
    }
}
