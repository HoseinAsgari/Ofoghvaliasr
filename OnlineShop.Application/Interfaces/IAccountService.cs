using OnlineShop.Application.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface IAccountService
    {
        Task<bool> SignIn(SignInViewModel signInViewModel);
        Task<bool> LogIn(LogInViewModel logInViewModel);
        Task<bool> EmailExists(string email);
        Task<bool> IsAdminByEmail(string userEmail);
        Task<UserPanelViewModel> GetPanelModel(string email);
        Task<bool> IsActivateByEmail(string email);
        Task<bool> ActiveAccount(string email, string activationCode);
        Task<string> GetUserNameByEmail(string email);
    }
}
