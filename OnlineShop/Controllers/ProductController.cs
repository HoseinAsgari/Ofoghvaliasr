using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
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

        [HttpGet("/Product/{productNumber}")]
        public async Task<IActionResult> ShowProduct(int productNumber)
        {
            var model = await _productService.GetProduct(productNumber);
            return View(model);
        }
    }
}
