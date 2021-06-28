using OnlineShop.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAllProducts();
        Task<bool> AddProduct(Product product);
        Task<bool> GetProduct(int id);
        void UpdateProduct(Product product);
        void RemoveProduct(Product product);
        Task<bool> SaveChanges();
    }
}
