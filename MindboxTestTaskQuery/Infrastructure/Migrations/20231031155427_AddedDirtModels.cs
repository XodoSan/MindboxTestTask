using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MindboxTestTaskQuery.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedDirtModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirtCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirtCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirtProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirtProducts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DirtCategories",
                columns: new[] { "Id", "CategoryId", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, "Computer peripherals", 4 },
                    { 2, 1, "Computer peripherals", 2 },
                    { 3, 1, "Computer peripherals", 3 },
                    { 4, 2, "TV's", 2 },
                    { 5, 2, "TV's", 3 },
                    { 6, 3, "Laptops", null },
                    { 7, 4, "Softwares", null },
                    { 8, 5, "Phones", 1 },
                    { 9, 5, "Phones", 2 },
                    { 10, 5, "Phones", 3 }
                });

            migrationBuilder.InsertData(
                table: "DirtProducts",
                columns: new[] { "Id", "CategoryId", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, 5, "Apple", 1 },
                    { 2, 5, "Samsung", 2 },
                    { 3, 5, "Xiaomi", 3 },
                    { 4, 1, "Logitech", 4 },
                    { 5, 1, "Samsung", 2 },
                    { 6, 1, "Xiaomi", 3 },
                    { 7, 2, "Samsung", 2 },
                    { 8, 2, "Xiaomi", 3 },
                    { 9, 4, "Microsoft", 5 },
                    { 10, null, "Coffee", 6 },
                    { 11, null, "Cookies", 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirtCategories");

            migrationBuilder.DropTable(
                name: "DirtProducts");
        }
    }
}
