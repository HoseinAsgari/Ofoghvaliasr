using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infra.Data.Migrations
{
    public partial class AddUserAddressField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "Users",
                type: "nvarchar(max)",
                maxLength: 100000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "UnitOfProduct",
                value: "دبه");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17,
                column: "UnitOfProduct",
                value: "بطری");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "UnitOfProduct",
                value: "دبه ای");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17,
                column: "UnitOfProduct",
                value: "");
        }
    }
}
