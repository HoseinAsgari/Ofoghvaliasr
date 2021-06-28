using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infra.Data.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infra.Data.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        readonly OnlineShopDbContext _dbContext;
        public CartItemRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddCartItem(CartItem cartItem)
        {
            await _dbContext.CartItems.AddAsync(cartItem);
            return true;
        }

        public IQueryable GetAllCartItems()
        {
            return _dbContext.CartItems;
        }

        public async Task<bool> GetCartItem(int id)
        {
            await _dbContext.CartItems.FindAsync(id);
            return true;
        }

        public void RemoveCartItem(CartItem cartItem)
        {
            _dbContext.Remove(cartItem);
        }

        public async Task<bool> SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _dbContext.Update(cartItem);
        }
    }
}
