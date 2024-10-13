using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aliquota.Domain.Webapp.Migrations
{
    /// <inheritdoc />
    public partial class RelationClienteProd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "ProdutoFinanceiro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoFinanceiro_ClienteId",
                table: "ProdutoFinanceiro",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoFinanceiro_Clientes_ClienteId",
                table: "ProdutoFinanceiro",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoFinanceiro_Clientes_ClienteId",
                table: "ProdutoFinanceiro");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoFinanceiro_ClienteId",
                table: "ProdutoFinanceiro");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "ProdutoFinanceiro");
        }
    }
}
