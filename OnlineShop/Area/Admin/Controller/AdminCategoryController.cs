using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Admin;
using OnlineShop.FilterAttributes;
using System.Threading.Tasks;

namespace OnlineShop.Area.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(AdminFilter))]
    public class AdminCategoryController : Controller
    {
        readonly IAdminService _adminService;
        public AdminCategoryController(IAdminService adminService)
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

        public async Task<IActionResult> AddCategory(AddOrEditCategoryViewModel addCategoryViewModel)
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

        public async Task<IActionResult> EditCategory(int categoryId)
        {
            var model = await _adminService.GetEditCategoryModel(categoryId);
            return View(model);
        }

        public async Task<IActionResult> EditCategory(AddOrEditCategoryViewModel editCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                await _adminService.EditCategory(editCategoryViewModel);
                return Redirect("/Admin/AdminCategory/ShowCategories");
            }
            return View();
        }
    }
}