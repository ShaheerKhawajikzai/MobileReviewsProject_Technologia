using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileReviewsProject.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsRefactorFiledInDeviceTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRefactor",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRefactor",
                table: "Devices");
        }
    }
}
