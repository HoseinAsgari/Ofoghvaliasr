using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infra.Data.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly OnlineShopDbContext _dbContext;
        public UserRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            return true;
        }

        public IQueryable<User> GetAllUsers()
        {
            return _dbContext.Users
                .Include(n => n.Cart).ThenInclude(n => n.CartItems).ThenInclude(n => n.Product)
                .Include(n => n.Cart).ThenInclude(n => n.User);
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public void RemoveUser(User user)
        {
            _dbContext.Remove(user);
        }

        public async Task<bool> SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateUser(User user)
        {
            _dbContext.Update(user);
        }
    }
}
