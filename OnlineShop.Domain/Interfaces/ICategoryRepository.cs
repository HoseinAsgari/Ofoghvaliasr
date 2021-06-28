using OnlineShop.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
        Task<bool> AddCategory(Category category);
        Task<bool> GetCategory(int id);
        void UpdateCategory(Category category);
        void RemoveCategory(Category category);
        Task<bool> SaveChanges();
    }
}
