using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineShop.Application.Interfaces;

namespace OnlineShop.FilterAttributes
{
    public class AdminFilter : IActionFilter
    {
        readonly IAccountService _accountService;
        public AdminFilter(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated || !_accountService.IsAdminByEmail(context.HttpContext.User.FindFirstValue(ClaimTypes.Email)).Result)
            {
                context.Result = new RedirectResult("/Account/LogIn");
            }
        }
    }
}