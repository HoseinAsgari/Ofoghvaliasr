using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Admin.Product;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        readonly IAdminService _adminService;
        public ProductController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> ShowProducts()
        {
            var model = await _adminService.GetProductsModel();
            return View(model);
        }

        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Categories = await _adminService.GetAllCategoriesName();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductViewModel addProductViewModel)
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

        public async Task<IActionResult> EditProduct(EditProductViewModel editProductViewModel)
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