using OnlineShop.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface ICartItemRepository
    {
        IQueryable GetAllCartItems();
        Task<bool> AddCartItem(CartItem cartItem);
        Task<bool> GetCartItem(int id);
        void UpdateCartItem(CartItem cartItem);
        void RemoveCartItem(CartItem cartItem);
        Task<bool> SaveChanges();
    }
}
