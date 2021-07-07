using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Cart;
using OnlineShop.Domain.Interfaces;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class CartService : ICartService
    {
        ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<ShowCartViewModel> GetCart(string email)
        {
            var cart = await _cartRepository.GetAllCarts().SingleAsync(n => n.User.UserEmail == email);
            return new ShowCartViewModel()
            {

            };
        }
    }
}
