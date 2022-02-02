using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlAsistencia.Data.Migrations
{
    public partial class AddCompetenciaA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenciaPrograma_Competencia_ProgramaConpetenciaCompetenciaId",
                table: "CompetenciaPrograma");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenciaPrograma_Programa_ProgramaConpetenciaProgramaId",
                table: "CompetenciaPrograma");

            migrationBuilder.RenameColumn(
                name: "ProgramaConpetenciaProgramaId",
                table: "CompetenciaPrograma",
                newName: "ProgramaCompetenciaProgramaId");

            migrationBuilder.RenameColumn(
                name: "ProgramaConpetenciaCompetenciaId",
                table: "CompetenciaPrograma",
                newName: "ProgramaCompetenciaCompetenciaId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenciaPrograma_ProgramaConpetenciaProgramaId",
                table: "CompetenciaPrograma",
                newName: "IX_CompetenciaPrograma_ProgramaCompetenciaProgramaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenciaPrograma_Competencia_ProgramaCompetenciaCompetenciaId",
                table: "CompetenciaPrograma",
                column: "ProgramaCompetenciaCompetenciaId",
                principalTable: "Competencia",
                principalColumn: "CompetenciaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenciaPrograma_Programa_ProgramaCompetenciaProgramaId",
                table: "CompetenciaPrograma",
                column: "ProgramaCompetenciaProgramaId",
                principalTable: "Programa",
                principalColumn: "ProgramaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenciaPrograma_Competencia_ProgramaCompetenciaCompetenciaId",
                table: "CompetenciaPrograma");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenciaPrograma_Programa_ProgramaCompetenciaProgramaId",
                table: "CompetenciaPrograma");

            migrationBuilder.RenameColumn(
                name: "ProgramaCompetenciaProgramaId",
                table: "CompetenciaPrograma",
                newName: "ProgramaConpetenciaProgramaId");

            migrationBuilder.RenameColumn(
                name: "ProgramaCompetenciaCompetenciaId",
                table: "CompetenciaPrograma",
                newName: "ProgramaConpetenciaCompetenciaId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenciaPrograma_ProgramaCompetenciaProgramaId",
                table: "CompetenciaPrograma",
                newName: "IX_CompetenciaPrograma_ProgramaConpetenciaProgramaId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenciaPrograma_Competencia_ProgramaConpetenciaCompetenciaId",
                table: "CompetenciaPrograma",
                column: "ProgramaConpetenciaCompetenciaId",
                principalTable: "Competencia",
                principalColumn: "CompetenciaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenciaPrograma_Programa_ProgramaConpetenciaProgramaId",
                table: "CompetenciaPrograma",
                column: "ProgramaConpetenciaProgramaId",
                principalTable: "Programa",
                principalColumn: "ProgramaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
