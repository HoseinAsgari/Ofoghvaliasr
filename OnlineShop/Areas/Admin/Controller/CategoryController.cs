using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Admin.Category;
using OnlineShop.FilterAttributes;
using System.Threading.Tasks;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(AdminFilter))]
    public class CategoryController : Controller
    {
        readonly IAdminService _adminService;
        public CategoryController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> ShowCategories()
        {
            var model = await _adminService.GetCategories();
            return View(model);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                await _adminService.AddCategory(addCategoryViewModel);
                return Redirect("/Admin/AdminCategory/ShowCategories");
            }
            return View();
        }

        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            await _adminService.RemoveCategory(categoryId);
            return Redirect("/Admin/AdminCategory/ShowCategories");
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            var model = await _adminService.GetEditCategoryModel(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(EditCategoryViewModel editCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                await _adminService.EditCategory(editCategoryViewModel);
                return Redirect("/Admin/Category/ShowCategories");
            }
            return View();
        }
    }
}