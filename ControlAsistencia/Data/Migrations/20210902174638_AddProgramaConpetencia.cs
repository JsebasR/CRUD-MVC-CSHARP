using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlAsistencia.Data.Migrations
{
    public partial class AddProgramaConpetencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetenciaPrograma",
                columns: table => new
                {
                    ProgramaConpetenciaCompetenciaId = table.Column<int>(type: "int", nullable: false),
                    ProgramaConpetenciaProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenciaPrograma", x => new { x.ProgramaConpetenciaCompetenciaId, x.ProgramaConpetenciaProgramaId });
                    table.ForeignKey(
                        name: "FK_CompetenciaPrograma_Competencia_ProgramaConpetenciaCompetenciaId",
                        column: x => x.ProgramaConpetenciaCompetenciaId,
                        principalTable: "Competencia",
                        principalColumn: "CompetenciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetenciaPrograma_Programa_ProgramaConpetenciaProgramaId",
                        column: x => x.ProgramaConpetenciaProgramaId,
                        principalTable: "Programa",
                        principalColumn: "ProgramaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenciaPrograma_ProgramaConpetenciaProgramaId",
                table: "CompetenciaPrograma",
                column: "ProgramaConpetenciaProgramaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenciaPrograma");
        }
    }
}
