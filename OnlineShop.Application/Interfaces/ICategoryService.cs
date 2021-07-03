using OnlineShop.Application.ViewModels.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineShop.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<List<ShowCategoriesViewModel>> GetAllCategories();
        Task<List<ShowCategoryProductsViewModel>> GetAllCategoryProducts(string categoryName);
        Task<string> GetPersianNameByEnglishName(string englishName);
    }
}
