using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces;
using OnlineShop.Application.ViewModels.Categories;
using OnlineShop.Domain.Interfaces;
using System;
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

        public Task<List<ShowCategories>> GetAllCategories()
        {
            return Task.FromResult(_categoryRepository.GetAllCategories().Select(n => new ShowCategories()
            {
                CategoryName = n.CategoryName
            }).ToList());
        }

        public async Task<List<CategoryProducts>> GetAllCategoryProducts(string categoryName)
        {
            return (await _categoryRepository.GetAllCategories().SingleAsync(n => n.CategoryName == categoryName)).Products.Select(n => new CategoryProducts()
            {
                ProductName = n.ProductName,
                ProductPrice = n.ProductPrice,
                UnitOfProduct = n.UnitOfProduct
            }).ToList();
        }
    }
}
