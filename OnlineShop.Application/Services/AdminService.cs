using OnlineShop.Application.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineShop.Application.ViewModels.Admin;
using OnlineShop.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using OnlineShop.Application.Helpers.CalendarHelper;

namespace OnlineShop.Application.Services
{
    public class AdminService : IAdminService
    {
        readonly IUserRepository _userRepository;
        readonly IHostingEnvironment _environment;
        readonly ICategoryRepository _categoryRepository;
        readonly IProductRepository _productRepository;
        public AdminService(IUserRepository userRepository, ICategoryRepository categoryRepository, IHostingEnvironment environment, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _environment = environment;
            _productRepository = productRepository;
        }

        public async Task<bool> AddCategory(AddCategoryViewModel addCategoryViewModel)
        {
            string picturePath = $@"{_environment.WebRootPath}\\Resources\\Pics\\Category\\{addCategoryViewModel.CategoryPersianName}.jpg";
            using (var stream = File.Create(picturePath))
            {
                await addCategoryViewModel.CategoryThumbnailFile.CopyToAsync(stream);
            }
            await _categoryRepository.AddCategory(new Domain.Models.Category()
            {
                CategoryEnglishName = addCategoryViewModel.CategoryEnglishName,
                CategoryName = addCategoryViewModel.CategoryPersianName
            });
            await _categoryRepository.SaveChanges();
            return true;
        }

        public async Task<bool> AddProduct(AddProductViewModel addProductViewModel)
        {
            string picturePath = $@"{_environment.WebRootPath}\\Resources\\Pics\\Category\\{addProductViewModel.ProductPersianName}.jpg";
            using (var stream = File.Create(picturePath))
            {
                await addProductViewModel.ProductThumbnail.CopyToAsync(stream);
            }
            await _productRepository.AddProduct(new Domain.Models.Product()
            {
                ProductName = addProductViewModel.ProductPersianName,
                ProductPrice = addProductViewModel.ProductPrice,
                UnitOfProduct = addProductViewModel.UnitOfProduct
            });
            await _categoryRepository.SaveChanges();
            return true;
        }

        public async Task<bool> EditCategory(EditCategoryViewModel editCategoryViewModel)
        {
            var category = await _categoryRepository.GetCategory(editCategoryViewModel.CategoryId);
            category.CategoryEnglishName = category.CategoryEnglishName;
            category.CategoryName = category.CategoryName;
            _categoryRepository.UpdateCategory(category);
            await _categoryRepository.SaveChanges();
            return true;
        }

        public async Task<bool> EditProduct(EditProductViewModel editProductViewModel)
        {
            var product = await _productRepository.GetProduct(editProductViewModel.ProductId);
            product.ProductName = editProductViewModel.ProductPersianName;
            product.ProductPrice = editProductViewModel.ProductPrice;
            product.UnitOfProduct = editProductViewModel.UnitOfProduct;
            _productRepository.UpdateProduct(product);
            await _productRepository.SaveChanges();
            return true;
        }

        public async Task<List<ShowCategoriesAdminViewModel>> GetCategories()
        {
            return await _categoryRepository.GetAllCategories().Select(n => new ShowCategoriesAdminViewModel()
            {
                CategoryEnglishName = n.CategoryEnglishName,
                CategoryId = n.CategoryId,
                CategoryLikedCount = n.Liked,
                CategoryName = n.CategoryName
            }).ToListAsync();
        }

        public async Task<ShowEditCategoryViewModel> GetEditCategoryModel(int categoryId)
        {
            var category = await _categoryRepository.GetCategory(categoryId);
            return new ShowEditCategoryViewModel()
            {
                CategoryId = categoryId,
                CategoryEnglishName = category.CategoryEnglishName,
                CategoryPersianName = category.CategoryName,
                CategoryThumbnail = category.CategoryName + ".jpg"
            };
        }

        public async Task<ShowEditProductViewModel> GetEditProductModel(int productId)
        {
            var product = await _productRepository.GetProduct(productId);
            return new ShowEditProductViewModel()
            {
                ProductId = productId,
                ProductPersianName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductThumbnail = product.ProductName + ".jpg",
                UnitOfProduct = product.UnitOfProduct
            };
        }

        public async Task<List<ShowProductsAdminViewModel>> GetProductsModel()
        {
            return await _productRepository.GetAllProducts().OrderByDescending(n => n.UserProductLikes.Count).Select(n => new ShowProductsAdminViewModel()
            {
                ProductName = n.ProductName,
                ProductPrice = n.ProductPrice,
                ProductThumbanil = n.ProductName + ".jpg",
                UnitOfProduct = n.UnitOfProduct
            }).ToListAsync();
        }

        public async Task<ShowUserDetailViewModel> GetUserDetails(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            return new ShowUserDetailViewModel()
            {
                BoughtCount = user.UserProductSolds.Count,
                IsActive = user.IsAccountActive,
                IsAdmin = user.IsAdmin,
                LikedCount = user.LikedProducts.Count,
                SignedInDateTime = await ShamsiCalendarHelper.ToShamsiWithTime(user.DateSignedIn),
                UserEmail = user.UserEmail,
                UserName = user.UserName,
                ViewsCount = user.UserProductViews.Count
            };
        }

        public async Task<List<ShowUsersViewModel>> GetUsers()
        {
            return await _userRepository.GetAllUsers().Select(n => new ShowUsersViewModel()
            {
                UserId = n.UserId,
                UserName = n.UserName,
                IsActive = n.IsAccountActive
            }).ToListAsync();
        }

        public async Task<bool> RemoveCategory(int categoryId)
        {
            _categoryRepository.RemoveCategory(await _categoryRepository.GetCategory(categoryId));
            await _categoryRepository.SaveChanges();
            return true;
        }

        public async Task<bool> RemoveProduct(int productId)
        {
            _productRepository.RemoveProduct(await _productRepository.GetProduct(productId));
            await _productRepository.SaveChanges();
            return true;
        }

        public async Task<bool> SetUserToAdmin(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            user.IsAdmin = true;
            _userRepository.UpdateUser(user);
            await _userRepository.SaveChanges();
            return true;
        }
    }
}