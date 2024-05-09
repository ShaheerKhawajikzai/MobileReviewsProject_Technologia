using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MobileReviewsProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceInPKR = table.Column<double>(type: "float", nullable: false),
                    PriceInUSD = table.Column<double>(type: "float", nullable: false),
                    OperatinSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserInterface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    Sim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoGBand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreeGBand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourGBand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiveGBand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Technology = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Protection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuiltIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Main = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Front = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WLAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bluetooth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NFC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sensors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Audio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Messaging = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Games = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Torch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Samsung" },
                    { 2, "Apple" },
                    { 3, "Vivo" },
                    { 4, "Techno" },
                    { 5, "Oppo" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "Audio", "Bluetooth", "BrandId", "Browser", "BuiltIn", "CPU", "Capacity", "Card", "Chipset", "Colors", "Data", "Description", "Dimensions", "Extra", "ExtraFeatures", "Features", "FiveGBand", "FourGBand", "Front", "GPS", "GPU", "Games", "ImageUrl", "Main", "Messaging", "Model", "NFC", "OperatinSystem", "PriceInPKR", "PriceInUSD", "Protection", "Resolution", "Sensors", "Sim", "Technology", "ThreeGBand", "Torch", "TwoGBand", "USB", "UserInterface", "WLAN", "Weight" },
                values: new object[,]
                {
                    { 1, null, null, 1, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "\\Images\\SamsungGalaxyS24Ultra-s.jpg", null, null, "S24", null, null, 150000.0, 1500.0, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 2, null, null, 2, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "\\Images\\Iphone.jpg", null, null, "Iphone14ProMax", null, null, 120000.0, 1200.0, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 3, null, null, 3, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "\\Images\\VivoV30.jpg", null, null, "V30", null, null, 11000.0, 1100.0, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 4, null, null, 4, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "\\Images\\TechnoSpark20256GB.jpg", null, null, "Spark20", null, null, 90000.0, 600.0, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 5, null, null, 5, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, "\\Images\\OppoReno11-s.jpg", null, null, "Reno11", null, null, 11000.0, 1100.0, null, null, null, null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_BrandId",
                table: "Devices",
                column: "BrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
