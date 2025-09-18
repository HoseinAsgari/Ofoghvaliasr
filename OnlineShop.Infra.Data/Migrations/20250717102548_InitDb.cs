using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryEnglishName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Liked = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: false),
                    UserActivationLink = table.Column<string>(type: "nvarchar(max)", maxLength: 10000, nullable: true),
                    IsAccountActive = table.Column<bool>(type: "bit", nullable: false),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Banned = table.Column<bool>(type: "bit", nullable: false),
                    DateSignedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", maxLength: 100000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductPrice = table.Column<long>(type: "bigint", nullable: false),
                    UnitOfProduct = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    IsOrdered = table.Column<bool>(type: "bit", nullable: false),
                    DateOrdered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Delivered = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersIPAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLogged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersIPAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersIPAddresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

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

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<long>(type: "bigint", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId");
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Banned", "DateSignedIn", "IsAccountActive", "IsAdmin", "UserActivationLink", "UserAddress", "UserEmail", "UserName", "UserPassword", "UserPhoneNumber" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, "تهران، دانشگاه شاهد", "hosein.asgari@gmail.com", "حسین عسگری", "84-85-F2-CF-5C-63-F1-72-85-B5-BA-29-03-D9-93-BF-F7-D5-5A-AE-91-09-0E-34-4A-86-26-6A-11-D9-74-55", "09123456789" },
                    { 2, false, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, null, "تهران، دانشگاه شاهد", "mohammad.tahriri@gmail.com", "محمد تحریری", "34-F8-G0-CF-5C-23-G1-72-85-B5-BA-A9-03-D9-93-BF-F7-65-5A-AE-91-09-0E-34-4A-86-26-9B-A1-D2-48-15", "09123456789" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "CartId", "DateOrdered", "Delivered", "IsOrdered", "Price", "UserId" },
                values: new object[] { 1, null, false, false, 0L, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductName", "ProductPrice", "UnitOfProduct" },
                values: new object[,]
                {
                    { 1, 1, "شیر دامداران", 7000L, "بطری" },
                    { 2, 1, "ماست میهن", 40000L, "دبه" },
                    { 3, 1, "کشک سمیه", 15000L, "شیشه" },
                    { 4, 1, "دوغ آبعلی", 5000L, "شیشه" },
                    { 5, 1, "دوغ عالیس", 10000L, "بطری" },
                    { 6, 1, "دوغ سنتی دامداران", 10000L, "بطری" },
                    { 7, 1, "خامه میهن", 10000L, "بسته" },
                    { 8, 1, "خامه دامداران", 10000L, "بسته" },
                    { 9, 1, "کره کوچک دامداران", 7000L, "بسته" },
                    { 10, 1, "کره متوسط دامداران", 1000L, "بسته" },
                    { 11, 1, "کره بزرگ دامداران", 12000L, "بسته" },
                    { 12, 1, "کشک کامبیز", 10000L, "شیشه" },
                    { 13, 3, "مایع ظرفشویی پریل", 20000L, "ظرف" },
                    { 14, 3, "پودر لباسشویی پرسیل", 20000L, "بسته" },
                    { 15, 3, "پودر لباسشویی سافتلن", 20000L, "بسته" },
                    { 16, 3, "پودر لباسشویی نگین", 20000L, "بسته" },
                    { 17, 3, "شامپو صحت", 20000L, "بطری" },
                    { 18, 3, "شامپو گلرنگ", 20000L, "بطری" },
                    { 19, 3, "صابون داو", 5000L, "قالب" },
                    { 20, 3, "صابون گلنار", 5000L, "قالب" },
                    { 21, 3, "مایع دستشویی داو", 20000L, "بطری" },
                    { 22, 3, "مایع دستشویی اوه", 20000L, "بطری" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

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

            migrationBuilder.CreateIndex(
                name: "IX_UsersIPAddresses_UserId",
                table: "UsersIPAddresses",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "UserProductLikes");

            migrationBuilder.DropTable(
                name: "UserProductSolds");

            migrationBuilder.DropTable(
                name: "UserProductViews");

            migrationBuilder.DropTable(
                name: "UsersIPAddresses");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
