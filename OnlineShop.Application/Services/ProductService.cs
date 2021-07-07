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
        readonly IUserProductLikesRepository _userProductLikesRepository;
        readonly IUserProductViewsRepository _userProductViewsRepository;
        public ProductService(IUserProductViewsRepository userProductViewsRepository, IUserProductLikesRepository userProductLikesRepository, IProductRepository productRepository, ICartItemRepository cartItemRepository, ICartRepository cartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _cartItemRepository = cartItemRepository;
            _cartRepository = cartRepository;
            _userRepository = userRepository;
            _userProductLikesRepository = userProductLikesRepository;
            _userProductViewsRepository = userProductViewsRepository;
        }

        public async Task<ShowIndexViewModel> GetIndexModel()
        {
            var products = _productRepository.GetAllProducts();
            if (products != null && products.Count() != 0)
            {
                return new ShowIndexViewModel()
                {
                    BestTenProductsModel = await products.OrderByDescending(n => n.UserProductLikes.Count).Take(10).Select(n => new BestTenProductsViewModel()
                    {
                        ProductId = n.ProductId,
                        ProductName = n.ProductName,
                        ProductPrice = n.ProductPrice,
                        ThumbnailName = n.ProductName + ".png"
                    }).ToListAsync(),
                    MostTenSoldProductsModel = await _productRepository.GetAllProducts().OrderByDescending(n => n.UserProductLikes.Count).Take(10).Select(n => new MostSoldArrivalsViewModel()
                    {
                        ProductId = n.ProductId,
                        CategoryName = n.Category.CategoryEnglishName,
                        ProductName = n.ProductName,
                        ProductPrice = n.ProductPrice,
                        ThumbnailName = n.ProductName + ".png"
                    }).ToListAsync()
                };
            }
            return null;
        }

        public async Task<ShowProductViewModel> GetProduct(int productNumber, string userEmail)
        {
            var product = await _productRepository.GetProduct(productNumber);
            var user = await _userRepository.GetAllUsers().SingleAsync(n => n.UserEmail == userEmail);
            var userCart = user.Cart;
            uint orderedCount = 0;

            await _userProductViewsRepository.AddUserProductView(new UserProductViews()
            {
                Product = product,
                ProductId = productNumber,
                User = user,
                UserId = user.UserId
            });
            await _userProductViewsRepository.SaveChanges();


            if (userCart.CartItems.Any(n => n.Product.ProductId == productNumber))
            {
                orderedCount = userCart.CartItems.Single(n => n.Product.ProductId == productNumber).Count;
            }
            return new ShowProductViewModel()
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ThumbnailFileName = product.ProductName + ".png",
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

        public async Task<bool> ProductLiked(int productId, string userEmail)
        {
            var product = await _productRepository.GetProduct(productId);
            var user = await _userRepository.GetAllUsers().SingleAsync(n => n.UserEmail == userEmail);
            await _userProductLikesRepository.AddUserProductLikes(new UserProductLikes()
            {
                Product = product,
                UserId = user.UserId,
                ProductId = product.ProductId,
                User = user
            });
            await _userProductLikesRepository.SaveChanges();
            return true;
        }

        public async Task<List<ShowSearchedProduct>> SearchProduct(string searchedPhrase)
        {
            return await _productRepository.GetAllProducts().Where(n => n.ProductName.Contains(searchedPhrase)).Select(n => new ShowSearchedProduct()
            {
                ProductId = n.ProductId,
                ProductName = n.ProductName,
                ThumbnailName = n.ProductName + ".png",
                ProductPrice = n.ProductPrice
            }).ToListAsync();
        }
    }
}
