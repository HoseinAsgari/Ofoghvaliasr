using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Domain.Models;

namespace OnlineShop.Domain.Interfaces
{
    public interface IUserProductViewsRepository
    {
        IQueryable<UserProductViews> GetAllUserProductViews();
        Task<bool> AddUserProductView(UserProductViews product);
        Task<UserProductViews> GetUserProductView(int id);
        void UpdateUserProductView(UserProductViews product);
        void RemoveUserProductView(UserProductViews product);
        Task<bool> SaveChanges();
    }
}