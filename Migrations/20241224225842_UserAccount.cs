using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrennansWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UserAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_Gardeners_Id",
                table: "Gardens");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_Id",
                table: "Gardens");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Gardens",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Gardeners",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Gardeners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "userAccount",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAccount", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_userId",
                table: "Gardens",
                column: "userId",
                unique: true,
                filter: "[userId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gardeners_userId",
                table: "Gardeners",
                column: "userId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gardeners_userAccount_userId",
                table: "Gardeners",
                column: "userId",
                principalTable: "userAccount",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_Gardeners_userId",
                table: "Gardens",
                column: "userId",
                principalTable: "Gardeners",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gardeners_userAccount_userId",
                table: "Gardeners");

            migrationBuilder.DropForeignKey(
                name: "FK_Gardens_Gardeners_userId",
                table: "Gardens");

            migrationBuilder.DropTable(
                name: "userAccount");

            migrationBuilder.DropIndex(
                name: "IX_Gardens_userId",
                table: "Gardens");

            migrationBuilder.DropIndex(
                name: "IX_Gardeners_userId",
                table: "Gardeners");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Gardeners");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Gardens",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Gardeners",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Gardens_Id",
                table: "Gardens",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Gardens_Gardeners_Id",
                table: "Gardens",
                column: "Id",
                principalTable: "Gardeners",
                principalColumn: "Id");
        }
    }
}
