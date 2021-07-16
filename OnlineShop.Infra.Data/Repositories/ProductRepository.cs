using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces;
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
            return _dbContext.Products.
            Include(n => n.UserProductLikes).ThenInclude(n => n.User).
            Include(n => n.UserProductViews).ThenInclude(n => n.User).
            Include(n => n.UserProductSolds).ThenInclude(n => n.User).
            Include(n => n.CartItems).ThenInclude(n => n.Cart).
            Include(n => n.Category).ThenInclude(n => n.Products)
            ;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _dbContext.Products.
            Include(n => n.UserProductLikes).ThenInclude(n => n.User).
            Include(n => n.UserProductViews).ThenInclude(n => n.User).
            Include(n => n.UserProductSolds).ThenInclude(n => n.User).
            Include(n => n.CartItems).ThenInclude(n => n.Cart).
            Include(n => n.Category).ThenInclude(n => n.Products).SingleAsync(n => n.ProductId == id);
        }

        public void RemoveProduct(Product product)
        {
            _dbContext.Remove(product);
        }

        public void RemoveRangeProduct(IQueryable<Product> products)
        {
            _dbContext.RemoveRange(products);
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
