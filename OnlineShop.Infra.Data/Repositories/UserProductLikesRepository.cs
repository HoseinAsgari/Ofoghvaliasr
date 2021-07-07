using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infra.Data.Contexts;

namespace OnlineShop.Infra.Data.Repositories
{
    public class UserProductLikesRepository : IUserProductLikesRepository
    {
        readonly OnlineShopDbContext _dbContext;
        public UserProductLikesRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUserProductLikes(UserProductLikes userProductLikes)
        {
            await _dbContext.UserProductLikes.AddAsync(userProductLikes);
            return true;
        }

        public IQueryable<UserProductLikes> GetAllUserProductLikes()
        {
            return _dbContext.UserProductLikes;
        }

        public async Task<UserProductLikes> GetUserProductLikes(int id)
        {
            return await _dbContext.UserProductLikes.FindAsync(id);;
        }

        public void RemoveUserProductLikes(UserProductLikes userProductLikes)
        {
            _dbContext.Remove(userProductLikes);
        }

        public async Task<bool> SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateUserProductLikes(UserProductLikes userProductLikes)
        {
            _dbContext.Update(userProductLikes);
        }
    }
}