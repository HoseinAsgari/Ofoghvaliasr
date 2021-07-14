using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infra.Data.Migrations
{
    public partial class AddOrderDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsFinished",
                table: "Carts",
                newName: "IsOrdered");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Carts",
                newName: "DateOrdered");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsOrdered",
                table: "Carts",
                newName: "IsFinished");

            migrationBuilder.RenameColumn(
                name: "DateOrdered",
                table: "Carts",
                newName: "DateCreated");
        }
    }
}
