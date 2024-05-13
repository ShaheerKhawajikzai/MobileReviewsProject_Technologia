using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileReviewsProject.Migrations
{
    /// <inheritdoc />
    public partial class PKRINT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriceInPKRInt",
                table: "Devices",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceInPKRInt",
                table: "Devices");
        }
    }
}
