using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infra.Data.Repositories
{
    public class UsersIPAddressesRepository : IUsersIPAddressesRepository
    {
        readonly OnlineShopDbContext _DbContext;
        public UsersIPAddressesRepository(OnlineShopDbContext onlineShopDbContext)
        {
            _DbContext = onlineShopDbContext;
        }

        public async Task AddUserIPAddress(UsersIPAddresses userIPAddress)
        {
            await _DbContext.UsersIPAddresses.AddAsync(userIPAddress);
        }

        public IQueryable<UsersIPAddresses> GetAllUserIPAddresses()
        {
            return _DbContext.UsersIPAddresses;
        }

        public async Task<UsersIPAddresses> GetUserIPAddress(int id)
        {
            return await _DbContext.UsersIPAddresses.FindAsync(id);
        }

        public async Task SaveChanges()
        {
            await _DbContext.SaveChangesAsync();
        }
    }
}
