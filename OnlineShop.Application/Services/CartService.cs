using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Cart;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class CartService : ICartService
    {
        readonly ICartRepository _cartRepository;
        readonly IUserRepository _userRepository;
        readonly IProductRepository _productRepository;
        readonly ICartItemRepository _cartItemRepository;
        public CartService(ICartItemRepository cartItemRepository, IUserRepository userRepository, IProductRepository productRepository, ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<List<ShowCartProductViewModel>> GetCart(string email)
        {
            var cart = await _cartRepository.GetAllCarts().SingleAsync(n => n.User.UserEmail == email);
            if (cart.CartItems != null && cart.CartItems.Any())
            {
                return cart.CartItems.Select(n => new ShowCartProductViewModel()
                {
                    ProductId = n.Product.ProductId,
                    Amount = n.Count,
                    UnitOfProduct = n.Product.UnitOfProduct,
                    ProductName = n.Product.ProductName,
                    ProductPrice = n.Product.ProductPrice,
                    ThumbnailName = n.Product.ProductName + ".png"
                }).ToList();
            }
            else
            {
                return null;
            }
        }


        public async Task<bool> OrderProduct(int productNumber, string email, int productCount = 1)
        {
            var product = await _productRepository.GetProduct(productNumber);
            var user = await _userRepository.GetAllUsers().SingleAsync(n => n.UserEmail == email);
            if (user.Cart.CartItems.Any())
            {
                if (user.Cart.CartItems.Any(n => n.Product.ProductId == productNumber))
                {
                    var cartItem = user.Cart.CartItems.Single(n => n.Product.ProductId == productNumber);
                    cartItem.Count++;
                    _cartItemRepository.UpdateCartItem(cartItem);
                }
                else
                {
                    var cartItem = new CartItem()
                    {
                        Cart = user.Cart,
                        Count = 1,
                        Product = product
                    };
                    await _cartItemRepository.AddCartItem(cartItem);
                }
            }
            else
            {
                var cart = await _cartRepository.GetCart(user.Cart.CartId);
                cart.DateCreated = System.DateTime.Now;
                _cartRepository.UpdateCart(cart);

                var cartItem = new CartItem()
                {
                    Cart = user.Cart,
                    Count = 1,
                    Product = product
                };
                await _cartItemRepository.AddCartItem(cartItem);
            }
            await _cartItemRepository.SaveChanges();
            return true;
        }
    }
}
