using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using System;
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

        [HttpGet("{controller}/{action}/{categoryName}")]
        public async Task<IActionResult> ShowCategoryProducts(string categoryName, int pageNumber = 1)
        {
            var model = await _categoryService.GetAllCategoryProducts(categoryName);
            ViewBag.CategoryName = categoryName;
            ViewBag.PageCount = (model.Count > 12) ? Math.Ceiling((double)(model.Count / 12)) : 1;
            ViewBag.PageNumber = (pageNumber <= ViewBag.PageCount) ? pageNumber : ViewBag.PageCount;
            ViewBag.PersianName = await _categoryService.GetPersianNameByEnglishName(categoryName);
            return View(model);
        }
    }
}
