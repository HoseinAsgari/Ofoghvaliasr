using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;

namespace OnlineShop.Infra.Data.Contexts
{
    public class OnlineShopDbContext : DbContext
    {
        public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserProductViews> UserProductViews { get; set; }
        public DbSet<UserProductLikes> UserProductLikes { get; set; }
        public DbSet<UserProductSold> UserProductSolds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SeedCategoryData
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "لبنیات",
                    CategoryEnglishName = "Dairy"
                }, new Category()
                {
                    CategoryId = 2,
                    CategoryName = "پروتئین",
                    CategoryEnglishName = "Meat"
                }, new Category()
                {
                    CategoryId = 3,
                    CategoryName = "بهداشتی",
                    CategoryEnglishName = "Health"
                }, new Category()
                {
                    CategoryId = 4,
                    CategoryName = "تنقلات",
                    CategoryEnglishName = "JunkFood"
                }, new Category()
                {
                    CategoryId = 5,
                    CategoryName = "خوار و بار",
                    CategoryEnglishName = "Grocery"
                });
            #endregion

            #region SeedProductData
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    CategoryId = 1,
                    ProductName = "شیر دامداران",
                    ProductPrice = 7000,
                    UnitOfProduct = "بطری"
                },new Product()
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "ماست میهن",
                    ProductPrice = 40000,
                    UnitOfProduct = "دبه"
                },new Product()
                {
                    ProductId = 3,
                    CategoryId = 1,
                    ProductName = "کشک سمیه",
                    ProductPrice = 15000,
                    UnitOfProduct = "شیشه"
                },new Product()
                {
                    ProductId = 4,
                    CategoryId = 1,
                    ProductName = "دوغ آبعلی",
                    ProductPrice = 5000,
                    UnitOfProduct = "شیشه"
                },new Product()
                {
                    ProductId = 5,
                    CategoryId = 1,
                    ProductName = "دوغ عالیس",
                    ProductPrice = 10000,
                    UnitOfProduct = "بطری"
                },new Product()
                {
                    ProductId = 6,
                    CategoryId = 1,
                    ProductName = "دوغ سنتی دامداران",
                    ProductPrice = 10000,
                    UnitOfProduct = "بطری"
                },new Product()
                {
                    ProductId = 7,
                    CategoryId = 1,
                    ProductName = "خامه میهن",
                    ProductPrice = 10000,
                    UnitOfProduct = "بسته"
                },new Product()
                {
                    ProductId = 8,
                    CategoryId = 1,
                    ProductName = "خامه دامداران",
                    ProductPrice = 10000,
                    UnitOfProduct = "بسته"
                },new Product()
                {
                    ProductId = 9,
                    CategoryId = 1,
                    ProductName = "کره کوچک دامداران",
                    ProductPrice = 7000,
                    UnitOfProduct = "بسته"
                },new Product()
                {
                    ProductId = 10,
                    CategoryId = 1,
                    ProductName = "کره متوسط دامداران",
                    ProductPrice = 1000,
                    UnitOfProduct = "بسته"
                },new Product()
                {
                    ProductId = 11,
                    CategoryId = 1,
                    ProductName = "کره بزرگ دامداران",
                    ProductPrice = 12000,
                    UnitOfProduct = "بسته"
                },new Product()
                {
                    ProductId = 12,
                    CategoryId = 1,
                    ProductName = "کشک کامبیز",
                    ProductPrice = 10000,
                    UnitOfProduct = "شیشه"
                },new Product()
                {
                    ProductId = 13,
                    CategoryId = 3,
                    ProductName = "مایع ظرفشویی پریل",
                    ProductPrice = 20000,
                    UnitOfProduct = "ظرف"
                },new Product()
                {
                    ProductId = 14,
                    CategoryId = 3,
                    ProductName = "پودر لباسشویی پرسیل",
                    ProductPrice = 20000,
                    UnitOfProduct = "بسته"
                },new Product()
                {
                    ProductId = 15,
                    CategoryId = 3,
                    ProductName = "پودر لباسشویی سافتلن",
                    ProductPrice = 20000,
                    UnitOfProduct = "بسته"
                },new Product()
                {
                    ProductId = 16,
                    CategoryId = 3,
                    ProductName = "پودر لباسشویی نگین",
                    ProductPrice = 20000,
                    UnitOfProduct = "بسته"
                },new Product()
                {
                    ProductId = 17,
                    CategoryId = 3,
                    ProductName = "شامپو صحت",
                    ProductPrice = 20000,
                    UnitOfProduct = "بطری"
                },new Product()
                {
                    ProductId = 18,
                    CategoryId = 3,
                    ProductName = "شامپو گلرنگ",
                    ProductPrice = 20000,
                    UnitOfProduct = "بطری"
                },new Product()
                {
                    ProductId = 19,
                    CategoryId = 3,
                    ProductName = "صابون داو",
                    ProductPrice = 5000,
                    UnitOfProduct = "قالب"
                },new Product()
                {
                    ProductId = 20,
                    CategoryId = 3,
                    ProductName = "صابون گلنار",
                    ProductPrice = 5000,
                    UnitOfProduct = "قالب"
                },new Product()
                {
                    ProductId = 21,
                    CategoryId = 3,
                    ProductName = "مایع دستشویی داو",
                    ProductPrice = 20000,
                    UnitOfProduct = "بطری"
                },new Product()
                {
                    ProductId = 22,
                    CategoryId = 3,
                    ProductName = "مایع دستشویی اوه",
                    ProductPrice = 20000,
                    UnitOfProduct = "بطری"
                }
    );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
