using System;
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
        public DbSet<UsersIPAddresses> UsersIPAddresses { get; set; }
        
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
                }, new Product()
                {
                    ProductId = 2,
                    CategoryId = 1,
                    ProductName = "ماست میهن",
                    ProductPrice = 40000,
                    UnitOfProduct = "دبه"
                }, new Product()
                {
                    ProductId = 3,
                    CategoryId = 1,
                    ProductName = "کشک سمیه",
                    ProductPrice = 15000,
                    UnitOfProduct = "شیشه"
                }, new Product()
                {
                    ProductId = 4,
                    CategoryId = 1,
                    ProductName = "دوغ آبعلی",
                    ProductPrice = 5000,
                    UnitOfProduct = "شیشه"
                }, new Product()
                {
                    ProductId = 5,
                    CategoryId = 1,
                    ProductName = "دوغ عالیس",
                    ProductPrice = 10000,
                    UnitOfProduct = "بطری"
                }, new Product()
                {
                    ProductId = 6,
                    CategoryId = 1,
                    ProductName = "دوغ سنتی دامداران",
                    ProductPrice = 10000,
                    UnitOfProduct = "بطری"
                }, new Product()
                {
                    ProductId = 7,
                    CategoryId = 1,
                    ProductName = "خامه میهن",
                    ProductPrice = 10000,
                    UnitOfProduct = "بسته"
                }, new Product()
                {
                    ProductId = 8,
                    CategoryId = 1,
                    ProductName = "خامه دامداران",
                    ProductPrice = 10000,
                    UnitOfProduct = "بسته"
                }, new Product()
                {
                    ProductId = 9,
                    CategoryId = 1,
                    ProductName = "کره کوچک دامداران",
                    ProductPrice = 7000,
                    UnitOfProduct = "بسته"
                }, new Product()
                {
                    ProductId = 10,
                    CategoryId = 1,
                    ProductName = "کره متوسط دامداران",
                    ProductPrice = 1000,
                    UnitOfProduct = "بسته"
                }, new Product()
                {
                    ProductId = 11,
                    CategoryId = 1,
                    ProductName = "کره بزرگ دامداران",
                    ProductPrice = 12000,
                    UnitOfProduct = "بسته"
                }, new Product()
                {
                    ProductId = 12,
                    CategoryId = 1,
                    ProductName = "کشک کامبیز",
                    ProductPrice = 10000,
                    UnitOfProduct = "شیشه"
                }, new Product()
                {
                    ProductId = 13,
                    CategoryId = 3,
                    ProductName = "مایع ظرفشویی پریل",
                    ProductPrice = 20000,
                    UnitOfProduct = "ظرف"
                }, new Product()
                {
                    ProductId = 14,
                    CategoryId = 3,
                    ProductName = "پودر لباسشویی پرسیل",
                    ProductPrice = 20000,
                    UnitOfProduct = "بسته"
                }, new Product()
                {
                    ProductId = 15,
                    CategoryId = 3,
                    ProductName = "پودر لباسشویی سافتلن",
                    ProductPrice = 20000,
                    UnitOfProduct = "بسته"
                }, new Product()
                {
                    ProductId = 16,
                    CategoryId = 3,
                    ProductName = "پودر لباسشویی نگین",
                    ProductPrice = 20000,
                    UnitOfProduct = "بسته"
                }, new Product()
                {
                    ProductId = 17,
                    CategoryId = 3,
                    ProductName = "شامپو صحت",
                    ProductPrice = 20000,
                    UnitOfProduct = "بطری"
                }, new Product()
                {
                    ProductId = 18,
                    CategoryId = 3,
                    ProductName = "شامپو گلرنگ",
                    ProductPrice = 20000,
                    UnitOfProduct = "بطری"
                }, new Product()
                {
                    ProductId = 19,
                    CategoryId = 3,
                    ProductName = "صابون داو",
                    ProductPrice = 5000,
                    UnitOfProduct = "قالب"
                }, new Product()
                {
                    ProductId = 20,
                    CategoryId = 3,
                    ProductName = "صابون گلنار",
                    ProductPrice = 5000,
                    UnitOfProduct = "قالب"
                }, new Product()
                {
                    ProductId = 21,
                    CategoryId = 3,
                    ProductName = "مایع دستشویی داو",
                    ProductPrice = 20000,
                    UnitOfProduct = "بطری"
                }, new Product()
                {
                    ProductId = 22,
                    CategoryId = 3,
                    ProductName = "مایع دستشویی اوه",
                    ProductPrice = 20000,
                    UnitOfProduct = "بطری"
                }
    );
            #endregion

            #region SeedUserData
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    UserAddress = "تهران، دانشگاه شاهد",
                    DateSignedIn = DateTime.Parse("2025-01-01"),
                    IsAccountActive = true,
                    IsAdmin = true,
                    UserEmail = "hosein.asgari@gmail.com",
                    UserId = 1,
                    UserName = "حسین عسگری",
                    //  BitConverter.ToString(SHA256.HashData(Encoding.UTF8.GetBytes("@Hosein84")))
                    UserPassword = "84-85-F2-CF-5C-63-F1-72-85-B5-BA-29-03-D9-93-BF-F7-D5-5A-AE-91-09-0E-34-4A-86-26-6A-11-D9-74-55",
                    UserPhoneNumber = "09123456789"
                },
                new User()
                {
                    UserAddress = "تهران، دانشگاه شاهد",
                    DateSignedIn = DateTime.Parse("2025-01-01"),
                    IsAccountActive = true,
                    IsAdmin = true,
                    UserEmail = "mohammad.tahriri@gmail.com",
                    UserId = 2,
                    UserName = "محمد تحریری",
                    //  BitConverter.ToString(SHA256.HashData(Encoding.UTF8.GetBytes("@Mohammad84")))
                    UserPassword = "34-F8-G0-CF-5C-23-G1-72-85-B5-BA-A9-03-D9-93-BF-F7-65-5A-AE-91-09-0E-34-4A-86-26-9B-A1-D2-48-15",
                    UserPhoneNumber = "09123456789"
                }
            );
            #endregion

            #region SeedCartData
            modelBuilder.Entity<Cart>().HasData(
            new Cart()
            {
                CartId = 1,
                UserId = 1,
                DateOrdered = null
            }
            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
