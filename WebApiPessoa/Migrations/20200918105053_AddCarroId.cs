using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiPessoa.Migrations
{
    public partial class AddCarroId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarroId",
                table: "Pessoa",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarroId",
                table: "Pessoa");
        }
    }
}
