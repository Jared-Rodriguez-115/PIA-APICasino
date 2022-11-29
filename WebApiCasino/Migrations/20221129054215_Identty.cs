using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCasino.Migrations
{
    public partial class Identty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Premios",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Premios_UsuarioId",
                table: "Premios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Premios_AspNetUsers_UsuarioId",
                table: "Premios",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Premios_AspNetUsers_UsuarioId",
                table: "Premios");

            migrationBuilder.DropIndex(
                name: "IX_Premios_UsuarioId",
                table: "Premios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Premios");
        }
    }
}
