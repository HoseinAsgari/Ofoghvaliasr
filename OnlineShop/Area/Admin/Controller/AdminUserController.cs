using OnlineShop.Application.ViewModels.Admin.User;
using OnlineShop.Application.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.FilterAttributes;

namespace OnlineShop.Area.Admin.Controllers
{
    [Area("Admin")]
    [ServiceFilter(typeof(AdminFilter))]
    public class AdminUserController : Controller
    {
        readonly IAdminService _adminService;
        public AdminUserController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> ShowUsers()
        {
            var model = await _adminService.GetUsers();
            return View(model);
        }

        public async Task<IActionResult> GetUserDetails(int userId)
        {
            var model = await _adminService.GetUserDetails(userId);
            return View(model);
        }

        public async Task<IActionResult> SetUserToAdmin(int userId)
        {
            await _adminService.SetUserToAdmin(userId);
            return View();
        }
    }
}