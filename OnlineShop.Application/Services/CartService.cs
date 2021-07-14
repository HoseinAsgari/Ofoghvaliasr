using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Cart;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System;
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
        readonly IUserProductSoldsRepository _userProductSoldsRepository;
        public CartService(IUserProductSoldsRepository userProductSoldsRepository, ICartItemRepository cartItemRepository, IUserRepository userRepository, IProductRepository productRepository, ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _cartItemRepository = cartItemRepository;
            _userProductSoldsRepository = userProductSoldsRepository;
        }

        public async Task<bool> FinlizeCart(string email)
        {
            var user = await _userRepository.GetAllUsers().SingleAsync(n => n.UserEmail == email);
            var cart = user.Carts.Single(n => !n.IsOrdered);
            cart.IsOrdered = true;
            cart.DateOrdered = DateTime.Now;
            cart.Price = (uint)cart.CartItems.Sum(n => n.Product.ProductPrice);
            _cartRepository.UpdateCart(cart);
            await _userProductSoldsRepository.AddUserProductSolds(cart.CartItems.Select(n => new UserProductSold()
            {
                User = user,
                ProductId = n.Product.ProductId,
                UserId = user.UserId,
                Product = n.Product
            }).ToList());
            await _cartRepository.AddCart(new Cart()
            {
                User = user,
                UserId = user.UserId
            });
            await _cartRepository.SaveChanges();
            return true;
        }

        public async Task<List<ShowCartProductViewModel>> GetCart(string email)
        {
            var cart = await _cartRepository.GetAllCarts().SingleOrDefaultAsync(n => n.User.UserEmail == email && !n.IsOrdered);
            if (cart != null && cart.CartItems != null && cart.CartItems.Any())
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

        public async Task<bool> OrderProduct(int productNumber, string email, uint productCount = 1)
        {
            var product = await _productRepository.GetProduct(productNumber);
            var user = await _userRepository.GetAllUsers().SingleAsync(n => n.UserEmail == email);
            if (user.Carts.Single(n => !n.IsOrdered).CartItems.Any())
            {
                if (user.Carts.Single(n => !n.IsOrdered).CartItems.Any(n => n.Product.ProductId == productNumber))
                {
                    var cartItem = user.Carts.Single(n => !n.IsOrdered).CartItems.Single(n => n.Product.ProductId == productNumber);
                    cartItem.Count += productCount;
                    _cartItemRepository.UpdateCartItem(cartItem);
                }
                else
                {
                    var cartItem = new CartItem()
                    {
                        Cart = user.Carts.Single(n => !n.IsOrdered),
                        Count = productCount,
                        Product = product
                    };
                    await _cartItemRepository.AddCartItem(cartItem);
                }
            }
            else
            {
                var cart = await _cartRepository.GetCart(user.Carts.Single(n => !n.IsOrdered).CartId);
                _cartRepository.UpdateCart(cart);

                var cartItem = new CartItem()
                {
                    Cart = user.Carts.Single(n => !n.IsOrdered),
                    Count = productCount,
                    Product = product
                };
                await _cartItemRepository.AddCartItem(cartItem);
            }
            await _cartItemRepository.SaveChanges();
            return true;
        }
    }
}
