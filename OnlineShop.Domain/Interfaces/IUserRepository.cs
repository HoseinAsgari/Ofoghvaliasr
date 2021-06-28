using OnlineShop.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IUserRepository
    {
        IQueryable GetAllUsers();
        Task<bool> AddUser(User user);
        Task<bool> GetUser(int id);
        void UpdateUser(User user);
        void RemoveUser(User user);
        Task<bool> SaveChanges();
    }
}
