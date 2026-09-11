using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeepDive11.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "_products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductSize = table.Column<int>(type: "int", nullable: true),
                    PricePerDay = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGender = table.Column<int>(type: "int", nullable: true),
                    Thickness = table.Column<double>(type: "float", nullable: true),
                    Volume = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sizes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondStage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Octopus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IncludedItems = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "_bookingProducts",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bookingProducts", x => new { x.BookingId, x.ProductId });
                    table.ForeignKey(
                        name: "FK__bookingProducts__bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "_bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__bookingProducts__products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "_products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "_products",
                columns: new[] { "ProductId", "Brand", "Category", "Description", "FirstStage", "Image", "IncludedItems", "Model", "Octopus", "PricePerDay", "ProductGender", "ProductSize", "SecondStage", "Sizes", "Thickness", "Type", "Volume" },
                values: new object[,]
                {
                    { 1, "Scubapro", "BCD", null, null, "NavigatorLiteBCD.webp", null, "Navigator Lite BCD", null, 125, null, null, null, "[\"S\",\"M\",\"L\"]", null, null, null },
                    { 2, "Scubapro", "BCD", null, null, "BCDGlide.webp", null, "BCD Glide", null, 140, null, null, null, "[\"S\",\"M\",\"L\"]", null, null, null },
                    { 3, "Scubapro", "BCD", null, null, "HydrosPro.webp", null, "BCD Hydros Pro", null, 200, null, null, null, "[\"S\",\"M\",\"L\"]", null, null, null },
                    { 4, "Seac", "BCD", null, null, "BCDModular.webp", null, "BCD Modular", null, 145, null, null, null, "[\"S\",\"M\",\"L\"]", null, null, null },
                    { 5, "Scubapro", "Dykkerdragter", null, null, "Våddragt.jpeg", null, "Definition", null, 100, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", 3.0, "Våddragt", null },
                    { 6, "Scubapro", "Dykkerdragter", null, null, "Våddragt.jpeg", null, "Definition", null, 100, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", 5.0, "Våddragt", null },
                    { 7, "Scubapro", "Dykkerdragter", null, null, "Våddragt.jpeg", null, "Definition", null, 100, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", 7.0, "Våddragt", null },
                    { 8, "Waterproof", "Dykkerdragter", null, null, "Våddragt.jpeg", null, "W5", null, 100, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", 3.5, "Våddragt", null },
                    { 9, "Fourth Element", "Dykkerdragter", null, null, "Våddragt.jpeg", null, "Proteus", null, 120, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", 5.0, "Våddragt", null },
                    { 10, "Scubapro", "Dykkerdragter", null, null, "Tørdragt.webp", null, "Exodry 4.0", null, 300, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, "Tørdragt", null },
                    { 11, "Waterproof", "Dykkerdragter", null, null, "Tørdragt.webp", null, "D7 Evo", null, 320, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, "Tørdragt", null },
                    { 12, "Santi", "Dykkerdragter", null, null, "Tørdragt.webp", null, "E.Lite Plus", null, 350, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, "Tørdragt", null },
                    { 13, "Scubapro", "Tanke", null, null, "Tank.jpg", null, "Tank 5 liter", null, 150, null, null, null, null, null, null, 5 },
                    { 14, "Scubapro", "Tanke", null, null, "Tank.jpg", null, "Tank 10 liter", null, 160, null, null, null, null, null, null, 10 },
                    { 15, "Scubapro", "Tanke", null, null, "Tank.jpg", null, "Tank 12 liter", null, 170, null, null, null, null, null, null, 12 },
                    { 16, "Scubapro", "Tanke", null, null, "Tank.jpg", null, "Tank 15 liter", null, 180, null, null, null, null, null, null, 15 },
                    { 17, "Scubapro", "Maske og Snorkel", null, null, "GhostMaske.jpg", null, "Ghost", null, 50, null, null, null, null, null, null, null },
                    { 18, "Scubapro", "Maske og Snorkel", null, null, "DMask.jpg", null, "D-Mask", null, 60, null, null, null, null, null, null, null },
                    { 19, "Scubapro", "Maske ogSnorkel", null, null, "SpectraMini.jpg", null, "Spectra Mini", null, 50, null, null, null, null, null, null, null },
                    { 20, "Scubapro", "Maske og Snorkel", null, null, "CrystalVU.jpg", null, "Crystal VU", null, 75, null, null, null, null, null, null, null },
                    { 21, "Fourth Element", "Maske og Snorkel", null, null, "ScoutKontrast.jpg", null, "Scout Kontrast", null, 75, null, null, null, null, null, null, null },
                    { 22, "Fourth Element", "Maske og Snorkel", null, null, "ScoutEnhance.webp", null, "Scout Enhance", null, 75, null, null, null, null, null, null, null },
                    { 23, "Tusa", "Maske og Snorkel", null, null, "TUSA.jpg", null, "Element", null, 75, null, null, null, null, null, null, null },
                    { 24, "Scubapro", "Finner", null, null, "JetFin.webp", null, "Jet Fin", null, 50, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, null, null },
                    { 25, "Scubapro", "Finner", null, null, "GOTravel.webp", null, "GO Travel", null, 50, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, null, null },
                    { 26, "Scubapro", "Finner", null, null, "SuperNova.webp", null, "Seawing Supernova", null, 60, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, null, null },
                    { 27, "Seac", "Finner", null, null, "Propulsion.webp", null, "Propulsion", null, 50, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, null, null },
                    { 28, "Seac", "Finner", null, null, "ALA.webp", null, "ALA", null, 50, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, null, null },
                    { 29, "Fourth Element", "Finner", null, null, "Tech", null, "Tech", null, 75, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, null, null },
                    { 30, "Fourth Element", "Finner", null, null, "RecFin.jpg", null, "Rec Fin", null, 80, null, null, null, "[\"XS\",\"S\",\"M\",\"L\",\"XL\"]", null, null, null },
                    { 31, "Scubapro", "Regulatorsæt", null, "MK25EVO", "RegulatorSæt31.webp", null, "MK25EVO/S600/R105", "R105", 125, null, null, "S600", null, null, null, null },
                    { 32, "Scubapro", "Regulatorsæt", null, "MK17EVO", "RegulatorSæt32.jpg", null, "MK17EVO/C370/R095", "R095", 100, null, null, "C370", null, null, null, null },
                    { 33, "Scubapro", "Regulatorsæt", null, "MK25EVO BT", "RegulatorSæt33.webp", null, "MK25EVO BT/A700 Carbon BT/S270", "S270", 150, null, null, "A700 Carbon BT", null, null, null, null },
                    { 34, "Dive Deep", "Komplette sæt", null, null, "DykkerSæt.jpg", "[\"BCD\",\"Dykkerdragt\",\"Regulators\\u00E6t\",\"Tank\",\"Finner\",\"Maske\",\"Snorkel\"]", "Komplet dykkersæt", null, 760, null, null, null, null, null, null, null },
                    { 35, "Dive Deep", "Komplette sæt", null, null, "snorkelsæt.webp", "[\"Maske\",\"Snorkel\",\"Finner\"]", "Komplet snorkelsæt", null, 650, null, null, null, null, null, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX__bookingProducts_ProductId",
                table: "_bookingProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_bookingProducts");

            migrationBuilder.DropTable(
                name: "_bookings");

            migrationBuilder.DropTable(
                name: "_products");
        }
    }
}
