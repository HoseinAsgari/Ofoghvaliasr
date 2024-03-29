﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Infra.Data.Contexts;

namespace OnlineShop.Infra.Data.Migrations
{
    [DbContext(typeof(OnlineShopDbContext))]
    [Migration("20210706155629_SeedProductsData")]
    partial class SeedProductsData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineShop.Domain.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.CartItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryEnglishName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("Liked")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryEnglishName = "Dairy",
                            CategoryName = "لبنیات",
                            Liked = 0
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryEnglishName = "Meat",
                            CategoryName = "پروتئین",
                            Liked = 0
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryEnglishName = "Health",
                            CategoryName = "بهداشتی",
                            Liked = 0
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryEnglishName = "JunkFood",
                            CategoryName = "تنقلات",
                            Liked = 0
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryEnglishName = "Grocery",
                            CategoryName = "خوار و بار",
                            Liked = 0
                        });
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("ProductPrice")
                        .HasColumnType("bigint");

                    b.Property<string>("UnitOfProduct")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ProductName = "شیر دامداران",
                            ProductPrice = 7000L,
                            UnitOfProduct = "بطری"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            ProductName = "ماست میهن",
                            ProductPrice = 40000L,
                            UnitOfProduct = "دبه ای"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            ProductName = "کشک سمیه",
                            ProductPrice = 15000L,
                            UnitOfProduct = "شیشه"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 1,
                            ProductName = "دوغ آبعلی",
                            ProductPrice = 5000L,
                            UnitOfProduct = "شیشه"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 1,
                            ProductName = "دوغ عالیس",
                            ProductPrice = 10000L,
                            UnitOfProduct = "بطری"
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 1,
                            ProductName = "دوغ سنتی دامداران",
                            ProductPrice = 10000L,
                            UnitOfProduct = "بطری"
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 1,
                            ProductName = "خامه میهن",
                            ProductPrice = 10000L,
                            UnitOfProduct = "بسته"
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 1,
                            ProductName = "خامه دامداران",
                            ProductPrice = 10000L,
                            UnitOfProduct = "بسته"
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 1,
                            ProductName = "کره کوچک دامداران",
                            ProductPrice = 7000L,
                            UnitOfProduct = "بسته"
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 1,
                            ProductName = "کره متوسط دامداران",
                            ProductPrice = 1000L,
                            UnitOfProduct = "بسته"
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 1,
                            ProductName = "کره بزرگ دامداران",
                            ProductPrice = 12000L,
                            UnitOfProduct = "بسته"
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 1,
                            ProductName = "کشک کامبیز",
                            ProductPrice = 10000L,
                            UnitOfProduct = "شیشه"
                        },
                        new
                        {
                            ProductId = 13,
                            CategoryId = 3,
                            ProductName = "مایع ظرفشویی پریل",
                            ProductPrice = 20000L,
                            UnitOfProduct = "ظرف"
                        },
                        new
                        {
                            ProductId = 14,
                            CategoryId = 3,
                            ProductName = "پودر لباسشویی پرسیل",
                            ProductPrice = 20000L,
                            UnitOfProduct = "بسته"
                        },
                        new
                        {
                            ProductId = 15,
                            CategoryId = 3,
                            ProductName = "پودر لباسشویی سافتلن",
                            ProductPrice = 20000L,
                            UnitOfProduct = "بسته"
                        },
                        new
                        {
                            ProductId = 16,
                            CategoryId = 3,
                            ProductName = "پودر لباسشویی نگین",
                            ProductPrice = 20000L,
                            UnitOfProduct = "بسته"
                        },
                        new
                        {
                            ProductId = 17,
                            CategoryId = 3,
                            ProductName = "شامپو صحت",
                            ProductPrice = 20000L,
                            UnitOfProduct = ""
                        },
                        new
                        {
                            ProductId = 18,
                            CategoryId = 3,
                            ProductName = "شامپو گلرنگ",
                            ProductPrice = 20000L,
                            UnitOfProduct = "بطری"
                        },
                        new
                        {
                            ProductId = 19,
                            CategoryId = 3,
                            ProductName = "صابون داو",
                            ProductPrice = 5000L,
                            UnitOfProduct = "قالب"
                        },
                        new
                        {
                            ProductId = 20,
                            CategoryId = 3,
                            ProductName = "صابون گلنار",
                            ProductPrice = 5000L,
                            UnitOfProduct = "قالب"
                        },
                        new
                        {
                            ProductId = 21,
                            CategoryId = 3,
                            ProductName = "مایع دستشویی داو",
                            ProductPrice = 20000L,
                            UnitOfProduct = "بطری"
                        },
                        new
                        {
                            ProductId = 22,
                            CategoryId = 3,
                            ProductName = "مایع دستشویی اوه",
                            ProductPrice = 20000L,
                            UnitOfProduct = "بطری"
                        });
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Banned")
                        .HasColumnType("bit");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSignedIn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAccountActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("UserActivationLink")
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("UserId");

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.UserProductLikes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProductLikes");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.UserProductSold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProductSolds");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.UserProductViews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProductViews");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Domain.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Product", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.User", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Cart", "Cart")
                        .WithOne("User")
                        .HasForeignKey("OnlineShop.Domain.Models.User", "CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.UserProductLikes", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Product", "Product")
                        .WithMany("UserProductLikes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Domain.Models.User", "User")
                        .WithMany("LikedProducts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.UserProductSold", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Product", "Product")
                        .WithMany("UserProductSolds")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Domain.Models.User", "User")
                        .WithMany("UserProductSolds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.UserProductViews", b =>
                {
                    b.HasOne("OnlineShop.Domain.Models.Product", "Product")
                        .WithMany("UserProductViews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Domain.Models.User", "User")
                        .WithMany("UserProductViews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Cart", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("UserProductLikes");

                    b.Navigation("UserProductSolds");

                    b.Navigation("UserProductViews");
                });

            modelBuilder.Entity("OnlineShop.Domain.Models.User", b =>
                {
                    b.Navigation("LikedProducts");

                    b.Navigation("UserProductSolds");

                    b.Navigation("UserProductViews");
                });
#pragma warning restore 612, 618
        }
    }
}
