﻿using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infra.Data.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly OnlineShopDbContext _dbContext;
        public ProductRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            return true;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _dbContext.Products;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _dbContext.Products.FindAsync(id);;
        }

        public void RemoveProduct(Product product)
        {
            _dbContext.Remove(product);
        }

        public async Task<bool> SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Update(product);
        }
    }
}
