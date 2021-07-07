using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Account;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await _accountService.EmailExists(model.Email))
            {
                ModelState.AddModelError("", "ایمیل شما قبلا در سیستم ثبت شده.");
                return View("LogIn", new LogInViewModel()
                {
                    Email = model.Email
                });
            }

            if (await _accountService.SignIn(model, HttpContext.Request.Host.Host))
            {
                await SetUserAuthenticationCookies(model);
                return Redirect("/");
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> LogOut(string ReturnUrl = "/")
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(ReturnUrl);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid && await _accountService.LogIn(model))
            {
                var userName = await _accountService.GetUserNameByEmail(model.Email);
                await SetUserAuthenticationCookies(model, userName);
                return Redirect(ReturnUrl ?? "/");
            }
            ModelState.AddModelError("", "اطلاعات درست نیست.");
            return View();
        }

        private async Task<bool> SetUserAuthenticationCookies(LogInViewModel user, string name)
        {
            try
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.Email.ToLower()),
                    new Claim(ClaimTypes.Name, name),
                    new Claim("IsAdmin", (await _accountService.IsAdminByEmail(user.Email)).ToString())
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var property = new AuthenticationProperties
                {
                    IsPersistent = user.RememberMe
                };
                await HttpContext.SignInAsync(principal, property);
                return true;
            }
            catch
            {
                throw;
            }
        }

        private async Task<bool> SetUserAuthenticationCookies(SignInViewModel user)
        {
            try
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, user.Email.ToLower()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim("IsAdmin", "false"),
                    new Claim("PhoneNumber", user.PhoneNumber),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var property = new AuthenticationProperties
                {
                    IsPersistent = user.RememberMe
                };
                await HttpContext.SignInAsync(principal, property);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [Authorize]
        public async Task<IActionResult> Panel()
        {
            var model = await _accountService.GetPanelModel(User.FindFirstValue(ClaimTypes.Email));
            return View("AccountPanel", model);
        }

        [Authorize]
        public async Task<IActionResult> ActiveAccount(AccountActivateViewModel viewModel)
        {
            if (!ModelState.IsValid || !await _accountService.ActiveAccount(User.FindFirstValue(ClaimTypes.Email), viewModel.ActivationCode))
                ViewBag.Error = "عملیات ناموفق بود!!!";
            var model = await _accountService.GetPanelModel(User.FindFirstValue(ClaimTypes.Email));
            return View("Panel", model);
        }
    }
}
