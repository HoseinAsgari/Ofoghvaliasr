using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Helpers.CalendarHelper;
using OnlineShop.Application.Helpers.MessageHelper;
using OnlineShop.Application.Helpers.SecurityHelper;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.SendMessage;
using OnlineShop.Application.ViewModels.Account;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class AccountService : IAccountService
    {
        readonly IUserRepository _userRepository;
        readonly IMailSender _mailSender;
        public AccountService(IUserRepository userRepository, IMailSender mailSender)
        {
            _userRepository = userRepository;
            _mailSender = mailSender;
        }

        public async Task<bool> EmailExists(string email)
        {
            try
            {
                return await _userRepository.GetAllUsers().AnyAsync(n => n.UserEmail == email);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsAdminByEmail(string userEmail)
        {
            try
            {
                return (await GetUserByEmail(userEmail)).IsAdmin;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> LogIn(LogInViewModel logInViewModel)
        {
            try
            {
                var hashedPassword = await PasswordHelper.EncodePasswordMd5(logInViewModel.Password);
                bool result = await _userRepository.GetAllUsers().AnyAsync(n => n.UserEmail == logInViewModel.Email && n.UserPassword == hashedPassword);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> SignIn(SignInViewModel signInViewModel, string domainName)
        {
            try
            {
                var activationCode = EmailActivationLinkGenerator.CodeGenerator();
                User model = new()
                {
                    UserEmail = signInViewModel.Email.Trim().ToLower(),
                    UserActivationLink = await PasswordHelper.EncodePasswordMd5(activationCode),//@"/Account/Active?password=""" + Guid.NewGuid().ToString() + @""""
                    IsAccountActive = false,
                    IsAdmin = false,
                    UserPassword = await PasswordHelper.EncodePasswordMd5(signInViewModel.Password),
                    DateSignedIn = DateTime.Now,
                    UserName = signInViewModel.Name
                };
                await _userRepository.AddUser(model);
                await _userRepository.SaveChanges();
                await new SendMail(_mailSender).SendActivationCode(activationCode, signInViewModel.Email, domainName);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<User> GetUserByEmail(string userEmail)
        {
            try
            {
                return await _userRepository.GetAllUsers().SingleAsync(n => n.UserEmail == userEmail);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserPanelViewModel> GetPanelModel(string email)
        {
            try
            {
                var user = await GetUserByEmail(email);
                var model = new UserPanelViewModel()
                {
                    Email = email,
                    SignInDate = await ShamsiCalendarHelper.ToShamsi(user.DateSignedIn),
                    ActiveEmail = user.IsAccountActive
                };
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> IsActivateByEmail(string email)
        {
            try
            {
                return (await GetUserByEmail(email)).IsAccountActive;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ActiveAccount(string email, string activationCode)
        {
            try
            {
                var user = await GetUserByEmail(email);
                if ((await PasswordHelper.EncodePasswordMd5(activationCode)) == user.UserActivationLink)
                {
                    user.IsAccountActive = true;
                    _userRepository.UpdateUser(user);
                    await _userRepository.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string> GetUserNameByEmail(string email)
        {
            return (await GetUserByEmail(email)).UserName;
        }
    }
}
