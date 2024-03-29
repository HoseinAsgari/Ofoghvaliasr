﻿using OnlineShop.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
        Task<bool> AddUser(User user);
        Task<User> GetUser(int id);
        void UpdateUser(User user);
        void RemoveUser(User user);
        Task<bool> SaveChanges();
    }
}
