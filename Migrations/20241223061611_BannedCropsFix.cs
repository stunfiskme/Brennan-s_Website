using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrennansWebsite.Migrations
{
    /// <inheritdoc />
    public partial class BannedCropsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BannedCrops",
                table: "BannedCrops");

            migrationBuilder.AlterColumn<string>(
                name: "CropName",
                table: "BannedCrops",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "bannedID",
                table: "BannedCrops",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BannedCrops",
                table: "BannedCrops",
                column: "bannedID");

            migrationBuilder.CreateIndex(
                name: "IX_BannedCrops_GardenId",
                table: "BannedCrops",
                column: "GardenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BannedCrops",
                table: "BannedCrops");

            migrationBuilder.DropIndex(
                name: "IX_BannedCrops_GardenId",
                table: "BannedCrops");

            migrationBuilder.DropColumn(
                name: "bannedID",
                table: "BannedCrops");

            migrationBuilder.AlterColumn<string>(
                name: "CropName",
                table: "BannedCrops",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BannedCrops",
                table: "BannedCrops",
                columns: new[] { "GardenId", "CropName" });
        }
    }
}
