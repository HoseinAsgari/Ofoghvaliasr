using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SeedCategoryDate
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
