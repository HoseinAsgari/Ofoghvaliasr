using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infra.Data.Migrations
{
    public partial class AddDeliveredToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Delivered",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateSignedIn",
                value: new DateTime(2021, 7, 14, 19, 43, 28, 219, DateTimeKind.Local).AddTicks(5778));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delivered",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateSignedIn",
                value: new DateTime(2021, 7, 14, 18, 13, 42, 74, DateTimeKind.Local).AddTicks(5384));
        }
    }
}
