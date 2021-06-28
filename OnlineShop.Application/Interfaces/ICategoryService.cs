using OnlineShop.Application.ViewModels.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<ShowCategories>> GetAllCategories();
        Task<List<CategoryProducts>> GetAllCategoryProducts(string categoryName);
    }
}
