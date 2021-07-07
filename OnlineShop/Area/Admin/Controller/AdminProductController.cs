using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Admin;

namespace OnlineShop.Area.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductController : Controller
    {
        readonly IAdminService _adminService;
        public AdminProductController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> ShowProducts()
        {
            var model = await _adminService.GetProductsModel();
            return View(model);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddOrEditProductViewModel addProductViewModel)
        {
            if (ModelState.IsValid)
            {
                await _adminService.AddProduct(addProductViewModel);
                return Redirect("/Admin/AdminProduct/ShowProducts");
            }
            return View();
        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _adminService.RemoveProduct(id);
            return Redirect("/Admin/AdminProduct/ShowProducts");
        }

        public async Task<IActionResult> EditProduct(int productId)
        {
            var model = await _adminService.GetEditProductModel(productId);
            return View(model);
        }

        public async Task<IActionResult> EditProduct(AddOrEditProductViewModel editProductViewModel)
        {
            if (ModelState.IsValid)
            {
                await _adminService.EditProduct(editProductViewModel);
                return Redirect("/Admin/AdminProduct/ShowProducts");
            }
            return View();
        }
    }
}