using OnlineShop.Application.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineShop.Application.ViewModels.Admin;
using OnlineShop.Domain.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Application.Services
{
    public class AdminService : IAdminService
    {
        readonly IUserRepository _userRepository;
        public AdminService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<ShowUsersViewModel>> GetUsers()
        {
            return await _userRepository.GetAllUsers().Select(n => new ShowUsersViewModel()
            {

            }).ToListAsync();
        }

        public async Task<bool> SetUserToAdmin(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            user.IsAdmin = true;
            _userRepository.UpdateUser(user);
            await _userRepository.SaveChanges();
            return true;
        }
    }
}