using Microsoft.EntityFrameworkCore;
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

        public IQueryable<Category> GetAllCategories()
        {
            return _dbContext.Categories.Include(n => n.Products).ThenInclude(n => n.Category);
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public void RemoveCategory(Category category)
        {
            _dbContext.Categories.Remove(category);
        }

        public async Task<bool> SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
        }
    }
}
