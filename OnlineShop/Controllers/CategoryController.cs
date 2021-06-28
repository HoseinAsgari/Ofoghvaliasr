using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ShowCategories()
        {
            var model = await _categoryService.GetAllCategories();
            return View(model);
        }

        [HttpGet("/Category/{categoryName}")]
        public async Task<IActionResult> ShowCategory(string categoryName)
        {
            var model = await _categoryService.GetAllCategoryProducts(categoryName);
            return View(model);
        }
    }
}
