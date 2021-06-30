using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/Product/{productNumber}")]
        public async Task<IActionResult> ShowProduct(int productNumber)
        {
            var model = await _productService.GetProduct(productNumber, User.FindFirstValue(ClaimTypes.Email));
            return View(model);
        }

        public async Task<IActionResult> OrderProduct(int productNumber)
        {
            var result = await _productService.OrderProduct(productNumber, User.FindFirstValue(ClaimTypes.Email));
            return Json(result);
        }
    }
}
