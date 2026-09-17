using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeepDive11.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 31,
                column: "Model",
                value: null);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 32,
                column: "Model",
                value: null);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 33,
                column: "Model",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 31,
                column: "Model",
                value: "MK25EVO/S600/R105");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 32,
                column: "Model",
                value: "MK17EVO/C370/R095");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 33,
                column: "Model",
                value: "MK25EVO BT/A700 Carbon BT/S270");
        }
    }
}
