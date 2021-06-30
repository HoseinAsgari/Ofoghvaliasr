using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        IAccountController _accountController;
        public AccountController(IAccountController accountController)
        {
            _accountController = accountController;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
