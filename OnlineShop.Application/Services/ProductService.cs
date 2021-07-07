using OnlineShop.Application.Interfaces;
using OnlineShop.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using OnlineShop.Application.ViewModels.Product;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Models;
using OnlineShop.Application.ViewModels.Shared;

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

        public async Task<ShowIndexViewModel> GetIndexModel()
        {
            return new ShowIndexViewModel()
            {

            };
        }

        public async Task<ShowProductViewModel> GetProduct(int productNumber, string userEmail)
        {
            var product = await _productRepository.GetProduct(productNumber);
            var user = await _userRepository.GetAllUsers().SingleAsync(n => n.UserEmail == userEmail);
            var userCart = user.Cart;
            uint orderedCount = 0;
            if (userCart.CartItems.Any(n => n.Product.ProductId == productNumber))
            {
                orderedCount = userCart.CartItems.Single(n => n.Product.ProductId == productNumber).Count;
            }
            return new ShowProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ThumbnailFileName = product.ProductName + product.ProductId + ".jpg",
                UnitOfProduct = product.UnitOfProduct,
                OrderedCount = orderedCount,
                CategoryName = product.Category.CategoryEnglishName,
                CategoryPersianName = product.Category.CategoryName,
                ProductRate = (product.UserProductLikes.Count / product.UserProductSolds.Count) * 5
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

        public Task<bool> ProductLiked(int productId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<ShowSearchedProduct>> SearchProduct(string searchedPhrase)
        {
            return await _productRepository.GetAllProducts().Where(n => searchedPhrase.Contains(n.ProductName)).Select(n => new ShowSearchedProduct()
            {
                ProductId = n.ProductId,
                ProductName = n.ProductName,
                ThumbnailName = n.ProductName + n.ProductId + ".jpg",
                ProductPrice = n.ProductPrice
            }).ToListAsync();
        }
    }
}
