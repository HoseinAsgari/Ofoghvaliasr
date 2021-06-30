using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OnlineShop.Application.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.Services
{
    public class ProductService : IProductService
    {
        readonly IProductRepository _productRepository;
        readonly ICartItemRepository _cartItemRepository;
        readonly ICartRepository _cartRepository;
        readonly IUserRepository _userRepository;
        public ProductService(IProductRepository productRepository, ICartItemRepository cartItemRepository, ICartRepository cartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        public async Task<ShowProductViewModel> GetProduct(int productNumber)
        {
            var product = await _productRepository.GetProduct(productNumber);
            return new ShowProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ThumbnailFileName = product.ThumbnailFileName,
                UnitOfProduct = product.UnitOfProduct
            };
        }

        public async Task<bool> OrderProduct(int productNumber, string email)
        {
            var product = await _productRepository.GetProduct(productNumber);
            var user = await _userRepository.GetAllUsers().SingleAsync(n => n.UserEmail == email);
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
            await _cartItemRepository.SaveChanges();
            return true;
        }
    }
}
