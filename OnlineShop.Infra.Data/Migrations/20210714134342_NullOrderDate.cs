using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infra.Data.Migrations
{
    public partial class NullOrderDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Carts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1,
                column: "DateOrdered",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateSignedIn",
                value: new DateTime(2021, 7, 14, 18, 13, 42, 74, DateTimeKind.Local).AddTicks(5384));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOrdered",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1,
                column: "DateOrdered",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateSignedIn",
                value: new DateTime(2021, 7, 14, 18, 9, 35, 214, DateTimeKind.Local).AddTicks(2804));
        }
    }
}
