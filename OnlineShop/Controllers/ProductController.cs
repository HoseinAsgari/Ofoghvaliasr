using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        public async Task<IActionResult> ShowProduct(int id)
        {
            var model = await _productService.GetProduct(id, User.FindFirstValue(ClaimTypes.Email));
            return View(model);
        }

        public async Task<IActionResult> Search(string search)
        {
            var model = await _productService.SearchProduct(search);
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> ProductLiked(int id)
        {
            await _productService.ProductLiked(id, User.FindFirstValue(ClaimTypes.Email));
            return null;
        }
    }
}
