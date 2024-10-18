using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aliquota.Domain.Webapp.Migrations
{
    /// <inheritdoc />
    public partial class AddValorImpostoInHistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorImposto",
                table: "HistoricoMovimentacao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorImposto",
                table: "HistoricoMovimentacao");
        }
    }
}
