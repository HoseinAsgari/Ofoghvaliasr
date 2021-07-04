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

        [HttpGet("/Product/ShowProduct/{productNumber}")]
        public async Task<IActionResult> ShowProduct(int productNumber)
        {
            var model = await _productService.GetProduct(productNumber, User.FindFirstValue(ClaimTypes.Email));
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> AddToCart(int productNumber)
        {
            await _productService.OrderProduct(productNumber, User.FindFirstValue(ClaimTypes.Email));
            return Redirect("/Product/ShowProduct/" + productNumber);
        }

        public async Task<IActionResult> Search(string search)
        {
            var model = await _productService.SearchProduct(search);
            return View(model);
        }

        [HttpGet("/{controller}/{action}/{productId}")]
        public async Task<IActionResult> ProductLiked(int productId)
        {
            await _productService.ProductLiked(productId);
            return null;
        }
    }
}
