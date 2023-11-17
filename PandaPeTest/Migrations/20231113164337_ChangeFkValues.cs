using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PandaPeTest.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFkValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarqueInformacion_Archivo",
                schema: "dbo",
                table: "CandidateExperiences");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatesExperiences_Candidates",
                schema: "dbo",
                table: "CandidateExperiences",
                column: "IdCandidate",
                principalSchema: "dbo",
                principalTable: "Candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatesExperiences_Candidates",
                schema: "dbo",
                table: "CandidateExperiences");

            migrationBuilder.AddForeignKey(
                name: "FK_CarqueInformacion_Archivo",
                schema: "dbo",
                table: "CandidateExperiences",
                column: "IdCandidate",
                principalSchema: "dbo",
                principalTable: "Candidates",
                principalColumn: "IdCandidate",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
