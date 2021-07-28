using OnlineShop.Application.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineShop.Application.ViewModels.Admin.Category;
using OnlineShop.Application.ViewModels.Admin.Product;
using OnlineShop.Application.ViewModels.Admin.User;
using OnlineShop.Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using OnlineShop.Application.Helpers.CalendarHelper;
using OnlineShop.Domain.Models;

namespace OnlineShop.Application.Services
{
    public class AdminService : IAdminService
    {
        readonly IUserRepository _userRepository;
        readonly IHostingEnvironment _environment;
        readonly ICategoryRepository _categoryRepository;
        readonly ICartRepository _cartRepository;
        readonly IProductRepository _productRepository;
        public AdminService(ICartRepository cartRepository, IUserRepository userRepository, ICategoryRepository categoryRepository, IHostingEnvironment environment, IProductRepository productRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
            _environment = environment;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public async Task<bool> AddCategory(AddCategoryViewModel addCategoryViewModel)
        {
            string picturePath = $@"{_environment.WebRootPath}\\Resources\\Pics\\CategoryThumbnail\\{addCategoryViewModel.CategoryPersianName}.png";
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
            string picturePath = $@"{_environment.WebRootPath}\\Resources\\Pics\\ProductThumbnail\\{addProductViewModel.ProductPersianName}.png";
            using (var stream = File.Create(picturePath))
            {
                await addProductViewModel.ProductThumbnail.CopyToAsync(stream);
            }

            var category = await GetCategoryByName(addProductViewModel.CategoryName);

            await _productRepository.AddProduct(new Domain.Models.Product()
            {
                ProductName = addProductViewModel.ProductPersianName,
                ProductPrice = addProductViewModel.ProductPrice,
                UnitOfProduct = addProductViewModel.UnitOfProduct,
                Category = category,
                CategoryId = category.CategoryId
            });
            await _productRepository.SaveChanges();
            return true;
        }

        public async Task<bool> EditCategory(EditCategoryViewModel editCategoryViewModel)
        {
            var category = await _categoryRepository.GetCategory(editCategoryViewModel.CategoryId);
            string picturePath = $@"{_environment.WebRootPath}\\Resources\\Pics\\CategoryThumbnail\\";
            try
            {
                System.IO.File.Move(picturePath + category.CategoryName + ".png", picturePath + editCategoryViewModel.CategoryPersianName + ".png");
                category.CategoryEnglishName = editCategoryViewModel.CategoryEnglishName;
                category.CategoryName = editCategoryViewModel.CategoryPersianName;
                _categoryRepository.UpdateCategory(category);
                await _categoryRepository.SaveChanges();
                return true;
            }
            catch
            {
                category.CategoryEnglishName = editCategoryViewModel.CategoryEnglishName;
                category.CategoryName = editCategoryViewModel.CategoryPersianName;
                _categoryRepository.UpdateCategory(category);
                await _categoryRepository.SaveChanges();
                return true;
            }

        }

        public async Task<bool> EditProduct(EditProductViewModel editProductViewModel)
        {
            var product = await _productRepository.GetProduct(editProductViewModel.ProductId);
            string picturePath = $@"{_environment.WebRootPath}\\Resources\\Pics\\ProductThumbnail\\";
            try
            {
                System.IO.File.Move(picturePath + product.ProductName + ".png", picturePath + editProductViewModel.ProductPersianName + ".png");
                product.ProductName = editProductViewModel.ProductPersianName;
                product.ProductPrice = editProductViewModel.ProductPrice;
                product.UnitOfProduct = editProductViewModel.UnitOfProduct;
                _productRepository.UpdateProduct(product);
                await _productRepository.SaveChanges();
                return true;
            }
            catch
            {
                product.ProductName = editProductViewModel.ProductPersianName;
                product.ProductPrice = editProductViewModel.ProductPrice;
                product.UnitOfProduct = editProductViewModel.UnitOfProduct;
                _productRepository.UpdateProduct(product);
                await _productRepository.SaveChanges();
                return true;
            }

        }

        public async Task<List<string>> GetAllCategoriesName()
        {
            return await _categoryRepository.GetAllCategories().Select(n => n.CategoryName).ToListAsync();
        }

        public async Task<List<ShowCategoriesAdminViewModel>> GetCategories()
        {
            return await _categoryRepository.GetAllCategories().Select(n => new ShowCategoriesAdminViewModel()
            {
                CategoryEnglishName = n.CategoryEnglishName,
                CategoryId = n.CategoryId,
                CategoryLikedCount = n.Liked,
                CategoryName = n.CategoryName,
                CategoryThumbnailName = n.CategoryName + ".png"
            }).ToListAsync();
        }

        public async Task<EditCategoryViewModel> GetEditCategoryModel(int categoryId)
        {
            var category = await _categoryRepository.GetCategory(categoryId);
            return new EditCategoryViewModel()
            {
                CategoryId = categoryId,
                CategoryEnglishName = category.CategoryEnglishName,
                CategoryPersianName = category.CategoryName,
                CategoryThumbnailName = category.CategoryName + ".png"
            };
        }

        public async Task<EditProductViewModel> GetEditProductModel(int productId)
        {
            var product = await _productRepository.GetProduct(productId);
            return new EditProductViewModel()
            {
                ProductId = productId,
                ProductPersianName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductCurrentThumbnail = product.ProductName + ".png",
                UnitOfProduct = product.UnitOfProduct
            };
        }

        public async Task<List<ShowOrderesViewModel>> GetOrderes()
        {
            return await _cartRepository.GetAllCarts().Where(n => n.IsOrdered && !n.Delivered).Select(n => new ShowOrderesViewModel()
            {
                CartId = n.CartId,
                DateOrdered = ShamsiCalendarHelper.ToShamsiWithTime(n.DateOrdered.Value).Result,
                UserName = n.User.UserName,
                UserAddress = n.User.UserAddress,
                UserPhoneNumber = n.User.UserPhoneNumber
            }).ToListAsync();
        }

        public async Task<List<ShowProductsAdminViewModel>> GetProductsModel()
        {
            return await _productRepository.GetAllProducts().OrderByDescending(n => n.UserProductLikes.Count).Select(n => new ShowProductsAdminViewModel()
            {
                ProductId = n.ProductId,
                ProductName = n.ProductName,
                ProductPrice = n.ProductPrice,
                ProductThumbanil = n.ProductName + ".png",
                UnitOfProduct = n.UnitOfProduct
            }).ToListAsync();
        }

        public async Task<List<ShowUserCartProductsViewModel>> GetUserCartProducts(int cartId)
        {
            return (await _cartRepository.GetCart(cartId)).CartItems.Select(n => new ShowUserCartProductsViewModel()
            {
                Amount = n.Count,
                ProductId = n.Product.ProductId,
                ProductName = n.Product.ProductName,
                ThumbnailName = n.Product.ProductName + ".png",
                UnitOfProduct = n.Product.UnitOfProduct,
                Price = n.Product.ProductPrice
            }).ToList();
        }

        public async Task<ShowUserDetailsViewModel> GetUserDetails(int userId)
        {
            var user = await _userRepository.GetUser(userId);
            return new ShowUserDetailsViewModel()
            {
                UserId = userId,
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
                IsAdmin = n.IsAdmin,
                Banned = n.Banned,
                IsActive = n.IsAccountActive
            }).ToListAsync();
        }

        public async Task<bool> RemoveCategory(int categoryId)
        {
            _categoryRepository.RemoveCategory(await _categoryRepository.GetCategory(categoryId));
            var categoryProducts = _productRepository.GetAllProducts().Where(n => n.CategoryId == categoryId);
            _productRepository.RemoveRangeProduct(categoryProducts);
            RemoveProductPicsCategory(categoryId);
            await _categoryRepository.SaveChanges();
            return true;
        }

        public void RemoveProductPicsCategory(int categoryId)
        {
            var productsName = _productRepository.GetAllProducts().Where(n => n.CategoryId == categoryId).Select(n => n.ProductName);
            foreach (var item in productsName)
            {
                string picturePath = $@"{_environment.WebRootPath}\\Resources\\Pics\\ProductThumbnail\\{item}.png";
                if (File.Exists(picturePath))
                {
                    File.Delete(picturePath);
                }
            }
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

        public async Task CartDelivered(int cartId)
        {
            var cart = await _cartRepository.GetCart(cartId);
            cart.Delivered = true;
            _cartRepository.UpdateCart(cart);
            await _cartRepository.SaveChanges();
        }

        public async Task BanUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            user.Banned = true;
            _userRepository.UpdateUser(user);
            await _userRepository.SaveChanges();
        }

        private async Task<Category> GetCategoryByName(string categoryName)
        {
            return await _categoryRepository.GetAllCategories().SingleAsync(n => n.CategoryName == categoryName);
        }
    }
}