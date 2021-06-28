using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Infra.Data.Repositories;
using System;

namespace OnlineShop.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();


        }
    }
}
