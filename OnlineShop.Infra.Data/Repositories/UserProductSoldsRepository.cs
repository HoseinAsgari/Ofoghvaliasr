using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infra.Data.Contexts;

namespace OnlineShop.Infra.Data.Repositories
{
    public class UserProductSoldsRepository : IUserProductSoldsRepository
    {
        readonly OnlineShopDbContext _dbContext;
        public UserProductSoldsRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddUserProductSold(UserProductSold userProductSold)
        {
            await _dbContext.UserProductSolds.AddAsync(userProductSold);
            return true;
        }

        public async Task<bool> AddUserProductSolds(List<UserProductSold> userProductSolds)
        {
            await _dbContext.UserProductSolds.AddRangeAsync(userProductSolds);
            return true;
        }

        public IQueryable<UserProductSold> GetAllUserProductSold()
        {
            return _dbContext.UserProductSolds;
        }

        public async Task<UserProductSold> GetUserProductSold(int id)
        {
            return await _dbContext.UserProductSolds.FindAsync(id);;
        }

        public void RemoveUserProductSold(UserProductSold userProductSold)
        {
            _dbContext.Remove(userProductSold);
        }

        public async Task<bool> SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateUserProductSold(UserProductSold userProductSold)
        {
            _dbContext.Update(userProductSold);
        }
    }
}