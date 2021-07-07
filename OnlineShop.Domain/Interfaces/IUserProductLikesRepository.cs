using OnlineShop.Domain.Models;
using System.Threading.Tasks;
using System.Linq;

namespace OnlineShop.Domain.Interfaces
{
    public interface IUserProductLikesRepository
    {
        IQueryable<UserProductLikes> GetAllUserProductLikes();
        Task<bool> AddUserProductLikes(UserProductLikes userProductLikes);
        Task<UserProductLikes> GetUserProductLikes(int id);
        void UpdateUserProductLikes(UserProductLikes userProductLikes);
        void RemoveUserProductLikes(UserProductLikes userProductLikes);
        Task<bool> SaveChanges();
    }
}