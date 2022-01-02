using Microsoft.EntityFrameworkCore.Migrations;

namespace Prover.Data.Migrations
{
    public partial class ColunaUserCargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Cargos",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Cargos");
        }
    }
}
