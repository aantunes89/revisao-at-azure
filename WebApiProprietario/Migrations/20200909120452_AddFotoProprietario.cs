using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProprietario.Migrations
{
    public partial class AddFotoProprietario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Proprietarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Proprietarios");
        }
    }
}
