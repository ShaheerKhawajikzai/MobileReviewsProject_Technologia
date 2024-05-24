using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileReviewsProject.Migrations
{
    /// <inheritdoc />
    public partial class addingSEOFieldInDeviceTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SEO",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SEO",
                table: "Devices");
        }
    }
}
