using Microsoft.EntityFrameworkCore.Migrations;

namespace Prover.Data.Migrations
{
    public partial class RemoverUserCadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Cadastros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Cadastros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
