using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Categories;
using OnlineShop.Domain.Interfaces;
using OnlineShop.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<List<ShowCategoriesViewModel>> GetAllCategories()
        {
            return Task.FromResult(_categoryRepository.GetAllCategories().Select(n => new ShowCategoriesViewModel()
            {
                CategoryName = n.CategoryName,
                CategoryThumbnail = n.CategoryName + ".jpg",
                EnglishName = n.CategoryEnglishName
            }).ToList());
        }

        public async Task<List<ShowCategoryProductsViewModel>> GetAllCategoryProducts(string categoryName)
        {
            return (await _categoryRepository.GetAllCategories().SingleAsync(n => n.CategoryEnglishName == categoryName)).Products.Select(n => new ShowCategoryProductsViewModel()
            {
                ProductName = n.ProductName,
                ProductPrice = n.ProductPrice,
                ProductId = n.ProductId,
                ProductThumbnail = n.ProductName + ".jpg"
            }).ToList();
        }

        public async Task<string> GetPersianNameByEnglishName(string englishName)
        {
            return (await GetCategoryByEnglishName(englishName)).CategoryName;
        }

        private async Task<Category> GetCategoryByEnglishName(string englishName)
        {
            return await _categoryRepository.GetAllCategories().SingleAsync(n => n.CategoryEnglishName == englishName);
        }
    }
}
