using Microsoft.AspNetCore.Mvc;
using OnlineShop.FilterAttributes;

namespace OnlineShop.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(AdminFilter))]
    [Area("Admin")]
    public class HomeController : Controller
    {
        [HttpGet("/Admin/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}