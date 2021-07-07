using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Infra.Data.Migrations
{
    public partial class AddProductUserRels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoughtCount",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "UserProductLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProductLikes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProductLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProductSolds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductSolds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProductSolds_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProductSolds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProductViews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProductViews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProductViews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProductLikes_ProductId",
                table: "UserProductLikes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductLikes_UserId",
                table: "UserProductLikes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductSolds_ProductId",
                table: "UserProductSolds",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductSolds_UserId",
                table: "UserProductSolds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductViews_ProductId",
                table: "UserProductViews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductViews_UserId",
                table: "UserProductViews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProductLikes");

            migrationBuilder.DropTable(
                name: "UserProductSolds");

            migrationBuilder.DropTable(
                name: "UserProductViews");

            migrationBuilder.AddColumn<long>(
                name: "BoughtCount",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
