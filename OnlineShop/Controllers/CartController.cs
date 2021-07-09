using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> MyCart()
        {
            var model = await _cartService.GetCart(User.FindFirstValue(ClaimTypes.Email));
            ViewBag.SumOfPrice = model.Sum(n => n.ProductPrice * n.Amount);
            return View("ShowCart", model);
        }

        public async Task<IActionResult> AddToCart(int id, int? count)
        {
            await _cartService.OrderProduct(id, User.FindFirstValue(ClaimTypes.Email), count.HasValue ? count.Value : 1);
            return Redirect("/Product/ShowProduct/" + id);
        }
    }
}
