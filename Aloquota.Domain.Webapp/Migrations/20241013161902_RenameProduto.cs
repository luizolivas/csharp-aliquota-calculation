using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aliquota.Domain.Webapp.Migrations
{
    /// <inheritdoc />
    public partial class RenameProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoMovimentacao_Produtos_ProdutoFinanceiroId",
                table: "HistoricoMovimentacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "ProdutoFinanceiro");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoFinanceiro",
                table: "ProdutoFinanceiro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoMovimentacao_ProdutoFinanceiro_ProdutoFinanceiroId",
                table: "HistoricoMovimentacao",
                column: "ProdutoFinanceiroId",
                principalTable: "ProdutoFinanceiro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoMovimentacao_ProdutoFinanceiro_ProdutoFinanceiroId",
                table: "HistoricoMovimentacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoFinanceiro",
                table: "ProdutoFinanceiro");

            migrationBuilder.RenameTable(
                name: "ProdutoFinanceiro",
                newName: "Produtos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoMovimentacao_Produtos_ProdutoFinanceiroId",
                table: "HistoricoMovimentacao",
                column: "ProdutoFinanceiroId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
