using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Domain.Models;

namespace OnlineShop.Domain.Interfaces
{
    public interface IUserProductSoldsRepository
    {
        IQueryable<UserProductSold> GetAllUserProductSold();
        Task<bool> AddUserProductSold(UserProductSold userProductSold);
        Task<bool> AddUserProductSolds(List<UserProductSold> userProductSolds);
        Task<UserProductSold> GetUserProductSold(int id);
        void UpdateUserProductSold(UserProductSold userProductSold);
        void RemoveUserProductSold(UserProductSold userProductSold);
        Task<bool> SaveChanges();
    }
}