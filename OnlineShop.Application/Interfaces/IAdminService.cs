using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Application.ViewModels.Admin;

namespace OnlineShop.Application.Interfaces
{
    public interface IAdminService
    {
        Task<List<ShowUsersViewModel>> GetUsers();
        Task<bool> SetUserToAdmin(int userId);
        Task<ShowUserDetailViewModel> GetUserDetails(int userId);


        Task<List<ShowProductsAdminViewModel>> GetProductsModel();
        Task<AddOrEditProductViewModel> GetEditProductModel(int productId);
        Task<bool> EditProduct(AddOrEditProductViewModel editProductViewModel);
        Task<bool> AddProduct(AddOrEditProductViewModel addProductViewModel);
        Task<bool> RemoveProduct(int productId);


        Task<AddOrEditCategoryViewModel> GetEditCategoryModel(int categoryId);
        Task<List<ShowCategoriesAdminViewModel>> GetCategories();
        Task<bool> EditCategory(AddOrEditCategoryViewModel addCategoryViewModel);
        Task<bool> RemoveCategory(int categoryId);
        Task<bool> AddCategory(AddOrEditCategoryViewModel addCategoryViewModel);
    }
}