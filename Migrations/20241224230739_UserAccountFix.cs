using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrennansWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UserAccountFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "userAccount",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "userAccount");
        }
    }
}
