using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infra.Data.Migrations
{
    public partial class SeedCategoriesData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailFileName",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "CategoryEnglishName",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryEnglishName", "CategoryName", "Liked" },
                values: new object[,]
                {
                    { 1, "Dairy", "لبنیات", 0 },
                    { 2, "Meat", "پروتئین", 0 },
                    { 3, "Health", "بهداشتی", 0 },
                    { 4, "JunkFood", "تنقلات", 0 },
                    { 5, "Grocery", "خوار و بار", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CategoryEnglishName",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "ThumbnailFileName",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
