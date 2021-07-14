using OnlineShop.Application.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.FilterAttributes;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(AdminFilter))]
    public class UserController : Controller
    {
        readonly IAdminService _adminService;
        public UserController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> ShowUsers()
        {
            var model = await _adminService.GetUsers();
            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _adminService.GetUserDetails(id);
            return View(model);
        }

        public async Task<IActionResult> SetUserToAdmin(int id)
        {
            await _adminService.SetUserToAdmin(id);
            return Redirect("/Admin/User/ShowUsers");
        }

        public async Task<IActionResult> Orderes()
        {
            var model = await _adminService.GetOrderes();
            return View(model);
        }

        public async Task<IActionResult> Delivered(int id)
        {
            await _adminService.CartDelivered(id);
            return Redirect("/Admin/User/Orderes");
        }

        public async Task<IActionResult> ShowUserCartProducts(int id)
        {
            var model = await _adminService.GetUserCartProducts(id);
            return View(model);
        }
    }
}