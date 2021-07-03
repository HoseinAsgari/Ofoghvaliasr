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
        readonly ICartService _cartRepository;
        public CartController(ICartService cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IActionResult> MyCart()
        {
            var model = await _cartRepository.GetCart(User.FindFirstValue(ClaimTypes.Email));
            return View(model);
        }
    }
}
