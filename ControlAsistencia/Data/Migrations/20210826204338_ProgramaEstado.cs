using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlAsistencia.Data.Migrations
{
    public partial class ProgramaEstado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Programa",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Programa");
        }
    }
}
