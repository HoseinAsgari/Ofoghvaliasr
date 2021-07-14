using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infra.Data.Migrations
{
    public partial class SeedUserAndCartData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Banned", "DateSignedIn", "IsAccountActive", "IsAdmin", "UserActivationLink", "UserAddress", "UserEmail", "UserName", "UserPassword", "UserPhoneNumber" },
                values: new object[] { 1, false, new DateTime(2021, 7, 14, 18, 9, 35, 214, DateTimeKind.Local).AddTicks(2804), true, true, null, "کرج، بلوار دانش آموز، کوی ولیعصر ،پشت بانک ملی ،کوچه دوازدهم، ساختمان یاس، پلاک ۱۵،طبقه اول ،واحد 2.", "hosein.asgari.00@gmail.com", "حسین عسگری", "F0-99-2F-88-E6-1F-2D-B7-A7-03-F9-29-6C-A2-FA-69", "09199908681" });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "DateOrdered", "IsOrdered", "Price", "UserId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 0L, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "Carts",
                keyColumn: "CartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Carts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
