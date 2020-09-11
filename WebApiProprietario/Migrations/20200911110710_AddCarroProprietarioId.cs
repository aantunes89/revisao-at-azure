using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiProprietario.Migrations
{
    public partial class AddCarroProprietarioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carro_Proprietarios_ProprietarioId",
                table: "Carro");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProprietarioId",
                table: "Carro",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carro_Proprietarios_ProprietarioId",
                table: "Carro",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carro_Proprietarios_ProprietarioId",
                table: "Carro");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProprietarioId",
                table: "Carro",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Carro_Proprietarios_ProprietarioId",
                table: "Carro",
                column: "ProprietarioId",
                principalTable: "Proprietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
