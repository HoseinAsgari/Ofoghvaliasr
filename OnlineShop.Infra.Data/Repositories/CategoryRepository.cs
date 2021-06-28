using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using OnlineShop.Infra.Data.Contexts;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly OnlineShopDbContext _dbContext;
        public CategoryRepository(OnlineShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddCategory(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            return true;
        }

        public IQueryable GetAllCategories()
        {
            return _dbContext.Categories;
        }

        public async Task<bool> GetCategory(int id)
        {
            await _dbContext.Categories.FindAsync(id);
            return true;
        }

        public void RemoveCategory(Category category)
        {
            _dbContext.Remove(category);
        }

        public async Task<bool> SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Update(category);
        }
    }
}
