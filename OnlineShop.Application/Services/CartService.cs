using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Cart;
using OnlineShop.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<ShowCartProductViewModel>> GetCart(string email)
        {
            var cart = await _cartRepository.GetAllCarts().SingleAsync(n => n.User.UserEmail == email);
            return cart.CartItems.Select(n => new ShowCartProductViewModel()
            {
                ProductId = n.Product.ProductId,
                Amount = n.Count.ToString() + " " + n.Product.UnitOfProduct,
                ProductName = n.Product.ProductName,
                ProductPrice = n.Product.ProductPrice,
                ThumbnailName = n.Product.ProductName + ".png",
                UnitOfProduct = n.Product.UnitOfProduct
            }).ToList();
        }
    }
}
