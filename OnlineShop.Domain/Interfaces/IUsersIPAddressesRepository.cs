using OnlineShop.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IUsersIPAddressesRepository
    {
        IQueryable<UsersIPAddresses> GetAllUserIPAddresses();
        Task AddUserIPAddress(UsersIPAddresses userIPAddress);
        Task<UsersIPAddresses> GetUserIPAddress(int id);
        Task SaveChanges();
    }
}
