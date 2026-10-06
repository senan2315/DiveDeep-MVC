using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DeepDive11.Migrations
{
    /// <inheritdoc />
    public partial class AddProductCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "_products");

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId",
                table: "_products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "_productCategories",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__productCategories", x => x.ProductCategoryId);
                });

            migrationBuilder.InsertData(
                table: "_productCategories",
                columns: new[] { "ProductCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "BCD" },
                    { 2, "Dykkerdragter" },
                    { 3, "Tanke" },
                    { 4, "Maske og Snorkel" },
                    { 5, "Finner" },
                    { 6, "Regulatorsæt" },
                    { 7, "Komplette sæt" }
                });

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ProductCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "ProductCategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "ProductCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "ProductCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "ProductCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "ProductCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "ProductCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "ProductCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 11,
                column: "ProductCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 12,
                column: "ProductCategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 13,
                column: "ProductCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 14,
                column: "ProductCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 15,
                column: "ProductCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 16,
                column: "ProductCategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 17,
                column: "ProductCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 18,
                column: "ProductCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 19,
                column: "ProductCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 20,
                column: "ProductCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 21,
                column: "ProductCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 22,
                column: "ProductCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 23,
                column: "ProductCategoryId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 24,
                column: "ProductCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 25,
                column: "ProductCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 26,
                column: "ProductCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 27,
                column: "ProductCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 28,
                column: "ProductCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 29,
                column: "ProductCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 30,
                column: "ProductCategoryId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 31,
                column: "ProductCategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 32,
                column: "ProductCategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 33,
                column: "ProductCategoryId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 34,
                column: "ProductCategoryId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 35,
                column: "ProductCategoryId",
                value: 7);

            migrationBuilder.CreateIndex(
                name: "IX__products_ProductCategoryId",
                table: "_products",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK__products__productCategories_ProductCategoryId",
                table: "_products",
                column: "ProductCategoryId",
                principalTable: "_productCategories",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__products__productCategories_ProductCategoryId",
                table: "_products");

            migrationBuilder.DropTable(
                name: "_productCategories");

            migrationBuilder.DropIndex(
                name: "IX__products_ProductCategoryId",
                table: "_products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "_products");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "_products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "Category",
                value: "BCD");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "Category",
                value: "BCD");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "Category",
                value: "BCD");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "Category",
                value: "BCD");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "Category",
                value: "Dykkerdragter");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "Category",
                value: "Dykkerdragter");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "Category",
                value: "Dykkerdragter");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "Category",
                value: "Dykkerdragter");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "Category",
                value: "Dykkerdragter");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "Category",
                value: "Dykkerdragter");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 11,
                column: "Category",
                value: "Dykkerdragter");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 12,
                column: "Category",
                value: "Dykkerdragter");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 13,
                column: "Category",
                value: "Tanke");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 14,
                column: "Category",
                value: "Tanke");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 15,
                column: "Category",
                value: "Tanke");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 16,
                column: "Category",
                value: "Tanke");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 17,
                column: "Category",
                value: "Maske og Snorkel");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 18,
                column: "Category",
                value: "Maske og Snorkel");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 19,
                column: "Category",
                value: "Maske ogSnorkel");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 20,
                column: "Category",
                value: "Maske og Snorkel");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 21,
                column: "Category",
                value: "Maske og Snorkel");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 22,
                column: "Category",
                value: "Maske og Snorkel");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 23,
                column: "Category",
                value: "Maske og Snorkel");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 24,
                column: "Category",
                value: "Finner");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 25,
                column: "Category",
                value: "Finner");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 26,
                column: "Category",
                value: "Finner");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 27,
                column: "Category",
                value: "Finner");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 28,
                column: "Category",
                value: "Finner");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 29,
                column: "Category",
                value: "Finner");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 30,
                column: "Category",
                value: "Finner");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 31,
                column: "Category",
                value: "Regulatorsæt");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 32,
                column: "Category",
                value: "Regulatorsæt");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 33,
                column: "Category",
                value: "Regulatorsæt");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 34,
                column: "Category",
                value: "Komplette sæt");

            migrationBuilder.UpdateData(
                table: "_products",
                keyColumn: "ProductId",
                keyValue: 35,
                column: "Category",
                value: "Komplette sæt");
        }
    }
}
