using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class testingfk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Results",
                newName: "MatchRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Matches_MatchRefId",
                table: "Results",
                column: "MatchRefId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Matches_MatchRefId",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "MatchRefId",
                table: "Results",
                newName: "MatchId");
        }
    }
}
