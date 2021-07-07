using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infra.Data.Contexts;

namespace OnlineShop.Infra.Data.Repositories
{
    public class UserProductViewsRepository : IUserProductViewsRepository
    {
        readonly OnlineShopDbContext _dbContext;
        public UserProductViewsRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUserProductView(UserProductViews userProductViews)
        {
            await _dbContext.UserProductViews.AddAsync(userProductViews);
            return true;
        }

        public IQueryable<UserProductViews> GetAllUserProductViews()
        {
            return _dbContext.UserProductViews;
        }

        public async Task<UserProductViews> GetUserProductView(int id)
        {
            return await _dbContext.UserProductViews.FindAsync(id);;
        }

        public void RemoveUserProductView(UserProductViews userProductViews)
        {
            _dbContext.Remove(userProductViews);
        }

        public async Task<bool> SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateUserProductView(UserProductViews userProductViews)
        {
            _dbContext.Update(userProductViews);
        }
    }
}