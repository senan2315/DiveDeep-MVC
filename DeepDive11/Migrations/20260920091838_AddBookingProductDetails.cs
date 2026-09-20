using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepDive11.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingProductDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "_bookingProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "_bookingProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "_bookingProducts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "_bookingProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "_bookingProducts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "_bookingProducts");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "_bookingProducts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "_bookingProducts");
        }
    }
}
