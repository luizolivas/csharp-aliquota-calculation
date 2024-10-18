using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aliquota.Domain.Webapp.Migrations
{
    /// <inheritdoc />
    public partial class AddLucroEmMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Lucro",
                table: "HistoricoMovimentacao",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lucro",
                table: "HistoricoMovimentacao");
        }
    }
}
