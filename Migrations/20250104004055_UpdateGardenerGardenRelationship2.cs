using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrennansWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGardenerGardenRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_Gardeners_userId",
                table: "Gardens");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_userId",
                table: "Gardens");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Gardens",
                newName: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_LeaderId",
                table: "Gardens",
                column: "LeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_Gardeners_LeaderId",
                table: "Gardens",
                column: "LeaderId",
                principalTable: "Gardeners",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_Gardeners_LeaderId",
                table: "Gardens");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_LeaderId",
                table: "Gardens");

            migrationBuilder.RenameColumn(
                name: "LeaderId",
                table: "Gardens",
                newName: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_userId",
                table: "Gardens",
                column: "userId",
                unique: true,
                filter: "[userId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_Gardeners_userId",
                table: "Gardens",
                column: "userId",
                principalTable: "Gardeners",
                principalColumn: "id");
        }
    }
}
