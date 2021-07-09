using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infra.Data.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infra.Data.Repositories
{
    public class CartRepository : ICartRepository
    {
        readonly OnlineShopDbContext _dbContext;
        public CartRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddCart(Cart cart)
        {
            await _dbContext.Carts.AddAsync(cart);
            return true;
        }

        public IQueryable<Cart> GetAllCarts()
        {
            return _dbContext.Carts.
            Include(n => n.CartItems).ThenInclude(n => n.Product).
            Include(n => n.User)
            ;
        }

        public async Task<Cart> GetCart(int id)
        {
            return await _dbContext.Carts.FindAsync(id);
        }

        public void RemoveCart(Cart cart)
        {
            _dbContext.Remove(cart);
        }

        public async Task<bool> SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateCart(Cart cart)
        {
            _dbContext.Update(cart);
        }
    }
}
