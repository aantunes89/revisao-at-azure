using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiPessoa.Migrations
{
    public partial class MigFilhos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Pessoa_ConjugeId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_ConjugeId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "ConjugeId",
                table: "Pessoa");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_PessoaId",
                table: "Pessoa",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Pessoa_PessoaId",
                table: "Pessoa",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Pessoa_PessoaId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_PessoaId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Pessoa");

            migrationBuilder.AddColumn<int>(
                name: "ConjugeId",
                table: "Pessoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_ConjugeId",
                table: "Pessoa",
                column: "ConjugeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Pessoa_ConjugeId",
                table: "Pessoa",
                column: "ConjugeId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
