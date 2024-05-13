using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileReviewsProject.Migrations
{
    /// <inheritdoc />
    public partial class AddingSlugTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevicesOldNewSlug",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OldSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicesOldNewSlug", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevicesOldNewSlug_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevicesOldNewSlug_DeviceId",
                table: "DevicesOldNewSlug",
                column: "DeviceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevicesOldNewSlug");
        }
    }
}
