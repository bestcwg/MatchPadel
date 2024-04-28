using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class testingfk2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameTypeId",
                table: "Matches",
                newName: "GameTypeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GameTypeRefId",
                table: "Matches",
                column: "GameTypeRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_GameTypes_GameTypeRefId",
                table: "Matches",
                column: "GameTypeRefId",
                principalTable: "GameTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_GameTypes_GameTypeRefId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_GameTypeRefId",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "GameTypeRefId",
                table: "Matches",
                newName: "GameTypeId");
        }
    }
}
